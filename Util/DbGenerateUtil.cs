using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using WM_Plane_CreateDBImport.Common;
using WM_Plane_CreateDBImport.Model;
using WM_Plane_CreateDBImport.Util;

namespace WM_Plane_CreateDBImport.Util
{
    //主要是用来生成sql create table 语句
    public static class DbGenerateUtil
    {
        /// <summary>
        /// 数据库创建表语句拼接
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        public static String GenerateCreateTableSql(String tableName, AscField[] fields)
        {

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("CREATE TABLE ");
            stringBuilder.Append("`" + tableName + "` (  ");
            stringBuilder.Append("id int NOT NULL auto_increment ,");
            for (int i = 0; i < fields.Length; ++i)
            {

                stringBuilder.Append("`" + fields[i].FieldName + "` " + fields[i].Type + " ,");

            }
            stringBuilder.Append("PRIMARY KEY (`id`) )ENGINE=InnoDB DEFAULT CHARSET=utf8");
            return stringBuilder.ToString();

        }

        public static void CreateTable(String csvfilepath, String renamefilepath, String tableName)
        {
            //1 read csv
            //2 预处理字段名 ，将空格去掉，-改为_ 
            //3 检测重名， 重名的采用 先加_filename ,如果在重复 加_i
            //4 没有重名后，写入 文件，原来 以及改完后的，对于那4个30行，需要处理
            //5 拼接sql，并执行

            //1
            List<String[]> headers = CSVUtil.ReadCsv(csvfilepath);
            
            //2
            List<String[]> renameHeaders=PerProcessingFieldName(headers);
            //3
            #region 检测重名， 重名的采用 先加_filename ,如果在重复 加_i


            ISet<String> set = new HashSet<String>();
            foreach (String[] strs in renameHeaders)
            {

                String fieldName = strs[0];
                if (set.Contains(fieldName.ToLower()))
                {
                    //rename
                    fieldName += "_" + strs[3];

                    int i = 0;
                    String temp = null;
                    do
                    {
                        i++;
                        temp = fieldName + "_" + i;
                    } while (set.Contains(temp.ToLower()));
                    fieldName = temp;

                    strs[0] = fieldName;
                }
                set.Add(fieldName.ToLower());
            }
            #endregion
            //4 没有重名后，写入 文件，原来 以及改完后的，对于那4个30行，需要处理
            StringBuilder stringBuilder = new StringBuilder();
            using (StreamWriter sw = new StreamWriter(renamefilepath))
            {

                for (int i = 0; i < headers.Count(); ++i)
                {
                    foreach (String str in headers[i])
                    {
                        stringBuilder.Append(str + " ");
                    }
                    foreach (String str in renameHeaders[i])
                    {
                        stringBuilder.Append(str + " ");
                    }
                    sw.WriteLine(stringBuilder.ToString());
                    stringBuilder.Clear();
                }
            }
            //5
            List<AscField> fieldHeaders = new List<AscField>();
            foreach (String[] strs in renameHeaders)
            {
                AscField field = new AscField();
                //special
                if (strs[2] == "F10039" || strs[2] == "F10040" || strs[2] == "F10041" || strs[2] == "F10043" || strs[2] == "F10044")
                {
                    String formula = strs[2];
                    String type = null;

                    if (formula == "F10039")
                    {
                        type = "DOUBLE(12,6)";
                    }
                    else
                    {
                        type = "FLOAT(12,6)";
                    }

                    for (int i = 0; i < 30; ++i)
                    {

                        field = new AscField();
                        field.FieldName = strs[0] + "_" + (i + 1);
                        field.Type = type;
                        field.Formula = strs[2];
                        fieldHeaders.Add(field);
                    }


                }
                else
                {
                    //ordinary
                    field.FieldName = strs[0];
                    field.Type = strs[1].Replace("\"", "");
                    field.Formula = strs[2];
                    fieldHeaders.Add(field);
                }

            }
            //output last rename field -> .last file
            using (StreamWriter sw = new StreamWriter(renamefilepath + ".last"))
            {
                foreach (AscField f in fieldHeaders)
                {
                    stringBuilder.Append(f.FieldName + " " + f.Type + " " + f.Formula);
                    sw.WriteLine(stringBuilder.ToString());
                    stringBuilder.Clear();
                }
            }

            String strSql = GenerateCreateTableSql(tableName, fieldHeaders.ToArray());
            Console.WriteLine("创建表sql语句\n" + strSql);
            
            MySqlDatabaseUtil.ExecuteNoQuery(strSql);

        }

        public static List<String[]> PerProcessingFieldName(List<String[]>headers)
        {
            List<String[]> renameHeaders = new List<string[]>();
            Regex regex = new Regex("-",RegexOptions.Compiled);
            foreach (String[] strs in headers)
            {
                String[] temp = new string[strs.Length];
                Array.Copy(strs, temp, strs.Length);
                //
                String name = temp[0];
                temp[0] = regex.Replace(temp[0], "_");
                temp[0] = Regex.Replace(temp[0]," ", "");
                

                //

                renameHeaders.Add(temp);
            }
            return renameHeaders;
        }

        /// <summary>
        /// 通过 tableName 生成 Insert Sql
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static String GenerateInsertDbSql(String tableName, List<ValAndFieldName> data)
        {
            StringBuilder cols = new StringBuilder();
            StringBuilder vals = new StringBuilder();
            String sqlPrefix = "INSERT `" + tableName + "` (";
            for (int i = 0; i < data.Count(); ++i)
            {
                ValAndFieldName temp = data[i];
                cols.Append("`" + temp.Name + "`,");
                String val = DbGenerateUtil.ParseType(temp.Val);
                vals.Append(val + ",");
            }
            //去掉最后一个 ,
            cols.Remove(cols.Length - 1, 1);
            vals.Remove(vals.Length - 1, 1);
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(sqlPrefix);
            stringBuilder.Append(cols);
            stringBuilder.Append(" ) VALUES ( ");
            stringBuilder.Append(vals);
            stringBuilder.Append(" ) ;");
            return stringBuilder.ToString();
        }

        /// <summary>
        /// 根据 c# 反射 的类型，生成insert sql的值，因为字符串,DataTime是有双引号，数值没有
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private static String ParseType(Object obj)
        {
            Type type = obj.GetType();
            String typeName = type.Name;
            String str = "";
            switch (typeName)
            {
                case "Double":
                case "Single":
                    str = obj.ToString();
                    break;
                case "DateTime":
                    DateTime dateTime = (DateTime)obj;
                    str = "\"" + dateTime.ToString("yyyy-MM-dd HH:mm:ss") + "\"";
                    break;
                case "String":
                    str = "\"" + obj.ToString() + "\"";

                    break;
                default:
                    Console.WriteLine("ParseType" + typeName + "unresloved");
                    throw new Exception("Error parse type"+typeName);
            }
            return str;
        }
    }
}

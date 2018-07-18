using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace WM_Plane_CreateDBImport.Util
{
    public static class ASCUtil
    {

        /// <summary>
        /// 读取ASC文件
        /// </summary>
        /// <param name="filepath"></param>
        /// <param name="fileHeader">ASC 文件格式</param>
        /// <returns></returns>
        public static List<String[]> ParseAsc(String filepath,out List<String>fileHeader)
        {
            List<String[]> listStringArray = new List<string[]>();
            List<String> formats = new List<string>();
            Regex regex = new Regex("(\"[^\"]*(\"{2})*[^\"]*\")*[^ ]*", RegexOptions.Compiled|RegexOptions.Singleline);
            using (StreamReader streamReader = new StreamReader(filepath))
            {
                String line=streamReader.ReadLine();
                var Matches=regex.Matches(line);
                for(int i=0;i<Matches.Count;++i)
                {
                    if (Matches[i].Value.Equals(";") || String.IsNullOrWhiteSpace(Matches[i].Value)) continue;
                    formats.Add(Matches[i].Value);
                }

                while ((line = streamReader.ReadLine()) != null)
                {
                    if (String.IsNullOrEmpty(line) || line[0]==';') continue;
                    List<String> data = new List<string>();
                    Matches = regex.Matches(line);
                    
                    for (int i = 0; i < Matches.Count; ++i)
                    {
                        if (String.IsNullOrWhiteSpace(Matches[i].Value)) continue;
                        data.Add(Matches[i].Value);
                    }
                    
                    if (data.Count() != formats.Count())
                    {
                        throw new FormatException("file header is not equals data");
                    }
                    listStringArray.Add(data.ToArray());

                }
            }
            fileHeader = formats;
            return listStringArray;
        }


        ///格式为
        /*
        ; name type index formula format
        "Date" RA -1 F1 "%s,"
        "Time" RA -1 F0 "%s,"
        "LATITU" RA -1 F1101 "%9.5f,"
        "LONGITU" RA -1 F1102 "%9.5f,"
         */
        /// <summary>
        /// 根据header 生成字段
        /// 这里
        /// </summary>
        /// <param name="header"></param>
        /// <returns>AscField </returns>
        public static AscField ParseHeader(String[]header)
        {
            AscField temp = new AscField();
            //这里是hardcode !! reuse 要重写，或像java 有profile,去解析他？？
            temp.FieldName = header[0];
            String formula = header[header.Length - 2];
            temp.Formula = formula;
            String t = header[header.Length - 1];
            temp.Type = ASCUtil.FormmaterString2GetType(t);

            if (temp.Type == null)
            {
                return null;
            }
            else
            {
                return (temp);
            }
        }
        private static String ProcessTypeStr(String str)
        {
            //去掉空字符与"
            str=Regex.Replace(str,"\"| ","");
            if (str[str.Length - 1] == ',')
            {
                str=str.Remove(str.Length-1);
            }
            if (str[0] == ',')
            {
                str = str.Remove(0,1);
            }
            str = Regex.Replace(str, "%", "");
            return str;
        }
        /// <summary>
        /// 解析%m,nf
        /// 目前只能解析 f,d,s类型
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private static String FormmaterString2GetType(String str)
        {
            //总共数位
            int digitPlaces = 0;
            //小数位
            int decimalPlaces = 0;
            String res = null;
            str = ProcessTypeStr(str);
            char type = str[str.Length - 1];
            
            String[] sperators = { "." };
            switch (type)
            {
                case 'd':
                    {
                        str = str.Remove(str.Length - 1);
                        //提取位数与小数位
                        String[] nums = str.Split(sperators, StringSplitOptions.RemoveEmptyEntries);
                        if (nums.Length >= 1)
                        {
                            digitPlaces = Convert.ToInt32(nums[0]);
                        }
                        if (nums.Length >= 2)
                        {
                            decimalPlaces = Convert.ToInt32(nums[1]);
                        }
                        if (nums.Length < 1)
                        {
                            res = "DOUBLE";
                        }
                        else res = "DOUBLE(" + digitPlaces + "," + decimalPlaces + ")";

                        break;
                    }
                case 'f':
                    {
                        str = str.Remove(str.Length - 1);

                        String[] nums = str.Split(sperators, StringSplitOptions.RemoveEmptyEntries);
                        if (nums.Length >= 1)
                        {
                            digitPlaces = Convert.ToInt32(nums[0]);
                        }


                        if (nums.Length >= 2)
                        {
                            decimalPlaces = Convert.ToInt32(nums[1]);
                        }
                        if (nums.Length < 1)
                        {
                            res = "FLOAT";
                        }
                        else
                            res = "FLOAT(" + digitPlaces + "," + decimalPlaces + ")"; ;
                        break;
                    }
                case 's':
                    
                    res = "VARCHAR(200)";
                    break;
                default:
                    break;
            }
            return res;
        }
    }
    
   
}

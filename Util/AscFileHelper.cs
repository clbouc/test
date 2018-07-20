using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using WM_Plane_KingData.ASC;
using WM_Plane_MY.ASC;

namespace WM_Plane_KingData.Util
{
    public class AscFileHelper
    {
        //处理单个 asc文件-》.asc.parse 文件,包含 Field的属性，以及每个字段出现的文件名
        public static void  ProcessOneAscFile(String ascfilepath,String destFolder)
        {
            //自动创建目录
            if (!Directory.Exists(destFolder))
            {
                Directory.CreateDirectory(destFolder);
            }
            
            List<String> fileHeader = null;
            List<String[]> dataheaders = ASCUtil.ParseAsc(ascfilepath,out fileHeader);
            //process header, 生成Field 
            List<AscField> fields = new List<AscField>();
            foreach (String[] strs in dataheaders)
            {
                AscField temp = ASCUtil.ParseHeader(strs);
                if (temp != null)
                {
                    fields.Add(temp);
                }
            }
            List<String[]> headers = FML300Util.ParseThirdHundredFile(ascfilepath+@"\fml.300");
            List<FML300Field> fml300fields = FML300Util.ParsethirdHundred(headers);
            //decorate to find fast,assume key is not duplicate

            Dictionary<String, int> dict = new Dictionary<string, int>();

            foreach (FML300Field fml300field in fml300fields)
            {

                if (dict.ContainsKey(fml300field.formula))
                {
                    Console.WriteLine("fml300Fields formula is duplicate {0} {1} {2} ", fml300field.formula, fml300field.number, dict[fml300field.formula]);
                    
                }
                else
                {
                    dict.Add(fml300field.formula, fml300field.number);
                }
            }



            //利用fml.300文件，AscField ，生成AdvancedAscField
            List<AdvancedAscField> advancedfields = new List<AdvancedAscField>();
            foreach(AscField field in fields)
            {
                AdvancedAscField advancedAscField = new AdvancedAscField
                {
                    FieldName = field.FieldName,
                    Formula = field.Formula,
                    Type = field.Type
                };
                if (dict.ContainsKey(field.Formula))
                {
                    advancedAscField.FieldNumber = dict[field.Formula];
                }
                else {
                    Console.WriteLine("field.Formula {0} is not found",field.Formula);
                    advancedAscField.FieldNumber = 1;
                }
                
                advancedfields.Add(advancedAscField);
            }

            FileInfo fileInfo = new FileInfo(ascfilepath);
            String fileName = fileInfo.Name;
            //output result
            String destpath = destFolder+"//"+fileName.Replace(".asc", "") + ".parse";
            using(StreamWriter sw=new StreamWriter(destpath))
            {
                StringBuilder stringBuilder = new StringBuilder();
                foreach (AdvancedAscField field in advancedfields)
                {
                    stringBuilder.Append(field.FieldName+" ");
                    stringBuilder.Append(field.Type+" ");
                    stringBuilder.Append(field.Formula + " ");
                    stringBuilder.Append(field.FieldNumber + " ");
                    stringBuilder.Append(fileName.Replace(".asc", ""));
                    sw.WriteLine(stringBuilder.ToString());
                    stringBuilder.Clear();
                }
            }

        }

     
    }
}

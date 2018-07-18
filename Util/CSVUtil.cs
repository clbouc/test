using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace WM_Plane_CreateDBImport.Util
{
    public static class CSVUtil {

        /// <summary>
        /// 读取csv文件，实现方式有两种，这个采用Regex 来实现的
        /// 另外一个是自己写解析方法，主要注意 "0,0"这种是一个字段就行
        /// </summary>
        /// <param name="filepath">文件路径</param>
        /// <returns></returns>
        public static List<String[]> ReadCsv(String filepath)
        {
            if (!File.Exists(filepath)) throw new FileNotFoundException("ASCUtil" + "filepath:" + filepath + "is not exists!");
            List<String[]> listStringArray = new List<string[]>();
            Regex regex = new Regex("(\"[^\"]*(\"{2})*[^\"]*\")*[^,]*", RegexOptions.Compiled);

            using (StreamReader streamReader = new StreamReader(filepath))
            {
                String temp = null;
                List<String> strs = new List<string>();
                while ((temp = streamReader.ReadLine()) != null)
                {

                    MatchCollection split = regex.Matches(temp);
                    for (int i = 0; i < split.Count; ++i)
                    {
                        if (split[i].Value != "")
                        {
                            strs.Add(split[i].Value);
                        }

                    }
                    if (strs.Count() != 0)
                    {
                        listStringArray.Add(strs.ToArray());
                        strs.Clear();
                    }

                }
            }

            return listStringArray;
        }
    }
   
}

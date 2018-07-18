using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using WM_Plane_MY.ASC;

namespace WM_Plane_CreateDBImport.Util
{
  
    public static class FML300Util
    {
        public static List<String[]> ParseThirdHundredFile(String filepath)
        {
            List<String[]> listStringArray = new List<string[]>();
            Regex regex = new Regex("(\"[^\"]*(\"{2})*[^\"]*\")*[^ ]*", RegexOptions.Compiled | RegexOptions.Singleline);
            using (StreamReader streamReader = new StreamReader(filepath))
            {
                String line = streamReader.ReadLine();
               
                while ((line = streamReader.ReadLine()) != null)
                {
                    if (String.IsNullOrEmpty(line) || line[0] == ';') continue;
                    List<String> data = new List<string>();
                    var Matches = regex.Matches(line);

                    for (int i = 0; i < Matches.Count; ++i)
                    {
                        if (String.IsNullOrWhiteSpace(Matches[i].Value)) continue;
                        data.Add(Matches[i].Value);
                    }

                  
                    listStringArray.Add(data.ToArray());

                }
            }
           
            return listStringArray;
        }
        public static List<FML300Field> ParsethirdHundred(List<String[]> datas)
        {
            List<FML300Field> fields = new List<FML300Field>();

            foreach(String []strs in datas)
            {
                FML300Field fML300Field = new FML300Field();
                fML300Field.fieldName = strs[0];
                fML300Field.unit = strs[1];
                fML300Field.formula = strs[2];
                
               
                fML300Field.number = Parseformula(strs[3]);
                fML300Field.other = strs[4];
                fields.Add(fML300Field);
            }
            return fields;
        }
        private static int Parseformula(String str)
        {
            
            int number = 0;
            if (str == null) return number;
            if (str.IndexOf("S") != -1 || str.IndexOf("s") != -1)
            {
                number = 1;
                return number;
            }
            String temp = Regex.Replace(str, "[a-zA-Z]|\\[|\\]", "");
            number = Convert.ToInt32(temp);
            return number;
        }
    }
}

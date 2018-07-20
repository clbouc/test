using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using WM_Plane_KingData.Util;
using WM_Plane_KingData.Model;

namespace WM_Plane_KingData.Util
{
   
    public static class ModelUtil
    {
       
        public static DateTime ParseDateTime(String date, String time)
        {
            Regex regex = new Regex("/");
            String[] dateStr = regex.Split(date);
            String[] timeStr = Regex.Split(time, ":");
            DateTime dateTime = new DateTime(Convert.ToInt32(dateStr[0]),
                Convert.ToInt32(dateStr[1]),
                Convert.ToInt32(dateStr[2]),
                Convert.ToInt32(timeStr[0]),
                Convert.ToInt32(timeStr[1]),
                Convert.ToInt32(timeStr[2]));


            return dateTime;

        }

        public static List<List<ModelCommon>> MergeByDateTimeMapRepeat<T1, T2>(List<List<T1>> data1, List<List<T2>> data2)
           where T1 : ModelCommon where T2 : ModelCommon
        {
            List<List<ModelCommon>> result = new List<List<ModelCommon>>();
            Dictionary<DateTime, int> dict = new Dictionary<DateTime, int>();

            for (int i = 0; i < data1.Count; ++i)
            {
                var t = data1[i][0];
                dict.Add(t.GetDateTime(), i);
            }
            for (int i = 0; i < data2.Count; ++i)
            {
                var t = data2[i][0];
                if (dict.ContainsKey(t.GetDateTime()))//match success
                {
                    int index = dict[t.GetDateTime()];
                    //merge
                    List<ModelCommon> dataMerge = new List<ModelCommon>();

                    foreach (var model in data1[index])
                    {
                        dataMerge.Add(model);
                    }
                    foreach (var model in data2[i])
                    {
                        dataMerge.Add(model);
                    }
                    result.Add(dataMerge);
                    
                }
                
            }

            return result;
        }

        

        public static List<List<ValAndFieldName>> GenerateListValAndFieldName(List<List<ModelCommon>> data)
        {
            List<List<ValAndFieldName>> valAndFieldNames = new List<List<ValAndFieldName>>();
            foreach (var listModelCommon in data)
            {
                List<ValAndFieldName> newLine = new List<ValAndFieldName>();
                foreach (var model in listModelCommon)
                {
                    newLine.AddRange(ModelUtil.FieldToValAndFieldArray(model));
                }
                valAndFieldNames.Add(newLine);
            }
            return valAndFieldNames;
        }

        //从filenpath中获取，这就要求文件夹必须一天一个
        public static DateTime ProcessSecondMidNight(String filepath,int secondsMidNight)
        {
            if (!Regex.IsMatch(filepath, @"\d{4}(\-|\/|.)\d{1,2}\1\d{1,2}")) {
                throw new Exception("filepath don't have date");
            }
            var match=Regex.Match(filepath, @"\d{4}(\-|\/|.)\d{1,2}\1\d{1,2}");
            DateTime d = DateTime.ParseExact(match.Value, "yyyy-MM-dd", System.Globalization.CultureInfo.CurrentCulture);
            
          
            int hour, minutes, seconds;
            ModelUtil.SecondsMidNight2Time(secondsMidNight, out hour, out minutes, out seconds);
            DateTime dateTime = new DateTime(d.Year, d.Month, d.Day, hour, minutes, seconds);
            return dateTime;
        }

        private static void SecondsMidNight2Time(int SecondsMidNight, out int hour, out int minutes, out int seconds)
        {
            int modMinutesAndSeconds = (SecondsMidNight % 3600);
            int hour_ = (SecondsMidNight - modMinutesAndSeconds) / 3600;
            int seconds_ = modMinutesAndSeconds % 60;
            int minutes_ = (modMinutesAndSeconds - seconds_) / 60;
            hour = hour_;
            minutes = minutes_;
            seconds = seconds_;
        }

        private static DateTime SecondsMidNight2DateTime(int SecondsMidNight, int year, int month, int day)
        {
            int hour, minutes, seconds;
            ModelUtil.SecondsMidNight2Time(SecondsMidNight, out hour, out minutes, out seconds);
            DateTime dateTime = new DateTime(year, month, day, hour, minutes, seconds);
            return dateTime;
        }

       
        //
        public static ValAndFieldName[] FieldToValAndFieldArray(Object obj)
        {
            Type type = obj.GetType();
            var fieldinfos = type.GetFields();
            ValAndFieldName[] array = new ValAndFieldName[fieldinfos.Length];
            int i = 0;
            foreach (var info in fieldinfos)
            {
                ValAndFieldName temp = new ValAndFieldName();
                temp.Name = info.Name;
                temp.Val=info.GetValue(obj);
                array[i++] = temp;
            }
            return array;
        }

        
     
    }
}

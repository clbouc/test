using System;
using System.Collections.Generic;
using System.Configuration;

namespace WM_Plane_KingData.Common
{
    public static class ConfigurationHelper
    {
        public static void initApplication()
        {
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var settings = configuration.AppSettings.Settings;
            try
            {
                if (settings.LockItem) return;
                //db
                settings.Add("username", "root");
                settings.Add("password", "1234");
                settings.Add("database", "rybdata_plane");
                settings.Add("ip", "127.0.0.1");
                settings.Add("port", "3306");
                settings.Add("log4netconfig", "log4net.config");
                settings.LockItem = true;
                configuration.Save();
            }
            catch (ConfigurationErrorsException e) {
                Console.WriteLine(e.BareMessage);
                
            }
          
        }
        private static void ReadConfiguration()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var settings = config.AppSettings.Settings;
            foreach (var key in settings.AllKeys)
            {
                Console.WriteLine(key + " " + settings[key].Value);
            }
        }

        public static String ReadConfiguration(String key)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var settings = config.AppSettings.Settings;
            List<String> keys = new List<String>(settings.AllKeys);
            bool isFind=keys.Exists((String str)=>{ return key.Equals(str); });
            if (!isFind)
            {
                //throw new Exception("key in config file" + key + " is not found");
                return null;
            }
            else
                return settings[key].Value;
        }
    }
}

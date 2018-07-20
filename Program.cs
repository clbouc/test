using log4net;
using System;
using System.IO;
using WM_Plane_KingData.Common;

namespace WM_Plane_KingData
{

    class Program
    {
        static Program()
        {
            ConfigurationHelper.initApplication();
            String filepath=ConfigurationHelper.ReadConfiguration("log4netconfig");
            log4net.Config.XmlConfigurator.Configure(new FileInfo(filepath));
            logger= LogManager.GetLogger("Program");
        }
        private static ILog logger = null; 
        private static String[]files={
                            "aimms",
                            
                            "bjwmo",
                            "icedet",
                            "inletcontroldata",
                            "m300TAS",
                            "nev",
                            "pcasp",
                            "pcasp_simple2",
                            "tracegas"
                            };
        delegate void testOp();
        static void Main(string[] args)
        {


            logger.Debug("处理完成");
            Console.Read();

        }
        

    }

}



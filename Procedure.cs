
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WM_Plane_CreateDBImport.Common;
using WM_Plane_CreateDBImport.Model;
using WM_Plane_CreateDBImport.Util;
using WM_Plane_MY.Util;

namespace WM_Plane_CreateDBImport
{
    /// <summary>
    /// 处理空中国王数据,主要是建表，和批量导入数据
    /// </summary>
    public static class Procedure
    {
        //kingdata file
        private static String[] kingdataFiles =
        {
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
        //kingdata func
        private static Func<String, List<ModelCommon>>[] readFunc = {
               KingdataUtil.ReadAnimmsFile,
               KingdataUtil.ReadArinc429File,
               KingdataUtil.ReadBjwmoFile,
               KingdataUtil.ReadBjwmoFile,
               KingdataUtil.ReadIcedetFile,
               KingdataUtil.ReadInletcontroldataFile,
               KingdataUtil.ReadM300TASFile,
               KingdataUtil.ReadNevFile,
               KingdataUtil.ReadPcaspFile,
               KingdataUtil.ReadPcaspSimple2File,
               KingdataUtil.ReadTracgasFile
            };


        /// <summary>
        /// 批量导入数据库
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="folder"></param>
        public static void ImportTableBatch(String tableName,String folder)
        {
            List<String> strSql = Procedure.MergeCsvFile2InsertSql(tableName,folder);
            
            StringBuilder stringBuilder = new StringBuilder();
            int count = 500;
            int currentSize = 0;
            int Count = strSql.Count;
            while (strSql.Count > 0)
            {

                for (int i = 0; i < count && currentSize < strSql.Count; ++i, ++currentSize)
                {
                    stringBuilder.Append(strSql[i] + "\n");
                }

                strSql.RemoveRange(0, currentSize < count ? currentSize : count);
                currentSize = 0;
                MySqlDatabaseUtil.ExecuteNoQuery(stringBuilder.ToString());
                
                Console.WriteLine("已处理{0},剩余{1}.",Count-strSql.Count,strSql.Count);
                stringBuilder.Clear();
            }
 
        }
        /// <summary>
        /// 预处理asc 文件，将其转化为易读的asc格式
        /// 去掉header,只有内容
        /// </summary>
        /// <param name="files"></param>
        /// /// <param name="folder">asc文件存放目录，确保只有一层</param>
        public static void ProcessAscFile2Format(String[] files,String folder)
        {
            foreach (String str in files)
            {
                String ascfilepath = folder + str + ".asc";
                AscFileHelper.ProcessOneAscFile(ascfilepath, folder+@"\parse");
            }

        }
        /// <summary>
        /// 创建表 根据 table.csv
        /// </summary>
        /// <param name="csvconfigfile">table.csv文件</param>
        /// <param name="tableName"></param>
        public static void CreateTableInProgram(String csvconfigfile, String tableName)
        {
            DbGenerateUtil.CreateTable(csvconfigfile, csvconfigfile + ".rename", tableName);
        }
        //hardcode
        public static void CreatTableByDefault(String tableName)
        {
            String str = "CREATE TABLE `" + tableName + "` (  id int NOT NULL auto_increment ,`DateTime` datetime ,`Latitude` FLOAT(12,6) ,`Longitude` FLOAT(12,6) ,`TAS` FLOAT(12,6) ,`Id0Count` DOUBLE(12,6) ,`Time` VARCHAR(200) ,`Temp` FLOAT(12,6) ,`RH` FLOAT(12,6) ,`BaroPress` FLOAT(12,6) ,`WindFlowNS` FLOAT(12,6) ,`WindFlowEW` FLOAT(12,6) ,`WindSpeed` FLOAT(12,6) ,`WindDir` FLOAT(12,6) ,`WindSolution` VARCHAR(200) ,`BaroPress_aimms_1` FLOAT(12,6) ,`WindSpeed_aimms_1` FLOAT(12,6) ,`Altitude` FLOAT(12,6) ,`Id1Count` DOUBLE(12,6) ,`Time_aimms_1` VARCHAR(200) ,`Latitude_aimms_1` FLOAT(12,6) ,`Longitude_aimms_1` FLOAT(12,6) ,`Altitude_aimms_1` FLOAT(12,6) ,`VelocityNS` FLOAT(12,6) ,`VelocityEW` FLOAT(12,6) ,`VelocityUD` FLOAT(12,6) ,`Roll` FLOAT(12,6) ,`Pitch` FLOAT(12,6) ,`Yaw` FLOAT(12,6) ,`TAS_aimms_1` FLOAT(12,6) ,`VerticalWind` FLOAT(12,6) ,`Sideslip` FLOAT(12,6) ,`AOAPressDiff` FLOAT(12,6) ,`SideslipDiff` FLOAT(12,6) ,`Latitude_aimms_2` VARCHAR(200) ,`Longitude_aimms_2` VARCHAR(200) ,`Altitude_aimms_2` FLOAT(12,6) ,`Id2Count` DOUBLE(12,6) ,`Time_aimms_2` FLOAT(12,6) ,`Latitude_aimms_3` FLOAT(12,6) ,`Longitude_aimms_3` FLOAT(12,6) ,`Altitude_aimms_3` FLOAT(12,6) ,`GroundSpeed` FLOAT(12,6) ,`GroundTrack` FLOAT(12,6) ,`HFOM` FLOAT(12,6) ,`VFOM` FLOAT(12,6) ,`NavMode` DOUBLE(12,6) ,`Satellites` FLOAT(12,6) ,`DatumNumber` FLOAT(12,6) ,`SolConfLevel` VARCHAR(200) ,`GPSTimeAlign` VARCHAR(200) ,`NavModeStatus` VARCHAR(200) ,`Latitude_aimms_4` VARCHAR(200) ,`Longitude_aimms_4` VARCHAR(200) ,`Altitude_aimms_4` FLOAT(12,6) ,`Latitude_aimms_5` FLOAT(12,6) ,`Longitude_aimms_5` FLOAT(12,6) ,`DateTime_arinc429_1` datetime ,`StaticPSSECorrected` FLOAT(12,6) ,`ImpactPressure` FLOAT(12,6) ,`Altitude_arinc429_1` FLOAT(12,6) ,`BaroCorrectedAltitude` FLOAT(12,6) ,`Mach` FLOAT(12,6) ,`Airspeed` FLOAT(12,6) ,`TrueAirSpeed` FLOAT(12,6) ,`Totaltemp` FLOAT(12,6) ,`StaticTemp` FLOAT(12,6) ,`veritcalSpeed` FLOAT(12,6) ,`magheadingdeg` FLOAT(12,6) ,`Date` datetime ,`AIMMSTime` VARCHAR(200) ,`Latitude_bjwmo_1` FLOAT(12,6) ,`Longitude_bjwmo_1` FLOAT(12,6) ,`LWC` FLOAT(12,6) ,`TWC` FLOAT(12,6) ,`Hygrometer` FLOAT(12,6) ,`RICEMsoFreqHz` FLOAT(12,6) ,`RMTTotalTempC` FLOAT(12,6) ,`RMTStaticTempC` FLOAT(12,6) ,`DewPointC` FLOAT(12,6) ,`TAS_bjwmo_1` FLOAT(12,6) ,`Temp_bjwmo_1` FLOAT(12,6) ,`RH_bjwmo_1` FLOAT(12,6) ,`WindFlowNS_bjwmo_1` FLOAT(12,6) ,`WindFlowEW_bjwmo_1` FLOAT(12,6) ,`WindSpeed_bjwmo_1` FLOAT(12,6) ,`WindDir_bjwmo_1` FLOAT(12,6) ,`WindSolution_bjwmo_1` VARCHAR(200) ,`BaroPress_bjwmo_1` FLOAT(12,6) ,`WindSpeed_bjwmo_2` FLOAT(12,6) ,`Altitude_bjwmo_1` FLOAT(12,6) ,`Latitude_bjwmo_2` FLOAT(12,6) ,`Longitude_bjwmo_2` FLOAT(12,6) ,`Altitude_bjwmo_2` FLOAT(12,6) ,`VelocityNS_bjwmo_1` FLOAT(12,6) ,`VelocityEW_bjwmo_1` FLOAT(12,6) ,`VelocityUD_bjwmo_1` FLOAT(12,6) ,`Roll_bjwmo_1` FLOAT(12,6) ,`Pitch_bjwmo_1` FLOAT(12,6) ,`Yaw_bjwmo_1` FLOAT(12,6) ,`TAS_bjwmo_2` FLOAT(12,6) ,`VerticalWind_bjwmo_1` FLOAT(12,6) ,`Sideslip_bjwmo_1` FLOAT(12,6) ,`AOAPressDiff_bjwmo_1` FLOAT(12,6) ,`SideslipDiff_bjwmo_1` FLOAT(12,6) ,`Latitude_bjwmo_3` VARCHAR(200) ,`Longitude_bjwmo_3` VARCHAR(200) ,`Altitude_bjwmo_3` FLOAT(12,6) ,`StaticPSSECorrected_bjwmo_1` FLOAT(12,6) ,`StaticPSSECorrected_bjwmo_2` FLOAT(12,6) ,`DateTime_icedet_1` datetime ,`ID_W` VARCHAR(200) ,`OnTimeCntr` DOUBLE(12,6) ,`Power` DOUBLE(12,6) ,`PermErr1` VARCHAR(200) ,`PermErr2` VARCHAR(200) ,`PermErr3` VARCHAR(200) ,`TotIceCnt` DOUBLE(12,6) ,`ID_X` VARCHAR(200) ,`MsoFreq` DOUBLE(12,6) ,`IceCycCnt` DOUBLE(12,6) ,`SigState` VARCHAR(200) ,`OprState` VARCHAR(200) ,`BitErr1` VARCHAR(200) ,`BitErr2` VARCHAR(200) ,`BitErr3` VARCHAR(200) ,`ID_Y` VARCHAR(200) ,`TotFailCnt` DOUBLE(12,6) ,`MsoFailCnt` DOUBLE(12,6) ,`IceFailCnt` DOUBLE(12,6) ,`StaFailCnt` DOUBLE(12,6) ,`HtrFailCnt` DOUBLE(12,6) ,`ID_Z` VARCHAR(200) ,`FaultLog1` VARCHAR(200) ,`FaultLog2` VARCHAR(200) ,`FaultLog3` VARCHAR(200) ,`FaultLog4` VARCHAR(200) ,`FaultLog5` VARCHAR(200) ,`FaultLog6` VARCHAR(200) ,`FaultLog7` VARCHAR(200) ,`DateTime_inletcontroldata_1` datetime ,`tip_flow` FLOAT(12,6) ,`tipfltrg` FLOAT(12,6) ,`airspeed_inletcontroldata_1` FLOAT(12,6) ,`oat_temp` FLOAT(12,6) ,`instflow` FLOAT(12,6) ,`inltpres` FLOAT(12,6) ,`blwrflow` FLOAT(12,6) ,`blwrtarg` FLOAT(12,6) ,`blwr_tmp` FLOAT(12,6) ,`blwr_pwr` FLOAT(12,6) ,`throtpos` FLOAT(12,6) ,`fconetmp` FLOAT(12,6) ,`rconetmp` FLOAT(12,6) ,`pylontmp` FLOAT(12,6) ,`sensrtmp` FLOAT(12,6) ,`fconepwr` FLOAT(12,6) ,`rconepwr` FLOAT(12,6) ,`pylonpwr` FLOAT(12,6) ,`sensrpwr` FLOAT(12,6) ,`DateTime_m300TAS_1` datetime ,`ARINCTAS` FLOAT(12,6) ,`DateTime_nev_1` datetime ,`ARINCAltitudeft` FLOAT(12,6) ,`NevTWC` FLOAT(12,6) ,`NevLWC` FLOAT(12,6) ,`DateTime_pcasp_1` datetime ,`Analog0` FLOAT(12,6) ,`Analog1` FLOAT(12,6) ,`Analog2` FLOAT(12,6) ,`Analog3` FLOAT(12,6) ,`Analog4` FLOAT(12,6) ,`Analog5` FLOAT(12,6) ,`Analog6` FLOAT(12,6) ,`Analog7` FLOAT(12,6) ,`HighGainBaselinev` FLOAT(12,6) ,`MidGainBaselinev` FLOAT(12,6) ,`LowGainBaselinev` FLOAT(12,6) ,`SampleFlow` FLOAT(12,6) ,`LaserReferencev` FLOAT(12,6) ,`Analog1v` FLOAT(12,6) ,`SheathFlow` FLOAT(12,6) ,`InternalTemp` FLOAT(12,6) ,`AvgTransit` FLOAT(12,6) ,`AvgTransit_pcasp_1` FLOAT(12,6) ,`FIFOFull` FLOAT(12,6) ,`ResetFlag` FLOAT(12,6) ,`SynsErrorA` FLOAT(12,6) ,`SyncErrorB` FLOAT(12,6) ,`SyncErrorC` FLOAT(12,6) ,`Overrange` FLOAT(12,6) ,`SPPSamples` FLOAT(12,6) ,`RangeValue` FLOAT(12,6) ,`RangeControl` FLOAT(12,6) ,`Range` FLOAT(12,6) ,`LasereReferencev` FLOAT(12,6) ,`Channel_1` DOUBLE(12,6) ,`Channel_2` DOUBLE(12,6) ,`Channel_3` DOUBLE(12,6) ,`Channel_4` DOUBLE(12,6) ,`Channel_5` DOUBLE(12,6) ,`Channel_6` DOUBLE(12,6) ,`Channel_7` DOUBLE(12,6) ,`Channel_8` DOUBLE(12,6) ,`Channel_9` DOUBLE(12,6) ,`Channel_10` DOUBLE(12,6) ,`Channel_11` DOUBLE(12,6) ,`Channel_12` DOUBLE(12,6) ,`Channel_13` DOUBLE(12,6) ,`Channel_14` DOUBLE(12,6) ,`Channel_15` DOUBLE(12,6) ,`Channel_16` DOUBLE(12,6) ,`Channel_17` DOUBLE(12,6) ,`Channel_18` DOUBLE(12,6) ,`Channel_19` DOUBLE(12,6) ,`Channel_20` DOUBLE(12,6) ,`Channel_21` DOUBLE(12,6) ,`Channel_22` DOUBLE(12,6) ,`Channel_23` DOUBLE(12,6) ,`Channel_24` DOUBLE(12,6) ,`Channel_25` DOUBLE(12,6) ,`Channel_26` DOUBLE(12,6) ,`Channel_27` DOUBLE(12,6) ,`Channel_28` DOUBLE(12,6) ,`Channel_29` DOUBLE(12,6) ,`Channel_30` DOUBLE(12,6) ,`MidSizes_1` FLOAT(12,6) ,`MidSizes_2` FLOAT(12,6) ,`MidSizes_3` FLOAT(12,6) ,`MidSizes_4` FLOAT(12,6) ,`MidSizes_5` FLOAT(12,6) ,`MidSizes_6` FLOAT(12,6) ,`MidSizes_7` FLOAT(12,6) ,`MidSizes_8` FLOAT(12,6) ,`MidSizes_9` FLOAT(12,6) ,`MidSizes_10` FLOAT(12,6) ,`MidSizes_11` FLOAT(12,6) ,`MidSizes_12` FLOAT(12,6) ,`MidSizes_13` FLOAT(12,6) ,`MidSizes_14` FLOAT(12,6) ,`MidSizes_15` FLOAT(12,6) ,`MidSizes_16` FLOAT(12,6) ,`MidSizes_17` FLOAT(12,6) ,`MidSizes_18` FLOAT(12,6) ,`MidSizes_19` FLOAT(12,6) ,`MidSizes_20` FLOAT(12,6) ,`MidSizes_21` FLOAT(12,6) ,`MidSizes_22` FLOAT(12,6) ,`MidSizes_23` FLOAT(12,6) ,`MidSizes_24` FLOAT(12,6) ,`MidSizes_25` FLOAT(12,6) ,`MidSizes_26` FLOAT(12,6) ,`MidSizes_27` FLOAT(12,6) ,`MidSizes_28` FLOAT(12,6) ,`MidSizes_29` FLOAT(12,6) ,`MidSizes_30` FLOAT(12,6) ,`Counts_1` FLOAT(12,6) ,`Counts_2` FLOAT(12,6) ,`Counts_3` FLOAT(12,6) ,`Counts_4` FLOAT(12,6) ,`Counts_5` FLOAT(12,6) ,`Counts_6` FLOAT(12,6) ,`Counts_7` FLOAT(12,6) ,`Counts_8` FLOAT(12,6) ,`Counts_9` FLOAT(12,6) ,`Counts_10` FLOAT(12,6) ,`Counts_11` FLOAT(12,6) ,`Counts_12` FLOAT(12,6) ,`Counts_13` FLOAT(12,6) ,`Counts_14` FLOAT(12,6) ,`Counts_15` FLOAT(12,6) ,`Counts_16` FLOAT(12,6) ,`Counts_17` FLOAT(12,6) ,`Counts_18` FLOAT(12,6) ,`Counts_19` FLOAT(12,6) ,`Counts_20` FLOAT(12,6) ,`Counts_21` FLOAT(12,6) ,`Counts_22` FLOAT(12,6) ,`Counts_23` FLOAT(12,6) ,`Counts_24` FLOAT(12,6) ,`Counts_25` FLOAT(12,6) ,`Counts_26` FLOAT(12,6) ,`Counts_27` FLOAT(12,6) ,`Counts_28` FLOAT(12,6) ,`Counts_29` FLOAT(12,6) ,`Counts_30` FLOAT(12,6) ,`ValidCounts` FLOAT(12,6) ,`MinSizes_1` FLOAT(12,6) ,`MinSizes_2` FLOAT(12,6) ,`MinSizes_3` FLOAT(12,6) ,`MinSizes_4` FLOAT(12,6) ,`MinSizes_5` FLOAT(12,6) ,`MinSizes_6` FLOAT(12,6) ,`MinSizes_7` FLOAT(12,6) ,`MinSizes_8` FLOAT(12,6) ,`MinSizes_9` FLOAT(12,6) ,`MinSizes_10` FLOAT(12,6) ,`MinSizes_11` FLOAT(12,6) ,`MinSizes_12` FLOAT(12,6) ,`MinSizes_13` FLOAT(12,6) ,`MinSizes_14` FLOAT(12,6) ,`MinSizes_15` FLOAT(12,6) ,`MinSizes_16` FLOAT(12,6) ,`MinSizes_17` FLOAT(12,6) ,`MinSizes_18` FLOAT(12,6) ,`MinSizes_19` FLOAT(12,6) ,`MinSizes_20` FLOAT(12,6) ,`MinSizes_21` FLOAT(12,6) ,`MinSizes_22` FLOAT(12,6) ,`MinSizes_23` FLOAT(12,6) ,`MinSizes_24` FLOAT(12,6) ,`MinSizes_25` FLOAT(12,6) ,`MinSizes_26` FLOAT(12,6) ,`MinSizes_27` FLOAT(12,6) ,`MinSizes_28` FLOAT(12,6) ,`MinSizes_29` FLOAT(12,6) ,`MinSizes_30` FLOAT(12,6) ,`MaxSizes_1` FLOAT(12,6) ,`MaxSizes_2` FLOAT(12,6) ,`MaxSizes_3` FLOAT(12,6) ,`MaxSizes_4` FLOAT(12,6) ,`MaxSizes_5` FLOAT(12,6) ,`MaxSizes_6` FLOAT(12,6) ,`MaxSizes_7` FLOAT(12,6) ,`MaxSizes_8` FLOAT(12,6) ,`MaxSizes_9` FLOAT(12,6) ,`MaxSizes_10` FLOAT(12,6) ,`MaxSizes_11` FLOAT(12,6) ,`MaxSizes_12` FLOAT(12,6) ,`MaxSizes_13` FLOAT(12,6) ,`MaxSizes_14` FLOAT(12,6) ,`MaxSizes_15` FLOAT(12,6) ,`MaxSizes_16` FLOAT(12,6) ,`MaxSizes_17` FLOAT(12,6) ,`MaxSizes_18` FLOAT(12,6) ,`MaxSizes_19` FLOAT(12,6) ,`MaxSizes_20` FLOAT(12,6) ,`MaxSizes_21` FLOAT(12,6) ,`MaxSizes_22` FLOAT(12,6) ,`MaxSizes_23` FLOAT(12,6) ,`MaxSizes_24` FLOAT(12,6) ,`MaxSizes_25` FLOAT(12,6) ,`MaxSizes_26` FLOAT(12,6) ,`MaxSizes_27` FLOAT(12,6) ,`MaxSizes_28` FLOAT(12,6) ,`MaxSizes_29` FLOAT(12,6) ,`MaxSizes_30` FLOAT(12,6) ,`DateTime_pcasp_simple2_1` datetime ,`Counts_pcasp_simple2_1_1` FLOAT(12,6) ,`Counts_pcasp_simple2_1_2` FLOAT(12,6) ,`Counts_pcasp_simple2_1_3` FLOAT(12,6) ,`Counts_pcasp_simple2_1_4` FLOAT(12,6) ,`Counts_pcasp_simple2_1_5` FLOAT(12,6) ,`Counts_pcasp_simple2_1_6` FLOAT(12,6) ,`Counts_pcasp_simple2_1_7` FLOAT(12,6) ,`Counts_pcasp_simple2_1_8` FLOAT(12,6) ,`Counts_pcasp_simple2_1_9` FLOAT(12,6) ,`Counts_pcasp_simple2_1_10` FLOAT(12,6) ,`Counts_pcasp_simple2_1_11` FLOAT(12,6) ,`Counts_pcasp_simple2_1_12` FLOAT(12,6) ,`Counts_pcasp_simple2_1_13` FLOAT(12,6) ,`Counts_pcasp_simple2_1_14` FLOAT(12,6) ,`Counts_pcasp_simple2_1_15` FLOAT(12,6) ,`Counts_pcasp_simple2_1_16` FLOAT(12,6) ,`Counts_pcasp_simple2_1_17` FLOAT(12,6) ,`Counts_pcasp_simple2_1_18` FLOAT(12,6) ,`Counts_pcasp_simple2_1_19` FLOAT(12,6) ,`Counts_pcasp_simple2_1_20` FLOAT(12,6) ,`Counts_pcasp_simple2_1_21` FLOAT(12,6) ,`Counts_pcasp_simple2_1_22` FLOAT(12,6) ,`Counts_pcasp_simple2_1_23` FLOAT(12,6) ,`Counts_pcasp_simple2_1_24` FLOAT(12,6) ,`Counts_pcasp_simple2_1_25` FLOAT(12,6) ,`Counts_pcasp_simple2_1_26` FLOAT(12,6) ,`Counts_pcasp_simple2_1_27` FLOAT(12,6) ,`Counts_pcasp_simple2_1_28` FLOAT(12,6) ,`Counts_pcasp_simple2_1_29` FLOAT(12,6) ,`Counts_pcasp_simple2_1_30` FLOAT(12,6) ,`SampleFlow_pcasp_simple2_1` FLOAT(12,6) ,`Altitudeft` FLOAT(12,6) ,`DateTime_tracegas_1` datetime ,`DateTime_tracegas_2` datetime ,`ARINCAltitudeft_tracegas_1` FLOAT(8,1) ,`ARINCStaticPmb` FLOAT(8,1) ,`RMTStaticC` FLOAT(8,1) ,`DPC` FLOAT(8,1) ,`O3` FLOAT(9,3) ,`NOX` FLOAT(9,3) ,`SO2` FLOAT(9,3) ,`H2O2` FLOAT(9,3) ,`CO` FLOAT(9,3) ,`O3_tracegas_1` FLOAT(9,0) ,`NOX_tracegas_1` FLOAT(9,0) ,`SO2_tracegas_1` FLOAT(9,0) ,`H2O2_tracegas_1` FLOAT(9,0) ,`CO_tracegas_1` FLOAT(9,0) ,PRIMARY KEY (`id`) )ENGINE=InnoDB DEFAULT CHARSET=utf8";
            MySqlDatabaseUtil.ExecuteNoQuery(str);

        }


        /// <summary>
        /// 根据文件夹查找文件，同时将其读取并根据DateTime合并,并返回sql语句（主键要自动生成）
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="folder">csv数据文件存放目录，确保只有一层</param>
        /// <returns>insert sql语句</returns>
        public static List<String> MergeCsvFile2InsertSql(String tableName,String folder)
        {

            String fileprefix = folder;
            List<List<ModelCommon>> datas = new List<List<ModelCommon>>();
            int i = 0;
            foreach (String file in kingdataFiles)
            {
                String filepath = fileprefix + file + ".csv";
                datas.Add(readFunc[i++](filepath));
            }
            //store 合并后的 data
            List<List<List<ModelCommon>>> temporaryResult = new List<List<List<ModelCommon>>>();
            //decorate to use MergeByDateTimeMapRepeat
            foreach (var datai in datas)
            {
                List<List<ModelCommon>> modelCommonss = new List<List<ModelCommon>>();
                foreach (var model in datai)
                {
                    List<ModelCommon> temp = new List<ModelCommon>();
                    temp.Add(model);
                    modelCommonss.Add(temp);
                }
                temporaryResult.Add(modelCommonss);
            }
            //合并为一个
            while (temporaryResult.Count > 1)
            {
                var res00 = temporaryResult[0];
                var res01 = temporaryResult[1];
                temporaryResult.RemoveAt(1);
                temporaryResult.RemoveAt(0);
                temporaryResult.Add(ModelUtil.MergeByDateTimeMapRepeat<ModelCommon, ModelCommon>(res00, res01));
            }
            
            List<List<ValAndFieldName>> valFieldAndNameList = ModelUtil.GenerateListValAndFieldName(temporaryResult[0]);

            List<String> sqlInsertList = new List<string>();
            foreach (var d in valFieldAndNameList)
            {
                String str = DbGenerateUtil.GenerateInsertDbSql(tableName, d);
                sqlInsertList.Add(str);
            }

            Console.WriteLine("\n" + sqlInsertList.Count + "\n");
            return sqlInsertList;
        }

        /// <summary>
        /// MergeCsvFile2InsertSql 利用LINQ，写起来方便
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="folder">csv数据文件存放目录，确保只有一层</param>
        /// <returns>insert sql语句</returns>
        public static List<String> MergeCsvFile2InsertSqlLINQ(String tableName, String folder)
        {
            String fileprefix = folder;
            List<List<ModelCommon>> datas = new List<List<ModelCommon>>();
            int i = 0;
            foreach (String file in kingdataFiles)
            {
                String filepath = fileprefix + file + ".csv";
                datas.Add(readFunc[i++](filepath));
            }
           


            # region join but not left join, 知道experssion tree 但是现在还不会
            var datacombine = from a in datas[0]
                             join b in datas[1] on a.GetDateTime() equals b.GetDateTime()
                             join c in datas[2] on a.GetDateTime() equals c.GetDateTime()
                             join d in datas[3] on a.GetDateTime() equals d.GetDateTime()
                             join e in datas[4] on a.GetDateTime() equals e.GetDateTime()
                             join f in datas[5] on a.GetDateTime() equals f.GetDateTime()
                             join g in datas[6] on a.GetDateTime() equals g.GetDateTime()
                             join h in datas[7] on a.GetDateTime() equals h.GetDateTime()
                             join j in datas[8] on a.GetDateTime() equals j.GetDateTime()
                             select new
                             {
                                 a,
                                 b,
                                 c,
                                 d,
                                 e,
                                 f,
                                 g,
                                 h,
                                 j
                             };
            #endregion

            List<List<ModelCommon>> result = new List<List<ModelCommon>>();
            foreach (var item in datacombine) {
                List<ModelCommon> list = new List<ModelCommon>() {
                    item.a,item.b,item.c,item.d,item.e,item.f,item.g,item.h,item.j
                };
                result.Add(list);                
            }
            List<List<ValAndFieldName>> valFieldAndNameList = ModelUtil.GenerateListValAndFieldName(result);
            Console.WriteLine(valFieldAndNameList.Count());
            List<String> sqlInsertList = new List<string>();
            foreach (var d in valFieldAndNameList)
            {
                String str = DbGenerateUtil.GenerateInsertDbSql(tableName, d);
                sqlInsertList.Add(str);
            }


            return sqlInsertList;
        }
    }
}

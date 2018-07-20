using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using WM_Plane_KingData.Model;
using WM_Plane_KingData.Util;

namespace WM_Plane_MY.Util
{
    public static class KingdataUtil
    {
        public static List<ModelCommon> ReadAnimmsFile(String filepath)
        {
            List<String[]> datas = CSVUtil.ReadCsv(filepath);
            List<ModelCommon> animmsFiles = new List<ModelCommon>();

            foreach (String[] data in datas)
            {
                //read date,time
                Aimms animms = new Aimms();

                animms.dateTime = ModelUtil.ParseDateTime(data[0], data[1]);

                animms.Latitude = float.Parse(data[2]);
                animms.Longitude = float.Parse(data[3]);

                animms.TAS = float.Parse(data[4]);
                animms.Id0Count = float.Parse(data[5]);
                animms.Time = data[6];
                animms.Temp = float.Parse(data[7]);
                animms.RH = float.Parse(data[8]);

                animms.BaroPress = float.Parse(data[9]);
                animms.WindFlowNS = float.Parse(data[10]);
                animms.WindFlowEW = float.Parse(data[11]);
                animms.WindSpeed = float.Parse(data[12]);
                animms.WindDir = float.Parse(data[13]);
                animms.WindSolution = data[14];

                animms.BaroPress_aimms_1 = float.Parse(data[15]);
                animms.WindSpeed_aimms_1 = float.Parse(data[16]);
                animms.Altitude = float.Parse(data[17]);
                animms.Id1Count = float.Parse(data[18]);
                animms.Time_aimms_1 = data[19];
                animms.Latitude_aimms_1 = float.Parse(data[20]);
                animms.Longitude_aimms_1 = float.Parse(data[21]);
                animms.Altitude_aimms_1 = float.Parse(data[22]);

                animms.VelocityNS = float.Parse(data[23]);
                animms.VelocityEW = float.Parse(data[24]);
                animms.VelocityUD = float.Parse(data[25]);
                animms.Roll = float.Parse(data[26]);
                animms.Pitch = float.Parse(data[27]);
                animms.Yaw = float.Parse(data[28]);
                animms.TAS_aimms_1 = float.Parse(data[29]);
                animms.VerticalWind = float.Parse(data[30]);

                animms.Sideslip = float.Parse(data[31]);
                animms.AOAPressDiff = float.Parse(data[32]);
                animms.SideslipDiff = float.Parse(data[33]);
                animms.Latitude_aimms_2 = data[34];
                animms.Longitude_aimms_2 = data[35];
                animms.Altitude_aimms_2 = float.Parse(data[36]);
                animms.Id2Count = float.Parse(data[37]);
                animms.Time_aimms_2 = float.Parse(data[38]);
                animms.Latitude_aimms_3 = float.Parse(data[39]);
                animms.Longitude_aimms_3 = float.Parse(data[40]);

                animms.Altitude_aimms_3 = float.Parse(data[41]);
                animms.GroundSpeed = float.Parse(data[42]);
                animms.GroundTrack = float.Parse(data[43]);
                animms.HFOM = float.Parse(data[44]);
                animms.VFOM = float.Parse(data[45]);
                animms.NavMode = float.Parse(data[46]);
                animms.Satellites = float.Parse(data[47]);
                animms.DatumNumber = float.Parse(data[48]);

                animms.SolConfLevel = data[49];
                animms.GPSTimeAlign = data[50];
                animms.NavModeStatus = data[51];

                animms.Latitude_aimms_4 = data[52];
                animms.Longitude_aimms_4 = data[53];
                animms.Altitude_aimms_4 = float.Parse(data[54]);
                animms.Latitude_aimms_5 = float.Parse(data[55]);
                animms.Longitude_aimms_5 = float.Parse(data[56]);

                animmsFiles.Add(animms);
            }

            return animmsFiles;
        }

        public static List<ModelCommon> ReadArinc429File(String filepath)
        {
            List<String[]> Arinc429datas = CSVUtil.ReadCsv(filepath);
            List<ModelCommon> arinc429s = new List<ModelCommon>();
            foreach (String[] data in Arinc429datas)
            {
                Arinc429 arinc429 = new Arinc429();

                arinc429.DateTime_arinc429_1 = ModelUtil.ParseDateTime(data[0], data[1]);
                arinc429.StaticPSSECorrected = float.Parse(data[2]);
                //
                String[] two = Regex.Split(data[3], "-");
                arinc429.ImpactPressure = float.Parse(two[0]);
                arinc429.Altitude_arinc429_1 = float.Parse(two[1]);
                arinc429.BaroCorrectedAltitude = float.Parse(data[4]);
                arinc429.Mach = float.Parse(data[5]);
                arinc429.Airspeed = float.Parse(data[6]);
                arinc429.TrueAirSpeed = float.Parse(data[7]);
                arinc429.Totaltemp = float.Parse(data[8]);
                arinc429.veritcalSpeed = float.Parse(data[9]);

                arinc429.magheadingdeg = float.Parse(data[10]);


                arinc429s.Add(arinc429);
            }
            return arinc429s;
        }

        public static List<ModelCommon> ReadBjwmoFile(String filepath)
        {
            List<String[]> datas = CSVUtil.ReadCsv(filepath);
            List<ModelCommon> bjwmos = new List<ModelCommon>();
            foreach (String[] strs in datas)
            {
                Bjwmo bjwmo = new Bjwmo();

                bjwmo.Date = ModelUtil.ParseDateTime(strs[0], strs[1]);
                bjwmo.AIMMSTime = strs[2];
                bjwmo.Latitude_bjwmo_1 = float.Parse(strs[3]);
                bjwmo.Longitude_bjwmo_1 = float.Parse(strs[4]);
                bjwmo.LWC = float.Parse(strs[5]);
                bjwmo.TWC = float.Parse(strs[6]);
                bjwmo.Hygrometer = float.Parse(strs[7]);
                bjwmo.RICEMsoFreqHz = float.Parse(strs[8]);
                bjwmo.RMTTotalTempC = float.Parse(strs[9]);
                bjwmo.RMTStaticTempC = float.Parse(strs[10]);

                bjwmo.DewPointC = float.Parse(strs[11]);
                bjwmo.TAS_bjwmo_1 = float.Parse(strs[12]);
                bjwmo.Temp_bjwmo_1 = float.Parse(strs[13]);
                bjwmo.RH_bjwmo_1 = float.Parse(strs[14]);
                bjwmo.WindFlowNS_bjwmo_1 = float.Parse(strs[15]);
                bjwmo.WindFlowEW_bjwmo_1 = float.Parse(strs[16]);
                bjwmo.WindSpeed_bjwmo_1 = float.Parse(strs[17]);
                bjwmo.WindDir_bjwmo_1 = float.Parse(strs[18]);
                bjwmo.WindSolution_bjwmo_1 = strs[19];

                bjwmo.BaroPress_bjwmo_1 = float.Parse(strs[20]);


                bjwmo.WindSpeed_bjwmo_2 = float.Parse(strs[21]);

                bjwmo.Altitude_bjwmo_1 = float.Parse(strs[22]);
                bjwmo.Latitude_bjwmo_2 = float.Parse(strs[23]);
                bjwmo.Latitude_bjwmo_2 = float.Parse(strs[24]);
                bjwmo.Altitude_bjwmo_2 = float.Parse(strs[25]);
                bjwmo.VelocityNS_bjwmo_1 = float.Parse(strs[26]);
                bjwmo.VelocityEW_bjwmo_1 = float.Parse(strs[27]);
                bjwmo.VelocityUD_bjwmo_1 = float.Parse(strs[28]);
                bjwmo.Roll_bjwmo_1 = float.Parse(strs[29]);
                bjwmo.Pitch_bjwmo_1 = float.Parse(strs[30]);
                bjwmo.Yaw_bjwmo_1 = float.Parse(strs[31]);

                bjwmo.TAS_bjwmo_2 = float.Parse(strs[32]);
                bjwmo.VerticalWind_bjwmo_1 = float.Parse(strs[33]);
                bjwmo.Sideslip_bjwmo_1 = float.Parse(strs[34]);
                bjwmo.AOAPressDiff_bjwmo_1 = float.Parse(strs[35]);
                bjwmo.SideslipDiff_bjwmo_1 = float.Parse(strs[36]);
                bjwmo.Latitude_bjwmo_3 = strs[37];
                bjwmo.Longitude_bjwmo_3 = strs[38];
                bjwmo.Altitude_bjwmo_3 = float.Parse(strs[39]);
                bjwmo.StaticPSSECorrected_bjwmo_1 = float.Parse(strs[40]);
                bjwmo.StaticPSSECorrected_bjwmo_2 = float.Parse(strs[41]);


                bjwmos.Add(bjwmo);
            }
            return bjwmos;
        }
        public static List<ModelCommon> ReadIcedetFile(String filepath)
        {
            List<String[]> datas = CSVUtil.ReadCsv(filepath);
            List<ModelCommon> icedets = new List<ModelCommon>();
            foreach (String[] data in datas)
            {
                Icedet icedet = new Icedet();
                icedet.DateTime_icedet_1 = ModelUtil.ParseDateTime(data[0], data[1]);
                icedet.ID_W = data[2];
                icedet.OnTimeCntr = Convert.ToDouble(data[3]);
                icedet.Power = Convert.ToDouble(data[4]);
                icedet.PermErr1 = data[5];
                icedet.PermErr2 = data[6];
                icedet.PermErr3 = data[7];
                icedet.TotIceCnt = Convert.ToDouble(data[8]);
                icedet.ID_X = data[9];
                icedet.MsoFreq = Convert.ToDouble(data[10]);

                icedet.IceCycCnt = Convert.ToDouble(data[11]);
                icedet.SigState = data[12];
                icedet.OprState = data[13];
                icedet.BitErr1 = data[14];
                icedet.BitErr2 = data[15];
                icedet.BitErr3 = data[16];
                icedet.ID_Y = data[17];
                icedet.TotFailCnt = Convert.ToDouble(data[18]);
                icedet.MsoFailCnt = Convert.ToDouble(data[19]);
                icedet.IceFailCnt = Convert.ToDouble(data[20]);

                icedet.StaFailCnt = Convert.ToDouble(data[21]);
                icedet.HtrFailCnt = Convert.ToDouble(data[22]);
                icedet.ID_Z = data[23];
                icedet.FaultLog1 = data[24];
                icedet.FaultLog2 = data[25];
                icedet.FaultLog3 = data[26];
                icedet.FaultLog4 = data[27];
                icedet.FaultLog5 = data[28];
                icedet.FaultLog6 = data[29];
                icedet.FaultLog7 = data[30];


                icedets.Add(icedet);
            }
            return icedets;
        }
        public static List<ModelCommon> ReadInletcontroldataFile(String filepath)
        {
            List<String[]> datas = CSVUtil.ReadCsv(filepath);
            List<ModelCommon> inletcontroldatas = new List<ModelCommon>();
            foreach (String[] data in datas)
            {
                Inletcontroldata inletcontroldata = new Inletcontroldata();
                inletcontroldata.DateTime_inletcontroldata_1 = ModelUtil.ParseDateTime(data[0], data[1]);
                inletcontroldata.tip_flow = float.Parse(data[2]);
                inletcontroldata.tipfltrg = float.Parse(data[3]);
                inletcontroldata.airspeed_inletcontroldata_1 = float.Parse(data[4]);
                inletcontroldata.oat_temp = float.Parse(data[5]);
                inletcontroldata.instflow = float.Parse(data[6]);
                inletcontroldata.inltpres = float.Parse(data[7]);
                inletcontroldata.blwrflow = float.Parse(data[8]);
                inletcontroldata.blwrtarg = float.Parse(data[9]);
                inletcontroldata.blwr_tmp = float.Parse(data[10]);

                inletcontroldata.blwr_pwr = float.Parse(data[11]);
                inletcontroldata.throtpos = float.Parse(data[12]);
                inletcontroldata.fconetmp = float.Parse(data[13]);
                inletcontroldata.rconetmp = float.Parse(data[14]);
                inletcontroldata.pylontmp = float.Parse(data[15]);
                inletcontroldata.sensrtmp = float.Parse(data[16]);
                inletcontroldata.fconepwr = float.Parse(data[17]);
                inletcontroldata.rconepwr = float.Parse(data[18]);
                inletcontroldata.pylonpwr = float.Parse(data[19]);
                inletcontroldata.sensrpwr = float.Parse(data[20]);

                inletcontroldatas.Add(inletcontroldata);
            }
            return inletcontroldatas;
        }

        public static List<ModelCommon> ReadM300TASFile(String filepath)
        {
            List<String[]> datas = CSVUtil.ReadCsv(filepath);
            List<ModelCommon> m300TASs = new List<ModelCommon>();
            foreach (String[] data in datas)
            {
                M300TAS m300TAS = new M300TAS();
                int secondsMidNight = Convert.ToInt32(data[0]);

                DateTime dateTime = ModelUtil.ProcessSecondMidNight(filepath, secondsMidNight);
                m300TAS.DateTime_m300TAS_1 = dateTime;

                m300TAS.ARINCTAS = float.Parse(data[1]);

                m300TASs.Add(m300TAS);
            }
            return m300TASs;
        }

        public static List<ModelCommon> ReadNevFile(String filepath)
        {
            List<String[]> datas = CSVUtil.ReadCsv(filepath);
            List<ModelCommon> nevs = new List<ModelCommon>();
            foreach (String[] data in datas)
            {
                Nev nev = new Nev();
                int secondsMidNight = Convert.ToInt32(data[0]);

                DateTime dateTime = ModelUtil.ProcessSecondMidNight(filepath, secondsMidNight);
                nev.DateTime_nev_1 = dateTime;
                nev.ARINCAltitudeft = float.Parse(data[1]);
                nev.NevTWC = float.Parse(data[2]);
                nev.NevLWC = float.Parse(data[3]);
                nevs.Add(nev);
            }
            return nevs;
        }

        public static List<ModelCommon> ReadPcaspFile(String filepath)
        {
            List<String[]> datas = CSVUtil.ReadCsv(filepath);
            List<ModelCommon> pcasps = new List<ModelCommon>();
            foreach (String[] data in datas)
            {
                Pcasp pcasp = new Pcasp();
                pcasp.DateTime_pcasp_1 = ModelUtil.ParseDateTime(data[0], data[1]);
                pcasp.Analog0 = float.Parse(data[2]);
                pcasp.Analog1 = float.Parse(data[3]);
                pcasp.Analog2 = float.Parse(data[4]);
                pcasp.Analog3 = float.Parse(data[5]);
                pcasp.Analog4 = float.Parse(data[6]);
                pcasp.Analog5 = float.Parse(data[7]);
                pcasp.Analog6 = float.Parse(data[8]);
                pcasp.Analog7 = float.Parse(data[9]);
                pcasp.HighGainBaselinev = float.Parse(data[10]);

                pcasp.MidGainBaselinev = float.Parse(data[10]);
                pcasp.LowGainBaselinev = float.Parse(data[11]);
                pcasp.SampleFlow = float.Parse(data[12]);
                pcasp.LaserReferencev = float.Parse(data[13]);
                pcasp.Analog1v = float.Parse(data[14]);
                pcasp.SheathFlow = float.Parse(data[15]);
                pcasp.InternalTemp = float.Parse(data[16]);
                pcasp.AvgTransit = float.Parse(data[17]);
                pcasp.AvgTransit_pcasp_1 = float.Parse(data[18]);
                pcasp.FIFOFull = float.Parse(data[19]);
                pcasp.ResetFlag = float.Parse(data[20]);

                pcasp.SynsErrorA = float.Parse(data[21]);
                pcasp.SyncErrorB = float.Parse(data[22]);
                pcasp.SyncErrorC = float.Parse(data[23]);
                pcasp.Overrange = float.Parse(data[24]);
                pcasp.SPPSamples = float.Parse(data[25]);
                pcasp.RangeValue = float.Parse(data[26]);
                pcasp.RangeControl = float.Parse(data[27]);
                pcasp.Range = float.Parse(data[28]);
                pcasp.LasereReferencev = float.Parse(data[29]);

                pcasp.Channel_1 = float.Parse(data[30]);
                pcasp.Channel_2 = float.Parse(data[31]);
                pcasp.Channel_3 = float.Parse(data[32]);
                pcasp.Channel_4 = float.Parse(data[33]);
                pcasp.Channel_5 = float.Parse(data[34]);
                pcasp.Channel_6 = float.Parse(data[35]);
                pcasp.Channel_7 = float.Parse(data[36]);
                pcasp.Channel_8 = float.Parse(data[37]);
                pcasp.Channel_9 = float.Parse(data[38]);
                pcasp.Channel_10 = float.Parse(data[39]);
                pcasp.Channel_11 = float.Parse(data[40]);
                pcasp.Channel_12 = float.Parse(data[41]);
                pcasp.Channel_13 = float.Parse(data[42]);
                pcasp.Channel_14 = float.Parse(data[43]);
                pcasp.Channel_15 = float.Parse(data[44]);
                pcasp.Channel_16 = float.Parse(data[45]);
                pcasp.Channel_17 = float.Parse(data[46]);
                pcasp.Channel_18 = float.Parse(data[47]);
                pcasp.Channel_19 = float.Parse(data[48]);
                pcasp.Channel_20 = float.Parse(data[49]);
                pcasp.Channel_21 = float.Parse(data[50]);
                pcasp.Channel_22 = float.Parse(data[51]);
                pcasp.Channel_23 = float.Parse(data[52]);
                pcasp.Channel_24 = float.Parse(data[53]);
                pcasp.Channel_25 = float.Parse(data[54]);
                pcasp.Channel_26 = float.Parse(data[55]);
                pcasp.Channel_27 = float.Parse(data[56]);
                pcasp.Channel_28 = float.Parse(data[57]);
                pcasp.Channel_29 = float.Parse(data[58]);
                pcasp.Channel_30 = float.Parse(data[59]);


                pcasp.MidSizes_1 = float.Parse(data[60]);
                pcasp.MidSizes_2 = float.Parse(data[61]);
                pcasp.MidSizes_3 = float.Parse(data[62]);
                pcasp.MidSizes_4 = float.Parse(data[63]);
                pcasp.MidSizes_5 = float.Parse(data[64]);
                pcasp.MidSizes_6 = float.Parse(data[65]);
                pcasp.MidSizes_7 = float.Parse(data[66]);
                pcasp.MidSizes_8 = float.Parse(data[67]);
                pcasp.MidSizes_9 = float.Parse(data[68]);
                pcasp.MidSizes_10 = float.Parse(data[69]);
                pcasp.MidSizes_11 = float.Parse(data[70]);
                pcasp.MidSizes_12 = float.Parse(data[71]);
                pcasp.MidSizes_13 = float.Parse(data[72]);
                pcasp.MidSizes_14 = float.Parse(data[73]);
                pcasp.MidSizes_15 = float.Parse(data[74]);
                pcasp.MidSizes_16 = float.Parse(data[75]);
                pcasp.MidSizes_17 = float.Parse(data[76]);
                pcasp.MidSizes_18 = float.Parse(data[77]);
                pcasp.MidSizes_19 = float.Parse(data[78]);
                pcasp.MidSizes_20 = float.Parse(data[79]);
                pcasp.MidSizes_21 = float.Parse(data[80]);
                pcasp.MidSizes_22 = float.Parse(data[81]);
                pcasp.MidSizes_23 = float.Parse(data[82]);
                pcasp.MidSizes_24 = float.Parse(data[83]);
                pcasp.MidSizes_25 = float.Parse(data[84]);
                pcasp.MidSizes_26 = float.Parse(data[85]);
                pcasp.MidSizes_27 = float.Parse(data[86]);
                pcasp.MidSizes_28 = float.Parse(data[87]);
                pcasp.MidSizes_29 = float.Parse(data[88]);
                pcasp.MidSizes_30 = float.Parse(data[89]);

                pcasp.Counts_1 = float.Parse(data[90]);
                pcasp.Counts_2 = float.Parse(data[91]);
                pcasp.Counts_3 = float.Parse(data[92]);
                pcasp.Counts_4 = float.Parse(data[93]);
                pcasp.Counts_5 = float.Parse(data[94]);
                pcasp.Counts_6 = float.Parse(data[95]);
                pcasp.Counts_7 = float.Parse(data[96]);
                pcasp.Counts_8 = float.Parse(data[97]);
                pcasp.Counts_9 = float.Parse(data[98]);
                pcasp.Counts_10 = float.Parse(data[99]);
                pcasp.Counts_11 = float.Parse(data[100]);
                pcasp.Counts_12 = float.Parse(data[101]);
                pcasp.Counts_13 = float.Parse(data[102]);
                pcasp.Counts_14 = float.Parse(data[103]);
                pcasp.Counts_15 = float.Parse(data[104]);
                pcasp.Counts_16 = float.Parse(data[105]);
                pcasp.Counts_17 = float.Parse(data[106]);
                pcasp.Counts_18 = float.Parse(data[107]);
                pcasp.Counts_19 = float.Parse(data[108]);
                pcasp.Counts_20 = float.Parse(data[109]);
                pcasp.Counts_21 = float.Parse(data[110]);
                pcasp.Counts_22 = float.Parse(data[111]);
                pcasp.Counts_23 = float.Parse(data[112]);
                pcasp.Counts_24 = float.Parse(data[113]);
                pcasp.Counts_25 = float.Parse(data[114]);
                pcasp.Counts_26 = float.Parse(data[115]);
                pcasp.Counts_27 = float.Parse(data[116]);
                pcasp.Counts_28 = float.Parse(data[117]);
                pcasp.Counts_29 = float.Parse(data[118]);
                pcasp.Counts_30 = float.Parse(data[119]);

                pcasp.ValidCounts = float.Parse(data[120]);

                pcasp.MinSizes_1 = float.Parse(data[121]);
                pcasp.MinSizes_2 = float.Parse(data[122]);
                pcasp.MinSizes_3 = float.Parse(data[123]);
                pcasp.MinSizes_4 = float.Parse(data[124]);
                pcasp.MinSizes_5 = float.Parse(data[125]);
                pcasp.MinSizes_6 = float.Parse(data[126]);
                pcasp.MinSizes_7 = float.Parse(data[127]);
                pcasp.MinSizes_8 = float.Parse(data[128]);
                pcasp.MinSizes_9 = float.Parse(data[129]);
                pcasp.MinSizes_10 = float.Parse(data[130]);
                pcasp.MinSizes_11 = float.Parse(data[131]);
                pcasp.MinSizes_12 = float.Parse(data[132]);
                pcasp.MinSizes_13 = float.Parse(data[133]);
                pcasp.MinSizes_14 = float.Parse(data[134]);
                pcasp.MinSizes_15 = float.Parse(data[135]);
                pcasp.MinSizes_16 = float.Parse(data[136]);
                pcasp.MinSizes_17 = float.Parse(data[137]);
                pcasp.MinSizes_18 = float.Parse(data[138]);
                pcasp.MinSizes_19 = float.Parse(data[139]);
                pcasp.MinSizes_20 = float.Parse(data[140]);
                pcasp.MinSizes_21 = float.Parse(data[141]);
                pcasp.MinSizes_22 = float.Parse(data[142]);
                pcasp.MinSizes_23 = float.Parse(data[143]);
                pcasp.MinSizes_24 = float.Parse(data[144]);
                pcasp.MinSizes_25 = float.Parse(data[145]);
                pcasp.MinSizes_26 = float.Parse(data[146]);
                pcasp.MinSizes_27 = float.Parse(data[147]);
                pcasp.MinSizes_28 = float.Parse(data[148]);
                pcasp.MinSizes_29 = float.Parse(data[149]);
                pcasp.MinSizes_30 = float.Parse(data[150]);

                pcasp.MaxSizes_1 = float.Parse(data[151]);
                pcasp.MaxSizes_2 = float.Parse(data[152]);
                pcasp.MaxSizes_3 = float.Parse(data[153]);
                pcasp.MaxSizes_4 = float.Parse(data[154]);
                pcasp.MaxSizes_5 = float.Parse(data[155]);
                pcasp.MaxSizes_6 = float.Parse(data[156]);
                pcasp.MaxSizes_7 = float.Parse(data[157]);
                pcasp.MaxSizes_8 = float.Parse(data[158]);
                pcasp.MaxSizes_9 = float.Parse(data[159]);
                pcasp.MaxSizes_10 = float.Parse(data[160]);
                pcasp.MaxSizes_11 = float.Parse(data[161]);
                pcasp.MaxSizes_12 = float.Parse(data[162]);
                pcasp.MaxSizes_13 = float.Parse(data[163]);
                pcasp.MaxSizes_14 = float.Parse(data[164]);
                pcasp.MaxSizes_15 = float.Parse(data[165]);
                pcasp.MaxSizes_16 = float.Parse(data[166]);
                pcasp.MaxSizes_17 = float.Parse(data[167]);
                pcasp.MaxSizes_18 = float.Parse(data[168]);
                pcasp.MaxSizes_19 = float.Parse(data[169]);
                pcasp.MaxSizes_20 = float.Parse(data[170]);
                pcasp.MaxSizes_21 = float.Parse(data[171]);
                pcasp.MaxSizes_22 = float.Parse(data[172]);
                pcasp.MaxSizes_23 = float.Parse(data[173]);
                pcasp.MaxSizes_24 = float.Parse(data[174]);
                pcasp.MaxSizes_25 = float.Parse(data[175]);
                pcasp.MaxSizes_26 = float.Parse(data[176]);
                pcasp.MaxSizes_27 = float.Parse(data[177]);
                pcasp.MaxSizes_28 = float.Parse(data[178]);
                pcasp.MaxSizes_29 = float.Parse(data[179]);
                pcasp.MaxSizes_30 = float.Parse(data[180]);




                pcasps.Add(pcasp);
            }
            return pcasps;
        }
        public static List<ModelCommon> ReadPcaspSimple2File(String filepath)
        {
            List<String[]> datas = CSVUtil.ReadCsv(filepath);
            List<ModelCommon> pcasp_Simple2s = new List<ModelCommon>();
            foreach (String[] data in datas)
            {
                PcaspSimple2 pcasp_Simple2 = new PcaspSimple2();
                pcasp_Simple2.DateTime_pcasp_simple2_1 = ModelUtil.ParseDateTime(data[0], data[1]);

                pcasp_Simple2.Counts_pcasp_simple2_1_1 = float.Parse(data[2]);
                pcasp_Simple2.Counts_pcasp_simple2_1_2 = float.Parse(data[3]);
                pcasp_Simple2.Counts_pcasp_simple2_1_3 = float.Parse(data[4]);
                pcasp_Simple2.Counts_pcasp_simple2_1_4 = float.Parse(data[5]);
                pcasp_Simple2.Counts_pcasp_simple2_1_5 = float.Parse(data[6]);
                pcasp_Simple2.Counts_pcasp_simple2_1_6 = float.Parse(data[7]);
                pcasp_Simple2.Counts_pcasp_simple2_1_7 = float.Parse(data[8]);
                pcasp_Simple2.Counts_pcasp_simple2_1_8 = float.Parse(data[9]);
                pcasp_Simple2.Counts_pcasp_simple2_1_9 = float.Parse(data[10]);
                pcasp_Simple2.Counts_pcasp_simple2_1_10 = float.Parse(data[11]);
                pcasp_Simple2.Counts_pcasp_simple2_1_11 = float.Parse(data[12]);
                pcasp_Simple2.Counts_pcasp_simple2_1_12 = float.Parse(data[13]);
                pcasp_Simple2.Counts_pcasp_simple2_1_13 = float.Parse(data[14]);
                pcasp_Simple2.Counts_pcasp_simple2_1_14 = float.Parse(data[15]);
                pcasp_Simple2.Counts_pcasp_simple2_1_15 = float.Parse(data[16]);
                pcasp_Simple2.Counts_pcasp_simple2_1_16 = float.Parse(data[17]);
                pcasp_Simple2.Counts_pcasp_simple2_1_17 = float.Parse(data[18]);
                pcasp_Simple2.Counts_pcasp_simple2_1_18 = float.Parse(data[19]);
                pcasp_Simple2.Counts_pcasp_simple2_1_19 = float.Parse(data[20]);
                pcasp_Simple2.Counts_pcasp_simple2_1_20 = float.Parse(data[21]);
                pcasp_Simple2.Counts_pcasp_simple2_1_21 = float.Parse(data[22]);
                pcasp_Simple2.Counts_pcasp_simple2_1_22 = float.Parse(data[23]);
                pcasp_Simple2.Counts_pcasp_simple2_1_23 = float.Parse(data[24]);
                pcasp_Simple2.Counts_pcasp_simple2_1_24 = float.Parse(data[25]);
                pcasp_Simple2.Counts_pcasp_simple2_1_25 = float.Parse(data[26]);
                pcasp_Simple2.Counts_pcasp_simple2_1_26 = float.Parse(data[27]);
                pcasp_Simple2.Counts_pcasp_simple2_1_27 = float.Parse(data[28]);
                pcasp_Simple2.Counts_pcasp_simple2_1_28 = float.Parse(data[29]);
                pcasp_Simple2.Counts_pcasp_simple2_1_29 = float.Parse(data[30]);
                pcasp_Simple2.Counts_pcasp_simple2_1_30 = float.Parse(data[31]);
                pcasp_Simple2.SampleFlow_pcasp_simple2_1 = float.Parse(data[32]);
                pcasp_Simple2.Altitudeft = float.Parse(data[33]);

                pcasp_Simple2s.Add(pcasp_Simple2);

            }
            return pcasp_Simple2s;
        }

        public static List<ModelCommon> ReadTracgasFile(String filepath)
        {
            List<String[]> datas = CSVUtil.ReadCsv(filepath);
            List<ModelCommon> traceGass = new List<ModelCommon>();
            foreach (String[] data in datas)
            {
                Tracegas tracegas = new Tracegas();

                tracegas.DateTime_tracegas_1 = ModelUtil.ParseDateTime(data[0], data[1]);
                int secondsMidNight = Convert.ToInt32(data[2]);
                DateTime dateTime = ModelUtil.ProcessSecondMidNight(filepath, secondsMidNight);
                tracegas.DateTime_tracegas_2 = dateTime;

                tracegas.ARINCAltitudeft_tracegas_1 = float.Parse(data[3]);
                tracegas.ARINCStaticPmb = float.Parse(data[3]);
                tracegas.RMTStaticC = float.Parse(data[3]);
                tracegas.DPC = float.Parse(data[4]);
                tracegas.O3 = float.Parse(data[5]);
                tracegas.NOX = float.Parse(data[6]);
                tracegas.SO2 = float.Parse(data[7]);
                tracegas.H2O2 = float.Parse(data[8]);
                tracegas.O3_tracegas_1 = float.Parse(data[9]);
                tracegas.NOX_tracegas_1 = float.Parse(data[10]);
                tracegas.SO2_tracegas_1 = float.Parse(data[11]);
                tracegas.H2O2_tracegas_1 = float.Parse(data[12]);
                tracegas.CO_tracegas_1 = float.Parse(data[13]);

                traceGass.Add(tracegas);
            }
            return traceGass;
        }

    }
}

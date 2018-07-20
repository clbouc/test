using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WM_Plane_KingData.Util;

namespace WM_Plane_KingData.Model
{
    public class Bjwmo:ModelCommon
    {
        #region 字段列表
        public DateTime Date;
        public string AIMMSTime;
        public float Latitude_bjwmo_1;
        public float Longitude_bjwmo_1;
        public float LWC;
        public float TWC;
        public float Hygrometer;
        public float RICEMsoFreqHz;
        public float RMTTotalTempC;
        public float RMTStaticTempC;
        public float DewPointC;
        public float TAS_bjwmo_1;
        public float Temp_bjwmo_1;
        public float RH_bjwmo_1;
        public float WindFlowNS_bjwmo_1;
        public float WindFlowEW_bjwmo_1;
        public float WindSpeed_bjwmo_1;
        public float WindDir_bjwmo_1;
        public string WindSolution_bjwmo_1;
        public float BaroPress_bjwmo_1;
        public float WindSpeed_bjwmo_2;
        public float Altitude_bjwmo_1;
        public float Latitude_bjwmo_2;
        public float Longitude_bjwmo_2;
        public float Altitude_bjwmo_2;
        public float VelocityNS_bjwmo_1;
        public float VelocityEW_bjwmo_1;
        public float VelocityUD_bjwmo_1;
        public float Roll_bjwmo_1;
        public float Pitch_bjwmo_1;
        public float Yaw_bjwmo_1;
        public float TAS_bjwmo_2;
        public float VerticalWind_bjwmo_1;
        public float Sideslip_bjwmo_1;
        public float AOAPressDiff_bjwmo_1;
        public float SideslipDiff_bjwmo_1;
        public string Latitude_bjwmo_3;
        public string Longitude_bjwmo_3;
        public float Altitude_bjwmo_3;
        public float StaticPSSECorrected_bjwmo_1;
        public float StaticPSSECorrected_bjwmo_2;

        #endregion 字段列表
        

        public DateTime GetDateTime()
        {
            return this.Date;
        }

        
       
    }
}

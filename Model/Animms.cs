using System;
using System.Collections;
using System.Collections.Generic;
using WM_Plane_CreateDBImport.Util;

namespace WM_Plane_CreateDBImport.Model
{
    public class Aimms :ModelCommon
    {
        #region 字段列表
        public DateTime dateTime;
        public float Latitude, Longitude;
        public float TAS;
        public double Id0Count;
        public String Time;
        public float Temp;
        public float RH;
        public float BaroPress;
        public float WindFlowNS;
        public float WindFlowEW;
        public float WindSpeed;
        public float WindDir;
        public string WindSolution;

        public float BaroPress_aimms_1;
        public float WindSpeed_aimms_1;
        public float Altitude;
        public double Id1Count;
        public string Time_aimms_1;
        public float Latitude_aimms_1;
        public float Longitude_aimms_1;
        public float Altitude_aimms_1;
        public float VelocityNS;
        public float VelocityEW;
        public float VelocityUD;
        public float Roll;
        public float Pitch;
        public float Yaw;
        public float TAS_aimms_1;
        public float VerticalWind;
        public float Sideslip;
        public float AOAPressDiff;
        public float SideslipDiff;
        public string Latitude_aimms_2;
        public string Longitude_aimms_2;
        public float Altitude_aimms_2;
        public float Id2Count;
        public float Time_aimms_2;
        public float Latitude_aimms_3;
        public float Longitude_aimms_3;
        public float Altitude_aimms_3;
        public float GroundSpeed;
        public float GroundTrack;
        public float HFOM;
        public float VFOM;
        public double NavMode;
        public float Satellites;
        public float DatumNumber;
        public string SolConfLevel;
        public string GPSTimeAlign;
        public string NavModeStatus;
        public string Latitude_aimms_4;
        public string Longitude_aimms_4;
        public float Altitude_aimms_4;
        public float Latitude_aimms_5;
        public float Longitude_aimms_5;
        #endregion
       

        public DateTime GetDateTime()
        {
            return this.dateTime;
        }

      
    }

    
}

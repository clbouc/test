using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using WM_Plane_CreateDBImport.Util;

namespace WM_Plane_CreateDBImport.Model
{
    public class Arinc429:ModelCommon
    {
        #region 字段列表
        public DateTime DateTime_arinc429_1;
        public float StaticPSSECorrected;
        public float ImpactPressure;
        public float Altitude_arinc429_1;
        public float BaroCorrectedAltitude;
        public float Mach;
        public float Airspeed;
        public float TrueAirSpeed;
        public float Totaltemp;
        public float StaticTemp;
        public float veritcalSpeed;
        public float magheadingdeg;
        #endregion
        
        public DateTime GetDateTime()
        {
            return this.DateTime_arinc429_1;
        }
    }
}

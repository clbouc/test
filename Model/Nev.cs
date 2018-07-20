using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WM_Plane_KingData.Util;

namespace WM_Plane_KingData.Model
{
    public class Nev:ModelCommon
    {
        #region 字段列表
        public DateTime DateTime_nev_1;
        public float ARINCAltitudeft;
        public float NevTWC;
        public float NevLWC;
        #endregion
        

        public DateTime GetDateTime()
        {
            return this.DateTime_nev_1;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WM_Plane_CreateDBImport.Util;

namespace WM_Plane_CreateDBImport.Model
{
    public class Inletcontroldata:ModelCommon
    {
        #region 字段列表
        public DateTime DateTime_inletcontroldata_1;
        public float tip_flow;
        public float tipfltrg;
        public float airspeed_inletcontroldata_1;
        public float oat_temp;
        public float instflow;
        public float inltpres;
        public float blwrflow;
        public float blwrtarg;
        public float blwr_tmp;
        public float blwr_pwr;
        public float throtpos;
        public float fconetmp;
        public float rconetmp;
        public float pylontmp;
        public float sensrtmp;
        public float fconepwr;
        public float rconepwr;
        public float pylonpwr;
        public float sensrpwr;
        #endregion
        
        public DateTime GetDateTime()
        {
            return this.DateTime_inletcontroldata_1;
        }
    }
}

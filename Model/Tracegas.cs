using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WM_Plane_KingData.Util;

namespace WM_Plane_KingData.Model
{
    public class Tracegas:ModelCommon
    {
        #region 字段列表
        public DateTime DateTime_tracegas_1;
        public DateTime DateTime_tracegas_2;
        public float ARINCAltitudeft_tracegas_1;
        public float ARINCStaticPmb;
        public float RMTStaticC;
        public float DPC;
        public float O3;
        public float NOX;
        public float SO2;
        public float H2O2;
        public float CO;
        public float O3_tracegas_1;
        public float NOX_tracegas_1;
        public float SO2_tracegas_1;
        public float H2O2_tracegas_1;
        public float CO_tracegas_1;
        #endregion
    

        public DateTime GetDateTime()
        {
            return this.DateTime_tracegas_1;
        }
    }
}

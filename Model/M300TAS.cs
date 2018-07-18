using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WM_Plane_CreateDBImport.Util;

namespace WM_Plane_CreateDBImport.Model
{
    public class M300TAS:ModelCommon
    {
        #region 字段列表
        public DateTime DateTime_m300TAS_1;
        public float ARINCTAS;
        #endregion
        
       

        public DateTime GetDateTime()
        {
            return this.DateTime_m300TAS_1;
        }
    }
}

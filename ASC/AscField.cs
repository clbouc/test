using System;
using System.Collections.Generic;

namespace WM_Plane_CreateDBImport
{
    /// <summary>
    /// 针对此项目中的ASC文件产生的此Field类，为了程序解析ASC文件中的字段
    /// </summary>
    public class AscField 
    {
        public String FieldName { get; set; }
        public String Type { get; set; }
        public String Formula { get; set; }
    }
    //public class FieldCompare : IEqualityComparer<AscField>
    //{
    //    public bool Equals(AscField x, AscField y)
    //    {
    //        if (x == null&&y!=null ) return false;
    //        if (y == null&&x!=null) return true;
    //        if (x == null && y == null) return false;
    //        if (x.Formula == y.Formula) {
    //            return true;
    //        }
    //        else
    //        {
    //             return false;
    //        }
    //    }

    //    public int GetHashCode(AscField obj)
    //    {
    //        return obj.Formula.GetHashCode();
    //    }
    //}
}

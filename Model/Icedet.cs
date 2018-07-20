using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WM_Plane_KingData.Util;

namespace WM_Plane_KingData.Model
{
    public class Icedet:ModelCommon
    {
        #region 字段列表
        public DateTime DateTime_icedet_1;
        public string ID_W;
        public double OnTimeCntr;
        public double Power;
        public string PermErr1;
        public string PermErr2;
        public string PermErr3;
        public double TotIceCnt;
        public string ID_X;
        public double MsoFreq;
        public double IceCycCnt;
        public string SigState;
        public string OprState;
        public string BitErr1;
        public string BitErr2;
        public string BitErr3;
        public string ID_Y;
        public double TotFailCnt;
        public double MsoFailCnt;
        public double IceFailCnt;
        public double StaFailCnt;
        public double HtrFailCnt;
        public string ID_Z;
        public string FaultLog1;
        public string FaultLog2;
        public string FaultLog3;
        public string FaultLog4;
        public string FaultLog5;
        public string FaultLog6;
        public string FaultLog7;
        #endregion
        

        public DateTime GetDateTime()
        {
            return this.DateTime_icedet_1;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace WM_Plane_CreateDBImport.DAO
{
    public interface IKingDataDAO
    {
        //通过DateTime选择
        DataTable SelectByDateTime(DateTime dateTime);
        //选择所有
        DataTable SelectAll();
        //分页
        DataTable SelectByLimit(int start,int count);
        //获取记录数
        long getTotal();
        //自定义查询
        DataTable CustomQuery(String sql);
        //通过主键ID查询
        DataTable SelectByID(long id);
    }
}

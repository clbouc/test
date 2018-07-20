using System;
using System.Data;
using WM_Plane_KingData.Common;

namespace WM_Plane_KingData.DAO.DAOImpl
{
    class KingDataDaoImpl : IKingDataDAO
    {
        public DataTable CustomQuery(string sql)
        {
           
            DataTable dataTable = MySqlDatabaseUtil.ExecuteQuery(sql);
            return dataTable;
        }

        public long getTotal()
        {
            String sql = "SELECT COUNT(*) FROM tb_plane_kingdata";
            object data=MySqlDatabaseUtil.ExecuteScalar(sql);
            long val = 0;
            if (long.TryParse(data.ToString(), out val))
            {
                return val;
            }
            else {
                throw new Exception(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")+"Formmater Error in getTotal" );
            }
        }

        //不建议使用
        public DataTable SelectAll()
        {
            String sql = "SELECT * FROM tb_plane_kingdata;";
            DataTable dataTable= MySqlDatabaseUtil.ExecuteQuery(sql);
            return dataTable;
        }

        public DataTable SelectByDateTime(DateTime dateTime)
        {
            String sql = "SELECT * FROM tb_plane_kingdata where `DateTime`=\""+dateTime.ToString("yyyy-MM-dd HH:mm:ss")+"\";";
            DataTable dataTable = MySqlDatabaseUtil.ExecuteQuery(sql);
            return dataTable;
        }

        public DataTable SelectByID(long id)
        {
            String sql = "SELECT * FROM tb_plane_kingdata where `id`="+id ;
            DataTable dataTable = MySqlDatabaseUtil.ExecuteQuery(sql);
            return dataTable;
        }

        public DataTable SelectByLimit(int start, int count)
        {
            String sql =String.Format("SELECT * FROM tb_plane_kingdata LIMIT {0},{1}", start, count);
            
            DataTable dataTable = MySqlDatabaseUtil.ExecuteQuery(sql);
            return dataTable;
        }
    }
}

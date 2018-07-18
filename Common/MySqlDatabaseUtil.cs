using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace WM_Plane_CreateDBImport.Common
{
    //采用singleton模式
    public static class MySqlDatabaseUtil
    {
        private static readonly String dataBaseName;
        private static readonly String ip;
        private static readonly String port;
        private static readonly String url;
        private static readonly String username;
        private static readonly String password;
        private static MySqlConnection connection = null;
        //初始化
        static MySqlDatabaseUtil()
        {
            try
            {
                url=ConfigurationHelper.ReadConfiguration("url")??"127.0.0.1";
                port= ConfigurationHelper.ReadConfiguration("port")??"3306";
                ip= ConfigurationHelper.ReadConfiguration("ip")??"3306";
                dataBaseName= ConfigurationHelper.ReadConfiguration("database")?? "rybdata_plane";
                username= ConfigurationHelper.ReadConfiguration("username")??"root";
                password= ConfigurationHelper.ReadConfiguration("passwrod")??"1234";
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
           
        }
        
        private static MySqlConnection GetConnection()
        {
            if (connection == null)
            {
                String connstr = $"server={url};port={port};database={dataBaseName};user={username};password={password};";
                connection = new MySqlConnection(connstr);
            }

            return connection;
        }
        //返回一个值，默认开启事务
        public static object ExecuteScalar(String sql)
        {
            object result = null;
            MySqlConnection connection = GetConnection();
            MySqlTransaction trans = null;
            try {
                connection.Open();
                trans = connection.BeginTransaction();
                MySqlCommand mySqlCommand = new MySqlCommand(sql, connection);
                result = mySqlCommand.ExecuteScalar();
                trans.Commit();
                
            }catch(MySqlException e)
            {
                Console.WriteLine(e.ErrorCode + " " + e.Message);
            }
            finally
            {
                if (trans != null&&result==null)
                {
                    trans.Rollback();
                }
                trans.Dispose();
                connection.Close();
                connection.Dispose();
            }
            
            return result;
        }
        /// <summary>
        /// 默认开启事务
        /// </summary>
        /// <param name="sql"></param>
        /// <returns>受影响的行数 defalut -1 error</returns>
        public static int ExecuteNoQuery(String sql)
        {
            MySqlConnection connection = GetConnection();
            MySqlTransaction trans = null;
            int result = -1;
            try
            {
                connection.Open();
                trans = connection.BeginTransaction();
                MySqlCommand mySqlCommand = new MySqlCommand(sql, connection);
                result = mySqlCommand.ExecuteNonQuery();
                trans.Commit();

            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.ErrorCode + " " + e.Message);
            }
            finally
            {
                if (trans != null&&result==-1)
                {
                    trans.Rollback();
                }
                trans.Dispose();
                connection.Close();
                connection.Dispose();
            }
            return result;
        }
        //默认开启事务
        public static DataTable ExecuteQuery(String sql)
        {
            MySqlConnection connection = GetConnection();
            MySqlTransaction trans = null;
            DataTable result = null;
            try
            {
                connection.Open();
                trans = connection.BeginTransaction();
                MySqlCommand mySqlCommand = new MySqlCommand(sql, connection);
                IDataReader rdr = mySqlCommand.ExecuteReader();
                result = new DataTable();
                result.Load(rdr);
                trans.Commit();

            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.ErrorCode + " " + e.Message);
            }
            finally
            {
                if (trans != null&&result==null)
                {
                    trans.Rollback();
                }
                trans.Dispose();
                connection.Close();
                connection.Dispose();
            }
            return result;
        }
    }
}

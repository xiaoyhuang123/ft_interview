using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace FTInterviewDAL
{
    /************************************************************************/
    /*      数据库操作工具类                                                               
     * */
    /************************************************************************/
    public class MySqlDBHelper
    {
        //引导数据库连接数据库调用Web.Config文件    
        private static MySqlConnection connection;
        //创建连接
        public static MySqlConnection Connection
        {
            get
            {
                String conn_str = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ToString();
               // MySqlConnection myConn = new MySqlConnection("server=localhost;user id=root;password=root;database=vn_site;CharSet=utf8;");
                MySqlConnection myConn = new MySqlConnection(conn_str);
                string connectionString = myConn.ConnectionString;
                //用意在哪？？？

                if (connection == null)
                {
                    connection = new MySqlConnection(connectionString);
                    //打开连接
                    connection.Open();
                }
                else if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                }
                else if (connection.State == System.Data.ConnectionState.Broken)
                {
                    connection.Close();
                    connection.Open();
                }
                return connection;
            }
        }
        //（无参）返回执行的行数(删除修改更新)
        public static int ExecuteCommand(string safeSql)
        {
            MySqlCommand cmd = new MySqlCommand(safeSql, Connection);
            int result = cmd.ExecuteNonQuery();
            return result;
        }
        //（有参）
        public static int ExecuteCommand(string sql, params MySqlParameter[] values)
        {
            MySqlCommand cmd = new MySqlCommand(sql, Connection);
            cmd.Parameters.AddRange(values);
            return cmd.ExecuteNonQuery();
        }
        //（无参）返回第一行第一列(删除修改更新)
        public static int GetScalar(string safeSql)
        {
            MySqlCommand cmd = new MySqlCommand(safeSql, Connection);
            int result = Convert.ToInt32(cmd.ExecuteScalar());
            return result;
        }
        //（有参）
        public static int GetScalar(string sql, params MySqlParameter[] values)
        {
            MySqlCommand cmd = new MySqlCommand(sql, Connection);
            cmd.Parameters.AddRange(values);
            int result = Convert.ToInt32(cmd.ExecuteScalar());
            return result;
        }
        //返回一个DataReader（查询）
        public static MySqlDataReader GetReader(string safeSql)
        {
            MySqlCommand cmd = new MySqlCommand(safeSql, Connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }
        public static MySqlDataReader GetReader(string sql, params MySqlParameter[] values)
        {
            MySqlCommand cmd = new MySqlCommand(sql, Connection);
            cmd.Parameters.AddRange(values);
            MySqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }

        //返回一个DataTable
        public static DataTable GetDataSet(string safeSql)
        {
            DataSet ds = new DataSet();
            MySqlCommand cmd = new MySqlCommand(safeSql, Connection);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(ds);
            return ds.Tables[0];
        }
        public static DataTable GetDataSet(string sql, params MySqlParameter[] values)
        {
            DataSet ds = new DataSet();
            MySqlCommand cmd = new MySqlCommand(sql, Connection);
            cmd.Parameters.AddRange(values);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(ds);
            return ds.Tables[0];
        }
    }
}
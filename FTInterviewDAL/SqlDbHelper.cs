using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data.Common;
using System.Data;
using System.Collections.Generic.Dictionary;

namespace FTRailwayDAL
{
    public static class SqlDbHelper
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["DbHelperConnectionString"].ConnectionString.ToString();
        private static readonly string providerName = "System.Data.SqlClient";
        ///
        /// GetConnection 用于获取连接数据库的 connection 对象
        ///
        ///
        private static DbConnection GetConnection()
        {
            DbProviderFactory _factory = DbProviderFactories.GetFactory(providerName);
            DbConnection connection = _factory.CreateConnection();
            connection.ConnectionString = connectionString;
            return connection;
        }
        ///
        /// GetCommand 获取命令参数 command 对象
        ///
        ///
        ///
        ///
        ///
        private static DbCommand GetCommand(string commandText, CommandType commandType, DbConnection connection)
        {
            DbCommand command = connection.CreateCommand();
            command.CommandText = commandText;
            command.CommandType = commandType;
            return command;
        }
        ///
        /// GetCommand 方法重载
        ///
        /// sql语句
        ///
        ///
        private static DbCommand GetCommand(string commandText, DbConnection connection)
        {
            DbCommand command = connection.CreateCommand();
            command.CommandText = commandText;
            command.CommandType = CommandType.Text;
            return command;
        }
        ///
        /// GetParameter 用于为命令设置参数
        ///
        ///
        ///
        ///
        ///
        private static DbParameter GetParameter(string paramName, object paramValue, DbCommand command)
        {
            DbParameter parameter = command.CreateParameter();
            parameter.ParameterName = paramName;
            parameter.Value = paramValue;
            return parameter;
        }
        ///
        /// 执行无参的存储过程
        ///
        /// 存储过程名
        ///
        public static int ExecuteNonQueryProc(string sqlCommand)
        {
            int result = 0;
            using (DbConnection connection = GetConnection())
            {
                DbCommand command = GetCommand(sqlCommand, CommandType.StoredProcedure, connection);
                connection.Open();
                result = command.ExecuteNonQuery();
                command.Parameters.Clear();
            }
            return result;
        }
        ///
        /// 执行无返回值有参数的存储过程
        ///
        /// 存储过程名
        /// 参数
        ///
        public static int ExecuteNonQueryProc(string sqlCommand, Dictionary parameters)
        {
            int result = 0;
            using (DbConnection connection = GetConnection())
            {
                DbCommand command = GetCommand(sqlCommand, CommandType.StoredProcedure, connection);
                foreach (KeyValuePair p in parameters)
                {
                    command.Parameters.Add(GetParameter(p.Key, p.Value, command));
                }
                connection.Open();
                result = command.ExecuteNonQuery();
                command.Parameters.Clear();
            }
            return result;
        }

        ///
        /// 执行无返回值的sql语句
        ///
        ///
        ///
        public static int ExecuteNonQuery(string sqlCommand)
        {
            int result = 0;
            using (DbConnection connection = GetConnection())
            {
                DbCommand command = GetCommand(sqlCommand, CommandType.Text, connection);
                connection.Open();
                result = command.ExecuteNonQuery();
                command.Parameters.Clear();
                return result;
            }
        }
        ///
        /// 执行有参数的sql语句
        ///
        ///
        ///
        ///
        public static int ExecuteNonQuery(string sqlCommand, Dictionary para)
        {
            int result = 0;
            using (DbConnection connection = GetConnection())
            {
                DbCommand command = GetCommand(sqlCommand, CommandType.Text, connection);
                foreach (KeyValuePair p in para)
                {
                    command.Parameters.Add(GetParameter(p.Key, p.Value, command));
                }
                connection.Open();
                result = command.ExecuteNonQuery();
                command.Parameters.Clear();
                return result;
            }
        }
        ///
        /// 执行有返回值无参数的存储过程
        ///
        ///
        ///
        public static object ExecuteScalarProc(string cmdText)
        {
            using (DbConnection connection = GetConnection())
            {
                DbCommand command = GetCommand(cmdText, CommandType.StoredProcedure, connection);
                connection.Open();
                object val = command.ExecuteScalar();
                command.Parameters.Clear();
                return val;
            }
        }
        ///
        /// 执行有返回值的有参数的存储过程
        ///
        /// 存储过程名
        /// 参数
        ///
        public static object ExecuteScalarProc(string cmdText, Dictionary para)
        {
            using (DbConnection connection = GetConnection())
            {
                DbCommand command = GetCommand(cmdText, CommandType.StoredProcedure, connection);
                foreach (KeyValuePair p in para)
                {
                    command.Parameters.Add(GetParameter(p.Key, p.Value, command));
                }
                connection.Open();
                object val = command.ExecuteScalar();
                command.Parameters.Clear();
                return val;
            }
        }
        ///
        /// 执行有返回值的sql语句
        ///
        ///
        ///
        public static object ExecuteScalar(string cmdText)
        {
            using (DbConnection connection = GetConnection())
            {
                DbCommand command = GetCommand(cmdText, CommandType.Text, connection);
                connection.Open();
                object val = command.ExecuteScalar();
                command.Parameters.Clear();
                return val;
            }
        }
        ///
        /// 执行有返回值有参数的sql语句
        ///
        ///
        ///
        ///
        public static object ExecuteScalar(string cmdText, Dictionary para)
        {
            using (DbConnection connection = GetConnection())
            {
                DbCommand command = GetCommand(cmdText, CommandType.Text, connection);
                foreach (KeyValuePair p in para)
                {
                    command.Parameters.Add(GetParameter(p.Key, p.Value, command));
                }
                connection.Open();
                object val = command.ExecuteScalar();
                command.Parameters.Clear();
                return val;
            }
        }
        ///
        /// 执行无参数的存储过程,返回DbDataReader对象
        ///
        /// 存储过程名
        ///
        public static DbDataReader GetReaderProc(string sqlCommand)
        {
            try
            {
                DbConnection connection = GetConnection();
                DbCommand command = GetCommand(sqlCommand, CommandType.StoredProcedure, connection);
                connection.Open();
                DbDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                return reader;
            }
            catch (Exception ex)
            {
                Console.Write("" + ex.Message);
                return null;
            }
        }
        ///
        /// 执行有参数的存储过程,返回DbDataReader对象
        ///
        ///
        ///
        ///
        public static DbDataReader GetReaderProc(string sqlCommand, Dictionary parameters)
        {
            try
            {
                DbConnection connection = GetConnection();
                DbCommand command = GetCommand(sqlCommand, CommandType.StoredProcedure, connection);
                foreach (KeyValuePair p in parameters)
                {
                    command.Parameters.Add(GetParameter(p.Key, p.Value, command));
                }
                connection.Open();
                DbDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                command.Parameters.Clear();
                return reader;
            }
            catch
            {
                return null;
            }
        }
        #region
        ///
        /// 执行无参数的sql语句,返回DbDataReader对象
        ///
        ///
        ///
        public static DbDataReader GetReader(string sqlCommand)
        {
            try
            {
                DbConnection connection = GetConnection();
                DbCommand command = GetCommand(sqlCommand, CommandType.Text, connection);
                connection.Open();
                DbDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                command.Parameters.Clear();
                return reader;
            }
            catch (Exception ex)
            {
                Console.Write("" + ex.Message);
                return null;
            }
        }
        #endregion
        ///
        /// 执行有参数的sql语句,返回DbDataReader对象
        ///
        ///
        ///
        ///
        public static DbDataReader GetReader(string sqlCommand, Dictionary parameters)
        {
            try
            {
                DbConnection connection = GetConnection();
                DbCommand command = GetCommand(sqlCommand, CommandType.Text, connection);
                foreach (KeyValuePair p in parameters)
                {
                    command.Parameters.Add(GetParameter(p.Key, p.Value, command));
                }
                connection.Open();
                DbDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                command.Parameters.Clear();
                return reader;
            }
            catch (Exception ex)
            {
                Console.Write("" + ex.Message);
                return null;
            }
        }
        ///
        /// 返回DataTable对象
        ///
        ///
        ///
        public static DataTable GetDataSet(string safeSql)
        {

            using (DbConnection connection = GetConnection())
            {
                DbProviderFactory _factory = DbProviderFactories.GetFactory(providerName);
                DbCommand command = GetCommand(safeSql, CommandType.Text, connection);
                connection.Open();
                DbDataAdapter da = _factory.CreateDataAdapter();
                da.SelectCommand = command;
                DataTable datatable = new DataTable();
                da.Fill(datatable);
                return datatable;
            }
        }
    }
}
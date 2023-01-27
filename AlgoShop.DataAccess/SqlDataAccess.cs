using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AlgoShop.DataAccess
{
    public class SqlDataAccess
    {    

        private SqlConnection? _conn=null;
        private static SqlDataAccess? _dataAccess;
        private static string _connectionString = string.Empty;
        public static string SetConnectionString(string connectionString)
        {
          
                if (_connectionString == string.Empty)
                {
                    _connectionString = connectionString;
                }
                return _connectionString;
            
        }

        public static SqlDataAccess GetSqlDataAccess()
        {
            if (_dataAccess == null)
                _dataAccess = new SqlDataAccess();
            return _dataAccess;
        }

        public SqlConnection GetConnection()
        {
            if (_conn == null)
                _conn = new SqlConnection(_connectionString);
            return _conn;
            
        }

        public  SqlCommand GetCommand(string sql)
        {
            GetConnection();
            SqlCommand sqlCmd = new SqlCommand(sql, _conn);
            return sqlCmd;
        }


        public DataTable Execute(string sql)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = GetCommand(sql);
            cmd.Connection.Open();
            dt.Load(cmd.ExecuteReader());
            cmd.Connection.Close();
            return dt;
        }


        public DataTable Execute(SqlCommand command)
        {
            DataTable dt = new DataTable();
            command.Connection.Open();
            //command.ExecuteNonQuery();
            dt.Load(command.ExecuteReader());
            command.Connection.Close();
            return dt;
        }

        public int ExecuteNonQuery(string sql)
        {
            SqlCommand cmd = GetCommand(sql);
            cmd.Connection.Open();
            int result = cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            return result;
        }

        public int ExecuteNonQuery(SqlCommand command)
        {
            command.Connection.Open();
            int result = command.ExecuteNonQuery();
            command.Connection.Close();
            return result;
        }

        public int ExecuteStoredProcedure(string spName)
        {
            SqlCommand cmd = GetCommand(spName);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection.Open();
            int result = cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            return result;
        }

        public int ExecuteStoredProcedure(SqlCommand command,SqlParameterCollection sqlParameterCollection)
        {
            command.CommandType = CommandType.StoredProcedure;
            command.Connection.Open();
            int result = command.ExecuteNonQuery();
            command.Connection.Close();
            return result;
        }

    }
}

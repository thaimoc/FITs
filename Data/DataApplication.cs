using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public static class DataApplication
    {
        [ThreadStatic]
        private static IDbConnection connection;

        public static string ConnectionStringName
        {
            get
            {
                return string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["ConnectionStringName"]) 
                    ? ConfigurationManager.AppSettings["ConnectionStringName"]
                    : "DataConnectionString";
            }
        }

        public static string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings[ConnectionStringName].ConnectionString;
            }
        }

        public static IDbConnection OpenConnection()
        {
            if (connection == null)
            {
                connection = new SqlConnection(ConnectionString);
            }
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            return connection;
        }

        public static void CloseConnection()
        {
            if (connection != null && connection.State == ConnectionState.Open)
            {
                connection.Close();
                connection.Dispose();
                connection = null;
            }
        }

    }
}

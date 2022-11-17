using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;

namespace CCESymp.Data
{
    public static partial class DataRepository
    {
        /// <summary>
        /// Create the connection string to connect to DB
        /// </summary>
        /// <returns></returns>
        public static string BuildConnectionString()
        {
            // RR: Replaced with connection string built from current system & ENV variables
            //string connString = string.Format("Data Source={0}; Initial Catalog={1};Integrated security=false;Persist Security Info=true;User Id={2}; Password={3};", Common.Common.JIT_SQl_Instance, Common.Common.JIT_SQL_DBName, Common.Common.JIT_SQL_UName, Common.Common.JIT_SQL_PW);
            string connString = $"Data Source=tcp:{Common.Common.CCESymp_SQLServer_Dashboard};Initial Catalog={Common.Common.CCESymp_SQLDB_Dashboard};Persist Security Info=False;User ID={Common.Common.CCESymp_SQL_UName};Password={Common.Common.CCESymp_SQL_PW};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
            return connString;
        }



        public static List<T> Query<T>(string connString, string sqlFile, object parameters = null)
        {
            if (Common.Common.waitBeforeDeleteSessions.Equals("Wait"))
            {
                Thread.Sleep(5000);
            }
            var connection = new SqlConnection(connString);
            connection.Open();
            string sql = GetQuery(sqlFile);
            var results = connection.Query<T>(sql, parameters).ToList();
            connection.Close();
            return results;
        }

        public static List<T> ExecuteQuery<T>(string sqlQuery, object parameters = null)
        {
            var connection = new SqlConnection(BuildConnectionString());
            connection.Open();
            var results = connection.Query<T>(sqlQuery, parameters).ToList();
            connection.Close();
            return results;
        }

        /// <summary>
        /// Get the query of an sql file
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string GetQuery(string fileName)
        {
            string directoryRoot = Path.GetDirectoryName((new Uri(Assembly.GetExecutingAssembly().CodeBase)).LocalPath);
            string fileLocation = string.Format("{0}\\DBScripts\\", directoryRoot);
            string result = File.ReadAllText(string.Format("{0}\\{1}", fileLocation, fileName));
            return result;
        }
    }
}

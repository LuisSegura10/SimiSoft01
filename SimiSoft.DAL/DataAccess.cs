using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimiSoft.DAL
{
    public class DataAccces
    {
        #region Singleton
        private static volatile DataAccces instance = null;
        private static readonly object padlock = new object();
        private static string conString = "Server=LUIS10;Database=SimiDB;User Id = Segurilla; Password= 123";

        private DataAccces() { }

        public static DataAccces Instance()
        {
            if (instance == null)
                lock (padlock)
                    if (instance == null)
                        instance = new DataAccces();
            return instance;
        }
        #endregion

        #region Query/Execute Dapper

        public T QuerySingle<T>(string query)
        {
            using (var con = new SqlConnection(conString))
                return con.QuerySingle<T>(query, commandType: CommandType.StoredProcedure, commandTimeout: 300);
        }

        public T QuerySingle<T>(string query, DynamicParameters dynamicParameters)
        {
            using (var con = new SqlConnection(conString))
                return con.QuerySingle<T>(query, dynamicParameters, commandType: CommandType.StoredProcedure, commandTimeout: 300);
        }

        public T QuerySingleOrDefault<T>(string query)
        {
            using (var con = new SqlConnection(conString))
                return con.QuerySingleOrDefault<T>(query, commandType: CommandType.StoredProcedure, commandTimeout: 300);
        }

        public T QuerySingleOrDefault<T>(string query, DynamicParameters dynamicParameters)
        {
            using (var con = new SqlConnection(conString))
                return con.QuerySingleOrDefault<T>(query, dynamicParameters, commandType: CommandType.StoredProcedure, commandTimeout: 300);
        }

        public string QuerySingle(string query)
        {
            using (var con = new SqlConnection(conString))
                return con.QuerySingle(query, commandType: CommandType.StoredProcedure, commandTimeout: 300);
        }

        public string QuerySingle(string query, DynamicParameters dynamicParameters)
        {
            using (var con = new SqlConnection(conString))
                return con.QuerySingle(query, dynamicParameters, commandType: CommandType.StoredProcedure, commandTimeout: 300);
        }

        public List<T> Query<T>(string query)
        {
            using (var con = new SqlConnection(conString))
                return (List<T>)con.Query<T>(query, commandType: CommandType.StoredProcedure, commandTimeout: 300);
        }

        public List<T> Query<T>(string query, DynamicParameters dynamicParameters)
        {
            using (var con = new SqlConnection(conString))
                return (List<T>)con.Query<T>(query, dynamicParameters, commandType: CommandType.StoredProcedure, commandTimeout: 300);
        }

        public int Insert(string query, DynamicParameters dynamicParameters, string fieldName)
        {
            using (var con = new SqlConnection(conString))
                return (int)((Dictionary<string, object>) con.QuerySingle(query, dynamicParameters, commandType: CommandType.StoredProcedure, commandTimeout: 300))[fieldName];
        }

        public int Execute(string query)
        {
            using (var con = new SqlConnection(conString))
                return con.Execute(query, commandType: CommandType.StoredProcedure, commandTimeout: 300);
        }

        public int Execute(string query, DynamicParameters dynamicParameters)
        {
            using (var con = new SqlConnection(conString))
                return con.Execute(query, dynamicParameters, commandType: CommandType.StoredProcedure, commandTimeout: 300);
        }
        #endregion
    }
}

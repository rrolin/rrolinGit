using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace WebApi_Data.Class
{
    public class Data
    {
        /// <summary>
        /// Returns a DataTable filled with data from given entity.
        /// </summary>
        /// <param name="connectionString">Connection String</param>
        /// <param name="entityName">Entity Name</param>
        /// <param name="searchId">Search Id</param>
        /// <returns>DataTable</returns>
        public static DataTable getData(string connectionString, string entityName, int searchId)
        {
            
        }
        public static bool insertSql(string connectionString, string entityName)
        {
            
        }

        public static bool updateSql()
        {

            return true;
        }

        public static bool deleteSql()
        {
            return true;
        }
    }
}

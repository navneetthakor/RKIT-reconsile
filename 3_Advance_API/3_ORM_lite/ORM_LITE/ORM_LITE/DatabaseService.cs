using MySql.Data.MySqlClient;
using MySqlConnector;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_LITE.Models
{
    internal class DatabaseService
    {
        private static string connectionString = "Server=localhost;Database=nk_ormlite_demo;User=Admin;Password=gs@123;";
        public static IDbConnection GetDbConnection()
        {
            var dbFactory = new OrmLiteConnectionFactory(connectionString, MySqlDialect.Provider);
            return dbFactory.OpenDbConnection();
        }
    }
}

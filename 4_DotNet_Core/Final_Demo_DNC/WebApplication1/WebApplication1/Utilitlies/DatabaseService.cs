using MySql.Data.MySqlClient;
using MySqlConnector;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Demo_AvanceCSharp.Utilitlies
{
    internal class DatabaseService : IDatabaseService
    {
        private string connectionString { get; } = "Server=localhost;Database=nk_advanceCS_full_demo;User=Admin;Password=gs@123;";
        public IDbConnection db { get; set; }
        public DatabaseService()
        {
            var dbFactory = new OrmLiteConnectionFactory(connectionString, MySqlDialect.Provider);
            db = dbFactory.OpenDbConnection();
        }
    }
}

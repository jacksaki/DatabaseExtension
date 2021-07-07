using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseExtension;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace DatabaseExtension.MySQL {
    public class MySQLQuery : DbQueryBase {
        private static string _connectionString;
        public MySQLQuery(string connectionString) : base(connectionString) {
        }
        public MySQLQuery() : base(_connectionString) {
        }
        public static void SetConnectionString(string value) {
            using (var conn = new MySqlConnection(value)) {
                conn.Open();
                _connectionString = value;
            }
        }
        protected override IDbConnection GenerateConnection(string connectionString) {
            return new MySqlConnection(connectionString);
        }
        protected override IDbDataParameter CreateParameter(string name, object value) {
            return new MySqlParameter(name, value);
        }
    }
}
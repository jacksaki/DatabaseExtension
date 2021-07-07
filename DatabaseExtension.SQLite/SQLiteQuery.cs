using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseExtension;
using System.Data;

using Microsoft.Data.Sqlite;
namespace DatabaseExtension.SQLite {
    public class SQLiteQuery : DbQueryBase {
        private static string _connectionString;
        public SQLiteQuery(string connectionString) : base(connectionString) {
        }
        public SQLiteQuery() : base(_connectionString) {
        }

        public static void SetConnectionString(string value) {
            using (var conn = new SqliteConnection(value)) {
                conn.Open();
                _connectionString = value;
            }
        }
        protected override IDbConnection GenerateConnection(string connectionString) {
            return new SqliteConnection(connectionString);
        }
        protected override IDbDataParameter CreateParameter(string name, object value) {
            return new SqliteParameter(name, value);
        }

    }
}
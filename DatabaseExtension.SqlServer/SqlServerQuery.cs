using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseExtension;
using System.Data;
using System.Data.SqlClient;
namespace DatabaseExtension.SqlServer {
    public class SqlServerQuery : DbQueryBase {
        private static string _connectionString;
        public SqlServerQuery(string connectionString) : base(connectionString) {
        }
        public SqlServerQuery() : base(_connectionString) {
        }
        public static void SetConnectionString(string value) {
            using (var conn = new SqlConnection(value)) {
                conn.Open();
                _connectionString = value;
            }
        }
        protected override IDbConnection GenerateConnection(string connectionString) {
            return new SqlConnection(connectionString);
        }
        protected override IDbDataParameter CreateParameter(string name, object value) {
            return new SqlParameter(name, value);
        }
    }
}
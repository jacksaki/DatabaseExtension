using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DatabaseExtension.SampleApp.Models {
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Job {
        [JsonPropertyName("Clerk")]
        Clerk,
        [JsonPropertyName("Salesman")]
        Salesman,
        [JsonPropertyName("Manager")]
        Manager,
        [JsonPropertyName("President")]
        President,
        [JsonPropertyName("Analyst")]
        Analyst,
    }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Department {
        [JsonPropertyName("Accounting")]
        Accounting = 10,
        [JsonPropertyName("Research")]
        Research = 20,
        [JsonPropertyName("Sales")]
        Sales = 30,
        [JsonPropertyName("Operations")]
        Operations = 40,
    }
    public class Employee {
        [DbColumn("EMPNO")]
        public int Cd {
            get;
            private set;
        }
        [DbColumn("ENAME")]
        public string Name {
            get;
            private set;
        }
        [DbColumn("JOB")]
        public Job Job {
            get;
            private set;
        }
        [DbColumn("MGR")]
        public int? ManagerCd {
            get;
            private set;
        }
        [DbColumn("HIREDATE", "yyyyMMdd")]
        public DateTime HireDate {
            get;
            private set;
        }
        [DbColumn("SAL")]
        public int Salary {
            get;
            private set;
        }
        [DbColumn("COMM")]
        public int? Commission {
            get;
            private set;
        }
        [DbColumn("DEPTNO")]
        public Department Department {
            get;
            private set;
        }
        public static IEnumerable<Employee> GetAll(IDbQuery query) {
            var sb = new System.Text.StringBuilder();
            sb.AppendLine("SELECT");
            sb.AppendLine(" EMPNO");
            sb.AppendLine(",ENAME");
            sb.AppendLine(",JOB");
            sb.AppendLine(",MGR");
            sb.AppendLine(",HIREDATE");
            sb.AppendLine(",SAL");
            sb.AppendLine(",COMM");
            sb.AppendLine(",DEPTNO");
            sb.AppendLine("FROM");
            sb.AppendLine(" emp");
            return query.GetSqlResult(sb.ToString(), null).Rows.Select(x => x.Create<Employee>());
        }
    }
}

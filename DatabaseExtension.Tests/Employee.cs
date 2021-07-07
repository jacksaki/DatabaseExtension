using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseExtension.Tests {
    public enum Job {
        Clerk,
        Salesman,
        Manager,
        President,
        Analyst,
    }
    public enum Department {
        Accounting = 10,
        Research = 20,
        Sales = 30,
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
        [DbColumn("HIREDATE","yyyyMMdd")]
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
    }
}

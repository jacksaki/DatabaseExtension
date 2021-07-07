# DatabaseExtension


### SQLite (MySQL,PostgreSQL,SQLServer)
``` CSharp
   // Init ConnectionString
   SQLiteQuery.SetConnectionString("Data Source=xxx.db;");
   
   // Select Statement
   var employees = new SQLiteQuery().GetSqlResult("SELECT * FROM emp",null).Rows.Select(x => x.Create<Employee>());
   
   // Select Statement(Single Row)
   var smith = new SQLiteQuery().GetFirstRow("SELECT * FROM emp WHERE EMPNO = @EMPNO",new Dictionary<string,object> {
       { "EMPNO" ,7369 }
       })?.Create<Employee>();
       
   // DML Statement
   using(var q = new SQLiteQuery()) 
   using(var trans = q.BeginTransaction()) {
       try {
           q.ExecuteNonQuery("UPDATE emp SET COMM = NULL WHERE EMPNO = @EMPNO" ,new Dictionary<string,object> {
               { "EMPNO" ,7369 }
           });
           trans.Commit();
       } catch {
           trans.Rollback();
           throw;
       }
   }
```

### Oracle
``` CSharp
   // Init ConnectionString
   OracleQuery.SetConnectionString("Data Source=xxx;User Id=xxx;Password=xxx;");
   
   // Select Statement
   // Set FetchSize for performance.
   var employees = new OracleQuery().GetSqlResult("SELECT * FROM emp",null,100).Rows.Select(x => x.Create<Employee>());
  
```

### Employee.cs
``` CSharp:Employee.cs
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
        // if DbType is not DateTime and PropertyType is DateTime, Set DateFormat
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
    }
```



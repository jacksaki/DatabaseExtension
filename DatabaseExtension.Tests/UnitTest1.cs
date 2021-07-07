using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System;
using DatabaseExtension.SQLite;
namespace DatabaseExtension.Tests {
    public class Tests {
        [SetUp]
        public void Setup() {
            SQLite.SQLiteQuery.SetConnectionString("Data Source=scott.db;");
        }

        [Test]
        public void Test1() {
            var employees = new SQLiteQuery().GetSqlResult("SELECT * FROM EMP", null, 100).Rows.Select(x => x.Create<Employee>()).OrderBy(x => x.Cd).ToArray();

            var smith = employees.Where(x => x.Cd == 7369).FirstOrDefault();
            Assert.AreEqual(smith.Name, "SMITH");
            Assert.AreEqual(smith.Job, Job.Clerk);
            Assert.AreEqual(smith.ManagerCd, 7902);
            Assert.AreEqual(smith.HireDate, new DateTime(1980, 12, 17));
            Assert.AreEqual(smith.Salary, 800);
            Assert.AreEqual(smith.Commission, null);
            Assert.AreEqual(smith.Department, Department.Research);

            var allen = employees.Where(x => x.Cd == 7499).FirstOrDefault();
            Assert.AreEqual(allen.Name, "ALLEN");
            Assert.AreEqual(allen.Job, Job.Salesman);
            Assert.AreEqual(allen.ManagerCd, 7698);
            Assert.AreEqual(allen.HireDate, new DateTime(1981, 2, 20));
            Assert.AreEqual(allen.Salary, 1600);
            Assert.AreEqual(allen.Commission, 300);
            Assert.AreEqual(allen.Department, Department.Sales);


            var ward = employees.Where(x => x.Cd == 7521).FirstOrDefault();
            Assert.AreEqual(ward.Name, "WARD");
            Assert.AreEqual(ward.Job, Job.Salesman);
            Assert.AreEqual(ward.ManagerCd, 7698);
            Assert.AreEqual(ward.HireDate, new DateTime(1981, 2, 22));
            Assert.AreEqual(ward.Salary, 1250);
            Assert.AreEqual(ward.Commission, 500);
            Assert.AreEqual(ward.Department, Department.Sales);

            var jones = employees.Where(x => x.Cd == 7566).FirstOrDefault();
            Assert.AreEqual(jones.Name, "JONES");
            Assert.AreEqual(jones.Job, Job.Manager);
            Assert.AreEqual(jones.ManagerCd, 7839);
            Assert.AreEqual(jones.HireDate, new DateTime(1981, 4, 2));
            Assert.AreEqual(jones.Salary, 2975);
            Assert.AreEqual(jones.Commission, null);
            Assert.AreEqual(jones.Department, Department.Research);

            var martin = employees.Where(x => x.Cd == 7654).FirstOrDefault();
            Assert.AreEqual(martin.Name, "MARTIN");
            Assert.AreEqual(martin.Job, Job.Salesman);
            Assert.AreEqual(martin.ManagerCd, 7698);
            Assert.AreEqual(martin.HireDate, new DateTime(1981, 9, 28));
            Assert.AreEqual(martin.Salary, 1250);
            Assert.AreEqual(martin.Commission, 1400);
            Assert.AreEqual(martin.Department, Department.Sales);

            var blake = employees.Where(x => x.Cd == 7698).FirstOrDefault();
            Assert.AreEqual(blake.Name, "BLAKE");
            Assert.AreEqual(blake.Job, Job.Manager);
            Assert.AreEqual(blake.ManagerCd, 7839);
            Assert.AreEqual(blake.HireDate, new DateTime(1981, 5, 1));
            Assert.AreEqual(blake.Salary, 2850);
            Assert.AreEqual(blake.Commission, null);
            Assert.AreEqual(blake.Department, Department.Sales);

            var clark = employees.Where(x => x.Cd == 7782).FirstOrDefault();
            Assert.AreEqual(clark.Name, "CLARK");
            Assert.AreEqual(clark.Job, Job.Manager);
            Assert.AreEqual(clark.ManagerCd, 7839);
            Assert.AreEqual(clark.HireDate, new DateTime(1981, 6, 9));
            Assert.AreEqual(clark.Salary, 2450);
            Assert.AreEqual(clark.Commission, null);
            Assert.AreEqual(clark.Department, Department.Accounting);

            var king = employees.Where(x => x.Cd == 7839).FirstOrDefault();
            Assert.AreEqual(king.Name, "KING");
            Assert.AreEqual(king.Job, Job.President);
            Assert.AreEqual(king.ManagerCd, null);
            Assert.AreEqual(king.HireDate, new DateTime(1981, 11, 17));
            Assert.AreEqual(king.Salary, 5000);
            Assert.AreEqual(king.Commission, null);
            Assert.AreEqual(king.Department, Department.Accounting);

            var turner = employees.Where(x => x.Cd == 7844).FirstOrDefault();
            Assert.AreEqual(turner.Name, "TURNER");
            Assert.AreEqual(turner.Job, Job.Salesman);
            Assert.AreEqual(turner.ManagerCd, 7698);
            Assert.AreEqual(turner.HireDate, new DateTime(1981, 9, 8));
            Assert.AreEqual(turner.Salary, 1500);
            Assert.AreEqual(turner.Commission, 0);
            Assert.AreEqual(turner.Department, Department.Sales);

            var james = employees.Where(x => x.Cd == 7900).FirstOrDefault();
            Assert.AreEqual(james.Name, "JAMES");
            Assert.AreEqual(james.Job, Job.Clerk);
            Assert.AreEqual(james.ManagerCd, 7698);
            Assert.AreEqual(james.HireDate, new DateTime(1981, 12, 3));
            Assert.AreEqual(james.Salary, 950);
            Assert.AreEqual(james.Commission, null);
            Assert.AreEqual(james.Department, Department.Sales);

            var ford = employees.Where(x => x.Cd == 7902).FirstOrDefault();
            Assert.AreEqual(ford.Name, "FORD");
            Assert.AreEqual(ford.Job, Job.Analyst);
            Assert.AreEqual(ford.ManagerCd, 7566);
            Assert.AreEqual(ford.HireDate, new DateTime(1981, 12, 3));
            Assert.AreEqual(ford.Salary, 3000);
            Assert.AreEqual(ford.Commission, null);
            Assert.AreEqual(ford.Department, Department.Research);

            var miller = employees.Where(x => x.Cd == 7934).FirstOrDefault();
            Assert.AreEqual(miller.Name, "MILLER");
            Assert.AreEqual(miller.Job, Job.Clerk);
            Assert.AreEqual(miller.ManagerCd, 7782);
            Assert.AreEqual(miller.HireDate, new DateTime(1982, 1, 23));
            Assert.AreEqual(miller.Salary, 1300);
            Assert.AreEqual(miller.Commission, null);
            Assert.AreEqual(miller.Department, Department.Accounting);

            Assert.Pass();
        }
    }
}
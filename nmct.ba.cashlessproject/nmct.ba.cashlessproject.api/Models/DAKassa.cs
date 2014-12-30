using models;
using nmct.ba.cashlessproject.api.Helper;
using nmct.ba.cashlessproject.model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace nmct.ba.cashlessproject.api.Models
{
    public class DAKassa
    {
        const string CONNECTIONSTRING = "KlantDB";

        private static ConnectionStringSettings CreateConnectionString(IEnumerable<Claim> claims)
        {
            string dblogin = claims.FirstOrDefault(c => c.Type == "dblogin").Value;
            string dbpass = claims.FirstOrDefault(c => c.Type == "dbpass").Value;
            string dbname = claims.FirstOrDefault(c => c.Type == "dbname").Value;

            return Database.CreateConnectionString("System.Data.SqlClient", @"LAPTOPRUBEN", dbname, dblogin, Crypto.Decrypt(dbpass));
        }

        public static List<Kassa> GetKassas(IEnumerable<Claim> claims)
        {
            string sql = "SELECT ID, RegisterName, Device FROM Register";
            DbDataReader r = Database.GetData(Database.GetConnection(CreateConnectionString(claims)), sql);

            List<Kassa> list = new List<Kassa>();

            while (r.Read())
            {
                list.Add(new Kassa()
                {
                    ID = Int32.Parse(r[0].ToString()),
                    RegisterName = r[1].ToString(),
                    Device = r[2].ToString()
                });
            }

            r.Close();

            return list;
        }

        public static List<Employee> GetEmployeesByRegister(int id, IEnumerable<Claim> claims)
        {
            string sql = "SELECT Employee.ID, EmployeeName, Address, Email, Phone, Visible FROM Register_Employee INNER JOIN Employee ON EmployeeID = Employee.ID WHERE RegisterID = @id";
            DbParameter p0 = Database.AddParameter(CONNECTIONSTRING, "@id", id);
            DbDataReader r = Database.GetData(Database.GetConnection(CreateConnectionString(claims)), sql, p0);
            List<Employee> list = new List<Employee>();

            while (r.Read())
            {
                list.Add(new Employee()
                {
                    ID = Int32.Parse(r[0].ToString()),
                    EmployeeName = r[1].ToString(),
                    Address = r[2].ToString(),
                    Email = r[3].ToString(),
                    Phone = r[4].ToString()
                });
            }

            r.Close();

            return list;
        }
    }
}
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
    public class DAMedewerker
    {
        const string CONNECTIONSTRING = "KlantDB";

        private static ConnectionStringSettings CreateConnectionString(IEnumerable<Claim> claims)
        {
            string dblogin = claims.FirstOrDefault(c => c.Type == "dblogin").Value;
            string dbpass = claims.FirstOrDefault(c => c.Type == "dbpass").Value;
            string dbname = claims.FirstOrDefault(c => c.Type == "dbname").Value;

            return Database.CreateConnectionString("System.Data.SqlClient", @"LAPTOPRUBEN", dbname, dblogin, Crypto.Decrypt(dbpass));
        }

        public static List<Employee> GetEmployees(IEnumerable<Claim> claims)
        {
            string sql = "SELECT ID, EmployeeName, Address, Email, Phone FROM Employee WHERE Visible = 1";
            DbDataReader r = Database.GetData(Database.GetConnection(CreateConnectionString(claims)), sql);

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

        public static int Insert(Employee e, IEnumerable<Claim> claims)
        {
            string sql = "INSERT INTO Employee VALUES(@EmployeeName, @Address, @Email, @Phone, 1)";

            DbParameter par1 = Database.AddParameter(CONNECTIONSTRING, "@EmployeeName", e.EmployeeName);
            DbParameter par2 = Database.AddParameter(CONNECTIONSTRING, "@Address", e.Address);
            DbParameter par3 = Database.AddParameter(CONNECTIONSTRING, "@Email", e.Email);
            DbParameter par4 = Database.AddParameter(CONNECTIONSTRING, "@Phone", e.Phone);

            return Database.InsertData(Database.GetConnection(CreateConnectionString(claims)), sql, par1, par2, par3, par4);
        }

        public static void Update(Employee e, IEnumerable<Claim> claims)
        {
            string sql = "UPDATE Employee SET EmployeeName=@EmployeeName, Address=@Address, Email=@Email, Phone=@Phone WHERE ID=@ID";

            DbParameter par1 = Database.AddParameter(CONNECTIONSTRING, "@EmployeeName", e.EmployeeName);
            DbParameter par2 = Database.AddParameter(CONNECTIONSTRING, "@Address", e.Address);
            DbParameter par3 = Database.AddParameter(CONNECTIONSTRING, "@Email", e.Email);
            DbParameter par4 = Database.AddParameter(CONNECTIONSTRING, "@Phone", e.Phone);
            DbParameter par5 = Database.AddParameter(CONNECTIONSTRING, "@ID", e.ID);

            Database.ModifyData(Database.GetConnection(CreateConnectionString(claims)), sql, par1, par2, par3, par4, par5);
        }

        internal static void Delete(int id, IEnumerable<Claim> claims)
        {
            string sql = "UPDATE Employee SET Visible = 0 WHERE ID = @id";
            DbParameter par = Database.AddParameter(CONNECTIONSTRING, "@id", id);

            Database.ModifyData(Database.GetConnection(CreateConnectionString(claims)), sql, par);
        }
    }
}
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
    public class DACustomer
    {
        const string CONNECTIONSTRING = "KlantDB";

        private static ConnectionStringSettings CreateConnectionString(IEnumerable<Claim> claims)
        {
            string dblogin = claims.FirstOrDefault(c => c.Type == "dblogin").Value;
            string dbpass = claims.FirstOrDefault(c => c.Type == "dbpass").Value;
            string dbname = claims.FirstOrDefault(c => c.Type == "dbname").Value;

            return Database.CreateConnectionString("System.Data.SqlClient", @"LAPTOPRUBEN", dbname, dblogin, Crypto.Decrypt(dbpass));
        }

        public static List<Customer> GetKlanten(IEnumerable<Claim> claims)
        {
            string sql = "SELECT ID, CustomerName, Address, Picture, Balance FROM Customer";
            DbDataReader r = Database.GetData(Database.GetConnection(CreateConnectionString(claims)), sql);

            List<Customer> list = new List<Customer>();

            while (r.Read())
            {
                Customer c = new Customer();
                c.ID = Convert.ToInt32(r["ID"]);
                c.CustomerName = r["CustomerName"].ToString();
                c.Address = r["Address"].ToString();
                if (!DBNull.Value.Equals(r["Picture"]))
                    c.Picture = (byte[])r["Picture"];
                else
                    c.Picture = new byte[0];
                c.Balance = Double.Parse(r["Balance"].ToString());

                list.Add(c);
            }

            r.Close();

            return list;
        }

        public static void Update(Customer c, IEnumerable<Claim> claims)
        {
            string sql = "UPDATE Customer SET CustomerName=@CustomerName, Address=@Address, Picture=@Picture, Balance=@Balance WHERE ID=@ID";

            DbParameter par1 = Database.AddParameter(CONNECTIONSTRING, "@CustomerName", c.CustomerName);
            DbParameter par2 = Database.AddParameter(CONNECTIONSTRING, "@Address", c.Address);
            DbParameter par3 = Database.AddParameter(CONNECTIONSTRING, "@Picture", c.Picture);
            DbParameter par4 = Database.AddParameter(CONNECTIONSTRING, "@Balance", c.Balance);
            DbParameter par5 = Database.AddParameter(CONNECTIONSTRING, "@ID", c.ID);

            Database.ModifyData(Database.GetConnection(CreateConnectionString(claims)), sql, par1, par2, par3, par4, par5);
        }

        public static Customer GetKlantByName(string name)
        {
            string sql = "SELECT ID, CustomerName, Address, Picture, Balance FROM Customers";
            DbDataReader r = Database.GetData(CONNECTIONSTRING, sql);

            Customer c = new Customer();
            r.Read();
                
            c.ID = Convert.ToInt32(r["ID"]);
            c.CustomerName = r["CustomerName"].ToString();
            c.Address = r["Address"].ToString();
            if (!DBNull.Value.Equals(r["Picture"]))
                c.Picture = (byte[])r["Picture"];
            else
                c.Picture = new byte[0];
            c.Balance = Double.Parse(r["Balance"].ToString());

            r.Close();

            return c;
        }
    }
}
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
    public class DAProducts
    {
        const string CONNECTIONSTRING = "KlantDB";

        private static ConnectionStringSettings CreateConnectionString(IEnumerable<Claim> claims)
        {
            string dblogin = claims.FirstOrDefault(c => c.Type == "dblogin").Value;
            string dbpass = claims.FirstOrDefault(c => c.Type == "dbpass").Value;
            string dbname = claims.FirstOrDefault(c => c.Type == "dbname").Value;

            return Database.CreateConnectionString("System.Data.SqlClient", @"LAPTOPRUBEN", dbname, dblogin, Crypto.Decrypt(dbpass));
        }

        public static List<Products> GetProducts(IEnumerable<Claim> claims)
        {
            string sql = "SELECT ID, ProductName, Price FROM Product WHERE Visible = 1";
            DbDataReader r = Database.GetData(Database.GetConnection(CreateConnectionString(claims)), sql);
            
            List<Products> list = new List<Products>();

            while (r.Read())
            {
                list.Add(new Products()
                {
                    ID = Int32.Parse(r[0].ToString()),
                    ProductName = r[1].ToString(),
                    Price = Double.Parse(r[2].ToString())
                });
            }

            r.Close();

            return list;
        }

        public static int Insert(Products p, IEnumerable<Claim> claims)
        {
            string sql = "INSERT INTO Product VALUES(@ProductName, @Price, 1)";

            DbParameter par1 = Database.AddParameter(CONNECTIONSTRING, "@ProductName", p.ProductName);
            DbParameter par2 = Database.AddParameter(CONNECTIONSTRING, "@Price", p.Price);

            return Database.InsertData(Database.GetConnection(CreateConnectionString(claims)), sql, par1, par2);
        }

        public static void Update(Products p, IEnumerable<Claim> claims)
        {
            string sql = "UPDATE Product SET ProductName=@ProductName, Price=@Price WHERE ID=@ID";

            DbParameter par1 = Database.AddParameter(CONNECTIONSTRING, "@ProductName", p.ProductName);
            DbParameter par2 = Database.AddParameter(CONNECTIONSTRING, "@Price", p.Price);
            DbParameter par3 = Database.AddParameter(CONNECTIONSTRING, "@ID", p.ID);

            Database.ModifyData(Database.GetConnection(CreateConnectionString(claims)), sql, par1, par2, par3);
        }

        internal static void Delete(int id, IEnumerable<Claim> claims)
        {
            string sql = "UPDATE Product SET Visible = 0 WHERE ID = @id";
            DbParameter par = Database.AddParameter(CONNECTIONSTRING, "@id", id);

            Database.ModifyData(Database.GetConnection(CreateConnectionString(claims)), sql, par);
        }
    }
}
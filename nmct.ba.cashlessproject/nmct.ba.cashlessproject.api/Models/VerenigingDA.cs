using models;
using nmct.ba.cashlessproject.api.Helper;
using nmct.ba.cashlessproject.model;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace nmct.ba.cashlessproject.api.Models
{
    public class VerenigingDA
    {
        const string CONNECTIONSTRING = "DefaultConnection";

        public static IEnumerable<Organisations> GetVerenigingen()
        {
            string sql = "SELECT ID, Login, Password, DbName, DbLogin, DbPassword, OrganisationName, Address, Email, Phone FROM Organisations";
            DbDataReader r = Database.GetData(CONNECTIONSTRING, sql);
            List<Organisations> list = new List<Organisations>();
            while (r.Read())
            {
                list.Add(new Organisations()
                {
                    ID = Int32.Parse(r[0].ToString()),
                    Login = r[1].ToString(),
                    Password = r[2].ToString(),
                    DbName = r[3].ToString(),
                    DbLogin = r[4].ToString(),
                    DbPassword = r[5].ToString(),
                    OrganisationName = r[6].ToString(),
                    Address = r[7].ToString(),
                    Email = r[8].ToString(),
                    Phone = r[9].ToString()
                });
            }
            r.Close();
            return list;
        }

        public static Organisations GetVerenigingById(int id)
        {
            string sql = "SELECT ID, Login, Password, DbName, DbLogin, DbPassword, OrganisationName, Address, Email, Phone FROM Organisations WHERE ID = @id";
            DbParameter p0 = Database.AddParameter(CONNECTIONSTRING, "@id", id);
            DbDataReader r = Database.GetData(CONNECTIONSTRING, sql, p0);
            Organisations org = new Organisations();
            
            r.Read();

            org.ID = Int32.Parse(r[0].ToString());
            org.Login = r[1].ToString();
            org.Password = r[2].ToString();
            org.DbName = r[3].ToString();
            org.DbLogin = r[4].ToString();
            org.DbPassword = r[5].ToString();
            org.OrganisationName = r[6].ToString();
            org.Address = r[7].ToString();
            org.Email = r[8].ToString();
            org.Phone = r[9].ToString();
            
            r.Close();

            return org;
        }

        internal static void EditVereniging(Organisations org)
        {
            string sql = "UPDATE Organisations SET Login=@Login, Password=@Password, DbName=@DbName, DbLogin=@DbLogin, DbPassword=@DbPassword, OrganisationName=@OrganisationName, Address=@Address, Email=@Email, Phone=@Phone WHERE ID=@id";

            DbParameter pid = Database.AddParameter(CONNECTIONSTRING, "@id", org.ID);
            DbParameter p0 = Database.AddParameter(CONNECTIONSTRING, "@Login", org.Login);
            DbParameter p1 = Database.AddParameter(CONNECTIONSTRING, "@Password", Crypto.Encrypt(org.Password));
            DbParameter p2 = Database.AddParameter(CONNECTIONSTRING, "@DbName", org.DbName);
            DbParameter p3 = Database.AddParameter(CONNECTIONSTRING, "@DbLogin", org.DbLogin);
            DbParameter p4 = Database.AddParameter(CONNECTIONSTRING, "@DbPassword", Crypto.Encrypt(org.DbPassword));
            DbParameter p5 = Database.AddParameter(CONNECTIONSTRING, "@OrganisationName", org.OrganisationName);
            DbParameter p6 = Database.AddParameter(CONNECTIONSTRING, "@Address", org.Address);
            DbParameter p7 = Database.AddParameter(CONNECTIONSTRING, "@Email", org.Email);
            DbParameter p8 = Database.AddParameter(CONNECTIONSTRING, "@Phone", org.Phone);

            Database.ModifyData(CONNECTIONSTRING, sql, pid, p0, p1, p2, p3, p4, p5, p6, p7, p8);
        }

        internal static void DeleteVereniging(int id)
        {
            string sql = "DELETE FROM Organisations WHERE ID = @id";
            DbParameter par = Database.AddParameter(CONNECTIONSTRING, "@id", id);

            Database.ModifyData(CONNECTIONSTRING, sql, par);
        }

        public static int PostVereniging(Organisations org)
        {
            string sql = "INSERT INTO Organisations VALUES(@Login, @Password, @DbName, @DbLogin, @DbPassword, @OrganisationName, @Address, @Email, @Phone)";
            
            DbParameter p0 = Database.AddParameter(CONNECTIONSTRING, "@Login", org.Login);
            DbParameter p1 = Database.AddParameter(CONNECTIONSTRING, "@Password", Crypto.Encrypt(org.Password));
            DbParameter p2 = Database.AddParameter(CONNECTIONSTRING, "@DbName", org.DbName);
            DbParameter p3 = Database.AddParameter(CONNECTIONSTRING, "@DbLogin", org.DbLogin);
            DbParameter p4 = Database.AddParameter(CONNECTIONSTRING, "@DbPassword", Crypto.Encrypt(org.DbPassword));
            DbParameter p5 = Database.AddParameter(CONNECTIONSTRING, "@OrganisationName", org.OrganisationName);
            DbParameter p6 = Database.AddParameter(CONNECTIONSTRING, "@Address", org.Address);
            DbParameter p7 = Database.AddParameter(CONNECTIONSTRING, "@Email", org.Email);
            DbParameter p8 = Database.AddParameter(CONNECTIONSTRING, "@Phone", org.Phone);

            int inserted = Database.InsertData(CONNECTIONSTRING, sql, p0, p1, p2, p3, p4, p5, p6, p7, p8);

            CreateDatabase(org);

            return inserted;
        }

        //OPMERKING
        //BRONCODE WERD GESCHREVEN DOOR F. DUCHI (DOCENT BUSINESS APLLICATIONS)
        private static void CreateDatabase(Organisations o)
        {
            // create the actual database
            string create = File.ReadAllText(HostingEnvironment.MapPath(@"~/App_Data/create.txt")); //only for the web
            //string create = File.ReadAllText(@"..\..\Data\create.txt"); // only for desktop
            string sql = create.Replace("@@DbName", o.DbName).Replace("@@DbLogin", o.DbLogin).Replace("@@DbPassword", o.DbPassword);
            foreach (string commandText in RemoveGo(sql))
            {
                Database.ModifyData(CONNECTIONSTRING, commandText);

            }

            // create login, user and tables
            DbTransaction trans = null;
            try
            {
                trans = Database.BeginTransaction(CONNECTIONSTRING);

                string fill = File.ReadAllText(HostingEnvironment.MapPath(@"~/App_Data/fill.txt")); // only for the web
                //string fill = File.ReadAllText(@"..\..\Data\fill.txt"); // only for desktop
                string sql2 = fill.Replace("@@DbName", o.DbName).Replace("@@DbLogin", o.DbLogin).Replace("@@DbPassword", o.DbPassword);

                foreach (string commandText in RemoveGo(sql2))
                {
                    Database.ModifyData(trans, commandText);
                }

                trans.Commit();
            }
            catch (Exception ex)
            {
                trans.Rollback();
                Console.WriteLine(ex.Message);
            }
        }

        private static string[] RemoveGo(string input)
        {
            //split the script on "GO" commands
            string[] splitter = new string[] { "\r\nGO\r\n" };
            string[] commandTexts = input.Split(splitter, StringSplitOptions.RemoveEmptyEntries);
            return commandTexts;
        }
    }
}
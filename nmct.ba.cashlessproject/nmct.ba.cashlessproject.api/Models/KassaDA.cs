using nmct.ba.cashlessproject.api.Helper;
using nmct.ba.cashlessproject.model;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace nmct.ba.cashlessproject.api.Models
{
    public class KassaDA
    {
        const string CONNECTIONSTRING = "DefaultConnection";

        public static IEnumerable<Registers> GetRegisters()
        {
            string sql = "SELECT orgreg.RegisterID, reg.RegisterName, reg.Device, org.OrganisationName, reg.PurchaseDate, reg.ExpiresDate FROM Organisation_Register orgreg INNER JOIN Organisations org ON org.ID = orgreg.OrganisationID INNER JOIN Registers reg on reg.ID = orgreg.RegisterID";
            DbDataReader r = Database.GetData(CONNECTIONSTRING, sql);

            List<Registers> list = new List<Registers>();

            while (r.Read())
            {
                list.Add(new Registers()
                {
                    ID = Int32.Parse(r[0].ToString()),
                    RegisterName = r[1].ToString(),
                    Device = r[2].ToString(),
                    Organisation = r[3].ToString(),
                    PurchaseDate = DateTime.Parse(r[4].ToString()),
                    ExpiresDate = DateTime.Parse(r[5].ToString())
                });
            }
            
            r.Close();

            return list;
        }

        public static IEnumerable<Registers> GetRegistersByOrg(string org)
        {
            string sql = "SELECT orgreg.RegisterID, reg.RegisterName, reg.Device, org.OrganisationName, reg.PurchaseDate, reg.ExpiresDate FROM Organisation_Register orgreg INNER JOIN Organisations org ON org.ID = orgreg.OrganisationID AND org.OrganisationName=@org INNER JOIN Registers reg on reg.ID = orgreg.RegisterID";
            DbParameter p0 = Database.AddParameter(CONNECTIONSTRING, "@org", org);
            DbDataReader r = Database.GetData(CONNECTIONSTRING, sql, p0);

            List<Registers> list = new List<Registers>();

            while (r.Read())
            {
                list.Add(new Registers()
                {
                    ID = Int32.Parse(r[0].ToString()),
                    RegisterName = r[1].ToString(),
                    Device = r[2].ToString(),
                    Organisation = r[3].ToString(),
                    PurchaseDate = DateTime.Parse(r[4].ToString()),
                    ExpiresDate = DateTime.Parse(r[5].ToString())
                });
            }

            r.Close();

            return list;
        }

        public static IEnumerable<SelectListItem> GetVerenigingen()
        {
            string sql = "SELECT OrganisationName FROM Organisations";
            DbDataReader r = Database.GetData(CONNECTIONSTRING, sql);

            var l = new List<SelectListItem>();

            while (r.Read())
	        {
                l.Add(new SelectListItem
                {
                    Text = r[0].ToString(),
                    Value = r[0].ToString()
                });
	        }

            r.Close();
            return l;
        }

        public static IEnumerable<string> GetVerenigingenStrings()
        {
            string sql = "SELECT OrganisationName FROM Organisations";
            DbDataReader r = Database.GetData(CONNECTIONSTRING, sql);

            var l = new List<string>();

            while (r.Read())
            {
                l.Add(r[0].ToString());
            }

            r.Close();
            return l;
        }

        public static int PostRegister(Registers reg)
        {
            string sql = "INSERT INTO Registers VALUES(@RegisterName, @Device, @PurchaseDate, @ExpiresDate)";

            DbParameter p0 = Database.AddParameter(CONNECTIONSTRING, "@RegisterName", reg.RegisterName);
            DbParameter p1 = Database.AddParameter(CONNECTIONSTRING, "@Device", reg.Device);
            DbParameter p2 = Database.AddParameter(CONNECTIONSTRING, "@PurchaseDate", reg.PurchaseDate);
            DbParameter p3 = Database.AddParameter(CONNECTIONSTRING, "@ExpiresDate", reg.ExpiresDate);

            int inserted = Database.InsertData(CONNECTIONSTRING, sql, p0, p1, p2, p3);

            return inserted;
        }

        public static int GetOrgID(Registers reg)
        {
            string sql = "SELECT ID FROM Organisations WHERE OrganisationName=@Organisation";
            DbParameter p0 = Database.AddParameter(CONNECTIONSTRING, "@Organisation", reg.Organisation);
            DbDataReader r = Database.GetData(CONNECTIONSTRING, sql, p0);

            r.Read();

            int orgID = Int32.Parse(r[0].ToString());

            r.Close();

            return orgID;
        }

        public static int SaveRegister(Registers reg, int regID, int orgID)
        {
            string sql = "INSERT INTO Organisation_Register VALUES(@orgID, @regID, @From, @Until)";

            DbParameter p0 = Database.AddParameter(CONNECTIONSTRING, "@orgID", orgID);
            DbParameter p1 = Database.AddParameter(CONNECTIONSTRING, "@regID", regID);
            DbParameter p2 = Database.AddParameter(CONNECTIONSTRING, "@From", reg.PurchaseDate);
            DbParameter p3 = Database.AddParameter(CONNECTIONSTRING, "@Until", reg.ExpiresDate);

            int inserted = Database.InsertData(CONNECTIONSTRING, sql, p0, p1, p2, p3);

            return inserted;
        }

        public static Registers GetRegisterById(int id)
        {
            string sql = "SELECT ID, RegisterName, Device, PurchaseDate, ExpiresDate FROM Registers WHERE ID = @id";
            DbParameter p0 = Database.AddParameter(CONNECTIONSTRING, "@id", id);
            DbDataReader r = Database.GetData(CONNECTIONSTRING, sql, p0);
            Registers reg = new Registers();

            r.Read();

            reg.ID = Int32.Parse(r[0].ToString());
            reg.RegisterName = r[1].ToString();
            reg.Device = r[2].ToString();
            reg.PurchaseDate = DateTime.Parse(r[3].ToString());
            reg.ExpiresDate = DateTime.Parse(r[4].ToString());

            r.Close();

            return reg;
        }

        internal static void EditRegister(Registers reg)
        {
            string sql = "UPDATE Registers SET RegisterName=@RegisterName, Device=@Device, PurchaseDate=@PurchaseDate, ExpiresDate=@ExpiresDate WHERE ID=@id";

            DbParameter pid = Database.AddParameter(CONNECTIONSTRING, "@id", reg.ID);
            DbParameter p0 = Database.AddParameter(CONNECTIONSTRING, "@RegisterName", reg.RegisterName);
            DbParameter p1 = Database.AddParameter(CONNECTIONSTRING, "@Device", reg.Device);
            DbParameter p2 = Database.AddParameter(CONNECTIONSTRING, "@PurchaseDate", reg.PurchaseDate);
            DbParameter p3 = Database.AddParameter(CONNECTIONSTRING, "@ExpiresDate", reg.ExpiresDate);

            Database.ModifyData(CONNECTIONSTRING, sql, pid, p0, p1, p2, p3);
        }

        internal static void UpdateRegister(Registers reg, int orgID)
        {
            string sql = "UPDATE Organisation_Register SET OrganisationID=@orgID, RegisterID=@ID, FromDate=@PurchaseDate, UntilDate=@ExpiresDate WHERE RegisterID=@ID";

            DbParameter pid = Database.AddParameter(CONNECTIONSTRING, "@ID", reg.ID);
            DbParameter p0 = Database.AddParameter(CONNECTIONSTRING, "@orgID", orgID);
            DbParameter p1 = Database.AddParameter(CONNECTIONSTRING, "@PurchaseDate", reg.PurchaseDate);
            DbParameter p2 = Database.AddParameter(CONNECTIONSTRING, "@ExpiresDate", reg.ExpiresDate);

            Database.ModifyData(CONNECTIONSTRING, sql, pid, p0, p1, p2);
        }
    }
}
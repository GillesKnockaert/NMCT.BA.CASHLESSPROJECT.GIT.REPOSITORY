using nmct.ba.cashlessproject.api.Helper;
using nmct.ba.cashlessproject.model;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace nmct.ba.cashlessproject.api.Models
{
    public class LoggingDA
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

        public static IEnumerable<Errorlog> GetErrors(int id)
        {
            string sql = "SELECT log.RegisterID, log.Timestamp, log.Message, log.Stacktrace FROM Errorlog log WHERE log.RegisterID=@id";
            DbParameter p0 = Database.AddParameter(CONNECTIONSTRING, "@id", id);
            DbDataReader r = Database.GetData(CONNECTIONSTRING, sql, p0);

            List<Errorlog> list = new List<Errorlog>();

            while (r.Read())
            {
                list.Add(new Errorlog()
                {
                    RegisterID = Int32.Parse(r[0].ToString()),
                    Timestamp = DateTime.Parse(r[1].ToString()),
                    Message = r[2].ToString(),
                    Stacktrace = r[3].ToString(),
                });
            }

            r.Close();

            return list;
        }
    }
}
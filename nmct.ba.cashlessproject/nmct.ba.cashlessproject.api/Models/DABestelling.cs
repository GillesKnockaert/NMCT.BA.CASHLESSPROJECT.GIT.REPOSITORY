using nmct.ba.cashlessproject.api.Helper;
using nmct.ba.cashlessproject.model;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace nmct.ba.cashlessproject.api.Models
{
    public class DABestelling
    {
        const string CONNECTIONSTRING = "LauweDB";

        public static List<Products> GetProducts()
        {
            string sql = "SELECT ID, ProductName, Price FROM Product WHERE Visible = 1";
            DbDataReader r = Database.GetData(CONNECTIONSTRING, sql);

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
    }
}
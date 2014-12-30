using nmct.ba.cashlessproject.api.Models;
using nmct.ba.cashlessproject.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace nmct.ba.cashlessproject.api.Controllers
{
    public class KlantenController : ApiController
    {
        public List<Customer> Get()
        {
            ClaimsPrincipal p = RequestContext.Principal as ClaimsPrincipal;
            return DACustomer.GetKlanten(p.Claims);
        }

        public Customer Get(string name)
        {
            return DACustomer.GetKlantByName(name);
        }

        public HttpResponseMessage Put(Customer c)
        {
            ClaimsPrincipal p = RequestContext.Principal as ClaimsPrincipal;
            DACustomer.Update(c, p.Claims);

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}

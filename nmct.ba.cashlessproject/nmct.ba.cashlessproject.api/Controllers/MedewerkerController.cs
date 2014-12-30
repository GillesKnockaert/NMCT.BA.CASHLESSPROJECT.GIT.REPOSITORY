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
    public class MedewerkerController : ApiController
    {
        public List<Employee> Get()
        {
            ClaimsPrincipal p = RequestContext.Principal as ClaimsPrincipal;
            return DAMedewerker.GetEmployees(p.Claims);
        }

        public HttpResponseMessage Post(Employee e)
        {
            ClaimsPrincipal p = RequestContext.Principal as ClaimsPrincipal;
            int id = DAMedewerker.Insert(e, p.Claims);

            HttpResponseMessage message = new HttpResponseMessage(HttpStatusCode.OK);
            message.Content = new StringContent(id.ToString());

            return message;
        }

        public HttpResponseMessage Put(Employee e)
        {
            ClaimsPrincipal p = RequestContext.Principal as ClaimsPrincipal;
            DAMedewerker.Update(e, p.Claims);

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        public HttpResponseMessage Delete(int id)
        {
            ClaimsPrincipal p = RequestContext.Principal as ClaimsPrincipal;
            DAMedewerker.Delete(id, p.Claims);

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}

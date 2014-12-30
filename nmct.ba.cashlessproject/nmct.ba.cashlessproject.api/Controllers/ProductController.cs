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
    public class ProductController : ApiController
    {
        public List<Products> Get()
        {
            ClaimsPrincipal p = RequestContext.Principal as ClaimsPrincipal;
            return DAProducts.GetProducts(p.Claims);
        }

        public HttpResponseMessage Post(Products p)
        {
            ClaimsPrincipal prin = RequestContext.Principal as ClaimsPrincipal;
            int id = DAProducts.Insert(p, prin.Claims);

            HttpResponseMessage message = new HttpResponseMessage(HttpStatusCode.OK);
            message.Content = new StringContent(id.ToString());

            return message;
        }

        public HttpResponseMessage Put(Products p)
        {
            ClaimsPrincipal prin = RequestContext.Principal as ClaimsPrincipal;
            DAProducts.Update(p, prin.Claims);

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        public HttpResponseMessage Delete(int id)
        {
            ClaimsPrincipal prin = RequestContext.Principal as ClaimsPrincipal;
            DAProducts.Delete(id, prin.Claims);

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}

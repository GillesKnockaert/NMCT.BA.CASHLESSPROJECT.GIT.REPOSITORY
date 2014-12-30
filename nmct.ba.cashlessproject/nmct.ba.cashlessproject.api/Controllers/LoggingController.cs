using nmct.ba.cashlessproject.api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace nmct.ba.cashlessproject.api.Controllers
{
    public class LoggingController : Controller
    {
        // GET: Logging
        public ActionResult Index()
        {
            ViewBag.Registers = LoggingDA.GetRegisters();
            return View();
        }

        public ActionResult MakeLog(int id, string register)
        {
            ViewBag.Errors = LoggingDA.GetErrors(id);
            ViewBag.Register = register;
            return View();
        }
    }
}
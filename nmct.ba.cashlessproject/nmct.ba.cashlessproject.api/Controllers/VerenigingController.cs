using models;
using nmct.ba.cashlessproject.api.Models;
using nmct.ba.cashlessproject.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace nmct.ba.cashlessproject.api.Controllers
{
    public class VerenigingController : Controller
    {
        // GET: Vereniging
        public ActionResult Index()
        {
            ViewBag.Verenigingen = VerenigingDA.GetVerenigingen();
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            Organisations o = new Organisations();
            return View(o);
        }

        [HttpPost]
        public ActionResult Create(Organisations o)
        {
            VerenigingDA.PostVereniging(o);
            ViewBag.Verenigingen = VerenigingDA.GetVerenigingen();
            return View("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Organisations o = VerenigingDA.GetVerenigingById(id);
            return View(o);
        }

        [HttpPost]
        public ActionResult EditOrganisation(Organisations o)
        {
            VerenigingDA.EditVereniging(o);
            ViewBag.Verenigingen = VerenigingDA.GetVerenigingen();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            Organisations o = VerenigingDA.GetVerenigingById(id);
            return View(o);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Organisations o = VerenigingDA.GetVerenigingById(id);
            return View(o);
        }

        [HttpPost]
        public ActionResult DeleteOrganisation(int id)
        {
            VerenigingDA.DeleteVereniging(id);
            return RedirectToAction("Index");
        }
    }
}
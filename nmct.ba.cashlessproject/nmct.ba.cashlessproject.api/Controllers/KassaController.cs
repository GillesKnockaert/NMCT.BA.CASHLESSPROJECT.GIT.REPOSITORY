using nmct.ba.cashlessproject.api.Models;
using nmct.ba.cashlessproject.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace nmct.ba.cashlessproject.api.Controllers
{
    public class KassaController : Controller
    {
        // GET: Kassa
        public ActionResult Index()
        {
            ViewBag.Registers = KassaDA.GetRegisters();
            ViewBag.Verenigingen = KassaDA.GetVerenigingenStrings();
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            Registers r = new Registers();
            ViewBag.Verenigingen = KassaDA.GetVerenigingen();
            return View(r);
        }
        
        [HttpPost]
        public ActionResult Create(Registers r)
        {
            int regID = KassaDA.PostRegister(r);
            int orgID = KassaDA.GetOrgID(r);

            KassaDA.SaveRegister(r, regID, orgID);
            
            ViewBag.Registers = KassaDA.GetRegisters();
            ViewBag.Verenigingen = KassaDA.GetVerenigingenStrings();
            return View("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Registers r = KassaDA.GetRegisterById(id);
            ViewBag.Verenigingen = KassaDA.GetVerenigingen();
            return View(r);
        }

        [HttpPost]
        public ActionResult EditRegister(Registers r)
        {
            KassaDA.EditRegister(r);

            int orgID = KassaDA.GetOrgID(r);

            KassaDA.UpdateRegister(r, orgID);

            ViewBag.Registers = KassaDA.GetRegisters();
            ViewBag.Verenigingen = KassaDA.GetVerenigingenStrings();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int id, string org)
        {
            Registers r = KassaDA.GetRegisterById(id);
            r.Organisation = org;
            return View(r);
        }

        [HttpGet]
        public ActionResult GetRegisters(string org)
        {
            ViewBag.Organisation = org;
            ViewBag.Registers = KassaDA.GetRegistersByOrg(org);
            return View();
        }

        //DELETE WERKT NOG NIET
        //FOUT IN GETREGISTERS SQL CODE NEAR THE INNER JOIN
    }
}
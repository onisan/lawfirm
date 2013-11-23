using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcLawFirm.Models;

namespace MvcLawFirm.Controllers
{
    public class LawyerReportController : Controller
    {
        private LawFirmDbContext db = new LawFirmDbContext();
        private LawyerReport lawRep = new LawyerReport();
        //
        // GET: /LawyerReport/
        
        public ActionResult Index()
        {
            ViewBag.LAWID = new SelectList(db.NRBM_LAWYER, "LAWID", "FullName");
            return View();
        }

        //
        // GET: /LawyerReport/Details/5

        public ActionResult Report(int id)
        {
            lawRep.LAWID = id;
            NRBM_LAWYER la = db.NRBM_LAWYER.Select(x => x.LAWID == id).Cast<NRBM_LAWYER>;
            return View();
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /LawyerReport/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /LawyerReport/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /LawyerReport/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /LawyerReport/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /LawyerReport/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /LawyerReport/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

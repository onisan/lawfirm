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
    public class CourtAppearanceController : Controller
    {
        private LawFirmDbContext db = new LawFirmDbContext();

        //
        // GET: /CourtAppearance/

        public ActionResult Index()
        {
            return View(db.NRBM_COURTAPPEARANCE.ToList());
        }

        //
        // GET: /CourtAppearance/Details/5

        public ActionResult Details(int id = 0)
        {
            NRBM_COURTAPPEARANCE nrbm_courtappearance = db.NRBM_COURTAPPEARANCE.Find(id);
            if (nrbm_courtappearance == null)
            {
                return HttpNotFound();
            }
            return View(nrbm_courtappearance);
        }

        //
        // GET: /CourtAppearance/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /CourtAppearance/Create

        [HttpPost]
        public ActionResult Create(NRBM_COURTAPPEARANCE nrbm_courtappearance)
        {
            if (ModelState.IsValid)
            {
                db.NRBM_COURTAPPEARANCE.Add(nrbm_courtappearance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nrbm_courtappearance);
        }

        //
        // GET: /CourtAppearance/Edit/5

        public ActionResult Edit(int id = 0)
        {
            NRBM_COURTAPPEARANCE nrbm_courtappearance = db.NRBM_COURTAPPEARANCE.Find(id);
            if (nrbm_courtappearance == null)
            {
                return HttpNotFound();
            }
            return View(nrbm_courtappearance);
        }

        //
        // POST: /CourtAppearance/Edit/5

        [HttpPost]
        public ActionResult Edit(NRBM_COURTAPPEARANCE nrbm_courtappearance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nrbm_courtappearance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nrbm_courtappearance);
        }

        //
        // GET: /CourtAppearance/Delete/5

        public ActionResult Delete(int id = 0)
        {
            NRBM_COURTAPPEARANCE nrbm_courtappearance = db.NRBM_COURTAPPEARANCE.Find(id);
            if (nrbm_courtappearance == null)
            {
                return HttpNotFound();
            }
            return View(nrbm_courtappearance);
        }

        //
        // POST: /CourtAppearance/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            NRBM_COURTAPPEARANCE nrbm_courtappearance = db.NRBM_COURTAPPEARANCE.Find(id);
            db.NRBM_COURTAPPEARANCE.Remove(nrbm_courtappearance);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
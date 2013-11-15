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
    public class LitigatesController : Controller
    {
        private LawFirmDbContext db = new LawFirmDbContext();

        //
        // GET: /Litigates/

        public ActionResult Index()
        {
            return View(db.NRBM_LITIGATES.ToList());
        }

        //
        // GET: /Litigates/Details/5

        public ActionResult Details(int id = 0)
        {
            NRBM_LITIGATES nrbm_litigates = db.NRBM_LITIGATES.Find(id);
            if (nrbm_litigates == null)
            {
                return HttpNotFound();
            }
            return View(nrbm_litigates);
        }

        //
        // GET: /Litigates/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Litigates/Create

        [HttpPost]
        public ActionResult Create(NRBM_LITIGATES nrbm_litigates)
        {
            if (ModelState.IsValid)
            {
                db.NRBM_LITIGATES.Add(nrbm_litigates);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nrbm_litigates);
        }

        //
        // GET: /Litigates/Edit/5

        public ActionResult Edit(int id = 0)
        {
            NRBM_LITIGATES nrbm_litigates = db.NRBM_LITIGATES.Find(id);
            if (nrbm_litigates == null)
            {
                return HttpNotFound();
            }
            return View(nrbm_litigates);
        }

        //
        // POST: /Litigates/Edit/5

        [HttpPost]
        public ActionResult Edit(NRBM_LITIGATES nrbm_litigates)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nrbm_litigates).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nrbm_litigates);
        }

        //
        // GET: /Litigates/Delete/5

        public ActionResult Delete(int id = 0)
        {
            NRBM_LITIGATES nrbm_litigates = db.NRBM_LITIGATES.Find(id);
            if (nrbm_litigates == null)
            {
                return HttpNotFound();
            }
            return View(nrbm_litigates);
        }

        //
        // POST: /Litigates/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            NRBM_LITIGATES nrbm_litigates = db.NRBM_LITIGATES.Find(id);
            db.NRBM_LITIGATES.Remove(nrbm_litigates);
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
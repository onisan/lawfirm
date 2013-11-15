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
    public class StaffController : Controller
    {
        private LawFirmDbContext db = new LawFirmDbContext();

        //
        // GET: /Staff/

        public ActionResult Index()
        {
            return View(db.NRBM_STAFF.ToList());
        }

        //
        // GET: /Staff/Details/5

        public ActionResult Details(int id = 0)
        {
            NRBM_STAFF nrbm_staff = db.NRBM_STAFF.Find(id);
            if (nrbm_staff == null)
            {
                return HttpNotFound();
            }
            return View(nrbm_staff);
        }

        //
        // GET: /Staff/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Staff/Create

        [HttpPost]
        public ActionResult Create(NRBM_STAFF nrbm_staff)
        {
            if (ModelState.IsValid)
            {
                db.NRBM_STAFF.Add(nrbm_staff);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nrbm_staff);
        }

        //
        // GET: /Staff/Edit/5

        public ActionResult Edit(int id = 0)
        {
            NRBM_STAFF nrbm_staff = db.NRBM_STAFF.Find(id);
            if (nrbm_staff == null)
            {
                return HttpNotFound();
            }
            return View(nrbm_staff);
        }

        //
        // POST: /Staff/Edit/5

        [HttpPost]
        public ActionResult Edit(NRBM_STAFF nrbm_staff)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nrbm_staff).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nrbm_staff);
        }

        //
        // GET: /Staff/Delete/5

        public ActionResult Delete(int id = 0)
        {
            NRBM_STAFF nrbm_staff = db.NRBM_STAFF.Find(id);
            if (nrbm_staff == null)
            {
                return HttpNotFound();
            }
            return View(nrbm_staff);
        }

        //
        // POST: /Staff/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            NRBM_STAFF nrbm_staff = db.NRBM_STAFF.Find(id);
            db.NRBM_STAFF.Remove(nrbm_staff);
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
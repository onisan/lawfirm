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
    public class LawyerController : Controller
    {
        private LawFirmDbContext db = new LawFirmDbContext();

        //
        // GET: /Lawyer/

        public ActionResult Index()
        {
            return View(db.NRBM_LAWYER.ToList());
        }

        //
        // GET: /Lawyer/Details/5

        public ActionResult Details(int id = 0)
        {
            NRBM_LAWYER nrbm_lawyer = db.NRBM_LAWYER.Find(id);
            if (nrbm_lawyer == null)
            {
                return HttpNotFound();
            }
            return View(nrbm_lawyer);
        }

        //
        // GET: /Lawyer/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Lawyer/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NRBM_LAWYER nrbm_lawyer)
        {
            if (ModelState.IsValid)
            {
                db.NRBM_LAWYER.Add(nrbm_lawyer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nrbm_lawyer);
        }

        //
        // GET: /Lawyer/Edit/5

        public ActionResult Edit(int id = 0)
        {
            NRBM_LAWYER nrbm_lawyer = db.NRBM_LAWYER.Find(id);
            if (nrbm_lawyer == null)
            {
                return HttpNotFound();
            }
            return View(nrbm_lawyer);
        }

        //
        // POST: /Lawyer/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(NRBM_LAWYER nrbm_lawyer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nrbm_lawyer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nrbm_lawyer);
        }

        //
        // GET: /Lawyer/Delete/5

        public ActionResult Delete(int id = 0)
        {
            NRBM_LAWYER nrbm_lawyer = db.NRBM_LAWYER.Find(id);
            if (nrbm_lawyer == null)
            {
                return HttpNotFound();
            }
            return View(nrbm_lawyer);
        }

        //
        // POST: /Lawyer/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NRBM_LAWYER nrbm_lawyer = db.NRBM_LAWYER.Find(id);
            db.NRBM_LAWYER.Remove(nrbm_lawyer);
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
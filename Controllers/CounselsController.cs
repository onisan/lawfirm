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
    public class CounselsController : Controller
    {
        private LawFirmDbContext db = new LawFirmDbContext();

        //
        // GET: /Counsels/

        public ActionResult Index()
        {
            return View(db.NRBM_COUNSELS.ToList());
        }

        //
        // GET: /Counsels/Details/5

        public ActionResult Details(int id = 0)
        {
            NRBM_COUNSELS nrbm_counsels = db.NRBM_COUNSELS.Find(id);
            if (nrbm_counsels == null)
            {
                return HttpNotFound();
            }
            return View(nrbm_counsels);
        }

        //
        // GET: /Counsels/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Counsels/Create

        [HttpPost]
        public ActionResult Create(NRBM_COUNSELS nrbm_counsels)
        {
            if (ModelState.IsValid)
            {
                db.NRBM_COUNSELS.Add(nrbm_counsels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nrbm_counsels);
        }

        //
        // GET: /Counsels/Edit/5

        public ActionResult Edit(int id = 0)
        {
            NRBM_COUNSELS nrbm_counsels = db.NRBM_COUNSELS.Find(id);
            if (nrbm_counsels == null)
            {
                return HttpNotFound();
            }
            return View(nrbm_counsels);
        }

        //
        // POST: /Counsels/Edit/5

        [HttpPost]
        public ActionResult Edit(NRBM_COUNSELS nrbm_counsels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nrbm_counsels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nrbm_counsels);
        }

        //
        // GET: /Counsels/Delete/5

        public ActionResult Delete(int id = 0)
        {
            NRBM_COUNSELS nrbm_counsels = db.NRBM_COUNSELS.Find(id);
            if (nrbm_counsels == null)
            {
                return HttpNotFound();
            }
            return View(nrbm_counsels);
        }

        //
        // POST: /Counsels/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            NRBM_COUNSELS nrbm_counsels = db.NRBM_COUNSELS.Find(id);
            db.NRBM_COUNSELS.Remove(nrbm_counsels);
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
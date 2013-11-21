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
    public class WorkController : Controller
    {
        private LawFirmDbContext db = new LawFirmDbContext();

        //
        // GET: /Work/

        public ActionResult Index()
        {
            var nrbm_worksfor = db.NRBM_WORKSFOR.Include(n => n.NRBM_LAWYER).Include(n => n.NRBM_STAFF);
            return View(nrbm_worksfor.ToList());
        }

        //
        // GET: /Work/Details/5

        public ActionResult Details(int id = 0)
        {
            NRBM_WORKSFOR nrbm_worksfor = db.NRBM_WORKSFOR.Find(id);
            if (nrbm_worksfor == null)
            {
                return HttpNotFound();
            }
            return View(nrbm_worksfor);
        }

        //
        // GET: /Work/Create

        public ActionResult Create()
        {
            ViewBag.LAWID = new SelectList(db.NRBM_LAWYER, "LAWID", "FNAME");
            ViewBag.STAFFID = new SelectList(db.NRBM_STAFF, "STAFFID", "FNAME");
            return View();
        }

        //
        // POST: /Work/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NRBM_WORKSFOR nrbm_worksfor)
        {
            if (ModelState.IsValid)
            {
                db.NRBM_WORKSFOR.Add(nrbm_worksfor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LAWID = new SelectList(db.NRBM_LAWYER, "LAWID", "FNAME", nrbm_worksfor.LAWID);
            ViewBag.STAFFID = new SelectList(db.NRBM_STAFF, "STAFFID", "FNAME", nrbm_worksfor.STAFFID);
            return View(nrbm_worksfor);
        }

        //
        // GET: /Work/Edit/5

        public ActionResult Edit(int id = 0)
        {
            NRBM_WORKSFOR nrbm_worksfor = db.NRBM_WORKSFOR.Find(id);
            if (nrbm_worksfor == null)
            {
                return HttpNotFound();
            }
            ViewBag.LAWID = new SelectList(db.NRBM_LAWYER, "LAWID", "FNAME", nrbm_worksfor.LAWID);
            ViewBag.STAFFID = new SelectList(db.NRBM_STAFF, "STAFFID", "FNAME", nrbm_worksfor.STAFFID);
            return View(nrbm_worksfor);
        }

        //
        // POST: /Work/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(NRBM_WORKSFOR nrbm_worksfor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nrbm_worksfor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LAWID = new SelectList(db.NRBM_LAWYER, "LAWID", "FNAME", nrbm_worksfor.LAWID);
            ViewBag.STAFFID = new SelectList(db.NRBM_STAFF, "STAFFID", "FNAME", nrbm_worksfor.STAFFID);
            return View(nrbm_worksfor);
        }

        //
        // GET: /Work/Delete/5

        public ActionResult Delete(int id = 0)
        {
            NRBM_WORKSFOR nrbm_worksfor = db.NRBM_WORKSFOR.Find(id);
            if (nrbm_worksfor == null)
            {
                return HttpNotFound();
            }
            return View(nrbm_worksfor);
        }

        //
        // POST: /Work/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NRBM_WORKSFOR nrbm_worksfor = db.NRBM_WORKSFOR.Find(id);
            db.NRBM_WORKSFOR.Remove(nrbm_worksfor);
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
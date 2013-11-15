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
    public class WorksForController : Controller
    {
        private LawFirmDbContext db = new LawFirmDbContext();

        //
        // GET: /WorksFor/

        public ActionResult Index()
        {
            return View(db.NRBM_WORKSFOR.ToList());
        }

        //
        // GET: /WorksFor/Details/5

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
        // GET: /WorksFor/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /WorksFor/Create

        [HttpPost]
        public ActionResult Create(NRBM_WORKSFOR nrbm_worksfor)
        {
            if (ModelState.IsValid)
            {
                db.NRBM_WORKSFOR.Add(nrbm_worksfor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nrbm_worksfor);
        }

        //
        // GET: /WorksFor/Edit/5

        public ActionResult Edit(int id = 0)
        {
            NRBM_WORKSFOR nrbm_worksfor = db.NRBM_WORKSFOR.Find(id);
            if (nrbm_worksfor == null)
            {
                return HttpNotFound();
            }
            return View(nrbm_worksfor);
        }

        //
        // POST: /WorksFor/Edit/5

        [HttpPost]
        public ActionResult Edit(NRBM_WORKSFOR nrbm_worksfor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nrbm_worksfor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nrbm_worksfor);
        }

        //
        // GET: /WorksFor/Delete/5

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
        // POST: /WorksFor/Delete/5

        [HttpPost, ActionName("Delete")]
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
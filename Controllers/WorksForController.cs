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
        // GET: /WORKSVIEW/

        public ActionResult Index()
        {
            return View(db.NRBM_WORKSVIEW.ToList());
        }

        //
        // GET: /WORKSVIEW/Details/5

        public ActionResult Details(int wid = 0, int sid = 0, int lid = 0
        {
            NRBM_WORKSVIEW nrbm_worksview = db.NRBM_WORKSVIEW.Find(id);
            if (nrbm_worksview == null)
            {
                return HttpNotFound();
            }
            return View(nrbm_worksview);
        }

        //
        // GET: /WORKSVIEW/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /WORKSVIEW/Create

        [HttpPost]
        public ActionResult Create(NRBM_WORKSVIEW nrbm_worksview)
        {
            if (ModelState.IsValid)
            {
                db.NRBM_WORKSVIEW.Add(nrbm_worksview);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nrbm_worksview);
        }

        //
        // GET: /WORKSVIEW/Edit/5

        public ActionResult Edit(int wid = 0, int sid = 0, int lid = 0)
        {
            NRBM_WORKSVIEW nrbm_worksview = db.NRBM_WORKSVIEW.Find(wid,sid,lid);
            if (nrbm_worksview == null)
            {
                return HttpNotFound();
            }
            return View(nrbm_worksview);
        }

        //
        // POST: /WORKSVIEW/Edit/5

        [HttpPost]
        public ActionResult Edit(NRBM_WORKSVIEW nrbm_worksview)
        {
            if (ModelState.IsValid)
            {
                NRBM_WORKSFOR nrbm_worksfor = db.NRBM_WORKSFOR.Find(nrbm_worksview.WORKID);
                db.Entry(nrbm_worksfor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nrbm_worksview);
        }

        //
        // GET: /WORKSVIEW/Delete/5

        public ActionResult Delete(int wid = 0, int sid = 0, int lid = 0)
        {
            NRBM_WORKSVIEW nrbm_worksview = db.NRBM_WORKSVIEW.Find(wid,sid,lid);
            
            if (nrbm_worksview == null)
            {
                return HttpNotFound();
            }
            return View(nrbm_worksview);
        }

        //
        // POST: /WORKSVIEW/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int wid, int sid, int lid)
        {
            NRBM_WORKSFOR nrbm_worksfor = db.NRBM_WORKSFOR.Find(wid);
            NRBM_WORKSVIEW nrbm_worksview = db.NRBM_WORKSVIEW.Find(wid, sid, lid);
            db.NRBM_WORKSVIEW.Remove(nrbm_worksview);
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
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
    public class SetsController : Controller
    {
        private LawFirmDbContext db = new LawFirmDbContext();

        //
        // GET: /Sets/

        public ActionResult Index()
        {
            return View(db.NRBM_SETS.ToList());
        }

        //
        // GET: /Sets/Details/5

        public ActionResult Details(int id = 0)
        {
            NRBM_SETS nrbm_sets = db.NRBM_SETS.Find(id);
            if (nrbm_sets == null)
            {
                return HttpNotFound();
            }
            return View(nrbm_sets);
        }

        //
        // GET: /Sets/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Sets/Create

        [HttpPost]
        public ActionResult Create(NRBM_SETS nrbm_sets)
        {
            if (ModelState.IsValid)
            {
                db.NRBM_SETS.Add(nrbm_sets);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nrbm_sets);
        }

        //
        // GET: /Sets/Edit/5

        public ActionResult Edit(int id = 0)
        {
            NRBM_SETS nrbm_sets = db.NRBM_SETS.Find(id);
            if (nrbm_sets == null)
            {
                return HttpNotFound();
            }
            return View(nrbm_sets);
        }

        //
        // POST: /Sets/Edit/5

        [HttpPost]
        public ActionResult Edit(NRBM_SETS nrbm_sets)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nrbm_sets).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nrbm_sets);
        }

        //
        // GET: /Sets/Delete/5

        public ActionResult Delete(int id = 0)
        {
            NRBM_SETS nrbm_sets = db.NRBM_SETS.Find(id);
            if (nrbm_sets == null)
            {
                return HttpNotFound();
            }
            return View(nrbm_sets);
        }

        //
        // POST: /Sets/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            NRBM_SETS nrbm_sets = db.NRBM_SETS.Find(id);
            db.NRBM_SETS.Remove(nrbm_sets);
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
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
    public class CourtController : Controller
    {
        private LawFirmDbContext db = new LawFirmDbContext();

        //
        // GET: /Court/

        public ActionResult Index()
        {
            var nrbm_courtappearance = db.NRBM_COURTAPPEARANCE.Include(n => n.NRBM_ADVERSELAWYER).Include(n => n.NRBM_CASE).Include(n => n.NRBM_CLIENT).Include(n => n.NRBM_LAWYER);
            return View(nrbm_courtappearance.ToList());
        }
        public ActionResult Results(string searchString)
        {
            var apt = from m in db.NRBM_COURTAPPEARANCE
                      where ((string.IsNullOrEmpty(searchString) ? true : m.NRBM_LAWYER.FNAME.Contains(searchString)) ||
                      (string.IsNullOrEmpty(searchString) ? true : m.NRBM_LAWYER.LNAME.Contains(searchString)) ||
                      (string.IsNullOrEmpty(searchString) ? true : m.NRBM_CLIENT.FNAME.Contains(searchString)) ||
                      (string.IsNullOrEmpty(searchString) ? true : m.NRBM_CLIENT.LNAME.Contains(searchString)) ||
                      (string.IsNullOrEmpty(searchString) ? true : m.NRBM_ADVERSELAWYER.FNAME.Contains(searchString)) ||
                      (string.IsNullOrEmpty(searchString) ? true : m.NRBM_ADVERSELAWYER.LNAME.Contains(searchString)))
                      select m;
            return View(apt.ToList());
        }


        //
        // GET: /Court/Details/5

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
        // GET: /Court/Create

        public ActionResult Create()
        {
            ViewBag.ADLAWID = new SelectList(db.NRBM_ADVERSELAWYER, "ADLAWID", "FNAME");
            ViewBag.CASEID = new SelectList(db.NRBM_CASE, "CASEID", "EVIDENCE");
            ViewBag.CLIENTID = new SelectList(db.NRBM_CLIENT, "CLIENTID", "FNAME");
            ViewBag.LAWID = new SelectList(db.NRBM_LAWYER, "LAWID", "FNAME");
            return View();
        }

        //
        // POST: /Court/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NRBM_COURTAPPEARANCE nrbm_courtappearance)
        {
            if (ModelState.IsValid)
            {
                db.NRBM_COURTAPPEARANCE.Add(nrbm_courtappearance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ADLAWID = new SelectList(db.NRBM_ADVERSELAWYER, "ADLAWID", "FNAME", nrbm_courtappearance.ADLAWID);
            ViewBag.CASEID = new SelectList(db.NRBM_CASE, "CASEID", "EVIDENCE", nrbm_courtappearance.CASEID);
            ViewBag.CLIENTID = new SelectList(db.NRBM_CLIENT, "CLIENTID", "FNAME", nrbm_courtappearance.CLIENTID);
            ViewBag.LAWID = new SelectList(db.NRBM_LAWYER, "LAWID", "FNAME", nrbm_courtappearance.LAWID);
            return View(nrbm_courtappearance);
        }

        //
        // GET: /Court/Edit/5

        public ActionResult Edit(int id = 0)
        {
            NRBM_COURTAPPEARANCE nrbm_courtappearance = db.NRBM_COURTAPPEARANCE.Find(id);
            if (nrbm_courtappearance == null)
            {
                return HttpNotFound();
            }
            ViewBag.ADLAWID = new SelectList(db.NRBM_ADVERSELAWYER, "ADLAWID", "FNAME", nrbm_courtappearance.ADLAWID);
            ViewBag.CASEID = new SelectList(db.NRBM_CASE, "CASEID", "EVIDENCE", nrbm_courtappearance.CASEID);
            ViewBag.CLIENTID = new SelectList(db.NRBM_CLIENT, "CLIENTID", "FNAME", nrbm_courtappearance.CLIENTID);
            ViewBag.LAWID = new SelectList(db.NRBM_LAWYER, "LAWID", "FNAME", nrbm_courtappearance.LAWID);
            return View(nrbm_courtappearance);
        }

        //
        // POST: /Court/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(NRBM_COURTAPPEARANCE nrbm_courtappearance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nrbm_courtappearance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ADLAWID = new SelectList(db.NRBM_ADVERSELAWYER, "ADLAWID", "FNAME", nrbm_courtappearance.ADLAWID);
            ViewBag.CASEID = new SelectList(db.NRBM_CASE, "CASEID", "EVIDENCE", nrbm_courtappearance.CASEID);
            ViewBag.CLIENTID = new SelectList(db.NRBM_CLIENT, "CLIENTID", "FNAME", nrbm_courtappearance.CLIENTID);
            ViewBag.LAWID = new SelectList(db.NRBM_LAWYER, "LAWID", "FNAME", nrbm_courtappearance.LAWID);
            return View(nrbm_courtappearance);
        }

        //
        // GET: /Court/Delete/5

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
        // POST: /Court/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
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
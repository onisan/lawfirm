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
            var nrbm_counsels = db.NRBM_COUNSELS.Include(n => n.NRBM_CLIENT).Include(n => n.NRBM_LAWYER);
            return View(nrbm_counsels.ToList());
        }
        public ActionResult Results(string searchString)
        {
            var apt = from m in db.NRBM_COUNSELS
                      where ((string.IsNullOrEmpty(searchString) ? true : m.NRBM_LAWYER.FNAME.Contains(searchString)) ||
                      (string.IsNullOrEmpty(searchString) ? true : m.NRBM_LAWYER.LNAME.Contains(searchString)) ||
                      (string.IsNullOrEmpty(searchString) ? true : m.NRBM_CLIENT.FNAME.Contains(searchString)) ||
                      (string.IsNullOrEmpty(searchString) ? true : m.NRBM_CLIENT.LNAME.Contains(searchString)) ||
                      (string.IsNullOrEmpty(searchString) ? true : (m.NRBM_CLIENT.FNAME + " " + m.NRBM_CLIENT.LNAME).Contains(searchString)) ||
                      (string.IsNullOrEmpty(searchString) ? true : (m.NRBM_LAWYER.FNAME + " " + m.NRBM_LAWYER.LNAME).Contains(searchString)))
                      select m;
            return View(apt.ToList());
        }
        //
        // GET: /Counsels2/Details/5

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
        // GET: /Counsels2/Create

        public ActionResult Create()
        {
            ViewBag.CLIENTID = new SelectList(db.NRBM_CLIENT, "CLIENTID", "FullName");
            ViewBag.LAWID = new SelectList(db.NRBM_LAWYER, "LAWID", "FullName");
            return View();
        }

        //
        // POST: /Counsels2/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NRBM_COUNSELS nrbm_counsels)
        {
            if (ModelState.IsValid)
            {
                db.NRBM_COUNSELS.Add(nrbm_counsels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CLIENTID = new SelectList(db.NRBM_CLIENT, "CLIENTID", "FullName", nrbm_counsels.CLIENTID);
            ViewBag.LAWID = new SelectList(db.NRBM_LAWYER, "LAWID", "FullName", nrbm_counsels.LAWID);
            return View(nrbm_counsels);
        }

        //
        // GET: /Counsels2/Edit/5

        public ActionResult Edit(int id = 0)
        {
            NRBM_COUNSELS nrbm_counsels = db.NRBM_COUNSELS.Find(id);
            if (nrbm_counsels == null)
            {
                return HttpNotFound();
            }
            ViewBag.CLIENTID = new SelectList(db.NRBM_CLIENT, "CLIENTID", "FullName", nrbm_counsels.CLIENTID);
            ViewBag.LAWID = new SelectList(db.NRBM_LAWYER, "LAWID", "FullName", nrbm_counsels.LAWID);
            return View(nrbm_counsels);
        }

        //
        // POST: /Counsels2/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(NRBM_COUNSELS nrbm_counsels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nrbm_counsels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CLIENTID = new SelectList(db.NRBM_CLIENT, "CLIENTID", "FullName", nrbm_counsels.CLIENTID);
            ViewBag.LAWID = new SelectList(db.NRBM_LAWYER, "LAWID", "FullName", nrbm_counsels.LAWID);
            return View(nrbm_counsels);
        }

        //
        // GET: /Counsels2/Delete/5

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
        // POST: /Counsels2/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
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
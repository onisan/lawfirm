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
    public class CaseController : Controller
    {
        private LawFirmDbContext db = new LawFirmDbContext();

        //
        // GET: /Case/

        public ActionResult Index()
        {
            var nrbm_case = db.NRBM_CASE.Include(n => n.NRBM_CLIENT);
            return View(nrbm_case.ToList());
        }

        //
        // GET: /Case/Details/5

        public ActionResult Details(int id = 0)
        {
            NRBM_CASE nrbm_case = db.NRBM_CASE.Find(id);
            if (nrbm_case == null)
            {
                return HttpNotFound();
            }
            return View(nrbm_case);
        }

        //
        // GET: /Case/Create

        public ActionResult Create()
        {
            /*
            var select = new List<SelectListItem>();
            var clients = db.NRBM_CASE.ToList();
            foreach (var mem in clients)
            {
                select.Add(new SelectListItem {
                    Text = mem.NRBM_CLIENT.FNAME + " " + mem.NRBM_CLIENT.LNAME,
                    Value = mem.NRBM_CLIENT.CLIENTID.ToString()
                });
            }
            */
            ViewBag.CLIENTID = new SelectList(db.NRBM_CLIENT, "CLIENTID", "FullName");
            return View();
        }

        //
        // POST: /Case/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NRBM_CASE nrbm_case)
        {
            if (ModelState.IsValid)
            {
                db.NRBM_CASE.Add(nrbm_case);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CLIENTID = new SelectList(db.NRBM_CLIENT, "CLIENTID", "FullName", nrbm_case.CLIENTID);
            return View(nrbm_case);
        }

        //
        // GET: /Case/Edit/5

        public ActionResult Edit(int id = 0)
        {
            NRBM_CASE nrbm_case = db.NRBM_CASE.Find(id);
            if (nrbm_case == null)
            {
                return HttpNotFound();
            }
            ViewBag.CLIENTID = new SelectList(db.NRBM_CLIENT, "CLIENTID", "FullName", nrbm_case.CLIENTID);
            return View(nrbm_case);
        }

        //
        // POST: /Case/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(NRBM_CASE nrbm_case)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nrbm_case).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CLIENTID = new SelectList(db.NRBM_CLIENT, "CLIENTID", "FullName", nrbm_case.CLIENTID);
            return View(nrbm_case);
        }

        //
        // GET: /Case/Delete/5

        public ActionResult Delete(int id = 0)
        {
            NRBM_CASE nrbm_case = db.NRBM_CASE.Find(id);
            if (nrbm_case == null)
            {
                return HttpNotFound();
            }
            return View(nrbm_case);
        }

        //
        // POST: /Case/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NRBM_CASE nrbm_case = db.NRBM_CASE.Find(id);
            db.NRBM_CASE.Remove(nrbm_case);
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
﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcLawFirm.Models;
using System.Data.Entity.Infrastructure;

namespace MvcLawFirm.Controllers
{
    public class CaseController : Controller
    {
        private LawFirmDbContext db = new LawFirmDbContext();

        //
        // GET: /Case/

        public ActionResult Index()
        {
            var nrbm_case = db.NRBM_CASE.Include(n => n.NRBM_CLIENT).Take(20);
            return View(nrbm_case.ToList());
        }
        public ActionResult Results(string searchString)
        {
            string[] search = searchString.Split(null);
            var apt = from m in db.NRBM_CASE
                      where
                      (
                        (string.IsNullOrEmpty(searchString) ? true : search.Contains(m.NRBM_CLIENT.FNAME)) ||
                        (string.IsNullOrEmpty(searchString) ? true : search.Contains(m.NRBM_CLIENT.LNAME))
                     )
                      select m;
            return View(apt.ToList());
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
                nrbm_case.CASEID = db.NRBM_CASE.Max(x => x.CASEID) + 1;
                db.NRBM_CASE.Add(nrbm_case);
                var odb = ((IObjectContextAdapter)db).ObjectContext;
                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateException)
                {
                    odb.Refresh(RefreshMode.ClientWins, nrbm_case);
                }
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
                var odb = ((IObjectContextAdapter)db).ObjectContext;
                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    odb.Refresh(RefreshMode.StoreWins, nrbm_case);
                }
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
            var odb = ((IObjectContextAdapter)db).ObjectContext;
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                odb.Refresh(RefreshMode.StoreWins, nrbm_case);
            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
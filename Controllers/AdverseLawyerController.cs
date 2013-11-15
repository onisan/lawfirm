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
    public class AdverseLawyerController : Controller
    {
        private LawFirmDbContext db = new LawFirmDbContext();

        //
        // GET: /AdverseLawyer/

        public ActionResult Index()
        {
            return View(db.NRBM_ADVERSELAWYER.ToList());
        }

        //
        // GET: /AdverseLawyer/Details/5

        public ActionResult Details(int id = 0)
        {
            NRBM_ADVERSELAWYER nrbm_adverselawyer = db.NRBM_ADVERSELAWYER.Find(id);
            if (nrbm_adverselawyer == null)
            {
                return HttpNotFound();
            }
            return View(nrbm_adverselawyer);
        }

        //
        // GET: /AdverseLawyer/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /AdverseLawyer/Create

        [HttpPost]
        public ActionResult Create(NRBM_ADVERSELAWYER nrbm_adverselawyer)
        {
            if (ModelState.IsValid)
            {
                db.NRBM_ADVERSELAWYER.Add(nrbm_adverselawyer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nrbm_adverselawyer);
        }

        //
        // GET: /AdverseLawyer/Edit/5

        public ActionResult Edit(int id = 0)
        {
            NRBM_ADVERSELAWYER nrbm_adverselawyer = db.NRBM_ADVERSELAWYER.Find(id);
            if (nrbm_adverselawyer == null)
            {
                return HttpNotFound();
            }
            return View(nrbm_adverselawyer);
        }

        //
        // POST: /AdverseLawyer/Edit/5

        [HttpPost]
        public ActionResult Edit(NRBM_ADVERSELAWYER nrbm_adverselawyer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nrbm_adverselawyer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nrbm_adverselawyer);
        }

        //
        // GET: /AdverseLawyer/Delete/5

        public ActionResult Delete(int id = 0)
        {
            NRBM_ADVERSELAWYER nrbm_adverselawyer = db.NRBM_ADVERSELAWYER.Find(id);
            if (nrbm_adverselawyer == null)
            {
                return HttpNotFound();
            }
            return View(nrbm_adverselawyer);
        }

        //
        // POST: /AdverseLawyer/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            NRBM_ADVERSELAWYER nrbm_adverselawyer = db.NRBM_ADVERSELAWYER.Find(id);
            db.NRBM_ADVERSELAWYER.Remove(nrbm_adverselawyer);
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
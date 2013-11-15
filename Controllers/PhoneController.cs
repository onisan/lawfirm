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
    public class PhoneController : Controller
    {
        private LawFirmDbContext db = new LawFirmDbContext();

        //
        // GET: /Phone/

        public ActionResult Index()
        {
            return View(db.NRBM_PHONE.ToList());
        }

        //
        // GET: /Phone/Details/5

        public ActionResult Details(int id = 0)
        {
            NRBM_PHONE nrbm_phone = db.NRBM_PHONE.Find(id);
            if (nrbm_phone == null)
            {
                return HttpNotFound();
            }
            return View(nrbm_phone);
        }

        //
        // GET: /Phone/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Phone/Create

        [HttpPost]
        public ActionResult Create(NRBM_PHONE nrbm_phone)
        {
            if (ModelState.IsValid)
            {
                db.NRBM_PHONE.Add(nrbm_phone);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nrbm_phone);
        }

        //
        // GET: /Phone/Edit/5

        public ActionResult Edit(int id = 0)
        {
            NRBM_PHONE nrbm_phone = db.NRBM_PHONE.Find(id);
            if (nrbm_phone == null)
            {
                return HttpNotFound();
            }
            return View(nrbm_phone);
        }

        //
        // POST: /Phone/Edit/5

        [HttpPost]
        public ActionResult Edit(NRBM_PHONE nrbm_phone)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nrbm_phone).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nrbm_phone);
        }

        //
        // GET: /Phone/Delete/5

        public ActionResult Delete(int id = 0)
        {
            NRBM_PHONE nrbm_phone = db.NRBM_PHONE.Find(id);
            if (nrbm_phone == null)
            {
                return HttpNotFound();
            }
            return View(nrbm_phone);
        }

        //
        // POST: /Phone/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            NRBM_PHONE nrbm_phone = db.NRBM_PHONE.Find(id);
            db.NRBM_PHONE.Remove(nrbm_phone);
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
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
    public class ClientController : Controller
    {
        private LawFirmDbContext db = new LawFirmDbContext();

        //
        // GET: /Client/

        public ActionResult Index()
        {
            return View(db.NRBM_CLIENT.ToList());
        }

        //
        // GET: /Client/Details/5

        public ActionResult Details(int id = 0)
        {
            NRBM_CLIENT nrbm_client = db.NRBM_CLIENT.Find(id);
            if (nrbm_client == null)
            {
                return HttpNotFound();
            }
            return View(nrbm_client);
        }

        //
        // GET: /Client/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Client/Create

        [HttpPost]
        public ActionResult Create(NRBM_CLIENT nrbm_client)
        {
            if (ModelState.IsValid)
            {
                db.NRBM_CLIENT.Add(nrbm_client);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nrbm_client);
        }

        //
        // GET: /Client/Edit/5

        public ActionResult Edit(int id = 0)
        {
            NRBM_CLIENT nrbm_client = db.NRBM_CLIENT.Find(id);
            if (nrbm_client == null)
            {
                return HttpNotFound();
            }
            return View(nrbm_client);
        }

        //
        // POST: /Client/Edit/5

        [HttpPost]
        public ActionResult Edit(NRBM_CLIENT nrbm_client)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nrbm_client).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nrbm_client);
        }

        //
        // GET: /Client/Delete/5

        public ActionResult Delete(int id = 0)
        {
            NRBM_CLIENT nrbm_client = db.NRBM_CLIENT.Find(id);
            if (nrbm_client == null)
            {
                return HttpNotFound();
            }
            return View(nrbm_client);
        }

        //
        // POST: /Client/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            NRBM_CLIENT nrbm_client = db.NRBM_CLIENT.Find(id);
            db.NRBM_CLIENT.Remove(nrbm_client);
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
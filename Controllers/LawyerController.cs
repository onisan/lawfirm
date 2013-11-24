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
    public class LawyerController : Controller
    {
        private LawFirmDbContext db = new LawFirmDbContext();

        //
        // GET: /Lawyer/

        public ActionResult Index()
        {
            return View(db.NRBM_LAWYER.ToList());
        }

        //
        // GET: /Lawyer/Details/5

        public ActionResult Details(int id = 0)
        {
            NRBM_LAWYER nrbm_lawyer = db.NRBM_LAWYER.Find(id);
            if (nrbm_lawyer == null)
            {
                return HttpNotFound();
            }
            return View(nrbm_lawyer);
        }

        //
        // GET: /Lawyer/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Lawyer/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NRBM_LAWYER nrbm_lawyer)
        {
            if (ModelState.IsValid)
            {
                db.NRBM_LAWYER.Add(nrbm_lawyer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nrbm_lawyer);
        }

        //
        // GET: /Lawyer/Edit/5

        public ActionResult Edit(int id = 0)
        {
            NRBM_LAWYER nrbm_lawyer = db.NRBM_LAWYER.Find(id);
            if (nrbm_lawyer == null)
            {
                return HttpNotFound();
            }
            return View(nrbm_lawyer);
        }

        //
        // POST: /Lawyer/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(NRBM_LAWYER nrbm_lawyer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nrbm_lawyer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nrbm_lawyer);
        }

        //
        // GET: /Lawyer/Delete/5

        public ActionResult Delete(int id = 0)
        {
            NRBM_LAWYER nrbm_lawyer = db.NRBM_LAWYER.Find(id);
            if (nrbm_lawyer == null)
            {
                return HttpNotFound();
            }
            return View(nrbm_lawyer);
        }

        //
        // POST: /Lawyer/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NRBM_LAWYER nrbm_lawyer = db.NRBM_LAWYER.Find(id);
            db.NRBM_LAWYER.Remove(nrbm_lawyer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Report()
        {
            IEnumerable<NRBM_LAWYER> lrep = db.NRBM_LAWYER.ToList();
            IEnumerable<NRBM_LAWYER> law = db.NRBM_LAWYER.ToList();

            foreach(var mem in lrep) {
                mem.Appointments = mem.NRBM_APPOINTMENT.Where(x=>x.LAWID == mem.LAWID).Count();
                mem.Clients = mem.NRBM_COUNSELS.Where(x => x.LAWID == mem.LAWID).Count();
                mem.CourtAppearances = mem.NRBM_COURTAPPEARANCE.Where(x => x.LAWID == mem.LAWID).Count();
                mem.Earnings = mem.NRBM_COUNSELS.Where(x => x.LAWID == mem.LAWID).Sum(x => x.HOURS.Value) * mem.NRBM_COUNSELS.Where(x => x.LAWID == mem.LAWID).Sum(x => x.FEES.Value);
                mem.Expenses = mem.NRBM_WORKSFOR.Where(x => x.LAWID == mem.LAWID).Sum(x => x.SALARY.Value) / 12;
            }
            return View(lrep.OrderByDescending(x=>x.Earnings));
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
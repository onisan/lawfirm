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
    public class AppointmentController : Controller
    {
        private LawFirmDbContext db = new LawFirmDbContext();

        //
        // GET: /TestApt/

        public ActionResult Index()
        {
            var nrbm_appointment = db.NRBM_APPOINTMENT.Include(n => n.NRBM_CASE).Include(n => n.NRBM_CLIENT).Include(n => n.NRBM_LAWYER);
            return View(nrbm_appointment.ToList());
        }

        //
        // GET: /TestApt/Details/5

        public ActionResult Details(int id = 0)
        {
            NRBM_APPOINTMENT nrbm_appointment = db.NRBM_APPOINTMENT.Find(id);
            if (nrbm_appointment == null)
            {
                return HttpNotFound();
            }
            return View(nrbm_appointment);
        }

        //
        // GET: /TestApt/Create

        public ActionResult Create()
        {
            ViewBag.CASEID = new SelectList(db.NRBM_CASE, "CASEID", "EVIDENCE");
            ViewBag.CLIENTID = new SelectList(db.NRBM_CLIENT, "CLIENTID", "FNAME");
            ViewBag.LAWID = new SelectList(db.NRBM_LAWYER, "LAWID", "FNAME");
            return View();
        }

        //
        // POST: /TestApt/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NRBM_APPOINTMENT nrbm_appointment)
        {
            if (ModelState.IsValid)
            {
                db.NRBM_APPOINTMENT.Add(nrbm_appointment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CASEID = new SelectList(db.NRBM_CASE, "CASEID", "EVIDENCE", nrbm_appointment.CASEID);
            ViewBag.CLIENTID = new SelectList(db.NRBM_CLIENT, "CLIENTID", "FNAME", nrbm_appointment.CLIENTID);
            ViewBag.LAWID = new SelectList(db.NRBM_LAWYER, "LAWID", "FNAME", nrbm_appointment.LAWID);
            return View(nrbm_appointment);
        }

        //
        // GET: /TestApt/Edit/5

        public ActionResult Edit(int id = 0)
        {
            NRBM_APPOINTMENT nrbm_appointment = db.NRBM_APPOINTMENT.Find(id);
            if (nrbm_appointment == null)
            {
                return HttpNotFound();
            }
            ViewBag.CASEID = new SelectList(db.NRBM_CASE, "CASEID", "EVIDENCE", nrbm_appointment.CASEID);
            ViewBag.CLIENTID = new SelectList(db.NRBM_CLIENT, "CLIENTID", "FNAME", nrbm_appointment.CLIENTID);
            ViewBag.LAWID = new SelectList(db.NRBM_LAWYER, "LAWID", "FNAME", nrbm_appointment.LAWID);
            return View(nrbm_appointment);
        }

        //
        // POST: /TestApt/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(NRBM_APPOINTMENT nrbm_appointment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nrbm_appointment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CASEID = new SelectList(db.NRBM_CASE, "CASEID", "EVIDENCE", nrbm_appointment.CASEID);
            ViewBag.CLIENTID = new SelectList(db.NRBM_CLIENT, "CLIENTID", "FNAME", nrbm_appointment.CLIENTID);
            ViewBag.LAWID = new SelectList(db.NRBM_LAWYER, "LAWID", "FNAME", nrbm_appointment.LAWID);
            return View(nrbm_appointment);
        }

        //
        // GET: /TestApt/Delete/5

        public ActionResult Delete(int id = 0)
        {
            NRBM_APPOINTMENT nrbm_appointment = db.NRBM_APPOINTMENT.Find(id);
            if (nrbm_appointment == null)
            {
                return HttpNotFound();
            }
            return View(nrbm_appointment);
        }

        //
        // POST: /TestApt/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NRBM_APPOINTMENT nrbm_appointment = db.NRBM_APPOINTMENT.Find(id);
            db.NRBM_APPOINTMENT.Remove(nrbm_appointment);
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
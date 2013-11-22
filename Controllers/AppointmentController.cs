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
        public ActionResult Results (string searchString)
        {
            var apt = from m in db.NRBM_APPOINTMENT
                     where ((string.IsNullOrEmpty(searchString) ? true : m.NRBM_LAWYER.FNAME.Contains(searchString)) ||
                     (string.IsNullOrEmpty(searchString) ? true : m.NRBM_LAWYER.LNAME.Contains(searchString)) ||
                     (string.IsNullOrEmpty(searchString) ? true : m.NRBM_CLIENT.FNAME.Contains(searchString)) ||
                     (string.IsNullOrEmpty(searchString) ? true : m.NRBM_CLIENT.LNAME.Contains(searchString)) ||
                     (string.IsNullOrEmpty(searchString) ? true : (m.NRBM_CLIENT.FNAME + " " + m.NRBM_CLIENT.LNAME).Contains(searchString)) ||
                     (string.IsNullOrEmpty(searchString) ? true : (m.NRBM_LAWYER.FNAME + " " + m.NRBM_LAWYER.LNAME).Contains(searchString)))
                     
                select m;
            return View(apt.ToList());
        }
        public ActionResult Create()
        {
            ViewBag.CLIENTID = new SelectList(db.NRBM_CLIENT, "CLIENTID", "FullName");
            ViewBag.LAWID = new SelectList(db.NRBM_LAWYER, "LAWID", "FullName");
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

            ViewBag.CLIENTID = new SelectList(db.NRBM_CLIENT, "CLIENTID", "FullName", nrbm_appointment.CLIENTID);
            ViewBag.LAWID = new SelectList(db.NRBM_LAWYER, "LAWID", "FullName", nrbm_appointment.LAWID);
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
            ViewBag.CLIENTID = new SelectList(db.NRBM_CLIENT, "CLIENTID", "FullName", nrbm_appointment.CLIENTID);
            ViewBag.LAWID = new SelectList(db.NRBM_LAWYER, "LAWID", "FullName", nrbm_appointment.LAWID);
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
            ViewBag.CLIENTID = new SelectList(db.NRBM_CLIENT, "CLIENTID", "FullName", nrbm_appointment.CLIENTID);
            ViewBag.LAWID = new SelectList(db.NRBM_LAWYER, "LAWID", "FullName", nrbm_appointment.LAWID);
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
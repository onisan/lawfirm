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
        // GET: /Appointment/

        public ActionResult Index()
        {

            return View(db.NRBM_APTVIEW.ToList());
        }

        //
        // GET: /Appointment/Details/5

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
        // GET: /Appointment/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Appointment/Create

        [HttpPost]
        public ActionResult Create(NRBM_APPOINTMENT nrbm_appointment)
        {
            if (ModelState.IsValid)
            {
                db.NRBM_APPOINTMENT.Add(nrbm_appointment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nrbm_appointment);
        }

        //
        // GET: /Appointment/Edit/5

        public ActionResult Edit(int id = 0)
        {
            NRBM_APPOINTMENT nrbm_appointment = db.NRBM_APPOINTMENT.Find(id);
            if (nrbm_appointment == null)
            {
                return HttpNotFound();
            }
            return View(nrbm_appointment);
        }

        //
        // POST: /Appointment/Edit/5

        [HttpPost]
        public ActionResult Edit(NRBM_APPOINTMENT nrbm_appointment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nrbm_appointment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nrbm_appointment);
        }

        //
        // GET: /Appointment/Delete/5

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
        // POST: /Appointment/Delete/5

        [HttpPost, ActionName("Delete")]
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
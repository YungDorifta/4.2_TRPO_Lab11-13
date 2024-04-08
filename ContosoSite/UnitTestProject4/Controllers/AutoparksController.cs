using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ContosoSite.Models;

namespace ContosoSite.Controllers
{
    public class AutoparksController : Controller
    {
        private AutoRentDatabaseEntitiesActual db = new AutoRentDatabaseEntitiesActual();

        // GET: Autoparks
        public ActionResult Index()
        {
            var autopark = db.Autopark.Include(a => a.ModelTable);
            return View(autopark.ToList());
        }

        // GET: Autoparks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Autopark autopark = db.Autopark.Find(id);
            if (autopark == null)
            {
                return HttpNotFound();
            }
            return View(autopark);
        }

        // GET: Autoparks/Create
        public ActionResult Create()
        {
            ViewBag.modelID = new SelectList(db.ModelTable, "modelID", "brand");
            return View();
        }

        // POST: Autoparks/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "autoID,modelID,licensePlate,mileage,pricePerHour")] Autopark autopark)
        {
            if (ModelState.IsValid)
            {
                db.Autopark.Add(autopark);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.modelID = new SelectList(db.ModelTable, "modelID", "brand", autopark.modelID);
            return View(autopark);
        }

        // GET: Autoparks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Autopark autopark = db.Autopark.Find(id);
            if (autopark == null)
            {
                return HttpNotFound();
            }
            ViewBag.modelID = new SelectList(db.ModelTable, "modelID", "brand", autopark.modelID);
            return View(autopark);
        }

        // POST: Autoparks/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "autoID,modelID,licensePlate,mileage,pricePerHour")] Autopark autopark)
        {
            if (ModelState.IsValid)
            {
                db.Entry(autopark).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.modelID = new SelectList(db.ModelTable, "modelID", "brand", autopark.modelID);
            return View(autopark);
        }

        // GET: Autoparks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Autopark autopark = db.Autopark.Find(id);
            if (autopark == null)
            {
                return HttpNotFound();
            }
            return View(autopark);
        }

        // POST: Autoparks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Autopark autopark = db.Autopark.Find(id);
            db.Autopark.Remove(autopark);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

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
    public class FixesController : Controller
    {
        private AutoRentDatabaseEntitiesActual db = new AutoRentDatabaseEntitiesActual();

        // GET: Fixes
        public ActionResult Index()
        {
            var fixes = db.Fixes.Include(f => f.Autopark);
            return View(fixes.ToList());
        }

        // GET: Fixes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fixes fixes = db.Fixes.Find(id);
            if (fixes == null)
            {
                return HttpNotFound();
            }
            return View(fixes);
        }

        // GET: Fixes/Create
        public ActionResult Create()
        {
            ViewBag.autoID = new SelectList(db.Autopark, "autoID", "licensePlate");
            return View();
        }

        // POST: Fixes/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "fixID,autoID,Description,Appeared,Fixed")] Fixes fixes)
        {
            if (ModelState.IsValid)
            {
                db.Fixes.Add(fixes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.autoID = new SelectList(db.Autopark, "autoID", "licensePlate", fixes.autoID);
            return View(fixes);
        }

        // GET: Fixes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fixes fixes = db.Fixes.Find(id);
            if (fixes == null)
            {
                return HttpNotFound();
            }
            ViewBag.autoID = new SelectList(db.Autopark, "autoID", "licensePlate", fixes.autoID);
            return View(fixes);
        }

        // POST: Fixes/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "fixID,autoID,Description,Appeared,Fixed")] Fixes fixes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fixes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.autoID = new SelectList(db.Autopark, "autoID", "licensePlate", fixes.autoID);
            return View(fixes);
        }

        // GET: Fixes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fixes fixes = db.Fixes.Find(id);
            if (fixes == null)
            {
                return HttpNotFound();
            }
            return View(fixes);
        }

        // POST: Fixes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Fixes fixes = db.Fixes.Find(id);
            db.Fixes.Remove(fixes);
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

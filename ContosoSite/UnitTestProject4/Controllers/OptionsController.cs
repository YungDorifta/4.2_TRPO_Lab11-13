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
    public class OptionsController : Controller
    {
        private AutoRentDatabaseEntitiesActual db = new AutoRentDatabaseEntitiesActual();

        // GET: Options
        public ActionResult Index()
        {
            return View(db.Options.ToList());
        }

        // GET: Options/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Options options = db.Options.Find(id);
            if (options == null)
            {
                return HttpNotFound();
            }
            return View(options);
        }

        // GET: Options/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Options/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "optionsID,trailer,bicycleRack,babySeat")] Options options)
        {
            if (ModelState.IsValid)
            {
                db.Options.Add(options);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(options);
        }

        // GET: Options/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Options options = db.Options.Find(id);
            if (options == null)
            {
                return HttpNotFound();
            }
            return View(options);
        }

        // POST: Options/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "optionsID,trailer,bicycleRack,babySeat")] Options options)
        {
            if (ModelState.IsValid)
            {
                db.Entry(options).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(options);
        }

        // GET: Options/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Options options = db.Options.Find(id);
            if (options == null)
            {
                return HttpNotFound();
            }
            return View(options);
        }

        // POST: Options/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Options options = db.Options.Find(id);
            db.Options.Remove(options);
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

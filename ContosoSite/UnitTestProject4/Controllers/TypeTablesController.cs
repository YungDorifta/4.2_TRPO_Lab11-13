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
    public class TypeTablesController : Controller
    {
        private AutoRentDatabaseEntitiesActual db = new AutoRentDatabaseEntitiesActual();

        // GET: TypeTables
        public ActionResult Index()
        {
            return View(db.TypeTable.ToList());
        }

        // GET: TypeTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeTable typeTable = db.TypeTable.Find(id);
            if (typeTable == null)
            {
                return HttpNotFound();
            }
            return View(typeTable);
        }

        // GET: TypeTables/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TypeTables/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "typeID,body,group")] TypeTable typeTable)
        {
            if (ModelState.IsValid)
            {
                db.TypeTable.Add(typeTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(typeTable);
        }

        // GET: TypeTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeTable typeTable = db.TypeTable.Find(id);
            if (typeTable == null)
            {
                return HttpNotFound();
            }
            return View(typeTable);
        }

        // POST: TypeTables/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "typeID,body,group")] TypeTable typeTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(typeTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(typeTable);
        }

        // GET: TypeTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeTable typeTable = db.TypeTable.Find(id);
            if (typeTable == null)
            {
                return HttpNotFound();
            }
            return View(typeTable);
        }

        // POST: TypeTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TypeTable typeTable = db.TypeTable.Find(id);
            db.TypeTable.Remove(typeTable);
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

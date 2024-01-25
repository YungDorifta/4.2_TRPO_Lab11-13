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
    public class ModelTablesController : Controller
    {
        private AutoRentDatabaseEntitiesActual db = new AutoRentDatabaseEntitiesActual();

        // GET: ModelTables
        public ActionResult Index()
        {
            var modelTable = db.ModelTable.Include(m => m.TypeTable);
            return View(modelTable.ToList());
        }

        // GET: ModelTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModelTable modelTable = db.ModelTable.Find(id);
            if (modelTable == null)
            {
                return HttpNotFound();
            }
            return View(modelTable);
        }

        // GET: ModelTables/Create
        public ActionResult Create()
        {
            ViewBag.typeID = new SelectList(db.TypeTable, "typeID", "body");
            return View();
        }

        // POST: ModelTables/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "modelID,brand,model,typeID,photo")] ModelTable modelTable, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                if (upload != null && upload.ContentLength > 0)
                {
                    using (var reader = new System.IO.BinaryReader(upload.InputStream))
                    {
                        modelTable.photo = reader.ReadBytes(upload.ContentLength);
                    }
                }

                db.ModelTable.Add(modelTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.typeID = new SelectList(db.TypeTable, "typeID", "body", modelTable.typeID);
            return View(modelTable);
        }

        // GET: ModelTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModelTable modelTable = db.ModelTable.Find(id);
            if (modelTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.typeID = new SelectList(db.TypeTable, "typeID", "body", modelTable.typeID);
            return View(modelTable);
        }

        // POST: ModelTables/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "modelID,brand,model,typeID,photo")] ModelTable modelTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(modelTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.typeID = new SelectList(db.TypeTable, "typeID", "body", modelTable.typeID);
            return View(modelTable);
        }

        // GET: ModelTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModelTable modelTable = db.ModelTable.Find(id);
            if (modelTable == null)
            {
                return HttpNotFound();
            }
            return View(modelTable);
        }

        // POST: ModelTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ModelTable modelTable = db.ModelTable.Find(id);
            db.ModelTable.Remove(modelTable);
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

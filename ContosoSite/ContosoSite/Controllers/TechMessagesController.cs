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
    public class TechMessagesController : Controller
    {
        private AutoRentDatabaseEntitiesActual db = new AutoRentDatabaseEntitiesActual();

        // GET: TechMessages
        public ActionResult Index()
        {
            var techMessages = db.TechMessages.Include(t => t.Rents);
            return View(techMessages.ToList());
        }

        // GET: TechMessages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TechMessages techMessages = db.TechMessages.Find(id);
            if (techMessages == null)
            {
                return HttpNotFound();
            }
            return View(techMessages);
        }

        // GET: TechMessages/Create
        public ActionResult Create()
        {
            ViewBag.rentID = new SelectList(db.Rents, "rentID", "insuranse");
            return View();
        }

        // POST: TechMessages/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "rentID,start,description")] TechMessages techMessages)
        {
            if (ModelState.IsValid)
            {
                db.TechMessages.Add(techMessages);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.rentID = new SelectList(db.Rents, "rentID", "insuranse", techMessages.rentID);
            return View(techMessages);
        }

        // GET: TechMessages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TechMessages techMessages = db.TechMessages.Find(id);
            if (techMessages == null)
            {
                return HttpNotFound();
            }
            ViewBag.rentID = new SelectList(db.Rents, "rentID", "insuranse", techMessages.rentID);
            return View(techMessages);
        }

        // POST: TechMessages/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "rentID,start,description")] TechMessages techMessages)
        {
            if (ModelState.IsValid)
            {
                db.Entry(techMessages).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.rentID = new SelectList(db.Rents, "rentID", "insuranse", techMessages.rentID);
            return View(techMessages);
        }

        // GET: TechMessages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TechMessages techMessages = db.TechMessages.Find(id);
            if (techMessages == null)
            {
                return HttpNotFound();
            }
            return View(techMessages);
        }

        // POST: TechMessages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TechMessages techMessages = db.TechMessages.Find(id);
            db.TechMessages.Remove(techMessages);
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

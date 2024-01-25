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
    public class RentsController : Controller
    {
        private AutoRentDatabaseEntitiesActual db = new AutoRentDatabaseEntitiesActual();

        // GET: Rents
        /*
        public ActionResult Index()
        {
            var rents = db.Rents.Include(r => r.Autopark).Include(r => r.Options).Include(r => r.TechMessages).Include(r => r.Users);
            return View(rents.ToList());
        }
        */
        
        public ActionResult Index(string sortOrder, string searchString)
        {
            ViewBag.NameSortParm = (sortOrder != "FIO") ? "FIO" : "";
            ViewBag.DateSortParm = (sortOrder != "start_desc") ? "start_desc" : "startTime";
            var rents = db.Rents.Include(r => r.Autopark).Include(r => r.Options).Include(r => r.TechMessages).Include(r => r.Users);
            if (!String.IsNullOrEmpty(searchString))
            {
                rents = rents.Where((s) => s.Users.FIO.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "FIO":
                    rents = rents.OrderBy(s => s.Users.FIO);
                    break;
                case "start_desc":
                    rents = rents.OrderByDescending(s => s.startTime);
                    break;
                default:
                    rents = rents.OrderBy(s => s.userID);
                    break;
            }
            //ViewBag.ErrorMessage = rents.ToList()[0].Users.FIO.ToString() + rents.ToList()[1].Users.FIO.ToString() + rents.ToList()[2].Users.FIO.ToString();
            return View(rents.ToList());
        }

        // GET: Rents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rents rents = db.Rents.Find(id);
            if (rents == null)
            {
                return HttpNotFound();
            }
            return View(rents);
        }

        // GET: Rents/Create
        public ActionResult Create()
        {
            ViewBag.autoID = new SelectList(db.Autopark, "autoID", "licensePlate");
            ViewBag.optionsID = new SelectList(db.Options, "optionsID", "trailer");
            ViewBag.rentID = new SelectList(db.TechMessages, "rentID", "description");
            ViewBag.userID = new SelectList(db.Users, "UserID", "FIO");
            return View();
        }

        // POST: Rents/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "rentID,userID,autoID,optionsID,startTime,endTime,insuranse")] Rents rents)
        {
            if (ModelState.IsValid)
            {
                db.Rents.Add(rents);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.autoID = new SelectList(db.Autopark, "autoID", "licensePlate", rents.autoID);
            ViewBag.optionsID = new SelectList(db.Options, "optionsID", "trailer", rents.optionsID);
            ViewBag.rentID = new SelectList(db.TechMessages, "rentID", "description", rents.rentID);
            ViewBag.userID = new SelectList(db.Users, "UserID", "FIO", rents.userID);
            return View(rents);
        }

        // GET: Rents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rents rents = db.Rents.Find(id);
            if (rents == null)
            {
                return HttpNotFound();
            }
            ViewBag.autoID = new SelectList(db.Autopark, "autoID", "licensePlate", rents.autoID);
            ViewBag.optionsID = new SelectList(db.Options, "optionsID", "trailer", rents.optionsID);
            ViewBag.rentID = new SelectList(db.TechMessages, "rentID", "description", rents.rentID);
            ViewBag.userID = new SelectList(db.Users, "UserID", "FIO", rents.userID);
            return View(rents);
        }

        // POST: Rents/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "rentID,userID,autoID,optionsID,startTime,endTime,insuranse")] Rents rents)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rents).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.autoID = new SelectList(db.Autopark, "autoID", "licensePlate", rents.autoID);
            ViewBag.optionsID = new SelectList(db.Options, "optionsID", "trailer", rents.optionsID);
            ViewBag.rentID = new SelectList(db.TechMessages, "rentID", "description", rents.rentID);
            ViewBag.userID = new SelectList(db.Users, "UserID", "FIO", rents.userID);
            return View(rents);
        }

        // GET: Rents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rents rents = db.Rents.Find(id);
            if (rents == null)
            {
                return HttpNotFound();
            }
            return View(rents);
        }

        // POST: Rents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rents rents = db.Rents.Find(id);
            db.Rents.Remove(rents);
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

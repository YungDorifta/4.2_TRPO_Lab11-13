using ContosoSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContosoSite.Controllers
{
    public class HomeController : Controller
    {
        private AutoRentDatabaseEntitiesActual db = new AutoRentDatabaseEntitiesActual();

        //начальная страница
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //страница регистрации
        public ActionResult Registration()
        {
            ViewBag.Message = "Your registration page.";

            return View();
        }

        //страница для авторизированных пользователей
        public ActionResult ForAuthorized()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration([Bind(Include = "FIO, email, phone, password")] Users users)
        {
            if (ModelState.IsValid)
            {
                InsertUser(users);
                return RedirectToAction("Index");
            }

            return View(users);
        }

        //выполнение хранимой процедуры для регистрации
        public ActionResult InsertUser([Bind(Include = "UserID,FIO,role,email,phone,password")] Users users)
        {
            try
            {
                // Verification.    
                if (ModelState.IsValid)
                {
                    // Initialization.    
                    var regInfo = this.db.Insert_User(users.email, users.phone, users.password, users.FIO).ToList();
                    // Verification.    
                    if (regInfo != null && Convert.ToInt32(regInfo[0]) != -1)
                    {
                        //SAVING CHANGES TO DATABASE
                        db.SaveChanges();
                        //    return RedirectToAction("Index", "Home");
                        return RedirectToAction("Home", "Index");

                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Пользователь с таким именем/e-mail/телефоном уже существует!");
                    }
                }
            }
            catch (Exception ex)
            { }

            return this.View(users);
        }
    }
}
using ContosoSite.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
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
        
        //о приложении
        public ActionResult About()
        {
            ViewBag.Message = "Описание приложения:";

            return View();
        }

        //контакты 
        public ActionResult Contact()
        {
            ViewBag.Message = "Контакты создателя сайта:";

            return View();
        }




        //страница регистрации
        public ActionResult Registration()
        {
            ViewBag.Message = "Здесь Вы можете создать новый аккаунт:";

            return View();
        }

        //Регистрация
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration([Bind(Include = "FIO, email, phone, password")] Users users)
        {
            if (ModelState.IsValid)
            {
                InsertUser(users);
                // Login In.    
                SignInUser(users.email, false);
                return RedirectToAction("Index");
            }

            return View(users);
        }

        //выполнение ХП регистрация
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
                        ModelState.AddModelError(string.Empty, "Пользователь с таким именем/эл. почтой/телефоном уже существует!");
                    }
                }
            }
            catch (Exception ex)
            {
                // Info  
                throw ex;
            }

            return this.View(users);
        }



        //страница авторизации
        public ActionResult Authorization(string returnUrl)
        {
            ViewBag.Message = "Войдите в аккаунт здесь:";

            try
            {
                // Verification.    
                if (this.Request.IsAuthenticated)
                {
                    // Info.    
                    return this.RedirectToLocal(returnUrl);
                }
            }
            catch (Exception ex)
            {
                // Info  
                throw ex;
            }
            // Info.    
            return View();
        }

        //авторизация
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Authorization(Users model, string returnUrl)
        {
            try
            {
                // Verification.    
                if (ModelState.IsValid)
                {
                    // Initialization.    
                    var loginInfo = this.db.LoginByEmailPassword(model.email, model.password).ToList();
                    // Verification.    
                    if (loginInfo != null && loginInfo.Count() > 0)
                    {
                        // Initialization.    
                        var logindetails = loginInfo.First();
                        // Login In.    
                        SignInUser(logindetails.email, false);
                        // Info.    
                        return RedirectToLocal(returnUrl);
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Неправильно введена эл. почта и/или пароль");
                    }
                }
            }
            catch (Exception ex)
            {
                // Info  
            }
            // If we got this far, something failed, redisplay form    
            return View(model);
        }

        //выполнение ХП авторизация
        private void SignInUser(string username, bool isPersistent)
        {
            // Initialization.    
            var claims = new List<Claim>();
            try
            {
                // Setting    
                claims.Add(new Claim(ClaimTypes.Name, username));
                var claimIdenties = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);
                var ctx = Request.GetOwinContext();
                var authenticationManager = ctx.Authentication;
                // Sign In.    
                authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, claimIdenties);
            }
            catch (Exception ex)
            {
                // Info    
                throw ex;
            }
        }

        //выход из аккаунта
        public ActionResult LogOff()
        {
            {
                try
                {
                    // Setting.    
                    var ctx = Request.GetOwinContext();
                    var authenticationManager = ctx.Authentication;
                    // Sign Out.    
                    authenticationManager.SignOut();
                }
                catch (Exception ex)
                {
                    // Info   
                    throw ex;
                }
                // Info.    
                return this.RedirectToAction("Authorization", "Home");
            }

        }




        //все таблицы (для авторизированного администратора)
        public ActionResult AllTables()
        {
            return View();
        }

        //Переход к локальной странице
        private ActionResult RedirectToLocal(string returnUrl)
        {
            try
            {
                // Verification.    
                if (Url.IsLocalUrl(returnUrl))
                {
                    // Info.    
                    return this.Redirect(returnUrl);
                }
            }
            catch (Exception ex)
            {
                // Info  
                throw ex;
            }
            // Info.    
            return this.RedirectToAction("Index", "Home");
        }

    }
}
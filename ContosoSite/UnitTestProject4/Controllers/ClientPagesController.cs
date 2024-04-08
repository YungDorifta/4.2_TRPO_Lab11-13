using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContosoSite.Controllers
{
    public class ClientPagesController : Controller
    {
        public ActionResult FormirovanieZakaza()
        {
            return View();
        }
        
        public ActionResult ProsmotrAvto()
        {
            return View();
        }
        
        public ActionResult ProsmotrZakazov()
        {
            return View();
        }
    }
}
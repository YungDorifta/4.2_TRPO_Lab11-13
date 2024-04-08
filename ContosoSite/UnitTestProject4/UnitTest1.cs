using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using ContosoSite;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContosoSite.Controllers;

namespace UnitTestProject4
{
    [TestClass]
    public class UnitTest1
    {
        //проверка на создание
        [TestMethod]
        public void TestMethod1()
        {
            UsersController controller = new UsersController();
            ViewResult result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);
        }





    }
}

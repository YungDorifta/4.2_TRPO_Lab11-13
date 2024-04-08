using ContosoSite.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ContosoSite.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        /// <summary>
        /// Тест на создание главной страницы
        /// </summary>
        [TestMethod]
        public void HomeIndex()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
        
        /// <summary>
        /// Тест на вызов исключения при попытке перейти на неуказанную страницу
        /// </summary>
        [TestMethod]
        public void RedirectToNotStatedTest()
        {
            HomeController controller = new HomeController();
            try
            {
                ViewResult result = controller.RedirectToLocal(null) as ViewResult;
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message.Contains("Ссылка на объект не указывает на экземпляр"));
            }
            
        }

        
        /// <summary>
        /// Тест на вывод правильного сообщения
        /// </summary>
        [TestMethod]
        public void RedirectToStatedTest()
        {
            HomeController controller = new HomeController();
            ViewResult result = controller.About() as ViewResult;

            Assert.AreEqual("Описание приложения:", result.ViewBag.Message);
        }
    }
}

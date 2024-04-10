using System;
using System.Web.Mvc;
using ContosoSite.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ContosoSite.Tests
{
    [TestClass]
    public class UnitTest1
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

        /*
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




       /// <summary>
       /// Тест на вывод правильного сообщения
       /// </summary>
       [TestMethod]
       public void CheckEditTest()
       {
           AutoparksController controller = new AutoparksController();
           HttpNotFoundResult result = controller.Delete(100) as HttpNotFoundResult;

           Assert.AreEqual(new HttpNotFoundResult(), result);
       }
       */
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using crud;
using crud.Controllers;

namespace UnitTesting
{
    [TestClass]
    public class ControllerTests
    {
        [TestMethod]
        public void Index()
        {
            LoginController controller = new LoginController();

            ViewResult result = controller.Index() as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Signup()
        {
            LoginController controller = new LoginController();

            ViewResult result = controller.Signup() as ViewResult;

            Assert.IsNotNull(result);
        }
    }
}

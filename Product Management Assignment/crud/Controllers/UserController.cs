using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using log4net;
namespace crud.Controllers
{
    public class UserController : Controller
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(UserController));

        // GET: User
        public ActionResult Index()
        {

            if (Session["UserId"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                return View();

            }
        }
        public ActionResult Logout()
        {
            try
            {


                Session.Abandon();
                Log.Debug("log4net Debug Level - Logout Controller");
                Log.Info("log4net Info Level - Logout Controller");
                Log.Warn("log4net Warn Level - Logout Controller");
                return RedirectToAction("Index", "Login");
            }
            catch (Exception ex)
            {
                Log.Error("log4net Error Level - Logout Controller exception", ex);
                Log.Fatal("log4net Fatal Level - Logout Controller exception", ex);
                throw;
            }
            }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using crud.Models;
using log4net;

namespace crud.Controllers
{
    public class LoginController : Controller
    {
        SignupLoginEntities db = new SignupLoginEntities();
        private static readonly ILog Log = LogManager.GetLogger(typeof(LoginController));

        public ActionResult Index()
        {
            try
            {
                Log.Debug("LoginController Index - log4net Debug Level");
                Log.Info("LoginController Index - log4net Info Level");
                Log.Warn("LoginController Index - log4net Warn Level");

                return View();
            }
            catch (Exception ex)
            {
                Log.Error("LoginController Index - log4net Error Level", ex);
                Log.Fatal("LoginController Index - log4net Fatal Level", ex);
                throw;
            }
            }

        [HttpPost]
        public ActionResult Index(user u)
        {
            // checking email and password for login.
            var user = db.users.Where(model => model.Email == u.Email && model.Password == u.Password).FirstOrDefault();
            if (user != null)
            {
                Session["UserID"] = u.Id.ToString();
                Session["Email"] = u.Email.ToString();
                Session["Username"] = user.UserName.ToString();

                TempData["LoginSuccessMessage"] = "<script>alert('Login Successfull')</script>";
                return RedirectToAction("Index", "User");
            }
            else
            {
                ViewBag.ErrorMessage= "<script>alert('Email-ID or Password is incorrect.')</script>";
                return View();
            }
         }

        public ActionResult Signup()
        {
            try
            {
                Log.Debug("log4net Debug Level - Signup Get method");
                Log.Info("log4net Info Level - Signup Get method");
                Log.Warn("log4net Warn Level - Level Signup Get");

                return View();
            }
            catch (Exception ex)
            {
                Log.Error("log4net Error Level - Signup Get method", ex);
                Log.Fatal("log4net Fatal Level - Signup Get method", ex);
                throw;

            }
        }
        [HttpPost]
        public ActionResult Signup(user u)
        {
            try
            {
                if (ModelState.IsValid == true)
                {
                    db.users.Add(u);
                    int a = db.SaveChanges();
                    if (a > 0)
                    {
                        ViewBag.InsertMessage = "<script>alert('Registered Successfully')</script>";
                        ModelState.Clear();
                    }
                    else
                    {
                        ViewBag.InsertMessage = "<script>alert('Registered Failed')</script>";

                    }
                }
                Log.Debug("log4net Debug Level - Signup try block Post method");
                Log.Info("log4net Info Level - Signup try block Post method");
                Log.Warn("log4net Warn Level - Signup try block Post method");

                return View();
            }
            catch (Exception ex)
            {
                Log.Error("log4net Error Level - Signup catch block Post method", ex);
                Log.Fatal("log4net Fatal Level - Signup catch block Post method", ex);
                throw;
            }
        }

    }
}
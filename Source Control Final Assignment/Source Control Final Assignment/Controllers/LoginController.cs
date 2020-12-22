using log4net;
using Source_Control_Final_Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Source_Control_Final_Assignment.Controllers
{
    public class LoginController : Controller
    {
        private static log4net.ILog Log { get; set; }
        ILog log = log4net.LogManager.GetLogger(typeof(LoginController));

        SignupEntities db = new SignupEntities();

        // GET: Login

        public ActionResult Index()
        {
            log.Debug("Debug message");
            log.Info("Info message");
            log.Warn("Warn message");
            log.Fatal("Fatal message");

            return View();
        }

        [HttpPost]
        public ActionResult Index(user u)
        {
            var user = db.users.Where(model => model.username == u.username && model.password == u.password).FirstOrDefault();
            if(user != null)
            {
                Session["UserId"] = user.Id.ToString();
                Session["Username"] = user.username.ToString();
                Session["FirstName"] = user.firstName.ToString();
                Session["LastName"] = user.lastName.ToString();
                Session["Age"] = user.age.ToString();
                Session["Gender"] = user.gender.ToString();
                Session["Email"] = user.email.ToString();

                log.Info("Info message - login successfully.");
                TempData["LoginSuccessMessage"] = "<script>alert('Login Successfully.')</script>";
                return RedirectToAction("Index", "User");
            }
            else
            {
                log.Error("Error message - Username or Password is incorrect.");
                ViewBag.ErrorMessage = "<script>alert('Username or Password is Incorrect.')</script>";
                return View();
            }

        }
        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Signup(user u)
        {
            if(ModelState.IsValid == true)
            {
                db.users.Add(u);
                int a = db.SaveChanges();
                if (a > 0)
                {
                    ViewBag.InsertMessage = "<script>alert('Registered Successfully.')</script>";
                    ModelState.Clear();
                }
                else
                {
                    ViewBag.InsertMessage = "<script>alert('Registration Failed.')</script>";
                }
            }
            return View();
        }
    }
}
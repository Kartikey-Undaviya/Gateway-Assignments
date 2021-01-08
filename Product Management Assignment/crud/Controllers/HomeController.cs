using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using crud.Models;
using System.IO;
using System.Data.Entity;
using PagedList;
using PagedList.Mvc;
using log4net;

namespace crud.Controllers
{
    public class HomeController : Controller
    {
        CrudDbEntities db = new CrudDbEntities();
        private static readonly ILog Log = LogManager.GetLogger(typeof(HomeController));

        public ActionResult Index(string SearchBy, string search, int? page, string sortBy)
        {
            try
            {
                ViewBag.SortNameParameter = string.IsNullOrEmpty(sortBy) ? "Name desc" : "";
                ViewBag.SortCategoryParameter = sortBy == "Category" ? "Category desc" : "Category";
                var product = db.products.AsQueryable();

                // search by Product Name and Category.
                
                if (SearchBy == "Product_name")
                {
                    product = product.Where(model => model.Product_name.StartsWith(search) || search == null);
                }
                else
                {
                    product = product.Where(model => model.Product_Category == search || search == null);
                }
                switch (sortBy)
                {
                    case "Name desc":
                        product = product.OrderByDescending(model => model.Product_name);
                        break;

                    case "Category desc":
                        product = product.OrderByDescending(model => model.Product_Category);
                        break;

                    case "Category":
                        product = product.OrderBy(model => model.Product_Category);
                        break;

                    default:
                        product = product.OrderBy(model => model.Product_name);
                        break;

                }

                Log.Debug("log4net Debug Level - Home Controller try block");
                Log.Info("log4net Info Level - Home Controller try block");
                Log.Warn("log4net Warn Level - Home Controller try block");
                
                return View(product.ToPagedList(page ?? 1, 3));
            }
            catch(Exception ex)
            {
                Log.Error("log4net Error Level - Home Controller Exception", ex);
                Log.Fatal("log4net Fatal Level - Home Controller Exception", ex);
                throw;
            }
            }
        public ActionResult Create()
        {
            try
            {
                Log.Debug("log4net Debug Level - Create Controller try block Get method");
                Log.Info("log4net Info Level  - Create Controller try block Get method");
                Log.Warn("log4net Warn Level  - Create Controller try block Get method");
                return View();
            }
            catch (Exception ex)
            {
                Log.Error("log4net Error Level - Create Controller Catch block Get method", ex);
                Log.Fatal("log4net Fatal Level - Create Controller Catch block Get method", ex);
                throw;
            }
           
        }

        [HttpPost]
        public ActionResult Create(product p)
        {
            // adding Product Details.
            try
            {
                if (ModelState.IsValid == true)
                {
                    string filename = Path.GetFileNameWithoutExtension(p.SImageFile.FileName);
                    string extension = Path.GetExtension(p.SImageFile.FileName);
                    HttpPostedFileBase postedFile = p.SImageFile;
                    int length = postedFile.ContentLength;

                    string filename1 = Path.GetFileNameWithoutExtension(p.LImageFile.FileName);
                    string extension1 = Path.GetExtension(p.LImageFile.FileName);
                    HttpPostedFileBase postedFile1 = p.LImageFile;
                    int length1 = postedFile.ContentLength;

                    if (extension.ToLower() == ".jpg" || extension.ToLower() == ".jpeg" || extension.ToLower() == ".png" && extension1.ToLower() == ".png" || extension1.ToLower() == ".jpeg" || extension1.ToLower() == ".jpg")
                    {
                        if (length <= 1000000 && length1 <= 100000000)
                        {
                            filename = filename + extension;
                            p.Small_Image_path = "~/SImages/" + filename;
                            filename = Path.Combine(Server.MapPath("~/SImages/"), filename);
                            p.SImageFile.SaveAs(filename);

                            filename1 = filename1 + extension1;
                            p.Large_Image_path = "~/LImages/" + filename1;
                            filename1 = Path.Combine(Server.MapPath("~/LImages/"), filename1);
                            p.LImageFile.SaveAs(filename1);

                            db.products.Add(p);
                            int a = db.SaveChanges();

                            if (a > 0)
                            {
                                TempData["CreateMessage"] = "<script>alert('Data Inserted Successfully') </script>";
                                ModelState.Clear();
                                return RedirectToAction("index", "Home");
                            }
                            else
                            {
                                TempData["CreateMessage"] = "<script>alert('Data Not Inserted') </script>";

                            }
                        }
                        else
                        {
                            TempData["SizeMessage"] = "<script>alert('Image Size Should be less than 5 MB') </script>";

                        }

                    }
                    else
                    {
                        TempData["ExtensionMessage"] = "<script>alert('Format Not Supported') </script>";
                    }
                }
                Log.Debug("log4net Debug Level - Create Controller try block post method");
                Log.Info("log4net Info Level - Create Controller try block post method");
                Log.Warn("log4net Warn Level - Create Controller try block post method");
              
                return View();
            }
            catch(Exception ex)
            {
                Log.Error("log4net Error Level - Create Controller Catch block post method", ex);
                Log.Fatal("Hi I am log4net Fatal Level - Create Controller Catch block post method", ex);
                throw;
            }

            }

        public ActionResult Edit(int id)
        {
            try
            {
                var productrow = db.products.Where(model => model.Product_Id == id).FirstOrDefault();
                Session["Simage"] = productrow.Small_Image_path;
                Session["Limage"] = productrow.Large_Image_path;

                Log.Debug("log4net Debug Level - Edit Controller try block get method");
                Log.Info("log4net Info Level - Edit Controller try block  get method");
                Log.Warn("log4net Warn Level - Edit Controller try block get method");

                return View(productrow);
            }
            catch(Exception ex)
            {
                Log.Error("log4net Error Level - Edit Controller Catch block get method", ex);
                Log.Fatal("log4net Fatal Level - Edit Controller Catch block get method", ex);
                throw;

            }
        }
        [HttpPost]
        public ActionResult Edit(product p)
        {
            // Editing Product Details.

            if (ModelState.IsValid == true)
            {
                if (p.SImageFile != null & p.LImageFile != null)
                {
                    string filename = Path.GetFileNameWithoutExtension(p.SImageFile.FileName);
                    string extension = Path.GetExtension(p.SImageFile.FileName);
                    HttpPostedFileBase postedFile = p.SImageFile;
                    int length = postedFile.ContentLength;
                    string filename1 = Path.GetFileNameWithoutExtension(p.LImageFile.FileName);
                    string extension1 = Path.GetExtension(p.LImageFile.FileName);
                    HttpPostedFileBase postedFile1 = p.LImageFile;
                    int length1 = postedFile.ContentLength;

                    if (extension.ToLower() == ".jpg" || extension.ToLower() == ".jpeg" || extension.ToLower() == ".png")
                    {
                        if (length <= 1000000)
                        {
                            filename = filename + extension;
                            p.Small_Image_path = "~/SImages/" + filename;
                            filename = Path.Combine(Server.MapPath("~/SImages/"), filename);
                            p.SImageFile.SaveAs(filename);

                            filename1 = filename1 + extension1;
                            p.Large_Image_path = "~/LImages/" + filename1;
                            filename1 = Path.Combine(Server.MapPath("~/LImages/"), filename1);
                            p.SImageFile.SaveAs(filename1);

                            db.Entry(p).State = EntityState.Modified;
                            int a = db.SaveChanges();

                            if (a > 0)
                            {
                                string S_image_path = Request.MapPath(Session["Simage"].ToString());
                                string L_image_path = Request.MapPath(Session["Limage"].ToString());

                                if (System.IO.File.Exists(S_image_path) & System.IO.File.Exists(L_image_path))
                                {
                                    System.IO.File.Delete(S_image_path);
                                    System.IO.File.Delete(L_image_path);

                                }
                                TempData["UpdateMessage"] = "<script>alert('Data Updated Successfully') </script>";
                                ModelState.Clear();
                                return RedirectToAction("index", "Home");
                            }
                            else
                            {
                                TempData["UpdateMessage"] = "<script>alert('Data Not Updated') </script>";
                            }
                        }
                        else
                        {
                            TempData["SizeMessage"] = "<script>alert('Image Size Should be less than 5 MB') </script>";
                        }

                    }
                    else
                    {
                        TempData["ExtensionMessage"] = "<script>alert('Format Not Supported') </script>";
                    }
                }
                else
                {
                    p.Small_Image_path = Session["Simage"].ToString();
                    p.Large_Image_path = Session["Limage"].ToString();

                    db.Entry(p).State = EntityState.Modified;
                    int a = db.SaveChanges();

                    if (a > 0)
                    {
                        TempData["UpdateMessage"] = "<script>alert('Data Updated Successfully') </script>";
                        ModelState.Clear();
                        return RedirectToAction("index", "Home");
                    }
                    else
                    {
                        TempData["UpdateMessage"] = "<script>alert('Data Not Updated') </script>";


                    }
                }

            }
            return View();
        }
        public ActionResult Delete(int id)
        {
            // Delete the Product.
            if (id > 0)
            {
                var productraw = db.products.Where(model => model.Product_Id == id).FirstOrDefault();
                if (productraw != null)
                {
                    db.Entry(productraw).State = EntityState.Deleted;

                    int a = db.SaveChanges();
                    if (a > 0)
                    {

                        TempData["DeleteMessage"] = "<script>alert('Data Deleted Succesfully')</script>";
                        string S_image_path = Request.MapPath(productraw.Small_Image_path.ToString());
                        string L_image_path = Request.MapPath(productraw.Large_Image_path.ToString());

                        if (System.IO.File.Exists(S_image_path) & System.IO.File.Exists(L_image_path))
                        {
                            System.IO.File.Delete(S_image_path);
                            System.IO.File.Delete(L_image_path);

                        }

                    }
                    else
                    {

                        TempData["DeleteMessage"] = "<script>alert('Data Not Deleted')</script>";

                    }

                }

            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Details(int id)
        {
            var productraw = db.products.Where(model => model.Product_Id == id).FirstOrDefault();
            Session["image1"] = productraw.Small_Image_path.ToString();
            Session["image2"] = productraw.Large_Image_path.ToString();

            return View(productraw);
        }

        [HttpPost]
        public ActionResult Index(FormCollection formCollection)
        {
            string[] ids = formCollection["ID"].Split(new char[] { ',' });
            foreach (string id in ids)
            {
                var employee = this.db.products.Find(int.Parse(id));
                this.db.products.Remove(employee);
                this.db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }

}
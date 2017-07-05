using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DB;
using MEGA.Models;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using PagedList;
using System.IO;

namespace MEGA.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {

        // GET: Products

        public ActionResult Index()
        {
            return View();
        }

        
        [HttpGet]
        public JsonResult GetUsers()
        {
            using (var context = new ApplicationDbContext())
            {
            
                var jsonData = new
                {
                    rows = (
                      from emp in context.Users.ToList()
                      select new
                      {
                          id = emp.Id.ToString(),
                          cell = new string[] {
                          emp.UserName.ToString(),
                          emp.PhoneNumber == null ? "Нет номера телефона": emp.PhoneNumber,
                          emp.Email.ToString()
                          }
                      }).ToArray()
                };
                return Json(jsonData, JsonRequestBehavior.AllowGet);
            }

        }
        public ActionResult Users()
        {
            return View();
        }
        [HttpGet]
        public ActionResult ProductsCreate()
        {
            using (var context = new ApplicationDbContext())
            {
                return View(context.GoodsTypes.ToList());
            }
            
        }
        [HttpPost]
        public ActionResult ProductsCreate(int ID,string name,string Information, HttpPostedFileBase uploadImage,float Price)
        {
            Product pro = new Product();
           pro.GoodsTypes. = ID;
            pro.Name = name;
            pro.Information = Information;
            pro.Price = Price;
            if (uploadImage != null)
            {
                // получаем имя файла
                string fileName = System.IO.Path.GetFileName(uploadImage.FileName);
                // сохраняем файл в папку Files в проекте
                uploadImage.SaveAs(Server.MapPath("~/Files/" + fileName));
                pro.Picture = "../../Files/" + fileName;
            }
            
                using (var context = new ApplicationDbContext())
                {
                        context.Products.Add(pro);
                        context.SaveChanges();
                }
                return RedirectToAction("ProductAll");
        }
        public ActionResult ProductDelete(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                Product b = context.Products.Find(id);
                if (b == null)
                {
                    return HttpNotFound();
                }
                context.Products.Remove(b);
                context.SaveChanges();
            }
            return RedirectToAction("ProductAll");
        }
        public ActionResult ProdectDetails(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                Product b = context.Products.Find(id);
                if (b == null)
                {
                    return HttpNotFound();
                }
                return View(b);
            }
            
        }
        [HttpGet]
        public ActionResult ProductEdit(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                Product b = context.Products.Find(id);
                if (b == null)
                {
                    return HttpNotFound();
                }
                return View(b);
            }
        }
        [HttpPost]
        public ActionResult ProductEdit(Product product, HttpPostedFileBase uploadImage)
        {
            if (uploadImage != null)
            {
                // получаем имя файла
                string fileName = System.IO.Path.GetFileName(uploadImage.FileName);
                // сохраняем файл в папку Files в проекте
                uploadImage.SaveAs(Server.MapPath("~/Files/" + fileName));
                product.Picture = "../../Files/" + fileName;
            }
            using (var context = new ApplicationDbContext())
            {
                context.Entry(product).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("ProductAll");
            }
        }
        public ActionResult ProductAll(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 3;
            using (var context = new ApplicationDbContext())
            {

                return View(context.Products.ToList().ToPagedList(pageNumber, pageSize));
            }
           
        }
        public ActionResult NewsAll(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 3;
            using (var context = new ApplicationDbContext())
            {

                return View(context.Newss.ToList().ToPagedList(pageNumber, pageSize));
            }
        }
        [HttpGet]
        public ActionResult NewsCreate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewsCreate(News news, HttpPostedFileBase uploadImage)
        {
            if (uploadImage != null)
            {
                // получаем имя файла
                string fileName = System.IO.Path.GetFileName(uploadImage.FileName);
                // сохраняем файл в папку Files в проекте
                uploadImage.SaveAs(Server.MapPath("~/Files/" + fileName));
                news.Picture = "../../Files/" + fileName;
            }
            using (var context = new ApplicationDbContext())
            {
                if (news == null)
                {
                    return HttpNotFound();
                }
                context.Newss.Add(news);
                context.SaveChanges();
                return RedirectToAction("NewsAll");
            }
        }
        public ActionResult NewsDetails(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                News b = context.Newss.Find(id);
                if (b == null)
                {
                    return HttpNotFound();
                }
                return View(b);
            }
        }
        [HttpGet]
        public ActionResult NewsEdit(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                News b = context.Newss.Find(id);
                if (b == null)
                {
                    return HttpNotFound();
                }
                return View(b);
            }
        }
        [HttpPost]
        public ActionResult NewsEdit(News news, HttpPostedFileBase uploadImage)
        {
            if (uploadImage != null)
            {
                // получаем имя файла
                string fileName = System.IO.Path.GetFileName(uploadImage.FileName);
                // сохраняем файл в папку Files в проекте
                uploadImage.SaveAs(Server.MapPath("~/Files/" + fileName));
                news.Picture = "../../Files/" + fileName;
            }
            using (var context = new ApplicationDbContext())
            {
                context.Entry(news).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("NewsAll");
            }
        }
        public ActionResult NewsDelete(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                News b = context.Newss.Find(id);
                if (b == null)
                {
                    return HttpNotFound();
                }
                context.Newss.Remove(b);
                context.SaveChanges();
            }
            return RedirectToAction("NewsAll");
        }
        public ActionResult AdvertisingAll(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 3;
            using (var context = new ApplicationDbContext())
            {

                return View(context.Advertisings.ToList().ToPagedList(pageNumber, pageSize));
            }
        }
        [HttpGet]
        public ActionResult AdvertisingCreate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdvertisingCreate(Advertising news)
        {
            using (var context = new ApplicationDbContext())
            {
                if (news == null)
                {
                    return HttpNotFound();
                }
                context.Advertisings.Add(news);
                context.SaveChanges();
                return RedirectToAction("AdvertisingAll");
            }
        }
        public ActionResult AdvertisingDetails(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                Advertising b = context.Advertisings.Find(id);
                if (b == null)
                {
                    return HttpNotFound();
                }
                return View(b);
            }
        }
        [HttpGet]
        public ActionResult AdvertisingEdit(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                Advertising b = context.Advertisings.Find(id);
                if (b == null)
                {
                    return HttpNotFound();
                }
                return View(b);
            }
        }
        [HttpPost]
        public ActionResult AdvertisingEdit(Advertising news)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Entry(news).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("AdvertisingAll");
            }
        }
        public ActionResult AdvertisingDelete(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                Advertising b = context.Advertisings.Find(id);
                if (b == null)
                {
                    return HttpNotFound();
                }
                context.Advertisings.Remove(b);
                context.SaveChanges();
            }
            return RedirectToAction("AdvertisingAll");
        }
    }
}

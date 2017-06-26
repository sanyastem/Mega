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
        public ActionResult ProductsCreate(int type, string Name,string Information,byte[] images,float Price)
        {
            Product pro = new Product();
            pro.GoodsTypes.Id = type;
            pro.Name = Name;
            pro.Information = Information;
            pro.Picture = images;
            pro.Price = Price;
            using (var context = new ApplicationDbContext())
            {
                if (pro!= null)
                {
                    context.Products.Add(pro);
                    context.SaveChanges();
                }
            }
            return View();
        }
        public ActionResult ProductAll()
        {
            using (var context = new ApplicationDbContext())
            {
                return View(context.Products.ToList());
            }

            
        }
    }
}

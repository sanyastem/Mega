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
        private ApplicationDbContext db = new ApplicationDbContext();

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
        [HttpGet]
        public JsonResult GetProducts()
        {
            using (var context = new ApplicationDbContext())
            {

                var jsonData = new
                {
                    rows = (
                      from emp in context.Products.ToList()
                      select new
                      {
                          id = emp.Id.ToString(),
                          cell = new string[] {
                          emp.Name.ToString(),
                          emp.Information.ToString(),
                          emp.Price.ToString(),
                          emp.Order.ToString()
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

        public ActionResult ProductAll()
        {
            return View();
        }
    }
}

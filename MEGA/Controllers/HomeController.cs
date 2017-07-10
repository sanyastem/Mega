using DB;
using MEGA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MEGA.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (var context = new ApplicationDbContext())
            {
                ViewBag.Advertisings = context.Advertisings.ToList();
                List<Product> pr = new List<Product>();
                var rand = new Random();
                rand.Next();
                ViewBag.pechat1 = context.GoodsTypes.Where(x => x.Id == 1).ToList();
                ViewBag.pechat2 = context.GoodsTypes.Where(x => x.Id == 2).ToList();
                ViewBag.pechat3 = context.GoodsTypes.Where(x=>x.Id == 3).ToList();
                ViewBag.one3 = context.Products.Where(x => x.GoodsTypeId == 4).ToList();
                ViewBag.one4 = context.Products.Where(x => x.GoodsTypeId == 5).ToList();
                ViewBag.suvenir = context.GoodsTypes.ToList();
                ViewBag.News = context.Newss.OrderByDescending(x => x.Id).ToList();
                return View();
            }
            
            
        }
        public ActionResult NewsDitails(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                return View(context.Newss.Where(x=>x.Id == id).ToList());
            }
        }
        public ActionResult NewsAll()
        {
            using (var context = new ApplicationDbContext())
            {
                return View(context.Newss.ToList());
            }
        }
        public ActionResult Services()
        {
            return View();
        }
        public ActionResult AllDeteils(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                return View(context.Products.Where(x=>x.GoodsTypeId == id).ToList());
            }
            
        }
        public ActionResult Ditails(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                return View(context.Products.Where(x=>x.Id == id).ToList());
            }
            
        }
        public ActionResult Search(string text)
        {
            string query = string.Format("SELECT * FROM Products WHERE Products.Name like '%" + text+ "%' OR Products.Information like '%" + text + "%'");
            using (var context = new ApplicationDbContext())
            {
                return View(context.Products.SqlQuery(query).ToList());
            }
            
        }

    }
}
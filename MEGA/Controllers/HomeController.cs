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
                
                ViewBag.one = context.Products.Where(x => x.GoodsTypeId == 1).ToList();
                ViewBag.one1 = context.Products.Where(x => x.GoodsTypeId == 2).ToList();
                ViewBag.one2 = context.Products.Where(x => x.GoodsTypeId == 3).ToList();
                ViewBag.one3 = context.Products.Where(x => x.GoodsTypeId == 4).ToList();
                ViewBag.one4 = context.Products.Where(x => x.GoodsTypeId == 5).ToList();
                ViewBag.one5 = context.Products.Where(x => x.GoodsTypeId == 6).ToList();
                ViewBag.one6 = context.Products.Where(x => x.GoodsTypeId == 7).ToList();
                ViewBag.one7 = context.Products.Where(x => x.GoodsTypeId == 8).ToList();
                ViewBag.one8 = context.Products.Where(x => x.GoodsTypeId == 9).ToList();
                ViewBag.one9 = context.Products.Where(x => x.GoodsTypeId == 10).ToList();
                ViewBag.one10 = context.Products.Where(x => x.GoodsTypeId == 11).ToList();
                ViewBag.one11 = context.Products.Where(x => x.GoodsTypeId == 12).ToList();
                ViewBag.one12 = context.Products.Where(x => x.GoodsTypeId == 13).ToList();
                ViewBag.one13 = context.Products.Where(x => x.GoodsTypeId == 14).ToList();
                ViewBag.one14 = context.Products.Where(x => x.GoodsTypeId == 15).ToList();
                ViewBag.one15 = context.Products.Where(x => x.GoodsTypeId == 16).ToList();
                ViewBag.one16 = context.Products.Where(x => x.GoodsTypeId == 17).ToList();
                ViewBag.one17 = context.Products.Where(x => x.GoodsTypeId == 18).ToList();
                ViewBag.one18 = context.Products.Where(x => x.GoodsTypeId == 19).ToList();
                ViewBag.one19 = context.Products.Where(x => x.GoodsTypeId == 20).ToList();
                ViewBag.one20 = context.Products.Where(x => x.GoodsTypeId == 21).ToList();
                ViewBag.one21 = context.Products.Where(x => x.GoodsTypeId == 22).ToList();
                ViewBag.one22 = context.Products.Where(x => x.GoodsTypeId == 23).ToList();

                return View();
            }
            
        }

    }
}
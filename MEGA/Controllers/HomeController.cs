using DB;
using MEGA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace MEGA.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {

            
        }
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
                ViewBag.Counts = context.Products.SqlQuery(query).ToList().Count;
                return View(context.Products.SqlQuery(query).ToList());
            }
            
        }
        public ActionResult Basket(int id,int col)
        {
            if (User.Identity.IsAuthenticated)
            {
                 using (var context = new ApplicationDbContext())
                {
                    Order ord = new Order();
                    ord.ProductId = id;
                    ord.oformlen = false;
                    ord.Status = false;
                    ord.DateOrder = DateTime.Now;
                    ord.AspNetUserId = Guid.Parse(User.Identity.GetUserId());
                    context.Orders.Add(ord);
                    context.SaveChanges();
                    return RedirectToAction("Ditails/"+id);
                }
            }
            else
            {
                return Redirect("~/Account/Login");
            }
        }
        public ActionResult BasketAll()
        {
            if (User.Identity.IsAuthenticated)
            {
                using (var context = new ApplicationDbContext())
                {
                    Guid users = Guid.Parse(User.Identity.GetUserId());

                    var s = context.Orders.Where(x => x.AspNetUserId == users && x.oformlen == false).ToList();
                    List<Product> odi = new List<Product>();
                    foreach (var item in s)
                    {
                        foreach (var items in context.Products.ToList())
                        {
                            if (item.ProductId == items.Id)
                            {
                                odi.Add(items);
                            }
                        }
                    }
                        return View(odi);
                }
            }
            else
            {
                return Redirect("~/Account/Login");
            }
        }
        public ActionResult BasketBuy(int[] id)
        {
            List<Order> ord = new List<Order>();
            using (var context = new ApplicationDbContext())
            {
                foreach (var item in id)
                {
                    ord.AddRange(context.Orders.Where(x => x.ProductId == item).ToList());
                    
                }
                foreach (var item in ord)
                {
                    item.oformlen = true;
                    context.Entry(item).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
            
            return Redirect("~/Home/BasketAll");
        }

        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Constructor()
        {
            return View();
        }

    }
}
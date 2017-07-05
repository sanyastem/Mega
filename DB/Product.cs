using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Information { get; set; }
        public float Price { get; set; }
        public string Picture { get; set; }
        public GoodsType GoodsTypes { get; set; }
        public ICollection<Order> Orders { get; set; }
        public Product()
        {
            GoodsTypes = new GoodsType();
            Orders = new List<Order>();
        }
    }
}
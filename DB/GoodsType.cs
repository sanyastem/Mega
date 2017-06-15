using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public class GoodsType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Product> Product { get; set; }
        public GoodsType()
        {
            Product = new List<Product>();
        }
    }
}
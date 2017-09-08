using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public class Slider
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public int IdProduct { get; set; }
        public ICollection<Product> Product { get; set; }
        public Slider()
        {
            Product = new List<Product>();
        }
    }
}

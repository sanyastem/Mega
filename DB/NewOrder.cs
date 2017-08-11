using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public class NewOrder
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public decimal Price { get; set; }
        public string Opis { get; set; } 
        public ICollection<Order> Orders { get; set; }
        public NewOrder()
        {
            Orders = new List<Order>();
        }

    }
}
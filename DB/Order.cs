using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public class Order
    {
        public int Id { get; set; }

        public Guid AspNetUserId { get; set; }
        public float Price { get; set; }
        public bool Status { get; set; }
        public int Quantity { get; set; }
        public DateTime DateOrder { get; set; }

    }
}
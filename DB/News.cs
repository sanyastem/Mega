using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public class News
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }
        public string Picture { get; set; }
    }
}
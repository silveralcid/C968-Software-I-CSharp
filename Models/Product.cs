using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C968_Software_I_CSharp.Models
{
    public class Product
    {
        public int? ProductID { get; set; }
        public string ProductName { get; set; }
        public int? ProductInventory { get; set; }
        public decimal? ProductPrice { get; set; }
        public int? ProductMin { get; set; }
        public int? ProductMax { get; set; }


    }
}

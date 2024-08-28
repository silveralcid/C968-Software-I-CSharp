using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C968_Software_I_CSharp.Models
{
    public abstract class Part
    {
        public int PartID { get; set; }
        public string PartName { get; set; }
        public decimal PartPrice { get; set; }
        public int PartInventory { get; set; }
        public int PartMin { get; set; }
        public int PartMax { get; set; }


        public Part(int id, string name, decimal price, int inventory, int min, int max)
        {
            this.PartID = id;
            this.PartName = name;
            this.PartPrice = price;
            this.PartInventory = inventory;
            this.PartMin = min;
            this.PartMax = max;
        }

        public Part() { }


    }
}

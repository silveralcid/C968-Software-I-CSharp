using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C968_Software_I_CSharp.Models
{
    public class Part
    {
        public int PartID { get; set; }
        public string PartName  { get; set; }
        public int PartInventory { get; set; }
        public decimal PartPrice { get; set; }
        public int PartMin { get; set; }
        public int PartMax { get; set; }
        public int PartMachineID { get; set; }
        public string PartCompanyName { get; set; }

    }
}

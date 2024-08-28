using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C968_Software_I_CSharp.Models
{
    public class InHouse : Part
    {
        public int MachineID { get; set; }
        public InHouse(int id, string name, decimal price, int inventory, int min, int max, int machineID)
            : base(id, name, price, inventory, min, max)
        {
            this.MachineID = machineID;
        }
        public InHouse() { }
    }
}

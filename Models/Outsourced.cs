using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C968_Software_I_CSharp.Models
{
    public class OutSourced : Part
    {
        public string CompanyName { get; set; }

        public OutSourced(int id, string name, decimal price, int inventory, int min, int max, string companyName)
            : base(id, name, price, inventory, min, max)
        {
            this.CompanyName = companyName;
        }

        public OutSourced() { }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C968_Software_I_CSharp.Models
{
    public class Product
    {

        public BindingList<Part> AssociatedParts = new BindingList<Part>();
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductInventory { get; set; }
        public int ProductMin { get; set; }
        public int ProductMax { get; set; }



        public Product(int id, string name, int inventory, decimal price, int min, int max)
        {
            this.ProductID = id;
            this.ProductName = name;
            this.ProductInventory = inventory;
            this.ProductPrice = price;
            this.ProductMin = min;
            this.ProductMax = max;
        }

        public Product() { }

        public void AddAssociatedPart(Part part)
        {
            AssociatedParts.Add(part);
        }
        public void RemoveAssociatedPart(int index)
        {
            AssociatedParts.RemoveAt(index);
        }
        public Part LookupAssociatedPart(int i)
        {
            int currentIndex;
            for (int j = 0; j < AssociatedParts.Count; j++)
            {
                if (AssociatedParts[j].PartID.Equals(i))
                {
                    currentIndex = j;
                    return AssociatedParts[j];
                }
            }
            currentIndex = -1;
            return null;
        }
    }
}

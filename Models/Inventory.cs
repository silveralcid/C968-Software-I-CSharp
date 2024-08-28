using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C968_Software_I_CSharp.Models
{
    public class Inventory
    {
        public static BindingList<Part> FullParts = new BindingList<Part>();
        public static BindingList<Product> FullProducts = new BindingList<Product>();

        public static Part CurrentPart { get; set; }
        public static int CurrentPartID { get; set; }
        public static int CurrentPartIndex { get; set; }
        public static Product CurrentProduct { get; set; }
        public static int CurrentProductID { get; set; }
        public static int CurrentProductIndex { get; set; }

        public static void SampleInventoryData()
        {
            Part samplePart1 = new InHouse(1, "Screw", 12, 3, 3, 9, 2990);
            Part samplePart2 = new InHouse(2, "Nail", 6, 1, 1, 8, 2991);
            Part samplePart3 = new OutSourced(3, "Washer", 5.00M, 10, 1, 10, "Toy Story Inc.");

            FullParts.Add(samplePart1);
            FullParts.Add(samplePart2);
            FullParts.Add(samplePart3);

            Product sampleProduct1 = new Product(1, "Bike", 5, 12.00M, 2, 8);

            FullProducts.Add(sampleProduct1);

            sampleProduct1.AssociatedParts.Add(samplePart1);
            sampleProduct1.AssociatedParts.Add(samplePart2);

        }

        public static void AddPart(Part part)
        {
            FullParts.Add(part);
        }
        public static Part LookupPart(int i)
        {   //Returns the currently selected Part object
            for (int j = 0; j < FullParts.Count; j++)
            {
                if (FullParts[j].Id.Equals(i))
                {
                    CurrentPartIndex = j;
                    return FullParts[j];
                }
            }
            CurrentPartIndex = -1;
            return null;
        }
        public static void UpdatePart(Part part)
        {
            FullParts.Insert(CurrentPartIndex, part);
            FullParts.RemoveAt(CurrentPartIndex + 1);
        }
        public static void RemovePart(Part part)
        {
            FullParts.Remove(part);
        }


        public static void AddProduct(Product product)
        {
            FullProducts.Add(product);
        }
        public static void RemoveProduct(Product product)
        {
            FullProducts.Remove(product);
        }
        public static Product LookupProduct(int i)
        {   //Returns the currently selected Product object
            for (int j = 0; j < FullProducts.Count; j++)
            {
                if (FullProducts[j].Id.Equals(i))
                {
                    CurrentProductIndex = j;
                    return FullProducts[j];
                }
            }
            CurrentProductIndex = -1;
            return null;
        }
        public static void UpdateProduct(Product product)
        {
            FullProducts.Insert(CurrentProductIndex, product);
            FullProducts.RemoveAt(CurrentProductIndex + 1);
        }
    }
}

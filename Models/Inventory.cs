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
            // Populate FullParts with sample data
            FullParts.Add(new InHouse { PartID = 0, PartName = "Wheel", PartInventory = 15, PartPrice = 12.11m, PartMin = 5, PartMax = 25, MachineID = 2990 });
            FullParts.Add(new OutSourced { PartID = 1, PartName = "Pedal", PartInventory = 11, PartPrice = 8.22m, PartMin = 5, PartMax = 25, CompanyName = "BikeParts Inc." });
            FullParts.Add(new OutSourced { PartID = 2, PartName = "Chain", PartInventory = 12, PartPrice = 8.33m, PartMin = 5, PartMax = 25, CompanyName = "ChainWorks Ltd." });
            FullParts.Add(new InHouse { PartID = 3, PartName = "Seat", PartInventory = 8, PartPrice = 4.55m, PartMin = 2, PartMax = 15, MachineID = 2991 });

            // Populate FullProducts with sample data
            FullProducts.Add(new Product { ProductID = 0, ProductName = "Red Bicycle", ProductInventory = 15, ProductPrice = 11.44m, ProductMin = 1, ProductMax = 25 });
            FullProducts.Add(new Product { ProductID = 1, ProductName = "Yellow Bicycle", ProductInventory = 19, ProductPrice = 9.66m, ProductMin = 1, ProductMax = 20 });
            FullProducts.Add(new Product { ProductID = 2, ProductName = "Blue Bicycle", ProductInventory = 5, ProductPrice = 12.77m, ProductMin = 1, ProductMax = 25 });


        }

        public static void AddPart(Part part)
        {
            FullParts.Add(part);
        }
        public static Part LookupPart(int id)
        {
            return FullParts.FirstOrDefault(p => p.PartID == id);
        }
        public static void UpdatePart(Part part)
        {
            int index = FullParts.ToList().FindIndex(p => p.PartID == part.PartID);
            if (index != -1)
            {
                // Update the existing part with the new values
                FullParts[index] = part;
            }
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
        public static Product LookupProduct(int id)
        {
            return FullProducts.FirstOrDefault(p => p.ProductID == id);
        }
        public static void UpdateProduct(Product product)
        {
            int index = FullProducts.ToList().FindIndex(p => p.ProductID == product.ProductID);
            if (index != -1)
            {
                // Update the existing product with the new values
                FullProducts[index] = product;
            }
        }
    }
}

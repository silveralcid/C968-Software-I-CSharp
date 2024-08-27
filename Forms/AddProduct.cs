using C968_Software_I_CSharp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C968_Software_I_CSharp.Forms
{
    public partial class AddProduct : Form
    {
        public Product Product { get; private set; }

        // Constructor for adding a new product
        public AddProduct()
        {
            InitializeComponent();
            InitializeForm(null); // No product passed in, so it's an "Add" operation
        }

        // Constructor for modifying an existing product
        public AddProduct(Product product)
        {
            InitializeComponent();
            InitializeForm(product); // Product passed in, so it's a "Modify" operation
        }

        private void InitializeForm(Product product)
        {
            if (product != null)
            {
                modifyProductLabel.Visible = true;
                addProductLabel.Visible = false;

                // Populate form fields with the existing product's data
                addProductIDTextBox.Text = product.ProductID.ToString();
                addProductNameTextBox.Text = product.ProductName;
                addProductInventoryTextBox.Text = product.ProductInventory.ToString();
                addProductPriceTextBox.Text = product.ProductPrice.ToString();
                addProductMinTextBox.Text = product.ProductMin.ToString();
                addProductMaxTextBox.Text = product.ProductMax.ToString();
            }
            else
            {
                modifyProductLabel.Visible = false;
                addProductLabel.Visible = true;
            }
        }

        private void addProductCancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addProductSaveButton_Click(object sender, EventArgs e)
        {
            // Parse the input values
            int inventory = int.Parse(addProductInventoryTextBox.Text);
            int min = int.Parse(addProductMinTextBox.Text);
            int max = int.Parse(addProductMaxTextBox.Text);

            if (inventory < min || inventory > max)
            {
                MessageBox.Show("Inventory value must be between Min and Max.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Create or modify the product object
            Product = new Product
            {
                ProductID = int.Parse(addProductIDTextBox.Text),
                ProductName = addProductNameTextBox.Text,
                ProductInventory = inventory,
                ProductPrice = decimal.Parse(addProductPriceTextBox.Text),
                ProductMin = min,
                ProductMax = max
            };

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void AddProduct_Load(object sender, EventArgs e)
        {
            // Any additional setup can be done here if needed
        }
    }
}

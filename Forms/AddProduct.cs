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

        // Constructor for adding a new product and showing parts list
        public AddProduct(BindingList<Part> partsList)
        {
            InitializeComponent();
            InitializeForm(null, partsList); // No product passed in, so it's an "Add" operation
        }

        // Constructor for modifying an existing product and showing parts list
        public AddProduct(Product product, BindingList<Part> partsList)
        {
            InitializeComponent();
            InitializeForm(product, partsList); // Product passed in, so it's a "Modify" operation
        }

        private void InitializeForm(Product product, BindingList<Part> partsList)
        {
            // Bind the parts list to the parts DataGridView in the product form
            partsGridView.DataSource = partsList;

            // partsGridView Customization
            partsGridView.Columns["PartMachineID"].Visible = false;
            partsGridView.Columns["PartCompanyName"].Visible = false;
            partsGridView.ReadOnly = true;
            partsGridView.RowHeadersVisible = false;
            partsGridView.AllowUserToAddRows = false;
            partsGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Change headers in partsGridView
            partsGridView.Columns["PartID"].HeaderText = "Part ID";
            partsGridView.Columns["PartName"].HeaderText = "Name";
            partsGridView.Columns["PartInventory"].HeaderText = "Inventory";
            partsGridView.Columns["PartPrice"].HeaderText = "Price";
            partsGridView.Columns["PartMin"].HeaderText = "Min";
            partsGridView.Columns["PartMax"].HeaderText = "Max";

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

        private void addProductCancelButton_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addProductSaveButton_Click_1(object sender, EventArgs e)
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
    }
}

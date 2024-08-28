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

        public AddProduct()
        {
            InitializeComponent();

            // Default to the add product label being visible
            modifyProductLabel.Visible = false;
            addProductLabel.Visible = true;
        }

        public AddProduct(Product product)
        {
            InitializeComponent();

            // Default to the modify product label being visible
            modifyProductLabel.Visible = true;
            addProductLabel.Visible = false;

            // Populate form fields with the existing product's data
            // ... (existing code for populating fields)
        }


        private void InitializeForm(Product product, BindingList<Part> partsList)
        {

        }

        private void CustomizePartsGridView()
        {

        }

        private void CustomizeAssociatedPartsGridView()
        {
  
        }


        private void addProductCancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void AddProduct_Load(object sender, EventArgs e)
        {
        }





        private void addPartButton_Click(object sender, EventArgs e)
        {

        }

        private void removePartButton_Click(object sender, EventArgs e)
        {

        }


        private void addProductSaveButton_Click_1(object sender, EventArgs e)
        {
            // Validate the inputs
            if (string.IsNullOrWhiteSpace(addProductIDTextBox.Text) ||
                string.IsNullOrWhiteSpace(addProductNameTextBox.Text) ||
                string.IsNullOrWhiteSpace(addProductInventoryTextBox.Text) ||
                string.IsNullOrWhiteSpace(addProductPriceTextBox.Text) ||
                string.IsNullOrWhiteSpace(addProductMinTextBox.Text) ||
                string.IsNullOrWhiteSpace(addProductMaxTextBox.Text))
            {
                MessageBox.Show("All fields are required. Please fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(addProductIDTextBox.Text, out int productID) ||
                !int.TryParse(addProductInventoryTextBox.Text, out int inventory) ||
                !decimal.TryParse(addProductPriceTextBox.Text, out decimal price) ||
                !int.TryParse(addProductMinTextBox.Text, out int min) ||
                !int.TryParse(addProductMaxTextBox.Text, out int max))
            {
                MessageBox.Show("Please enter valid numeric values for ID, Inventory, Price, Min, and Max.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (min > max)
            {
                MessageBox.Show("Min value cannot be greater than Max value.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (inventory < min || inventory > max)
            {
                MessageBox.Show("Inventory value must be between Min and Max.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Create the new product
            Product = new Product(productID, addProductNameTextBox.Text, inventory, price, min, max);

            // Set the dialog result to OK and close the form
            this.DialogResult = DialogResult.OK;
            this.Close();
        }


        private void addProductCancelButton_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void productPartsSearchButton_Click(object sender, EventArgs e)
        {
        }
    }
}

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
        private BindingList<Part> associatedPartsList = new BindingList<Part>();
        private BindingList<Part> partsList;



        // Constructor for adding a new product and showing parts list
        public AddProduct(BindingList<Part> partsList)
        {
            InitializeComponent();
            this.partsList = partsList;  // Initialize the partsList
            InitializeForm(null, partsList); // No product passed in, so it's an "Add" operation
        }

        // Constructor for modifying an existing product and showing parts list
        public AddProduct(Product product, BindingList<Part> partsList)
        {
            InitializeComponent();
            this.partsList = partsList;  // Initialize the partsList
            InitializeForm(product, partsList); // Product passed in, so it's a "Modify" operation
        }

        private void InitializeForm(Product product, BindingList<Part> partsList)
        {
            // Bind the parts list to the parts DataGridView in the product form
            partsGridView.DataSource = partsList;
            associatedPartsGridView.DataSource = associatedPartsList;

            CustomizePartsGridView();
            CustomizeAssociatedPartsGridView();


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

                // Populate the associated parts list with parts from the product
                foreach (var part in product.AssociatedParts)
                {
                    associatedPartsList.Add(part);
                }
            }
            else
            {
                modifyProductLabel.Visible = false;
                addProductLabel.Visible = true;
            }
        }

        private void CustomizePartsGridView()
        {
            if (partsGridView.Columns.Contains("PartMachineID"))
            {
                partsGridView.Columns["PartMachineID"].Visible = false;
            }

            if (partsGridView.Columns.Contains("PartCompanyName"))
            {
                partsGridView.Columns["PartCompanyName"].Visible = false;
            }

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
        }

        private void CustomizeAssociatedPartsGridView()
        {
            if (associatedPartsGridView.Columns.Contains("PartMachineID"))
            {
                associatedPartsGridView.Columns["PartMachineID"].Visible = false;
            }

            if (associatedPartsGridView.Columns.Contains("PartCompanyName"))
            {
                associatedPartsGridView.Columns["PartCompanyName"].Visible = false;
            }

            associatedPartsGridView.ReadOnly = true;
            associatedPartsGridView.RowHeadersVisible = false;
            associatedPartsGridView.AllowUserToAddRows = false;
            associatedPartsGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Change headers in associatedPartsGridView
            associatedPartsGridView.Columns["PartID"].HeaderText = "Part ID";
            associatedPartsGridView.Columns["PartName"].HeaderText = "Name";
            associatedPartsGridView.Columns["PartInventory"].HeaderText = "Inventory";
            associatedPartsGridView.Columns["PartPrice"].HeaderText = "Price";
            associatedPartsGridView.Columns["PartMin"].HeaderText = "Min";
            associatedPartsGridView.Columns["PartMax"].HeaderText = "Max";
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





        private void addPartButton_Click(object sender, EventArgs e)
        {
            if (partsGridView.SelectedRows.Count > 0)
            {
                int selectedIndex = partsGridView.SelectedRows[0].Index;
                Part selectedPart = (Part)partsGridView.Rows[selectedIndex].DataBoundItem;

                if (!associatedPartsList.Contains(selectedPart))
                {
                    associatedPartsList.Add(selectedPart);
                }
                else
                {
                    MessageBox.Show("This part is already associated with the product.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void removePartButton_Click(object sender, EventArgs e)
        {
            if (associatedPartsGridView.SelectedRows.Count > 0)
            {
                // Get the selected part from the grid
                int selectedIndex = associatedPartsGridView.SelectedRows[0].Index;
                Part selectedPart = (Part)associatedPartsGridView.Rows[selectedIndex].DataBoundItem;

                // Remove the selected part from the associated parts list
                associatedPartsList.Remove(selectedPart);
            }
            else
            {
                MessageBox.Show("Please select a part to remove.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void addProductSaveButton_Click_1(object sender, EventArgs e)
        {
            // Check if any of the required fields are empty
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

            // Validate data types for numeric fields
            if (!int.TryParse(addProductIDTextBox.Text, out _) ||
                !int.TryParse(addProductInventoryTextBox.Text, out _) ||
                !decimal.TryParse(addProductPriceTextBox.Text, out _) ||
                !int.TryParse(addProductMinTextBox.Text, out _) ||
                !int.TryParse(addProductMaxTextBox.Text, out _))
            {
                MessageBox.Show("Please enter valid numeric values for ID, Inventory, Price, Min, and Max.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Parse the input values
            int inventory = int.Parse(addProductInventoryTextBox.Text);
            int min = int.Parse(addProductMinTextBox.Text);
            int max = int.Parse(addProductMaxTextBox.Text);

            // Ensure Min is not greater than Max
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

            // Ensure AssociatedParts list is updated or create a new product object
            if (Product == null)
            {
                Product = new Product();
            }

            // Update the product fields
            Product.ProductID = int.Parse(addProductIDTextBox.Text);
            Product.ProductName = addProductNameTextBox.Text;
            Product.ProductInventory = inventory;
            Product.ProductPrice = decimal.Parse(addProductPriceTextBox.Text);
            Product.ProductMin = min;
            Product.ProductMax = max;

            // Update the associated parts list
            Product.AssociatedParts = associatedPartsList.ToList();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }


        private void addProductCancelButton_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void productPartsSearchButton_Click(object sender, EventArgs e)
        {
            string searchText = productPartsSearchTextBox.Text.ToLower();

            if (string.IsNullOrEmpty(searchText))
            {
                // If search box is empty, reset the grid to show all parts
                partsGridView.DataSource = partsList;
            }
            else
            {
                // Filter the partsList based on the search text
                var filteredPartsList = partsList.Where(p =>
                    p.PartName.ToLower().Contains(searchText) ||
                    p.PartID.ToString().Contains(searchText) ||
                    p.PartInventory.ToString().Contains(searchText) ||
                    p.PartPrice.ToString().Contains(searchText) ||
                    p.PartMin.ToString().Contains(searchText) ||
                    p.PartMax.ToString().Contains(searchText)).ToList();

                partsGridView.DataSource = new BindingList<Part>(filteredPartsList);
            }
        }
    }
}

using C968_Software_I_CSharp.Models;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace C968_Software_I_CSharp.Forms
{
    public partial class AddProduct : Form
    {
        public Product Product { get; private set; }

        public AddProduct()
        {
            InitializeComponent();
            InitializeFormForAdd(); 
        }

        public AddProduct(Product product)
        {
            InitializeComponent();
            InitializeFormForModify(product);
        }

        private void InitializeFormForAdd()
        {
            addProductIDTextBox.ReadOnly = false;

            modifyProductLabel.Visible = false;
            addProductLabel.Visible = true;
            Product = new Product(); 

            addProductIDTextBox.ReadOnly = true;
        }

        private void InitializeFormForModify(Product product)
        {

            addProductIDTextBox.ReadOnly = true;

            modifyProductLabel.Visible = true;
            addProductLabel.Visible = false;



            addProductIDTextBox.Text = product.ProductID.ToString();
            addProductNameTextBox.Text = product.ProductName;
            addProductInventoryTextBox.Text = product.ProductInventory.ToString();
            addProductPriceTextBox.Text = product.ProductPrice.ToString();
            addProductMinTextBox.Text = product.ProductMin.ToString();
            addProductMaxTextBox.Text = product.ProductMax.ToString();

            Product = product; 
        }

        private void AddProduct_Load(object sender, EventArgs e)
        {
            // Load all parts into the partsGridView
            partsGridView.DataSource = Inventory.FullParts;
            CustomizePartsGridView();

            // Initialize the associated parts grid with the current product's associated parts
            associatedPartsGridView.DataSource = Product.AssociatedParts;
            CustomizeAssociatedPartsGridView();
        }

        private void CustomizePartsGridView()
        {
            partsGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            partsGridView.ReadOnly = true;
            partsGridView.MultiSelect = false;
            partsGridView.AllowUserToAddRows = false;

            // Ensure columns have the correct headers
            partsGridView.Columns["PartID"].HeaderText = "Part ID";
            partsGridView.Columns["PartName"].HeaderText = "Name";
            partsGridView.Columns["PartInventory"].HeaderText = "Inventory";
            partsGridView.Columns["PartPrice"].HeaderText = "Price";
            partsGridView.Columns["PartMin"].HeaderText = "Min";
            partsGridView.Columns["PartMax"].HeaderText = "Max";

            partsGridView.RowHeadersVisible = false;
        }

        private void CustomizeAssociatedPartsGridView()
        {
            associatedPartsGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            associatedPartsGridView.ReadOnly = true;
            associatedPartsGridView.MultiSelect = false;
            associatedPartsGridView.AllowUserToAddRows = false;

            associatedPartsGridView.Columns["PartID"].HeaderText = "Part ID";
            associatedPartsGridView.Columns["PartName"].HeaderText = "Name";
            associatedPartsGridView.Columns["PartInventory"].HeaderText = "Inventory";
            associatedPartsGridView.Columns["PartPrice"].HeaderText = "Price";
            associatedPartsGridView.Columns["PartMin"].HeaderText = "Min";
            associatedPartsGridView.Columns["PartMax"].HeaderText = "Max";

            associatedPartsGridView.RowHeadersVisible = false;
        }

        private void addPartButton_Click(object sender, EventArgs e)
        {
            if (partsGridView.SelectedRows.Count > 0)
            {
                Part selectedPart = (Part)partsGridView.SelectedRows[0].DataBoundItem;
                Product.AddAssociatedPart(selectedPart);

                associatedPartsGridView.DataSource = null;
                associatedPartsGridView.DataSource = Product.AssociatedParts;
            }
            else
            {
                MessageBox.Show("Please select a part to add.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            CustomizePartsGridView();
            CustomizeAssociatedPartsGridView();
        }

        private void removePartButton_Click(object sender, EventArgs e)
        {
            if (associatedPartsGridView.SelectedRows.Count > 0)
            {
                int selectedIndex = associatedPartsGridView.SelectedRows[0].Index;
                Product.RemoveAssociatedPart(selectedIndex);

                associatedPartsGridView.DataSource = null;
                associatedPartsGridView.DataSource = Product.AssociatedParts;
            }
            else
            {
                MessageBox.Show("Please select a part to remove.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            CustomizePartsGridView();
            CustomizeAssociatedPartsGridView();
        }

        private void addProductSaveButton_Click_1(object sender, EventArgs e)
        {
            // Validate the inputs
            if (string.IsNullOrWhiteSpace(addProductNameTextBox.Text) ||
                string.IsNullOrWhiteSpace(addProductInventoryTextBox.Text) ||
                string.IsNullOrWhiteSpace(addProductPriceTextBox.Text) ||
                string.IsNullOrWhiteSpace(addProductMinTextBox.Text) ||
                string.IsNullOrWhiteSpace(addProductMaxTextBox.Text))
            {
                MessageBox.Show("All fields are required. Please fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(addProductInventoryTextBox.Text, out int inventory) ||
                !decimal.TryParse(addProductPriceTextBox.Text, out decimal price) ||
                !int.TryParse(addProductMinTextBox.Text, out int min) ||
                !int.TryParse(addProductMaxTextBox.Text, out int max))
            {
                MessageBox.Show("Please enter valid numeric values for Inventory, Price, Min, and Max.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            if (Product.ProductID == 0)
            {
                int newProductID = Inventory.GetNextProductID(); // Generate new ID
                Product = new Product(newProductID, addProductNameTextBox.Text, inventory, price, min, max);

                // Ensure associated parts are copied to the new product
                Product.AssociatedParts = new BindingList<Part>(associatedPartsGridView.Rows.Cast<DataGridViewRow>()
                                                          .Select(row => (Part)row.DataBoundItem)
                                                          .ToList());

                Inventory.AddProduct(Product);
            }
            else
            {
                Product.ProductName = addProductNameTextBox.Text;
                Product.ProductInventory = inventory;
                Product.ProductPrice = price;
                Product.ProductMin = min;
                Product.ProductMax = max;

                Inventory.UpdateProduct(Product);
            }

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
            string searchText = productPartsSearchTextBox.Text.ToLower();

            if (string.IsNullOrEmpty(searchText))
            {
                partsGridView.DataSource = Inventory.FullParts;
            }
            else
            {
                var filteredPartsList = new BindingList<Part>(Inventory.FullParts.Where(p =>
                    p.PartName.ToLower().Contains(searchText) ||
                    p.PartID.ToString().Contains(searchText) ||
                    p.PartInventory.ToString().Contains(searchText) ||
                    p.PartPrice.ToString().Contains(searchText) ||
                    p.PartMin.ToString().Contains(searchText) ||
                    p.PartMax.ToString().Contains(searchText)
                ).ToList());

                partsGridView.DataSource = filteredPartsList;
            }

            partsGridView.ClearSelection();
        }
    }
}

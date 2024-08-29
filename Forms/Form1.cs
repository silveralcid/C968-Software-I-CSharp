using C968_Software_I_CSharp.Forms;
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

namespace C968_Software_I_CSharp
{
    public partial class MainScreen : Form
    {




        public MainScreen()
        {
            InitializeComponent();

            // Initialize the sample data
            Inventory.SampleInventoryData();

            // Bind the parts inventory from Inventory.FullParts to the partsGridView
            partsGridView.DataSource = Inventory.FullParts;
            partsGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            partsGridView.ReadOnly = true;
            partsGridView.MultiSelect = false;
            partsGridView.AllowUserToAddRows = false;
            partsGridView.RowHeadersVisible = false;

            // Customize columns to show only relevant data
            CustomizePartsGridView();

            // Bind the products inventory from Inventory.FullProducts to the productsGridView
            productsGridView.DataSource = Inventory.FullProducts;
            productsGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            productsGridView.ReadOnly = true;
            productsGridView.MultiSelect = false;
            productsGridView.AllowUserToAddRows = false;
            productsGridView.RowHeadersVisible = false;

            // Customize columns to show only relevant data
            CustomizeProductsGridView();

        }

        private void CustomizePartsGridView()
        {

            partsGridView.Columns["PartID"].HeaderText = "Part ID";
            partsGridView.Columns["PartName"].HeaderText = "Name";
            partsGridView.Columns["PartInventory"].HeaderText = "Inventory";
            partsGridView.Columns["PartPrice"].HeaderText = "Price";
            partsGridView.Columns["PartMin"].HeaderText = "Min";
            partsGridView.Columns["PartMax"].HeaderText = "Max";

            // Hide any columns that shouldn't be visible
            if (partsGridView.Columns.Contains("MachineID"))
            {
                partsGridView.Columns["MachineID"].Visible = false;
            }
            if (partsGridView.Columns.Contains("CompanyName"))
            {
                partsGridView.Columns["CompanyName"].Visible = false;
            }

            // Set the width of columns to fit the content
            partsGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void CustomizeProductsGridView()
        {
            productsGridView.Columns["ProductID"].HeaderText = "Product ID";
            productsGridView.Columns["ProductName"].HeaderText = "Name";
            productsGridView.Columns["ProductInventory"].HeaderText = "Inventory";
            productsGridView.Columns["ProductPrice"].HeaderText = "Price";
            productsGridView.Columns["ProductMin"].HeaderText = "Min";
            productsGridView.Columns["ProductMax"].HeaderText = "Max";

            // Set the width of columns to fit the content
            productsGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        #region Parts Event Handlers



        private void partsAddButton_Click(object sender, EventArgs e)
        {
            AddPart addPartForm = new AddPart();
            if (addPartForm.ShowDialog() == DialogResult.OK)
            {
                partsGridView.DataSource = null;
                partsGridView.DataSource = Inventory.FullParts;
                CustomizePartsGridView();
            }
        }

        private void partsDeleteButton_Click(object sender, EventArgs e)
        {
            if (partsGridView.SelectedRows.Count > 0)
            {
                int selectedIndex = partsGridView.SelectedRows[0].Index;
                Part selectedPart = (Part)partsGridView.Rows[selectedIndex].DataBoundItem;

                bool isPartAssociated = Inventory.FullProducts.Any(product => product.AssociatedParts.Contains(selectedPart));

                if (isPartAssociated)
                {
                    MessageBox.Show("This part is associated with one or more products and cannot be deleted.", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var result = MessageBox.Show("Are you sure you want to delete the selected part?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    Inventory.RemovePart(selectedPart);
                    partsGridView.DataSource = null;
                    partsGridView.DataSource = Inventory.FullParts;
                    partsGridView.ClearSelection();
                    CustomizePartsGridView();
                }
            }
            else
            {
                MessageBox.Show("Please select a part to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void partsModifyButton_Click(object sender, EventArgs e)
        {
            if (partsGridView.SelectedRows.Count > 0)
            {
                int selectedIndex = partsGridView.SelectedRows[0].Index;
                Part selectedPart = Inventory.FullParts[selectedIndex];

                AddPart modifyPartForm = new AddPart(selectedPart);
                if (modifyPartForm.ShowDialog() == DialogResult.OK)
                {
                 //   Inventory.UpdatePart(modifyPartForm.Part);
                    partsGridView.DataSource = null;
                    partsGridView.DataSource = Inventory.FullParts;
                    CustomizePartsGridView();
                }
            }
            else
            {
                MessageBox.Show("Please select a part to modify.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void partsSearchButton_Click(object sender, EventArgs e)
        {
            string searchText = partsSearchBox.Text.ToLower();

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

        #endregion

        #region Products Event Handlers

        private void productsAddButton_Click(object sender, EventArgs e)
        {
            AddProduct addProductForm = new AddProduct();

            if (addProductForm.ShowDialog() == DialogResult.OK)
            {
                productsGridView.DataSource = null;
                productsGridView.DataSource = Inventory.FullProducts;
                CustomizeProductsGridView();
            }
        }

        private void productsModifyButton_Click(object sender, EventArgs e)
        {
            if (productsGridView.SelectedRows.Count > 0)
            {
                Product selectedProduct = (Product)productsGridView.SelectedRows[0].DataBoundItem;

                AddProduct modifyProductForm = new AddProduct(selectedProduct);

                if (modifyProductForm.ShowDialog() == DialogResult.OK)
                {
                    Inventory.UpdateProduct(modifyProductForm.Product);
                    productsGridView.DataSource = null;
                    productsGridView.DataSource = Inventory.FullProducts;
                    CustomizeProductsGridView();
                }
            }
            else
            {
                MessageBox.Show("Please select a product to modify.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void productsDeleteButton_Click(object sender, EventArgs e)
        {
            if (productsGridView.SelectedRows.Count > 0)
            {
                int selectedIndex = productsGridView.SelectedRows[0].Index;
                Product selectedProduct = (Product)productsGridView.Rows[selectedIndex].DataBoundItem;

                if (selectedProduct.AssociatedParts.Count > 0)
                {
                    MessageBox.Show("This product has associated parts and cannot be deleted.", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var result = MessageBox.Show("Are you sure you want to delete the selected product?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    Inventory.RemoveProduct(selectedProduct);
                    productsGridView.DataSource = null;
                    productsGridView.DataSource = Inventory.FullProducts;
                    productsGridView.ClearSelection();
                    CustomizeProductsGridView();
                }
            }
            else
            {
                MessageBox.Show("Please select a product to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void productsSearchButton_Click(object sender, EventArgs e)
        {
            string searchText = productsSearchBox.Text.ToLower();

            if (string.IsNullOrEmpty(searchText))
            {
                productsGridView.DataSource = Inventory.FullProducts;
            }
            else
            {
                var filteredProductsList = new BindingList<Product>(Inventory.FullProducts.Where(p =>
                    p.ProductName.ToLower().Contains(searchText) ||
                    p.ProductID.ToString().Contains(searchText) ||
                    p.ProductInventory.ToString().Contains(searchText) ||
                    p.ProductPrice.ToString().Contains(searchText) ||
                    p.ProductMin.ToString().Contains(searchText) ||
                    p.ProductMax.ToString().Contains(searchText)
                ).ToList());

                productsGridView.DataSource = filteredProductsList;
            }

            productsGridView.ClearSelection();
        }

        #endregion

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

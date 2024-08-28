﻿using C968_Software_I_CSharp.Forms;
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

            // Remove the row header column
            productsGridView.RowHeadersVisible = false;

            // Customize columns to show only relevant data
            CustomizeProductsGridView();
        }

        private void CustomizePartsGridView()
        {

            // Set column headers for better readability
            partsGridView.Columns["PartID"].HeaderText = "Part ID";
            partsGridView.Columns["PartName"].HeaderText = "Name";
            partsGridView.Columns["PartInventory"].HeaderText = "Inventory";
            partsGridView.Columns["PartPrice"].HeaderText = "Price";
            partsGridView.Columns["PartMin"].HeaderText = "Min";
            partsGridView.Columns["PartMax"].HeaderText = "Max";

            // Set the width of columns to fit the content
            partsGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void CustomizeProductsGridView()
        {
            // Set column headers for better readability
            productsGridView.Columns["ProductID"].HeaderText = "Product ID";
            productsGridView.Columns["ProductName"].HeaderText = "Name";
            productsGridView.Columns["ProductInventory"].HeaderText = "Inventory";
            productsGridView.Columns["ProductPrice"].HeaderText = "Price";
            productsGridView.Columns["ProductMin"].HeaderText = "Min";
            productsGridView.Columns["ProductMax"].HeaderText = "Max";

            // Set the width of columns to fit the content
            productsGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }


        private void InitializeData()
        {


        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void productsSearchBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void partsAddButton_Click(object sender, EventArgs e)
        {
            // Create a new instance of the AddPart form
            AddPart addPartForm = new AddPart();

            // Show the AddPart form as a dialog
            if (addPartForm.ShowDialog() == DialogResult.OK)
            {
                // If the user clicked 'Save', add the new part to the inventory
                Inventory.AddPart(addPartForm.Part);

                // Refresh the partsGridView to show the new part
                partsGridView.DataSource = null;
                partsGridView.DataSource = Inventory.FullParts;

                // Clear selection after adding the new part
                partsGridView.ClearSelection();
            }
        }

        private void partsDeleteButton_Click(object sender, EventArgs e)
        {
            // Check if a row is selected
            if (partsGridView.SelectedRows.Count > 0)
            {
                // Get the selected part
                int selectedIndex = partsGridView.SelectedRows[0].Index;
                Part selectedPart = (Part)partsGridView.Rows[selectedIndex].DataBoundItem;

                // Check if the selected part is associated with any products
                bool isPartAssociated = Inventory.FullProducts.Any(product => product.AssociatedParts.Contains(selectedPart));

                if (isPartAssociated)
                {
                    MessageBox.Show("This part is associated with one or more products and cannot be deleted.", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Confirm deletion
                var result = MessageBox.Show("Are you sure you want to delete the selected part?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    // Remove the part from the Inventory
                    Inventory.RemovePart(selectedPart);

                    // Update the grid view
                    partsGridView.DataSource = null;  // Reset the data source
                    partsGridView.DataSource = Inventory.FullParts;  // Rebind the updated parts list

                    // Clear selection
                    partsGridView.ClearSelection();
                }
            }
            else
            {
                MessageBox.Show("Please select a part to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void partsModifyButton_Click(object sender, EventArgs e)
        {
      
        }

        private void partsSearchButton_Click(object sender, EventArgs e)
        {
            string searchText = partsSearchBox.Text.ToLower();

            if (string.IsNullOrEmpty(searchText))
            {
                // If search box is empty, reset the grid to show all parts
                partsGridView.DataSource = Inventory.FullParts;
            }
            else
            {
                // Filter the FullParts list based on the search text
                var filteredPartsList = new BindingList<Part>(Inventory.FullParts.Where(p =>
                    p.PartName.ToLower().Contains(searchText) ||
                    p.PartID.ToString().Contains(searchText) ||
                    p.PartInventory.ToString().Contains(searchText) ||
                    p.PartPrice.ToString().Contains(searchText) ||
                    p.PartMin.ToString().Contains(searchText) ||
                    p.PartMax.ToString().Contains(searchText)
                ).ToList());

                // Update the DataGridView with the filtered list
                partsGridView.DataSource = filteredPartsList;
            }

            // Clear selection after search
            partsGridView.ClearSelection();
        }

        private void productsAddButton_Click(object sender, EventArgs e)
        {
           
        }

        private void productsModifyButton_Click(object sender, EventArgs e)
        {
          
        }

        private void productsDeleteButton_Click(object sender, EventArgs e)
        {
            // Check if a row is selected
            if (productsGridView.SelectedRows.Count > 0)
            {
                // Get the selected product
                int selectedIndex = productsGridView.SelectedRows[0].Index;
                Product selectedProduct = (Product)productsGridView.Rows[selectedIndex].DataBoundItem;

                // Check if the selected product has any associated parts
                if (selectedProduct.AssociatedParts.Count > 0)
                {
                    MessageBox.Show("This product has associated parts and cannot be deleted.", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Confirm deletion
                var result = MessageBox.Show("Are you sure you want to delete the selected product?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    // Remove the product from the Inventory
                    Inventory.RemoveProduct(selectedProduct);

                    // Update the grid view
                    productsGridView.DataSource = null;  // Reset the data source
                    productsGridView.DataSource = Inventory.FullProducts;  // Rebind the updated products list

                    // Clear selection
                    productsGridView.ClearSelection();
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
                // If search box is empty, reset the grid to show all products
                productsGridView.DataSource = Inventory.FullProducts;
            }
            else
            {
                // Filter the FullProducts list based on the search text
                var filteredProductsList = new BindingList<Product>(Inventory.FullProducts.Where(p =>
                    p.ProductName.ToLower().Contains(searchText) ||
                    p.ProductID.ToString().Contains(searchText) ||
                    p.ProductInventory.ToString().Contains(searchText) ||
                    p.ProductPrice.ToString().Contains(searchText) ||
                    p.ProductMin.ToString().Contains(searchText) ||
                    p.ProductMax.ToString().Contains(searchText)
                ).ToList());

                // Update the DataGridView with the filtered list
                productsGridView.DataSource = filteredProductsList;
            }

            // Clear selection after search
            productsGridView.ClearSelection();
        }
    }
}

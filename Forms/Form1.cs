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
         
        }

        private void partsDeleteButton_Click(object sender, EventArgs e)
        {
        
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
            
          
        }

        private void productsSearchButton_Click(object sender, EventArgs e)
        {
        }
    }
}

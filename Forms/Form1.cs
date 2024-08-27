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
        private BindingList<Part> partsList = new BindingList<Part>();
        private BindingList<Product> productsList = new BindingList<Product>();
        private BindingList<Part> filteredPartsList;
        private BindingList<Product> filteredProductsList;





        public MainScreen()
        {
            InitializeComponent();
            InitializeData();

            // Wire up event handlers
            partsDeleteButton.Click += new EventHandler(partsDeleteButton_Click);
            partsSearchButton.Click += new EventHandler(partsSearchButton_Click);
            productsDeleteButton.Click += new EventHandler(productsDeleteButton_Click);
            productsSearchButton.Click += new EventHandler(productsSearchButton_Click);

        }

        private void InitializeData()
        {
            // Populate partsList with sample data
            partsList.Add(new Part { PartID = 0, PartName = "Wheel", PartInventory = 15, PartPrice = 12.11m, PartMin = 5, PartMax = 25 });
            partsList.Add(new Part { PartID = 1, PartName = "Pedal", PartInventory = 11, PartPrice = 8.22m, PartMin = 5, PartMax = 25 });
            partsList.Add(new Part { PartID = 2, PartName = "Chain", PartInventory = 12, PartPrice = 8.33m, PartMin = 5, PartMax = 25 });
            partsList.Add(new Part { PartID = 3, PartName = "Seat", PartInventory = 18, PartPrice = 4.55m, PartMin = 2, PartMax = 15 });



            // Populate productsList with sample data
            productsList.Add(new Product { ProductID = 0, ProductName = "Red Bicycle", ProductInventory = 15, ProductPrice = 11.44m, ProductMin = 1, ProductMax = 25 });
            productsList.Add(new Product { ProductID = 1, ProductName = "Yellow Bicycle", ProductInventory = 19, ProductPrice = 9.66m, ProductMin = 1, ProductMax = 20 });
            productsList.Add(new Product { ProductID = 2, ProductName = "Blue Bicycle", ProductInventory = 5, ProductPrice = 12.77m, ProductMin = 1, ProductMax = 25 });



            // Bind the lists to the datagridviews
            partsGridView.DataSource = partsList;
            productsGridView.DataSource = productsList;

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


            // productsGridView Customization
            productsGridView.ReadOnly = true;
            productsGridView.RowHeadersVisible = false;
            productsGridView.AllowUserToAddRows = false;
            productsGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;


            // Change headers in productsGridView
            productsGridView.Columns["ProductID"].HeaderText = "Product ID";
            productsGridView.Columns["ProductName"].HeaderText = "Name";
            productsGridView.Columns["ProductInventory"].HeaderText = "Inventory";
            productsGridView.Columns["ProductPrice"].HeaderText = "Price";
            productsGridView.Columns["ProductMin"].HeaderText = "Min";
            productsGridView.Columns["ProductMax"].HeaderText = "Max";


        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void partsGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
            AddPart addPartForm = new AddPart();
            if (addPartForm.ShowDialog() == DialogResult.OK)
            {
                partsList.Add(addPartForm.Part);
            }
        }

        private void partsDeleteButton_Click(object sender, EventArgs e)
        {
            // Check if a row is selected
            if (partsGridView.SelectedRows.Count > 0)
            {
                var result = MessageBox.Show("Are you sure you want to delete the selected part?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    int selectedIndex = partsGridView.SelectedRows[0].Index;
                    partsList.RemoveAt(selectedIndex);
                    partsGridView.ClearSelection();
                }
            }
        }

        private void partsModifyButton_Click(object sender, EventArgs e)
        {
            if (partsGridView.SelectedRows.Count > 0)
            {
                int selectedIndex = partsGridView.SelectedRows[0].Index;
                Part selectedPart = partsList[selectedIndex];

                AddPart modifyPartForm = new AddPart(selectedPart);
                if (modifyPartForm.ShowDialog() == DialogResult.OK)
                {
                    // Update the existing part in the list
                    partsList[selectedIndex] = modifyPartForm.Part;
                }
            }
        }

        private void partsSearchButton_Click(object sender, EventArgs e)
        {
            string searchText = partsSearchBox.Text.ToLower();

            if (string.IsNullOrEmpty(searchText))
            {
                // If search box is empty, reset the grid to show all parts
                partsGridView.DataSource = partsList;
            }
            else
            {
                // Filter the partsList based on the search text
                filteredPartsList = new BindingList<Part>(partsList.Where(p =>
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
        }

        private void productsAddButton_Click(object sender, EventArgs e)
        {
            AddProduct addProductForm = new AddProduct();
            if (addProductForm.ShowDialog() == DialogResult.OK)
            {
                productsList.Add(addProductForm.Product);
            }
        }

        private void productsModifyButton_Click(object sender, EventArgs e)
        {
            if (productsGridView.SelectedRows.Count > 0)
            {
                int selectedIndex = productsGridView.SelectedRows[0].Index;
                Product selectedProduct = productsList[selectedIndex];

                AddProduct modifyProductForm = new AddProduct(selectedProduct);
                if (modifyProductForm.ShowDialog() == DialogResult.OK)
                {
                    productsList[selectedIndex] = modifyProductForm.Product;
                }
            }
        }

        private void productsDeleteButton_Click(object sender, EventArgs e)
        {
            if (productsGridView.SelectedRows.Count > 0)
            {
                var result = MessageBox.Show("Are you sure you want to delete the selected product?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    int selectedIndex = productsGridView.SelectedRows[0].Index;
                    productsList.RemoveAt(selectedIndex);
                    productsGridView.ClearSelection();
                }
            }
        }

        private void productsSearchButton_Click(object sender, EventArgs e)
        {
            string searchText = productsSearchBox.Text.ToLower();

            if (string.IsNullOrEmpty(searchText))
            {
                productsGridView.DataSource = productsList;
            }
            else
            {
                filteredProductsList = new BindingList<Product>(productsList.Where(p =>
                    p.ProductName.ToLower().Contains(searchText) ||
                    p.ProductID.ToString().Contains(searchText) ||
                    p.ProductInventory.ToString().Contains(searchText) ||
                    p.ProductPrice.ToString().Contains(searchText) ||
                    p.ProductMin.ToString().Contains(searchText) ||
                    p.ProductMax.ToString().Contains(searchText)
                ).ToList());

                productsGridView.DataSource = filteredProductsList;
            }
        }
    }
}

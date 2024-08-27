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


        public MainScreen()
        {
            InitializeComponent();
            InitializeData();

            // Wire up the delete button event handler
            partsDeleteButton.Click += new EventHandler(partsDeleteButton_Click);
        }

        private void InitializeData()
        {
            // Populate partsList with sample data
            partsList.Add(new Part { PartID = 0, PartName = "Wheel", PartInventory = 15, PartPrice = 12.11m, PartMin = 5, PartMax = 25 });
            partsList.Add(new Part { PartID = 1, PartName = "Brake", PartInventory = 15, PartPrice = 12.11m, PartMin = 5, PartMax = 25 });


            // Populate productsList with sample data
            productsList.Add(new Product { ProductID = 0, ProductName = "Red Bicycle", ProductInventory = 15, ProductPrice = 11.44m, ProductMin = 1, ProductMax = 25 });
            productsList.Add(new Product { ProductID = 1, ProductName = "Blue Bicycle", ProductInventory = 15, ProductPrice = 11.44m, ProductMin = 1, ProductMax = 25 });


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

        private void button1_Click(object sender, EventArgs e)
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
            else
            {
                MessageBox.Show("The selection has been removed.", "Selection Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}

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
        }

        private void InitializeData()
        {
            // Populate partsList with sample data
            partsList.Add(new Part { PartID = 0, PartName = "Wheel", PartInventory = 15, PartPrice = 12.11m, PartMin = 5, PartMax = 25 });

            // Populate productsList with sample data
            productsList.Add(new Product { ProductID = 0, ProductName = "Red Bicycle", ProductInventory = 15, ProductPrice = 11.44m, ProductMin = 1, ProductMax = 25 });

            // Bind the lists to the datagridviews
            partsGridView.DataSource = partsList;
            productsGridView.DataSource = productsList;
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
            addPartForm.ShowDialog();
        }
    }
}

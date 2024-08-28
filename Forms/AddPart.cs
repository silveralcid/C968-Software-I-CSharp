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
    public partial class AddPart : Form
    {
        public Part Part { get; private set; }

        public AddPart()
        {
            InitializeComponent();

            // Attach event handlers to the radio buttons
            partInHouseRadio.CheckedChanged += new EventHandler(partInHouseRadio_CheckedChanged);
            partOutsourcedRadio.CheckedChanged += new EventHandler(partOutsourcedRadio_CheckedChanged);

            // Default to In-House
            partInHouseRadio.Checked = true;
        }
        private void InitializeForm(Part part)
        {
        
        }

        private void addPartPriceCostLabel_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void addPartCancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addPartSaveButton_Click(object sender, EventArgs e)
        {
            // Check if all required fields are filled
            if (string.IsNullOrWhiteSpace(addPartIDTextBox.Text) ||
                string.IsNullOrWhiteSpace(addPartNameTextBox.Text) ||
                string.IsNullOrWhiteSpace(addPartInventoryTextBox.Text) ||
                string.IsNullOrWhiteSpace(addPartPriceTextBox.Text) ||
                string.IsNullOrWhiteSpace(addPartMinTextBox.Text) ||
                string.IsNullOrWhiteSpace(addPartMaxTextBox.Text) ||
                (partInHouseRadio.Checked && string.IsNullOrWhiteSpace(addPartMachineIDTextBox.Text)) ||
                (partOutsourcedRadio.Checked && string.IsNullOrWhiteSpace(addPartCompanyNameTextBox.Text)))
            {
                MessageBox.Show("All fields are required. Please fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validate numeric inputs
            int machineID = 0; // Initialize machineID to avoid unassigned variable error
            if (!int.TryParse(addPartIDTextBox.Text, out int partID) ||
                !int.TryParse(addPartInventoryTextBox.Text, out int inventory) ||
                !decimal.TryParse(addPartPriceTextBox.Text, out decimal price) ||
                !int.TryParse(addPartMinTextBox.Text, out int min) ||
                !int.TryParse(addPartMaxTextBox.Text, out int max) ||
                (partInHouseRadio.Checked && !int.TryParse(addPartMachineIDTextBox.Text, out machineID)))
            {
                MessageBox.Show("Please enter valid numeric values for ID, Inventory, Price, Min, Max, and Machine ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Ensure Min is not greater than Max
            if (min > max)
            {
                MessageBox.Show("Min value cannot be greater than Max value.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Ensure Inventory is between Min and Max
            if (inventory < min || inventory > max)
            {
                MessageBox.Show("Inventory value must be between Min and Max.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Create a new Part object based on the user's input and selected part type
            if (partInHouseRadio.Checked)
            {
                Part = new InHouse(partID, addPartNameTextBox.Text, price, inventory, min, max, machineID);
            }
            else if (partOutsourcedRadio.Checked)
            {
                Part = new OutSourced(partID, addPartNameTextBox.Text, price, inventory, min, max, addPartCompanyNameTextBox.Text);
            }

            // Set the DialogResult to OK to indicate success and close the form
            this.DialogResult = DialogResult.OK;
            this.Close();
        }


        private void partOutsourcedRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (partOutsourcedRadio.Checked)
            {
                // Show Outsourced fields and hide In-House fields
                addPartMachineIDLabel.Visible = false;
                addPartMachineIDTextBox.Visible = false;
                addPartCompanyNameLabel.Visible = true;
                addPartCompanyNameTextBox.Visible = true;
            }
        }

        private void partInHouseRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (partInHouseRadio.Checked)
            {
                // Show In-House fields and hide Outsourced fields
                addPartMachineIDLabel.Visible = true;
                addPartMachineIDTextBox.Visible = true;
                addPartCompanyNameLabel.Visible = false;
                addPartCompanyNameTextBox.Visible = false;
            }
        }

        private void addPartCompanyNameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void addPartCompanyNameLabel_Click(object sender, EventArgs e)
        {

        }

        private void AddPart_Load(object sender, EventArgs e)
        {

        }
    }
}

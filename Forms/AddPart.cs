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
            InitializeForm(null); // No part passed in, so it's an "Add" operation
        }

        // Constructor for modifying an existing part
        public AddPart(Part part)
        {
            InitializeComponent();
            InitializeForm(part);
        }
        private void InitializeForm(Part part)
        {
            partInHouseRadio.CheckedChanged += new EventHandler(RadioButtons_CheckedChanged);
            partOutsourcedRadio.CheckedChanged += new EventHandler(RadioButtons_CheckedChanged);

            if (part != null)
            {
                // This is a modification scenario
                modifyPartLabel.Visible = true;
                addPartLabel.Visible = false;

                // Populate the form fields with the existing part's data
                addPartIDTextBox.Text = part.PartID.ToString();
                addPartNameTextBox.Text = part.PartName;
                addPartInventoryTextBox.Text = part.PartInventory.ToString();
                addPartPriceTextBox.Text = part.PartPrice.ToString();
                addPartMinTextBox.Text = part.PartMin.ToString();
                addPartMaxTextBox.Text = part.PartMax.ToString();

                if (part is InHouse inHousePart)
                {
                    partInHouseRadio.Checked = true;
                    addPartMachineIDTextBox.Text = inHousePart.MachineID.ToString();
                }
                else if (part is OutSourced outSourcedPart)
                {
                    partOutsourcedRadio.Checked = true;
                    addPartCompanyNameTextBox.Text = outSourcedPart.CompanyName;
                }
            }
            else
            {
                // This is an add scenario
                modifyPartLabel.Visible = false;
                addPartLabel.Visible = true;

                // Default to InHouse for new parts
                partInHouseRadio.Checked = true;

                // Clear all fields
                addPartIDTextBox.Clear();
                addPartNameTextBox.Clear();
                addPartInventoryTextBox.Clear();
                addPartPriceTextBox.Clear();
                addPartMinTextBox.Clear();
                addPartMaxTextBox.Clear();
                addPartMachineIDTextBox.Clear();
                addPartCompanyNameTextBox.Clear();
            }

            // Trigger the radio button change to set the initial state of fields
            RadioButtons_CheckedChanged(this, EventArgs.Empty);

            // Trigger the radio button change to set up the initial state of fields
            RadioButtons_CheckedChanged(this, EventArgs.Empty);
        }

        private void RadioButtons_CheckedChanged(object sender, EventArgs e)
        {
            if (partInHouseRadio.Checked)
            {
                addPartMachineIDLabel.Visible = true;
                addPartMachineIDTextBox.Visible = true;

                addPartCompanyNameLabel.Visible = false;
                addPartCompanyNameTextBox.Visible = false;
            }
            else if (partOutsourcedRadio.Checked)
            {
                addPartMachineIDLabel.Visible = false;
                addPartMachineIDTextBox.Visible = false;

                addPartCompanyNameLabel.Visible = true;
                addPartCompanyNameTextBox.Visible = true;
            }
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
            if (!int.TryParse(addPartIDTextBox.Text, out int partID) ||
                !int.TryParse(addPartInventoryTextBox.Text, out int inventory) ||
                !decimal.TryParse(addPartPriceTextBox.Text, out decimal price) ||
                !int.TryParse(addPartMinTextBox.Text, out int min) ||
                !int.TryParse(addPartMaxTextBox.Text, out int max))
            {
                MessageBox.Show("Please enter valid numeric values for ID, Inventory, Price, Min, and Max.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            // Create or update Part object based on the user's input
            if (partInHouseRadio.Checked)
            {
                if (!int.TryParse(addPartMachineIDTextBox.Text, out int machineID))
                {
                    MessageBox.Show("Please enter a valid numeric value for Machine ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Part = new InHouse(partID, addPartNameTextBox.Text, price, inventory, min, max, machineID);
            }
            else if (partOutsourcedRadio.Checked)
            {
                Part = new OutSourced(partID, addPartNameTextBox.Text, price, inventory, min, max, addPartCompanyNameTextBox.Text);
            }

            // Close the form and return the result
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

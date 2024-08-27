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

        public AddPart(Part part)
        {
            InitializeComponent();
            InitializeForm(part); // Part passed in, so it's a "Modify" operation
        }

        private void InitializeForm(Part part)
        {
            partInHouseRadio.CheckedChanged += new EventHandler(partInHouseRadio_CheckedChanged);
            partOutsourcedRadio.CheckedChanged += new EventHandler(partOutsourcedRadio_CheckedChanged);

            if (part != null)
            {
                modifyPartLabel.Visible = true;
                addPartLabel.Visible = false;

                // Populate form fields with the existing part's data
                addPartIDTextBox.Text = part.PartID.ToString();
                addPartNameTextBox.Text = part.PartName;
                addPartInventoryTextBox.Text = part.PartInventory.ToString();
                addPartPriceTextBox.Text = part.PartPrice.ToString();
                addPartMinTextBox.Text = part.PartMin.ToString();
                addPartMaxTextBox.Text = part.PartMax.ToString();

                if (part.PartMachineID.HasValue)
                {
                    partInHouseRadio.Checked = true;
                    addPartMachineIDTextBox.Text = part.PartMachineID.ToString();
                }
                else
                {
                    partOutsourcedRadio.Checked = true;
                    addPartCompanyNameTextBox.Text = part.PartCompanyName;
                }
            }
            else
            {
                modifyPartLabel.Visible = false;
                addPartLabel.Visible = true;

                partInHouseRadio.Checked = true; // Default selection
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
            // Check if any of the required fields are empty
            if (string.IsNullOrWhiteSpace(addPartIDTextBox.Text) ||
                string.IsNullOrWhiteSpace(addPartNameTextBox.Text) ||
                string.IsNullOrWhiteSpace(addPartInventoryTextBox.Text) ||
                string.IsNullOrWhiteSpace(addPartPriceTextBox.Text) ||
                string.IsNullOrWhiteSpace(addPartMinTextBox.Text) ||
                string.IsNullOrWhiteSpace(addPartMaxTextBox.Text) ||
                (partInHouseRadio.Checked && string.IsNullOrWhiteSpace(addPartMachineIDTextBox.Text)) ||  // Validate MachineID if In-House
                (partOutsourcedRadio.Checked && string.IsNullOrWhiteSpace(addPartCompanyNameTextBox.Text))) // Validate CompanyName if Outsourced
            {
                MessageBox.Show("All fields are required. Please fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Parse the input values
            int inventory = int.Parse(addPartInventoryTextBox.Text);
            int min = int.Parse(addPartMinTextBox.Text);
            int max = int.Parse(addPartMaxTextBox.Text);

            if (inventory < min || inventory > max)
            {
                MessageBox.Show("Inventory value must be between Min and Max.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (partInHouseRadio.Checked)
            {
                Part = new Part
                {
                    PartID = int.Parse(addPartIDTextBox.Text),
                    PartName = addPartNameTextBox.Text,
                    PartInventory = inventory,
                    PartPrice = decimal.Parse(addPartPriceTextBox.Text),
                    PartMin = min,
                    PartMax = max,
                    PartMachineID = int.Parse(addPartMachineIDTextBox.Text),
                    PartCompanyName = null // Clear the Company Name
                };
            }
            else if (partOutsourcedRadio.Checked)
            {
                Part = new Part
                {
                    PartID = int.Parse(addPartIDTextBox.Text),
                    PartName = addPartNameTextBox.Text,
                    PartInventory = inventory,
                    PartPrice = decimal.Parse(addPartPriceTextBox.Text),
                    PartMin = min,
                    PartMax = max,
                    PartMachineID = null, // Clear the Machine ID
                    PartCompanyName = addPartCompanyNameTextBox.Text
                };
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }


        private void partOutsourcedRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (partInHouseRadio.Checked)
            {
                addPartMachineIDLabel.Visible = true;
                addPartMachineIDTextBox.Visible = true;

            }

            else if (partOutsourcedRadio.Checked)
            {
                addPartMachineIDLabel.Visible = false;
                addPartMachineIDTextBox.Visible = false;
            }
        }

        private void partInHouseRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (partInHouseRadio.Checked)
            {

                addPartCompanyNameLabel.Visible = false;
                addPartCompanyNameTextBox.Visible = false;
            }

            else if (partOutsourcedRadio.Checked)
            {
                addPartCompanyNameLabel.Visible = true;
                addPartCompanyNameTextBox.Visible = true;
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

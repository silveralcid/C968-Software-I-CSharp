using C968_Software_I_CSharp.Models;
using System;
using System.Windows.Forms;

namespace C968_Software_I_CSharp.Forms
{
    public partial class AddPart : Form
    {
        public Part Part { get; private set; }
        private bool isModifyMode;

        public AddPart()
        {
            InitializeComponent();
            InitializeForm(null); 
        }

        public AddPart(Part part)
        {
            InitializeComponent();
            InitializeForm(part);
        }

        private void InitializeForm(Part part)
        {
            partInHouseRadio.CheckedChanged += RadioButtons_CheckedChanged;
            partOutsourcedRadio.CheckedChanged += RadioButtons_CheckedChanged;

            if (part != null)
            {
                isModifyMode = true;

                modifyPartLabel.Visible = true;
                addPartLabel.Visible = false;
                addPartIDTextBox.ReadOnly = true;

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

                Part = part;
            }
            else
            {
                isModifyMode = false;

                modifyPartLabel.Visible = false;
                addPartLabel.Visible = true;

                partInHouseRadio.Checked = true;

                addPartIDTextBox.Clear();
                addPartNameTextBox.Clear();
                addPartInventoryTextBox.Clear();
                addPartPriceTextBox.Clear();
                addPartMinTextBox.Clear();
                addPartMaxTextBox.Clear();
                addPartMachineIDTextBox.Clear();
                addPartCompanyNameTextBox.Clear();

                addPartIDTextBox.ReadOnly = true;
            }

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

        private void addPartSaveButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(addPartNameTextBox.Text) ||
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

            if (!int.TryParse(addPartInventoryTextBox.Text, out int inventory) ||
                !decimal.TryParse(addPartPriceTextBox.Text, out decimal price) ||
                !int.TryParse(addPartMinTextBox.Text, out int min) ||
                !int.TryParse(addPartMaxTextBox.Text, out int max))
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

            if (isModifyMode)
            {
                // Modifying an existing part
                Part.PartName = addPartNameTextBox.Text;
                Part.PartInventory = inventory;
                Part.PartPrice = price;
                Part.PartMin = min;
                Part.PartMax = max;

                if (Part is InHouse inHousePart)
                {
                    inHousePart.MachineID = int.Parse(addPartMachineIDTextBox.Text);
                }
                else if (Part is OutSourced outSourcedPart)
                {
                    outSourcedPart.CompanyName = addPartCompanyNameTextBox.Text;
                }

                Inventory.UpdatePart(Part);
            }
            else
            {
                int newPartID = Inventory.GetNextPartID(); 
                if (partInHouseRadio.Checked)
                {
                    if (!int.TryParse(addPartMachineIDTextBox.Text, out int machineID))
                    {
                        MessageBox.Show("Please enter a valid numeric value for Machine ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    Part = new InHouse(newPartID, addPartNameTextBox.Text, price, inventory, min, max, machineID);
                }
                else if (partOutsourcedRadio.Checked)
                {
                    Part = new OutSourced(newPartID, addPartNameTextBox.Text, price, inventory, min, max, addPartCompanyNameTextBox.Text);
                }
                Inventory.AddPart(Part);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void addPartCancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void AddPart_Load(object sender, EventArgs e)
        {

        }
    }
}

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
            Part = new Part
            {
                PartID = int.Parse(addPartIDTextBox.Text),
                PartName = addPartNameTextBox.Text,
                PartInventory = int.Parse(addPartInventoryTextBox.Text),
                PartPrice = decimal.Parse(addPartPriceTextBox.Text),
                PartMin = int.Parse(addPartMinTextBox.Text),
                PartMax = int.Parse(addPartMaxTextBox.Text),
                PartMachineID = int.Parse(addPartMachineIDTextBox.Text),
            };
            
            this.DialogResult = DialogResult.OK;
            this.Close();
            
        }
    }
}

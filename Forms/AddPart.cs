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

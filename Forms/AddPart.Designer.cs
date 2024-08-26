namespace C968_Software_I_CSharp.Forms
{
    partial class AddPart
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.addPartLabel = new System.Windows.Forms.Label();
            this.partInHouseRadio = new System.Windows.Forms.RadioButton();
            this.addPartIDTextBox = new System.Windows.Forms.TextBox();
            this.partOutsourcedRadio = new System.Windows.Forms.RadioButton();
            this.addPartIDLabel = new System.Windows.Forms.Label();
            this.addPartNameLabel = new System.Windows.Forms.Label();
            this.addPartNameTextBox = new System.Windows.Forms.TextBox();
            this.addPartInventoryTextBox = new System.Windows.Forms.TextBox();
            this.addPartInventoryLabel = new System.Windows.Forms.Label();
            this.addPartPriceTextBox = new System.Windows.Forms.TextBox();
            this.addPartPriceLabel = new System.Windows.Forms.Label();
            this.addPartMaxTextBox = new System.Windows.Forms.TextBox();
            this.addPartMaxLabel = new System.Windows.Forms.Label();
            this.addPartMachineIDTextBox = new System.Windows.Forms.TextBox();
            this.addPartMachineIDLabel = new System.Windows.Forms.Label();
            this.addPartMinTextBox = new System.Windows.Forms.TextBox();
            this.addPartMinLabel = new System.Windows.Forms.Label();
            this.addPartSaveButton = new System.Windows.Forms.Button();
            this.addPartCancelButton = new System.Windows.Forms.Button();
            this.addPartCompanyNameTextBox = new System.Windows.Forms.TextBox();
            this.addPartCompanyNameLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // addPartLabel
            // 
            this.addPartLabel.AutoSize = true;
            this.addPartLabel.Location = new System.Drawing.Point(13, 13);
            this.addPartLabel.Name = "addPartLabel";
            this.addPartLabel.Size = new System.Drawing.Size(71, 20);
            this.addPartLabel.TabIndex = 0;
            this.addPartLabel.Text = "Add Part";
            // 
            // partInHouseRadio
            // 
            this.partInHouseRadio.AutoSize = true;
            this.partInHouseRadio.Location = new System.Drawing.Point(163, 11);
            this.partInHouseRadio.Name = "partInHouseRadio";
            this.partInHouseRadio.Size = new System.Drawing.Size(100, 24);
            this.partInHouseRadio.TabIndex = 1;
            this.partInHouseRadio.TabStop = true;
            this.partInHouseRadio.Text = "In-House";
            this.partInHouseRadio.UseVisualStyleBackColor = true;
            this.partInHouseRadio.CheckedChanged += new System.EventHandler(this.partInHouseRadio_CheckedChanged);
            // 
            // addPartIDTextBox
            // 
            this.addPartIDTextBox.Location = new System.Drawing.Point(293, 89);
            this.addPartIDTextBox.Name = "addPartIDTextBox";
            this.addPartIDTextBox.Size = new System.Drawing.Size(191, 26);
            this.addPartIDTextBox.TabIndex = 2;
            // 
            // partOutsourcedRadio
            // 
            this.partOutsourcedRadio.AutoSize = true;
            this.partOutsourcedRadio.Location = new System.Drawing.Point(293, 11);
            this.partOutsourcedRadio.Name = "partOutsourcedRadio";
            this.partOutsourcedRadio.Size = new System.Drawing.Size(117, 24);
            this.partOutsourcedRadio.TabIndex = 3;
            this.partOutsourcedRadio.TabStop = true;
            this.partOutsourcedRadio.Text = "Outsourced";
            this.partOutsourcedRadio.UseVisualStyleBackColor = true;
            // 
            // addPartIDLabel
            // 
            this.addPartIDLabel.AutoSize = true;
            this.addPartIDLabel.Location = new System.Drawing.Point(222, 92);
            this.addPartIDLabel.Name = "addPartIDLabel";
            this.addPartIDLabel.Size = new System.Drawing.Size(26, 20);
            this.addPartIDLabel.TabIndex = 4;
            this.addPartIDLabel.Text = "ID";
            // 
            // addPartNameLabel
            // 
            this.addPartNameLabel.AutoSize = true;
            this.addPartNameLabel.Location = new System.Drawing.Point(198, 146);
            this.addPartNameLabel.Name = "addPartNameLabel";
            this.addPartNameLabel.Size = new System.Drawing.Size(51, 20);
            this.addPartNameLabel.TabIndex = 5;
            this.addPartNameLabel.Text = "Name";
            this.addPartNameLabel.Click += new System.EventHandler(this.addPartPriceCostLabel_Click);
            // 
            // addPartNameTextBox
            // 
            this.addPartNameTextBox.Location = new System.Drawing.Point(293, 143);
            this.addPartNameTextBox.Name = "addPartNameTextBox";
            this.addPartNameTextBox.Size = new System.Drawing.Size(191, 26);
            this.addPartNameTextBox.TabIndex = 6;
            // 
            // addPartInventoryTextBox
            // 
            this.addPartInventoryTextBox.Location = new System.Drawing.Point(293, 198);
            this.addPartInventoryTextBox.Name = "addPartInventoryTextBox";
            this.addPartInventoryTextBox.Size = new System.Drawing.Size(191, 26);
            this.addPartInventoryTextBox.TabIndex = 8;
            // 
            // addPartInventoryLabel
            // 
            this.addPartInventoryLabel.AutoSize = true;
            this.addPartInventoryLabel.Location = new System.Drawing.Point(174, 201);
            this.addPartInventoryLabel.Name = "addPartInventoryLabel";
            this.addPartInventoryLabel.Size = new System.Drawing.Size(74, 20);
            this.addPartInventoryLabel.TabIndex = 7;
            this.addPartInventoryLabel.Text = "Inventory";
            // 
            // addPartPriceTextBox
            // 
            this.addPartPriceTextBox.Location = new System.Drawing.Point(293, 253);
            this.addPartPriceTextBox.Name = "addPartPriceTextBox";
            this.addPartPriceTextBox.Size = new System.Drawing.Size(191, 26);
            this.addPartPriceTextBox.TabIndex = 10;
            // 
            // addPartPriceLabel
            // 
            this.addPartPriceLabel.AutoSize = true;
            this.addPartPriceLabel.Location = new System.Drawing.Point(160, 256);
            this.addPartPriceLabel.Name = "addPartPriceLabel";
            this.addPartPriceLabel.Size = new System.Drawing.Size(89, 20);
            this.addPartPriceLabel.TabIndex = 9;
            this.addPartPriceLabel.Text = "Price / Cost";
            // 
            // addPartMaxTextBox
            // 
            this.addPartMaxTextBox.Location = new System.Drawing.Point(293, 303);
            this.addPartMaxTextBox.Name = "addPartMaxTextBox";
            this.addPartMaxTextBox.Size = new System.Drawing.Size(108, 26);
            this.addPartMaxTextBox.TabIndex = 12;
            // 
            // addPartMaxLabel
            // 
            this.addPartMaxLabel.AutoSize = true;
            this.addPartMaxLabel.Location = new System.Drawing.Point(210, 306);
            this.addPartMaxLabel.Name = "addPartMaxLabel";
            this.addPartMaxLabel.Size = new System.Drawing.Size(38, 20);
            this.addPartMaxLabel.TabIndex = 11;
            this.addPartMaxLabel.Text = "Max";
            // 
            // addPartMachineIDTextBox
            // 
            this.addPartMachineIDTextBox.Location = new System.Drawing.Point(293, 352);
            this.addPartMachineIDTextBox.Name = "addPartMachineIDTextBox";
            this.addPartMachineIDTextBox.Size = new System.Drawing.Size(191, 26);
            this.addPartMachineIDTextBox.TabIndex = 14;
            // 
            // addPartMachineIDLabel
            // 
            this.addPartMachineIDLabel.AutoSize = true;
            this.addPartMachineIDLabel.Location = new System.Drawing.Point(158, 355);
            this.addPartMachineIDLabel.Name = "addPartMachineIDLabel";
            this.addPartMachineIDLabel.Size = new System.Drawing.Size(90, 20);
            this.addPartMachineIDLabel.TabIndex = 13;
            this.addPartMachineIDLabel.Text = "Machine ID";
            // 
            // addPartMinTextBox
            // 
            this.addPartMinTextBox.Location = new System.Drawing.Point(529, 303);
            this.addPartMinTextBox.Name = "addPartMinTextBox";
            this.addPartMinTextBox.Size = new System.Drawing.Size(108, 26);
            this.addPartMinTextBox.TabIndex = 16;
            // 
            // addPartMinLabel
            // 
            this.addPartMinLabel.AutoSize = true;
            this.addPartMinLabel.Location = new System.Drawing.Point(450, 306);
            this.addPartMinLabel.Name = "addPartMinLabel";
            this.addPartMinLabel.Size = new System.Drawing.Size(34, 20);
            this.addPartMinLabel.TabIndex = 15;
            this.addPartMinLabel.Text = "Min";
            this.addPartMinLabel.Click += new System.EventHandler(this.label5_Click);
            // 
            // addPartSaveButton
            // 
            this.addPartSaveButton.Location = new System.Drawing.Point(474, 423);
            this.addPartSaveButton.Name = "addPartSaveButton";
            this.addPartSaveButton.Size = new System.Drawing.Size(75, 40);
            this.addPartSaveButton.TabIndex = 17;
            this.addPartSaveButton.Text = "Save";
            this.addPartSaveButton.UseVisualStyleBackColor = true;
            this.addPartSaveButton.Click += new System.EventHandler(this.addPartSaveButton_Click);
            // 
            // addPartCancelButton
            // 
            this.addPartCancelButton.Location = new System.Drawing.Point(562, 423);
            this.addPartCancelButton.Name = "addPartCancelButton";
            this.addPartCancelButton.Size = new System.Drawing.Size(75, 40);
            this.addPartCancelButton.TabIndex = 18;
            this.addPartCancelButton.Text = "Cancel";
            this.addPartCancelButton.UseVisualStyleBackColor = true;
            this.addPartCancelButton.Click += new System.EventHandler(this.addPartCancelButton_Click);
            // 
            // addPartCompanyNameTextBox
            // 
            this.addPartCompanyNameTextBox.Location = new System.Drawing.Point(293, 352);
            this.addPartCompanyNameTextBox.Name = "addPartCompanyNameTextBox";
            this.addPartCompanyNameTextBox.Size = new System.Drawing.Size(191, 26);
            this.addPartCompanyNameTextBox.TabIndex = 20;
            this.addPartCompanyNameTextBox.TextChanged += new System.EventHandler(this.addPartCompanyNameTextBox_TextChanged);
            // 
            // addPartCompanyNameLabel
            // 
            this.addPartCompanyNameLabel.AutoSize = true;
            this.addPartCompanyNameLabel.Location = new System.Drawing.Point(126, 355);
            this.addPartCompanyNameLabel.Name = "addPartCompanyNameLabel";
            this.addPartCompanyNameLabel.Size = new System.Drawing.Size(122, 20);
            this.addPartCompanyNameLabel.TabIndex = 19;
            this.addPartCompanyNameLabel.Text = "Company Name";
            this.addPartCompanyNameLabel.Click += new System.EventHandler(this.addPartCompanyNameLabel_Click);
            // 
            // AddPart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 494);
            this.Controls.Add(this.addPartCompanyNameTextBox);
            this.Controls.Add(this.addPartCompanyNameLabel);
            this.Controls.Add(this.addPartCancelButton);
            this.Controls.Add(this.addPartSaveButton);
            this.Controls.Add(this.addPartMinTextBox);
            this.Controls.Add(this.addPartMinLabel);
            this.Controls.Add(this.addPartMachineIDTextBox);
            this.Controls.Add(this.addPartMachineIDLabel);
            this.Controls.Add(this.addPartMaxTextBox);
            this.Controls.Add(this.addPartMaxLabel);
            this.Controls.Add(this.addPartPriceTextBox);
            this.Controls.Add(this.addPartPriceLabel);
            this.Controls.Add(this.addPartInventoryTextBox);
            this.Controls.Add(this.addPartInventoryLabel);
            this.Controls.Add(this.addPartNameTextBox);
            this.Controls.Add(this.addPartNameLabel);
            this.Controls.Add(this.addPartIDLabel);
            this.Controls.Add(this.partOutsourcedRadio);
            this.Controls.Add(this.addPartIDTextBox);
            this.Controls.Add(this.partInHouseRadio);
            this.Controls.Add(this.addPartLabel);
            this.Name = "AddPart";
            this.Text = "Part";
            this.Load += new System.EventHandler(this.AddPart_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label addPartLabel;
        private System.Windows.Forms.RadioButton partInHouseRadio;
        private System.Windows.Forms.TextBox addPartIDTextBox;
        private System.Windows.Forms.RadioButton partOutsourcedRadio;
        private System.Windows.Forms.Label addPartIDLabel;
        private System.Windows.Forms.Label addPartNameLabel;
        private System.Windows.Forms.TextBox addPartNameTextBox;
        private System.Windows.Forms.TextBox addPartInventoryTextBox;
        private System.Windows.Forms.Label addPartInventoryLabel;
        private System.Windows.Forms.TextBox addPartPriceTextBox;
        private System.Windows.Forms.Label addPartPriceLabel;
        private System.Windows.Forms.TextBox addPartMaxTextBox;
        private System.Windows.Forms.Label addPartMaxLabel;
        private System.Windows.Forms.TextBox addPartMachineIDTextBox;
        private System.Windows.Forms.Label addPartMachineIDLabel;
        private System.Windows.Forms.TextBox addPartMinTextBox;
        private System.Windows.Forms.Label addPartMinLabel;
        private System.Windows.Forms.Button addPartSaveButton;
        private System.Windows.Forms.Button addPartCancelButton;
        private System.Windows.Forms.TextBox addPartCompanyNameTextBox;
        private System.Windows.Forms.Label addPartCompanyNameLabel;
    }
}
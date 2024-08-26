namespace C968_Software_I_CSharp
{
    partial class MainScreen
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
            this.titleLabel = new System.Windows.Forms.Label();
            this.partsSearchBox = new System.Windows.Forms.TextBox();
            this.partsGridView = new System.Windows.Forms.DataGridView();
            this.productsGridView = new System.Windows.Forms.DataGridView();
            this.productsSearchBox = new System.Windows.Forms.TextBox();
            this.partsGridLabel = new System.Windows.Forms.Label();
            this.productGridLabel = new System.Windows.Forms.Label();
            this.partsSearchButton = new System.Windows.Forms.Button();
            this.productsSearchButton = new System.Windows.Forms.Button();
            this.partsAddButton = new System.Windows.Forms.Button();
            this.partsDeleteButton = new System.Windows.Forms.Button();
            this.partsModifyButton = new System.Windows.Forms.Button();
            this.productsModifyButton = new System.Windows.Forms.Button();
            this.productsDeleteButton = new System.Windows.Forms.Button();
            this.productsAddButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.partsGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productsGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Location = new System.Drawing.Point(20, 20);
            this.titleLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(237, 20);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Inventory Management Systems";
            // 
            // partsSearchBox
            // 
            this.partsSearchBox.Location = new System.Drawing.Point(518, 85);
            this.partsSearchBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.partsSearchBox.Name = "partsSearchBox";
            this.partsSearchBox.Size = new System.Drawing.Size(228, 26);
            this.partsSearchBox.TabIndex = 1;
            this.partsSearchBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // partsGridView
            // 
            this.partsGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.partsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.partsGridView.Location = new System.Drawing.Point(24, 132);
            this.partsGridView.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.partsGridView.Name = "partsGridView";
            this.partsGridView.RowHeadersWidth = 62;
            this.partsGridView.Size = new System.Drawing.Size(720, 231);
            this.partsGridView.TabIndex = 2;
            this.partsGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.partsGridView_CellContentClick);
            // 
            // productsGridView
            // 
            this.productsGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.productsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.productsGridView.Location = new System.Drawing.Point(774, 132);
            this.productsGridView.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.productsGridView.Name = "productsGridView";
            this.productsGridView.RowHeadersWidth = 62;
            this.productsGridView.Size = new System.Drawing.Size(720, 231);
            this.productsGridView.TabIndex = 3;
            // 
            // productsSearchBox
            // 
            this.productsSearchBox.Location = new System.Drawing.Point(1266, 85);
            this.productsSearchBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.productsSearchBox.Name = "productsSearchBox";
            this.productsSearchBox.Size = new System.Drawing.Size(228, 26);
            this.productsSearchBox.TabIndex = 4;
            this.productsSearchBox.TextChanged += new System.EventHandler(this.productsSearchBox_TextChanged);
            // 
            // partsGridLabel
            // 
            this.partsGridLabel.AutoSize = true;
            this.partsGridLabel.Location = new System.Drawing.Point(29, 104);
            this.partsGridLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.partsGridLabel.Name = "partsGridLabel";
            this.partsGridLabel.Size = new System.Drawing.Size(46, 20);
            this.partsGridLabel.TabIndex = 5;
            this.partsGridLabel.Text = "Parts";
            // 
            // productGridLabel
            // 
            this.productGridLabel.AutoSize = true;
            this.productGridLabel.Location = new System.Drawing.Point(779, 104);
            this.productGridLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.productGridLabel.Name = "productGridLabel";
            this.productGridLabel.Size = new System.Drawing.Size(72, 20);
            this.productGridLabel.TabIndex = 6;
            this.productGridLabel.Text = "Products";
            // 
            // partsSearchButton
            // 
            this.partsSearchButton.Location = new System.Drawing.Point(417, 81);
            this.partsSearchButton.Name = "partsSearchButton";
            this.partsSearchButton.Size = new System.Drawing.Size(83, 34);
            this.partsSearchButton.TabIndex = 7;
            this.partsSearchButton.Text = "Search";
            this.partsSearchButton.UseVisualStyleBackColor = true;
            // 
            // productsSearchButton
            // 
            this.productsSearchButton.Location = new System.Drawing.Point(1166, 81);
            this.productsSearchButton.Name = "productsSearchButton";
            this.productsSearchButton.Size = new System.Drawing.Size(83, 34);
            this.productsSearchButton.TabIndex = 8;
            this.productsSearchButton.Text = "Search";
            this.productsSearchButton.UseVisualStyleBackColor = true;
            this.productsSearchButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // partsAddButton
            // 
            this.partsAddButton.Location = new System.Drawing.Point(523, 371);
            this.partsAddButton.Name = "partsAddButton";
            this.partsAddButton.Size = new System.Drawing.Size(70, 40);
            this.partsAddButton.TabIndex = 9;
            this.partsAddButton.Text = "Add";
            this.partsAddButton.UseVisualStyleBackColor = true;
            this.partsAddButton.Click += new System.EventHandler(this.partsAddButton_Click);
            // 
            // partsDeleteButton
            // 
            this.partsDeleteButton.Location = new System.Drawing.Point(675, 371);
            this.partsDeleteButton.Name = "partsDeleteButton";
            this.partsDeleteButton.Size = new System.Drawing.Size(70, 40);
            this.partsDeleteButton.TabIndex = 10;
            this.partsDeleteButton.Text = "Delete";
            this.partsDeleteButton.UseVisualStyleBackColor = true;
            this.partsDeleteButton.Click += new System.EventHandler(this.partsDeleteButton_Click);
            // 
            // partsModifyButton
            // 
            this.partsModifyButton.Location = new System.Drawing.Point(599, 371);
            this.partsModifyButton.Name = "partsModifyButton";
            this.partsModifyButton.Size = new System.Drawing.Size(70, 40);
            this.partsModifyButton.TabIndex = 11;
            this.partsModifyButton.Text = "Modify";
            this.partsModifyButton.UseVisualStyleBackColor = true;
            // 
            // productsModifyButton
            // 
            this.productsModifyButton.Location = new System.Drawing.Point(1346, 371);
            this.productsModifyButton.Name = "productsModifyButton";
            this.productsModifyButton.Size = new System.Drawing.Size(70, 40);
            this.productsModifyButton.TabIndex = 14;
            this.productsModifyButton.Text = "Modify";
            this.productsModifyButton.UseVisualStyleBackColor = true;
            // 
            // productsDeleteButton
            // 
            this.productsDeleteButton.Location = new System.Drawing.Point(1422, 371);
            this.productsDeleteButton.Name = "productsDeleteButton";
            this.productsDeleteButton.Size = new System.Drawing.Size(70, 40);
            this.productsDeleteButton.TabIndex = 13;
            this.productsDeleteButton.Text = "Delete";
            this.productsDeleteButton.UseVisualStyleBackColor = true;
            // 
            // productsAddButton
            // 
            this.productsAddButton.Location = new System.Drawing.Point(1270, 371);
            this.productsAddButton.Name = "productsAddButton";
            this.productsAddButton.Size = new System.Drawing.Size(70, 40);
            this.productsAddButton.TabIndex = 12;
            this.productsAddButton.Text = "Add";
            this.productsAddButton.UseVisualStyleBackColor = true;
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(1422, 448);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(70, 40);
            this.exitButton.TabIndex = 15;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(1512, 500);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.productsModifyButton);
            this.Controls.Add(this.productsDeleteButton);
            this.Controls.Add(this.productsAddButton);
            this.Controls.Add(this.partsModifyButton);
            this.Controls.Add(this.partsDeleteButton);
            this.Controls.Add(this.partsAddButton);
            this.Controls.Add(this.productsSearchButton);
            this.Controls.Add(this.partsSearchButton);
            this.Controls.Add(this.productGridLabel);
            this.Controls.Add(this.partsGridLabel);
            this.Controls.Add(this.productsSearchBox);
            this.Controls.Add(this.productsGridView);
            this.Controls.Add(this.partsGridView);
            this.Controls.Add(this.partsSearchBox);
            this.Controls.Add(this.titleLabel);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainScreen";
            this.Text = "Main Screen";
            ((System.ComponentModel.ISupportInitialize)(this.partsGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productsGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.TextBox partsSearchBox;
        private System.Windows.Forms.DataGridView partsGridView;
        private System.Windows.Forms.DataGridView productsGridView;
        private System.Windows.Forms.TextBox productsSearchBox;
        private System.Windows.Forms.Label partsGridLabel;
        private System.Windows.Forms.Label productGridLabel;
        private System.Windows.Forms.Button partsSearchButton;
        private System.Windows.Forms.Button productsSearchButton;
        private System.Windows.Forms.Button partsAddButton;
        private System.Windows.Forms.Button partsDeleteButton;
        private System.Windows.Forms.Button partsModifyButton;
        private System.Windows.Forms.Button productsModifyButton;
        private System.Windows.Forms.Button productsDeleteButton;
        private System.Windows.Forms.Button productsAddButton;
        private System.Windows.Forms.Button exitButton;
    }
}


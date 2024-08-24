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
            ((System.ComponentModel.ISupportInitialize)(this.partsGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productsGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Location = new System.Drawing.Point(13, 13);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(158, 13);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Inventory Management Systems";
            this.titleLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // partsSearchBox
            // 
            this.partsSearchBox.Location = new System.Drawing.Point(343, 60);
            this.partsSearchBox.Name = "partsSearchBox";
            this.partsSearchBox.Size = new System.Drawing.Size(153, 20);
            this.partsSearchBox.TabIndex = 1;
            this.partsSearchBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // partsGridView
            // 
            this.partsGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.partsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.partsGridView.Location = new System.Drawing.Point(16, 86);
            this.partsGridView.Name = "partsGridView";
            this.partsGridView.Size = new System.Drawing.Size(480, 150);
            this.partsGridView.TabIndex = 2;
            // 
            // productsGridView
            // 
            this.productsGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.productsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.productsGridView.Location = new System.Drawing.Point(516, 86);
            this.productsGridView.Name = "productsGridView";
            this.productsGridView.Size = new System.Drawing.Size(480, 150);
            this.productsGridView.TabIndex = 3;
            // 
            // productsSearchBox
            // 
            this.productsSearchBox.Location = new System.Drawing.Point(843, 60);
            this.productsSearchBox.Name = "productsSearchBox";
            this.productsSearchBox.Size = new System.Drawing.Size(153, 20);
            this.productsSearchBox.TabIndex = 4;
            // 
            // partsGridLabel
            // 
            this.partsGridLabel.AutoSize = true;
            this.partsGridLabel.Location = new System.Drawing.Point(12, 67);
            this.partsGridLabel.Name = "partsGridLabel";
            this.partsGridLabel.Size = new System.Drawing.Size(31, 13);
            this.partsGridLabel.TabIndex = 5;
            this.partsGridLabel.Text = "Parts";
            // 
            // productGridLabel
            // 
            this.productGridLabel.AutoSize = true;
            this.productGridLabel.Location = new System.Drawing.Point(513, 67);
            this.productGridLabel.Name = "productGridLabel";
            this.productGridLabel.Size = new System.Drawing.Size(49, 13);
            this.productGridLabel.TabIndex = 6;
            this.productGridLabel.Text = "Products";
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.productGridLabel);
            this.Controls.Add(this.partsGridLabel);
            this.Controls.Add(this.productsSearchBox);
            this.Controls.Add(this.productsGridView);
            this.Controls.Add(this.partsGridView);
            this.Controls.Add(this.partsSearchBox);
            this.Controls.Add(this.titleLabel);
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
    }
}


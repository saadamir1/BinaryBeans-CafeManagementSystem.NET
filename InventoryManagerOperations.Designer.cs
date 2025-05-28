namespace Project
{
    partial class InventoryManagerOperations
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
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.Products = new System.Windows.Forms.ListBox();
            this.Categories = new System.Windows.Forms.ListBox();
            this.buttonUpdateStock = new System.Windows.Forms.Button();
            this.textBoxStockCount = new System.Windows.Forms.TextBox();
            this.textBoxProductName = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Sans Unicode", 14.25F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 83);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(217, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Change Stock Count";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Khaki;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Script MT Bold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.DarkBlue;
            this.button1.Location = new System.Drawing.Point(483, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 32);
            this.button1.TabIndex = 16;
            this.button1.Text = "Log out";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Products
            // 
            this.Products.FormattingEnabled = true;
            this.Products.Location = new System.Drawing.Point(157, 119);
            this.Products.Margin = new System.Windows.Forms.Padding(2);
            this.Products.Name = "Products";
            this.Products.Size = new System.Drawing.Size(327, 95);
            this.Products.TabIndex = 14;
            this.Products.SelectedIndexChanged += new System.EventHandler(this.listBox2_SelectedIndexChanged);
            // 
            // Categories
            // 
            this.Categories.FormattingEnabled = true;
            this.Categories.Location = new System.Drawing.Point(13, 119);
            this.Categories.Margin = new System.Windows.Forms.Padding(2);
            this.Categories.Name = "Categories";
            this.Categories.Size = new System.Drawing.Size(123, 95);
            this.Categories.TabIndex = 13;
            this.Categories.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged_1);
            // 
            // buttonUpdateStock
            // 
            this.buttonUpdateStock.BackColor = System.Drawing.Color.YellowGreen;
            this.buttonUpdateStock.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonUpdateStock.Location = new System.Drawing.Point(375, 269);
            this.buttonUpdateStock.Name = "buttonUpdateStock";
            this.buttonUpdateStock.Size = new System.Drawing.Size(109, 23);
            this.buttonUpdateStock.TabIndex = 17;
            this.buttonUpdateStock.Text = "Update Stock";
            this.buttonUpdateStock.UseVisualStyleBackColor = false;
            this.buttonUpdateStock.Click += new System.EventHandler(this.buttonUpdateStock_Click_1);
            // 
            // textBoxStockCount
            // 
            this.textBoxStockCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxStockCount.Location = new System.Drawing.Point(375, 232);
            this.textBoxStockCount.Name = "textBoxStockCount";
            this.textBoxStockCount.Size = new System.Drawing.Size(109, 21);
            this.textBoxStockCount.TabIndex = 18;
            this.textBoxStockCount.Text = "Stock Count";
            this.textBoxStockCount.TextChanged += new System.EventHandler(this.stockCount_TextChanged);
            // 
            // textBoxProductName
            // 
            this.textBoxProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxProductName.Location = new System.Drawing.Point(157, 232);
            this.textBoxProductName.Name = "textBoxProductName";
            this.textBoxProductName.Size = new System.Drawing.Size(152, 21);
            this.textBoxProductName.TabIndex = 19;
            this.textBoxProductName.Text = "Product Name";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Goldenrod;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(596, 59);
            this.panel1.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Goldenrod;
            this.label2.Font = new System.Drawing.Font("Script MT Bold", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label2.Location = new System.Drawing.Point(11, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(272, 38);
            this.label2.TabIndex = 17;
            this.label2.Text = "Inventory Manager";
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Khaki;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Script MT Bold", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button5.Location = new System.Drawing.Point(690, 11);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(97, 38);
            this.button5.TabIndex = 7;
            this.button5.Text = "Back";
            this.button5.UseVisualStyleBackColor = false;
            // 
            // InventoryManagerOperations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Khaki;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxProductName);
            this.Controls.Add(this.textBoxStockCount);
            this.Controls.Add(this.buttonUpdateStock);
            this.Controls.Add(this.Products);
            this.Controls.Add(this.Categories);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "InventoryManagerOperations";
            this.Text = "InventoryManagerOperations";
            this.Load += new System.EventHandler(this.InventoryManagerOperations_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox Products;
        private System.Windows.Forms.ListBox Categories;
        private System.Windows.Forms.Button buttonUpdateStock;
        private System.Windows.Forms.TextBox textBoxStockCount;
        private System.Windows.Forms.TextBox textBoxProductName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label2;
    }
}
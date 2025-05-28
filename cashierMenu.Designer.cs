namespace Project
{
    partial class cashierMenu
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
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.total = new System.Windows.Forms.TextBox();
            this.applyDiscount = new System.Windows.Forms.Button();
            this.orderList = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.discount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.newTotal = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.labelOrderDetails = new System.Windows.Forms.Label();
            this.orderItemList = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.orderItemList)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Khaki;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Script MT Bold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.DarkBlue;
            this.button1.Location = new System.Drawing.Point(693, 15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 32);
            this.button1.TabIndex = 16;
            this.button1.Text = "Log out";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Goldenrod;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(2, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(797, 59);
            this.panel1.TabIndex = 27;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Goldenrod;
            this.label2.Font = new System.Drawing.Font("Script MT Bold", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label2.Location = new System.Drawing.Point(10, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(263, 38);
            this.label2.TabIndex = 17;
            this.label2.Text = "Cashier Dashboard";
            // 
            // total
            // 
            this.total.Location = new System.Drawing.Point(280, 279);
            this.total.Name = "total";
            this.total.Size = new System.Drawing.Size(109, 20);
            this.total.TabIndex = 25;
            this.total.Text = "Total Amount";
            this.total.TextChanged += new System.EventHandler(this.total_TextChanged);
            // 
            // applyDiscount
            // 
            this.applyDiscount.BackColor = System.Drawing.Color.YellowGreen;
            this.applyDiscount.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.applyDiscount.Location = new System.Drawing.Point(399, 314);
            this.applyDiscount.Name = "applyDiscount";
            this.applyDiscount.Size = new System.Drawing.Size(109, 23);
            this.applyDiscount.TabIndex = 24;
            this.applyDiscount.Text = "Apply Discount";
            this.applyDiscount.UseVisualStyleBackColor = false;
            this.applyDiscount.Click += new System.EventHandler(this.applyDiscount_Click);
            // 
            // orderList
            // 
            this.orderList.FormattingEnabled = true;
            this.orderList.Location = new System.Drawing.Point(14, 120);
            this.orderList.Margin = new System.Windows.Forms.Padding(2);
            this.orderList.Name = "orderList";
            this.orderList.Size = new System.Drawing.Size(235, 134);
            this.orderList.TabIndex = 22;
            this.orderList.SelectedIndexChanged += new System.EventHandler(this.orderList_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lucida Sans Unicode", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 85);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 23);
            this.label3.TabIndex = 28;
            this.label3.Text = "Orders Details";
            // 
            // discount
            // 
            this.discount.Location = new System.Drawing.Point(280, 314);
            this.discount.Name = "discount";
            this.discount.Size = new System.Drawing.Size(109, 20);
            this.discount.TabIndex = 29;
            this.discount.Text = "discount %";
            this.discount.TextChanged += new System.EventHandler(this.discount_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(54, 314);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 16);
            this.label1.TabIndex = 30;
            this.label1.Text = "Enter Discount percentage:";
            // 
            // newTotal
            // 
            this.newTotal.Location = new System.Drawing.Point(280, 353);
            this.newTotal.Name = "newTotal";
            this.newTotal.Size = new System.Drawing.Size(109, 20);
            this.newTotal.TabIndex = 31;
            this.newTotal.Text = "Subtotal";
            this.newTotal.TextChanged += new System.EventHandler(this.newTotal_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(146, 357);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 16);
            this.label4.TabIndex = 32;
            this.label4.Text = "New Subtotal:";
            // 
            // labelOrderDetails
            // 
            this.labelOrderDetails.AutoSize = true;
            this.labelOrderDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOrderDetails.Location = new System.Drawing.Point(75, 283);
            this.labelOrderDetails.Name = "labelOrderDetails";
            this.labelOrderDetails.Size = new System.Drawing.Size(47, 16);
            this.labelOrderDetails.TabIndex = 33;
            this.labelOrderDetails.Text = "Total:";
            this.labelOrderDetails.Click += new System.EventHandler(this.labelOrderDetails_Click);
            // 
            // orderItemList
            // 
            this.orderItemList.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.orderItemList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.orderItemList.Location = new System.Drawing.Point(280, 120);
            this.orderItemList.Name = "orderItemList";
            this.orderItemList.Size = new System.Drawing.Size(442, 134);
            this.orderItemList.TabIndex = 34;
            this.orderItemList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.orderItemList_CellContentClick);
            // 
            // cashierMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Khaki;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.orderItemList);
            this.Controls.Add(this.labelOrderDetails);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.newTotal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.discount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.total);
            this.Controls.Add(this.applyDiscount);
            this.Controls.Add(this.orderList);
            this.Name = "cashierMenu";
            this.Text = "Form4";
            this.Load += new System.EventHandler(this.Form4_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.orderItemList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox total;
        private System.Windows.Forms.Button applyDiscount;
        private System.Windows.Forms.ListBox orderList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox discount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox newTotal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelOrderDetails;
        private System.Windows.Forms.DataGridView orderItemList;
    }
}
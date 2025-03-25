namespace QuanLyTiemTapHoa
{
    partial class fDashboard
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancelOrder = new System.Windows.Forms.Button();
            this.lvNewOder = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmAdmin = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAccount = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAccInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbTotalBillCost = new System.Windows.Forms.Label();
            this.tbTotalBillCost = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.cbbProducts = new System.Windows.Forms.ComboBox();
            this.nudQuantity = new System.Windows.Forms.NumericUpDown();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.cbbCategories = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancelOrder);
            this.panel1.Controls.Add(this.lvNewOder);
            this.panel1.Location = new System.Drawing.Point(8, 71);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1292, 959);
            this.panel1.TabIndex = 0;
            // 
            // btnCancelOrder
            // 
            this.btnCancelOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelOrder.Location = new System.Drawing.Point(4, 849);
            this.btnCancelOrder.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelOrder.Name = "btnCancelOrder";
            this.btnCancelOrder.Size = new System.Drawing.Size(271, 110);
            this.btnCancelOrder.TabIndex = 6;
            this.btnCancelOrder.Text = "Hủy đơn";
            this.btnCancelOrder.UseVisualStyleBackColor = true;
            this.btnCancelOrder.Click += new System.EventHandler(this.btnCancelOrder_Click);
            // 
            // lvNewOder
            // 
            this.lvNewOder.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lvNewOder.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvNewOder.HideSelection = false;
            this.lvNewOder.Location = new System.Drawing.Point(4, 3);
            this.lvNewOder.Name = "lvNewOder";
            this.lvNewOder.Size = new System.Drawing.Size(1285, 838);
            this.lvNewOder.TabIndex = 0;
            this.lvNewOder.UseCompatibleStateImageBehavior = false;
            this.lvNewOder.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Tên sản phẩm";
            this.columnHeader1.Width = 530;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Số lượng";
            this.columnHeader2.Width = 111;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Đơn giá";
            this.columnHeader3.Width = 313;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Thành tiền";
            this.columnHeader4.Width = 316;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmAdmin,
            this.tsmAccount});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(1904, 51);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmAdmin
            // 
            this.tsmAdmin.Name = "tsmAdmin";
            this.tsmAdmin.Size = new System.Drawing.Size(126, 49);
            this.tsmAdmin.Text = "Admin";
            this.tsmAdmin.Click += new System.EventHandler(this.adminToolStripMenuItem_Click);
            // 
            // tsmAccount
            // 
            this.tsmAccount.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmAccInfo,
            this.tsmLogout});
            this.tsmAccount.Name = "tsmAccount";
            this.tsmAccount.Size = new System.Drawing.Size(165, 49);
            this.tsmAccount.Text = "Tài khoản";
            // 
            // tsmAccInfo
            // 
            this.tsmAccInfo.Name = "tsmAccInfo";
            this.tsmAccInfo.Size = new System.Drawing.Size(429, 50);
            this.tsmAccInfo.Text = "Đổi thông tin tài khoản";
            // 
            // tsmLogout
            // 
            this.tsmLogout.Name = "tsmLogout";
            this.tsmLogout.Size = new System.Drawing.Size(429, 50);
            this.tsmLogout.Text = "Đăng xuất";
            this.tsmLogout.Click += new System.EventHandler(this.tsmLogout_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lbTotalBillCost);
            this.panel2.Controls.Add(this.tbTotalBillCost);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Location = new System.Drawing.Point(1304, 830);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(587, 200);
            this.panel2.TabIndex = 1;
            // 
            // lbTotalBillCost
            // 
            this.lbTotalBillCost.AutoSize = true;
            this.lbTotalBillCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalBillCost.Location = new System.Drawing.Point(2, 7);
            this.lbTotalBillCost.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbTotalBillCost.Name = "lbTotalBillCost";
            this.lbTotalBillCost.Size = new System.Drawing.Size(266, 29);
            this.lbTotalBillCost.TabIndex = 7;
            this.lbTotalBillCost.Text = "Tổng chi phí hóa đơn:";
            // 
            // tbTotalBillCost
            // 
            this.tbTotalBillCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTotalBillCost.Location = new System.Drawing.Point(7, 39);
            this.tbTotalBillCost.Name = "tbTotalBillCost";
            this.tbTotalBillCost.ReadOnly = true;
            this.tbTotalBillCost.Size = new System.Drawing.Size(574, 44);
            this.tbTotalBillCost.TabIndex = 6;
            this.tbTotalBillCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(2, 88);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(583, 110);
            this.button2.TabIndex = 5;
            this.button2.Text = "Thanh toán";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(1304, 200);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(587, 626);
            this.panel3.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.cbbProducts);
            this.panel4.Controls.Add(this.nudQuantity);
            this.panel4.Controls.Add(this.btnAddProduct);
            this.panel4.Controls.Add(this.cbbCategories);
            this.panel4.Location = new System.Drawing.Point(1304, 71);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(587, 125);
            this.panel4.TabIndex = 2;
            // 
            // cbbProducts
            // 
            this.cbbProducts.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbProducts.FormattingEnabled = true;
            this.cbbProducts.Location = new System.Drawing.Point(4, 44);
            this.cbbProducts.Margin = new System.Windows.Forms.Padding(2);
            this.cbbProducts.Name = "cbbProducts";
            this.cbbProducts.Size = new System.Drawing.Size(394, 39);
            this.cbbProducts.TabIndex = 5;
            this.cbbProducts.SelectedIndexChanged += new System.EventHandler(this.cbbProducts_SelectedIndexChanged);
            // 
            // nudQuantity
            // 
            this.nudQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudQuantity.Location = new System.Drawing.Point(293, 87);
            this.nudQuantity.Margin = new System.Windows.Forms.Padding(2);
            this.nudQuantity.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.nudQuantity.Name = "nudQuantity";
            this.nudQuantity.Size = new System.Drawing.Size(105, 31);
            this.nudQuantity.TabIndex = 4;
            this.nudQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudQuantity.ThousandsSeparator = true;
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddProduct.Location = new System.Drawing.Point(402, 2);
            this.btnAddProduct.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(183, 121);
            this.btnAddProduct.TabIndex = 3;
            this.btnAddProduct.Text = "+";
            this.btnAddProduct.UseVisualStyleBackColor = true;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // cbbCategories
            // 
            this.cbbCategories.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbCategories.FormattingEnabled = true;
            this.cbbCategories.Location = new System.Drawing.Point(4, 2);
            this.cbbCategories.Margin = new System.Windows.Forms.Padding(2);
            this.cbbCategories.Name = "cbbCategories";
            this.cbbCategories.Size = new System.Drawing.Size(394, 39);
            this.cbbCategories.TabIndex = 0;
            this.cbbCategories.SelectedIndexChanged += new System.EventHandler(this.cbbCategories_SelectedIndexChanged);
            // 
            // fDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "fDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fDashboard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmAdmin;
        private System.Windows.Forms.ToolStripMenuItem tsmAccount;
        private System.Windows.Forms.ToolStripMenuItem tsmAccInfo;
        private System.Windows.Forms.ToolStripMenuItem tsmLogout;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.NumericUpDown nudQuantity;
        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.ComboBox cbbCategories;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListView lvNewOder;
        private System.Windows.Forms.Button btnCancelOrder;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.TextBox tbTotalBillCost;
        private System.Windows.Forms.Label lbTotalBillCost;
        private System.Windows.Forms.ComboBox cbbProducts;
    }
}
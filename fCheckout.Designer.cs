namespace QuanLyTiemTapHoa
{
    partial class fCheckout
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
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblColumnSTT = new System.Windows.Forms.Label();
            this.lblColumnName = new System.Windows.Forms.Label();
            this.lblColumnQty = new System.Windows.Forms.Label();
            this.lblColumnPrice = new System.Windows.Forms.Label();
            this.lblColumnTotal = new System.Windows.Forms.Label();
            this.flpBillItems = new System.Windows.Forms.FlowLayoutPanel();
            this.lblOrderID = new System.Windows.Forms.Label();
            this.lblOrderDate = new System.Windows.Forms.Label();
            this.lblTotalLabel = new System.Windows.Forms.Label();
            this.lblGrandTotal = new System.Windows.Forms.Label();
            this.txtPromoCode = new System.Windows.Forms.TextBox();
            this.lblPromoCode = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.White;
            this.panelHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelHeader.Controls.Add(this.lblColumnSTT);
            this.panelHeader.Controls.Add(this.lblColumnName);
            this.panelHeader.Controls.Add(this.lblColumnQty);
            this.panelHeader.Controls.Add(this.lblColumnPrice);
            this.panelHeader.Controls.Add(this.lblColumnTotal);
            this.panelHeader.Location = new System.Drawing.Point(10, 65);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(380, 35);
            this.panelHeader.TabIndex = 0;
            // 
            // lblColumnSTT
            // 
            this.lblColumnSTT.AutoSize = true;
            this.lblColumnSTT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColumnSTT.Location = new System.Drawing.Point(12, 10);
            this.lblColumnSTT.Name = "lblColumnSTT";
            this.lblColumnSTT.Size = new System.Drawing.Size(32, 15);
            this.lblColumnSTT.TabIndex = 0;
            this.lblColumnSTT.Text = "STT";
            // 
            // lblColumnName
            // 
            this.lblColumnName.AutoSize = true;
            this.lblColumnName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColumnName.Location = new System.Drawing.Point(62, 10);
            this.lblColumnName.Name = "lblColumnName";
            this.lblColumnName.Size = new System.Drawing.Size(98, 15);
            this.lblColumnName.TabIndex = 1;
            this.lblColumnName.Text = "Tên sản phẩm";
            // 
            // lblColumnQty
            // 
            this.lblColumnQty.AutoSize = true;
            this.lblColumnQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColumnQty.Location = new System.Drawing.Point(162, 10);
            this.lblColumnQty.Name = "lblColumnQty";
            this.lblColumnQty.Size = new System.Drawing.Size(24, 15);
            this.lblColumnQty.TabIndex = 2;
            this.lblColumnQty.Text = "SL";
            // 
            // lblColumnPrice
            // 
            this.lblColumnPrice.AutoSize = true;
            this.lblColumnPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColumnPrice.Location = new System.Drawing.Point(212, 10);
            this.lblColumnPrice.Name = "lblColumnPrice";
            this.lblColumnPrice.Size = new System.Drawing.Size(57, 15);
            this.lblColumnPrice.TabIndex = 3;
            this.lblColumnPrice.Text = "Đơn giá";
            // 
            // lblColumnTotal
            // 
            this.lblColumnTotal.AutoSize = true;
            this.lblColumnTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColumnTotal.Location = new System.Drawing.Point(280, 10);
            this.lblColumnTotal.Name = "lblColumnTotal";
            this.lblColumnTotal.Size = new System.Drawing.Size(75, 15);
            this.lblColumnTotal.TabIndex = 4;
            this.lblColumnTotal.Text = "Thành tiền";
            // 
            // flpBillItems
            // 
            this.flpBillItems.AutoScroll = true;
            this.flpBillItems.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpBillItems.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpBillItems.Location = new System.Drawing.Point(10, 106);
            this.flpBillItems.Name = "flpBillItems";
            this.flpBillItems.Size = new System.Drawing.Size(380, 406);
            this.flpBillItems.TabIndex = 1;
            this.flpBillItems.WrapContents = false;
            // 
            // lblOrderID
            // 
            this.lblOrderID.AutoSize = true;
            this.lblOrderID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderID.Location = new System.Drawing.Point(6, 42);
            this.lblOrderID.Name = "lblOrderID";
            this.lblOrderID.Size = new System.Drawing.Size(97, 20);
            this.lblOrderID.TabIndex = 4;
            this.lblOrderID.Text = "Mã hóa đơn:";
            // 
            // lblOrderDate
            // 
            this.lblOrderDate.AutoSize = true;
            this.lblOrderDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderDate.Location = new System.Drawing.Point(6, 9);
            this.lblOrderDate.Name = "lblOrderDate";
            this.lblOrderDate.Size = new System.Drawing.Size(76, 20);
            this.lblOrderDate.TabIndex = 5;
            this.lblOrderDate.Text = "Ngày tạo:";
            // 
            // lblTotalLabel
            // 
            this.lblTotalLabel.AutoSize = true;
            this.lblTotalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalLabel.Location = new System.Drawing.Point(13, 572);
            this.lblTotalLabel.Name = "lblTotalLabel";
            this.lblTotalLabel.Size = new System.Drawing.Size(130, 25);
            this.lblTotalLabel.TabIndex = 2;
            this.lblTotalLabel.Text = "Tổng cộng:";
            // 
            // lblGrandTotal
            // 
            this.lblGrandTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGrandTotal.Location = new System.Drawing.Point(149, 572);
            this.lblGrandTotal.Name = "lblGrandTotal";
            this.lblGrandTotal.Size = new System.Drawing.Size(239, 25);
            this.lblGrandTotal.TabIndex = 3;
            this.lblGrandTotal.Text = "0 VNĐ";
            this.lblGrandTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPromoCode
            // 
            this.txtPromoCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPromoCode.Location = new System.Drawing.Point(10, 543);
            this.txtPromoCode.Name = "txtPromoCode";
            this.txtPromoCode.Size = new System.Drawing.Size(380, 26);
            this.txtPromoCode.TabIndex = 7;
            // 
            // lblPromoCode
            // 
            this.lblPromoCode.AutoSize = true;
            this.lblPromoCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPromoCode.Location = new System.Drawing.Point(13, 515);
            this.lblPromoCode.Name = "lblPromoCode";
            this.lblPromoCode.Size = new System.Drawing.Size(178, 25);
            this.lblPromoCode.TabIndex = 8;
            this.lblPromoCode.Text = "Mã khuyến mãi:";
            // 
            // btnExport
            // 
            this.btnExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.Location = new System.Drawing.Point(10, 615);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(380, 54);
            this.btnExport.TabIndex = 6;
            this.btnExport.Text = "Xuất hóa đơn";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // fCheckout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(404, 681);
            this.Controls.Add(this.txtPromoCode);
            this.Controls.Add(this.lblPromoCode);
            this.Controls.Add(this.lblGrandTotal);
            this.Controls.Add(this.lblTotalLabel);
            this.Controls.Add(this.flpBillItems);
            this.Controls.Add(this.lblOrderDate);
            this.Controls.Add(this.lblOrderID);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.btnExport);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "fCheckout";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hóa Đơn Thanh Toán";
            this.Load += new System.EventHandler(this.fCheckout_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblColumnSTT;
        private System.Windows.Forms.Label lblColumnName;
        private System.Windows.Forms.Label lblColumnQty;
        private System.Windows.Forms.Label lblColumnPrice;
        private System.Windows.Forms.Label lblColumnTotal;
        private System.Windows.Forms.FlowLayoutPanel flpBillItems;
        private System.Windows.Forms.Label lblOrderID;
        private System.Windows.Forms.Label lblOrderDate;
        private System.Windows.Forms.Label lblTotalLabel;
        private System.Windows.Forms.Label lblGrandTotal;
        private System.Windows.Forms.TextBox txtPromoCode;
        private System.Windows.Forms.Label lblPromoCode;
        private System.Windows.Forms.Button btnExport;
    }
}

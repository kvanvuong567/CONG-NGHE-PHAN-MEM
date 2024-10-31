namespace PhoneShopManager
{
    partial class ManagerHomeFrm
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
            this.txtkey = new System.Windows.Forms.TextBox();
            this.btnsearch = new System.Windows.Forms.Button();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.pnlProduct = new System.Windows.Forms.Panel();
            this.pnlItem = new System.Windows.Forms.Panel();
            this.lbDes = new System.Windows.Forms.Label();
            this.lbbrand = new System.Windows.Forms.Label();
            this.lbstock = new System.Windows.Forms.Label();
            this.lbprice = new System.Windows.Forms.Label();
            this.lbname = new System.Windows.Forms.Label();
            this.lbid = new System.Windows.Forms.Label();
            this.pbimage = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.home = new System.Windows.Forms.ToolStripMenuItem();
            this.QLSP = new System.Windows.Forms.ToolStripMenuItem();
            this.Donhang = new System.Windows.Forms.ToolStripMenuItem();
            this.Report = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvProduct = new System.Windows.Forms.DataGridView();
            this.pnlProduct.SuspendLayout();
            this.pnlItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbimage)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduct)).BeginInit();
            this.SuspendLayout();
            // 
            // txtkey
            // 
            this.txtkey.Location = new System.Drawing.Point(66, 37);
            this.txtkey.Name = "txtkey";
            this.txtkey.Size = new System.Drawing.Size(481, 20);
            this.txtkey.TabIndex = 0;
            // 
            // btnsearch
            // 
            this.btnsearch.Location = new System.Drawing.Point(639, 37);
            this.btnsearch.Name = "btnsearch";
            this.btnsearch.Size = new System.Drawing.Size(75, 21);
            this.btnsearch.TabIndex = 1;
            this.btnsearch.Text = "Tìm kiếm";
            this.btnsearch.UseVisualStyleBackColor = true;
            this.btnsearch.Click += new System.EventHandler(this.btnsearch_Click_1);
            // 
            // cmbType
            // 
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(779, 36);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(121, 21);
            this.cmbType.TabIndex = 2;
            // 
            // pnlProduct
            // 
            this.pnlProduct.AutoScroll = true;
            this.pnlProduct.Controls.Add(this.pnlItem);
            this.pnlProduct.Location = new System.Drawing.Point(568, 101);
            this.pnlProduct.Name = "pnlProduct";
            this.pnlProduct.Size = new System.Drawing.Size(332, 328);
            this.pnlProduct.TabIndex = 3;
            // 
            // pnlItem
            // 
            this.pnlItem.Controls.Add(this.lbDes);
            this.pnlItem.Controls.Add(this.lbbrand);
            this.pnlItem.Controls.Add(this.lbstock);
            this.pnlItem.Controls.Add(this.lbprice);
            this.pnlItem.Controls.Add(this.lbname);
            this.pnlItem.Controls.Add(this.lbid);
            this.pnlItem.Controls.Add(this.pbimage);
            this.pnlItem.Location = new System.Drawing.Point(22, 27);
            this.pnlItem.Name = "pnlItem";
            this.pnlItem.Size = new System.Drawing.Size(283, 284);
            this.pnlItem.TabIndex = 0;
            // 
            // lbDes
            // 
            this.lbDes.AutoSize = true;
            this.lbDes.Location = new System.Drawing.Point(12, 262);
            this.lbDes.Name = "lbDes";
            this.lbDes.Size = new System.Drawing.Size(0, 13);
            this.lbDes.TabIndex = 11;
            // 
            // lbbrand
            // 
            this.lbbrand.AutoSize = true;
            this.lbbrand.Location = new System.Drawing.Point(12, 236);
            this.lbbrand.Name = "lbbrand";
            this.lbbrand.Size = new System.Drawing.Size(0, 13);
            this.lbbrand.TabIndex = 9;
            // 
            // lbstock
            // 
            this.lbstock.AutoSize = true;
            this.lbstock.Location = new System.Drawing.Point(12, 212);
            this.lbstock.Name = "lbstock";
            this.lbstock.Size = new System.Drawing.Size(0, 13);
            this.lbstock.TabIndex = 6;
            // 
            // lbprice
            // 
            this.lbprice.AutoSize = true;
            this.lbprice.Location = new System.Drawing.Point(12, 189);
            this.lbprice.Name = "lbprice";
            this.lbprice.Size = new System.Drawing.Size(0, 13);
            this.lbprice.TabIndex = 5;
            // 
            // lbname
            // 
            this.lbname.AutoSize = true;
            this.lbname.Location = new System.Drawing.Point(12, 167);
            this.lbname.Name = "lbname";
            this.lbname.Size = new System.Drawing.Size(0, 13);
            this.lbname.TabIndex = 3;
            // 
            // lbid
            // 
            this.lbid.AutoSize = true;
            this.lbid.Location = new System.Drawing.Point(12, 11);
            this.lbid.Name = "lbid";
            this.lbid.Size = new System.Drawing.Size(0, 13);
            this.lbid.TabIndex = 1;
            // 
            // pbimage
            // 
            this.pbimage.Location = new System.Drawing.Point(18, 11);
            this.pbimage.Name = "pbimage";
            this.pbimage.Size = new System.Drawing.Size(246, 137);
            this.pbimage.TabIndex = 0;
            this.pbimage.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.home,
            this.QLSP,
            this.Donhang,
            this.Report});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(912, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // home
            // 
            this.home.Name = "home";
            this.home.Size = new System.Drawing.Size(71, 20);
            this.home.Text = "Trang chủ";
            this.home.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.home.Click += new System.EventHandler(this.home_Click);
            // 
            // QLSP
            // 
            this.QLSP.Name = "QLSP";
            this.QLSP.Size = new System.Drawing.Size(118, 20);
            this.QLSP.Text = "Quản Lý Sản Phẩm";
            this.QLSP.Click += new System.EventHandler(this.QLSP_Click);
            // 
            // Donhang
            // 
            this.Donhang.Name = "Donhang";
            this.Donhang.Size = new System.Drawing.Size(95, 20);
            this.Donhang.Text = "Tạo Đơn Hàng";
            this.Donhang.Click += new System.EventHandler(this.Donhang_Click);
            // 
            // Report
            // 
            this.Report.Name = "Report";
            this.Report.Size = new System.Drawing.Size(151, 20);
            this.Report.Text = "Xem Báo Cáo Doanh Thu";
            this.Report.Click += new System.EventHandler(this.Report_Click);
            // 
            // dgvProduct
            // 
            this.dgvProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProduct.Location = new System.Drawing.Point(66, 88);
            this.dgvProduct.Name = "dgvProduct";
            this.dgvProduct.Size = new System.Drawing.Size(481, 341);
            this.dgvProduct.TabIndex = 5;
            this.dgvProduct.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProduct_CellContentClick);
            // 
            // ManagerHomeFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 527);
            this.Controls.Add(this.dgvProduct);
            this.Controls.Add(this.pnlProduct);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.btnsearch);
            this.Controls.Add(this.txtkey);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ManagerHomeFrm";
            this.Text = "ManagerHomeFrm";
            this.pnlProduct.ResumeLayout(false);
            this.pnlItem.ResumeLayout(false);
            this.pnlItem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbimage)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduct)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtkey;
        private System.Windows.Forms.Button btnsearch;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Panel pnlProduct;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem home;
        private System.Windows.Forms.ToolStripMenuItem QLSP;
        private System.Windows.Forms.ToolStripMenuItem Donhang;
        private System.Windows.Forms.ToolStripMenuItem Report;
        private System.Windows.Forms.Panel pnlItem;
        private System.Windows.Forms.PictureBox pbimage;
        private System.Windows.Forms.Label lbid;
        private System.Windows.Forms.Label lbname;
        private System.Windows.Forms.Label lbprice;
        private System.Windows.Forms.Label lbstock;
        private System.Windows.Forms.Label lbbrand;
        private System.Windows.Forms.Label lbDes;
        private System.Windows.Forms.DataGridView dgvProduct;
    }
}
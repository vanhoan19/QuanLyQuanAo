namespace QLQuanAo.Forms.KhachHang
{
	partial class frmKhachHang
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
			this.lblTenKH = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.lblTongTien = new System.Windows.Forms.Label();
			this.guna2ContainerControl1 = new Guna.UI2.WinForms.Guna2ContainerControl();
			this.btnExit = new Guna.UI2.WinForms.Guna2Button();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.thongTinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.lichSuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
			this.conKH = new Guna.UI2.WinForms.Guna2ContainerControl();
			this.guna2ContainerControl1.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblTenKH
			// 
			this.lblTenKH.AutoSize = true;
			this.lblTenKH.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTenKH.Location = new System.Drawing.Point(18, 11);
			this.lblTenKH.Name = "lblTenKH";
			this.lblTenKH.Size = new System.Drawing.Size(275, 31);
			this.lblTenKH.TabIndex = 35;
			this.lblTenKH.Text = "Tên khách hàng - Mã KH";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(22, 58);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(148, 28);
			this.label2.TabIndex = 35;
			this.label2.Text = "Tổng bán hàng:";
			// 
			// lblTongTien
			// 
			this.lblTongTien.AutoSize = true;
			this.lblTongTien.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTongTien.Location = new System.Drawing.Point(179, 58);
			this.lblTongTien.Name = "lblTongTien";
			this.lblTongTien.Size = new System.Drawing.Size(89, 28);
			this.lblTongTien.TabIndex = 35;
			this.lblTongTien.Text = "1000000";
			// 
			// guna2ContainerControl1
			// 
			this.guna2ContainerControl1.BackColor = System.Drawing.SystemColors.Control;
			this.guna2ContainerControl1.Controls.Add(this.lblTongTien);
			this.guna2ContainerControl1.Controls.Add(this.btnExit);
			this.guna2ContainerControl1.Controls.Add(this.label2);
			this.guna2ContainerControl1.Controls.Add(this.lblTenKH);
			this.guna2ContainerControl1.Dock = System.Windows.Forms.DockStyle.Top;
			this.guna2ContainerControl1.FillColor = System.Drawing.SystemColors.Control;
			this.guna2ContainerControl1.Location = new System.Drawing.Point(0, 0);
			this.guna2ContainerControl1.Name = "guna2ContainerControl1";
			this.guna2ContainerControl1.Size = new System.Drawing.Size(1061, 105);
			this.guna2ContainerControl1.TabIndex = 36;
			this.guna2ContainerControl1.Text = "guna2ContainerControl1";
			// 
			// btnExit
			// 
			this.btnExit.BackColor = System.Drawing.SystemColors.Control;
			this.btnExit.BorderRadius = 10;
			this.btnExit.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			this.btnExit.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			this.btnExit.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.btnExit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
			this.btnExit.FillColor = System.Drawing.SystemColors.Control;
			this.btnExit.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.btnExit.ForeColor = System.Drawing.Color.White;
			this.btnExit.Image = global::QLQuanAo.Properties.Resources.exit;
			this.btnExit.ImageSize = new System.Drawing.Size(25, 25);
			this.btnExit.Location = new System.Drawing.Point(1008, 6);
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new System.Drawing.Size(41, 36);
			this.btnExit.TabIndex = 34;
			this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
			// 
			// menuStrip1
			// 
			this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
			this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thongTinToolStripMenuItem,
            this.lichSuToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(9, 116);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(290, 36);
			this.menuStrip1.TabIndex = 37;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// thongTinToolStripMenuItem
			// 
			this.thongTinToolStripMenuItem.Name = "thongTinToolStripMenuItem";
			this.thongTinToolStripMenuItem.Size = new System.Drawing.Size(110, 32);
			this.thongTinToolStripMenuItem.Text = "Thông tin";
			this.thongTinToolStripMenuItem.Click += new System.EventHandler(this.thongTinToolStripMenuItem_Click);
			// 
			// lichSuToolStripMenuItem
			// 
			this.lichSuToolStripMenuItem.Name = "lichSuToolStripMenuItem";
			this.lichSuToolStripMenuItem.Size = new System.Drawing.Size(172, 32);
			this.lichSuToolStripMenuItem.Text = "Lịch sử bán hàng";
			this.lichSuToolStripMenuItem.Click += new System.EventHandler(this.lichSuToolStripMenuItem_Click);
			// 
			// guna2Separator1
			// 
			this.guna2Separator1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(198)))), ((int)(((byte)(231)))));
			this.guna2Separator1.FillThickness = 4;
			this.guna2Separator1.Location = new System.Drawing.Point(0, 153);
			this.guna2Separator1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.guna2Separator1.Name = "guna2Separator1";
			this.guna2Separator1.Size = new System.Drawing.Size(1061, 10);
			this.guna2Separator1.TabIndex = 41;
			// 
			// conKH
			// 
			this.conKH.FillColor = System.Drawing.SystemColors.Control;
			this.conKH.Location = new System.Drawing.Point(24, 180);
			this.conKH.Name = "conKH";
			this.conKH.Size = new System.Drawing.Size(1014, 482);
			this.conKH.TabIndex = 42;
			this.conKH.Text = "guna2ContainerControl2";
			// 
			// frmKhachHang
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1061, 700);
			this.Controls.Add(this.conKH);
			this.Controls.Add(this.guna2Separator1);
			this.Controls.Add(this.guna2ContainerControl1);
			this.Controls.Add(this.menuStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "frmKhachHang";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "frmKhachHang";
			this.Load += new System.EventHandler(this.frmKhachHang_Load);
			this.guna2ContainerControl1.ResumeLayout(false);
			this.guna2ContainerControl1.PerformLayout();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Guna.UI2.WinForms.Guna2Button btnExit;
		private System.Windows.Forms.Label lblTenKH;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label lblTongTien;
		private Guna.UI2.WinForms.Guna2ContainerControl guna2ContainerControl1;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem thongTinToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem lichSuToolStripMenuItem;
		private Guna.UI2.WinForms.Guna2Separator guna2Separator1;
		private Guna.UI2.WinForms.Guna2ContainerControl conKH;
	}
}
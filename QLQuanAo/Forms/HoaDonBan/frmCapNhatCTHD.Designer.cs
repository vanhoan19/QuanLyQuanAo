namespace QLQuanAo.Forms.HoaDonBan
{
	partial class frmCapNhatCTHD
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCapNhatCTHD));
			this.panel2 = new System.Windows.Forms.Panel();
			this.btnBoQua = new Guna.UI2.WinForms.Guna2Button();
			this.btnCapNhat = new Guna.UI2.WinForms.Guna2Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.panel3 = new System.Windows.Forms.Panel();
			this.cmbMaHang = new Guna.UI2.WinForms.Guna2ComboBox();
			this.txtGiamGia = new Guna.UI2.WinForms.Guna2TextBox();
			this.txtThanhTien = new Guna.UI2.WinForms.Guna2TextBox();
			this.txtGiaBan = new Guna.UI2.WinForms.Guna2TextBox();
			this.txtSoLuong = new Guna.UI2.WinForms.Guna2TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.panel2.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel3.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.White;
			this.panel2.Controls.Add(this.btnBoQua);
			this.panel2.Controls.Add(this.btnCapNhat);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel2.Location = new System.Drawing.Point(0, 277);
			this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(596, 69);
			this.panel2.TabIndex = 4;
			// 
			// btnBoQua
			// 
			this.btnBoQua.BorderRadius = 10;
			this.btnBoQua.DefaultAutoSize = true;
			this.btnBoQua.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			this.btnBoQua.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			this.btnBoQua.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.btnBoQua.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
			this.btnBoQua.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			this.btnBoQua.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnBoQua.ForeColor = System.Drawing.Color.Black;
			this.btnBoQua.Image = ((System.Drawing.Image)(resources.GetObject("btnBoQua.Image")));
			this.btnBoQua.Location = new System.Drawing.Point(330, 8);
			this.btnBoQua.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnBoQua.Name = "btnBoQua";
			this.btnBoQua.Padding = new System.Windows.Forms.Padding(8);
			this.btnBoQua.Size = new System.Drawing.Size(111, 50);
			this.btnBoQua.TabIndex = 10;
			this.btnBoQua.Text = "H&ủy";
			this.btnBoQua.Click += new System.EventHandler(this.btnBoQua_Click);
			// 
			// btnCapNhat
			// 
			this.btnCapNhat.BorderRadius = 10;
			this.btnCapNhat.DefaultAutoSize = true;
			this.btnCapNhat.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			this.btnCapNhat.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			this.btnCapNhat.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.btnCapNhat.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
			this.btnCapNhat.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(226)))), ((int)(((byte)(255)))));
			this.btnCapNhat.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnCapNhat.ForeColor = System.Drawing.Color.Black;
			this.btnCapNhat.Image = ((System.Drawing.Image)(resources.GetObject("btnCapNhat.Image")));
			this.btnCapNhat.Location = new System.Drawing.Point(121, 8);
			this.btnCapNhat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnCapNhat.Name = "btnCapNhat";
			this.btnCapNhat.Padding = new System.Windows.Forms.Padding(8);
			this.btnCapNhat.Size = new System.Drawing.Size(149, 50);
			this.btnCapNhat.TabIndex = 9;
			this.btnCapNhat.Text = "Cập &nhật";
			this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.White;
			this.panel1.Controls.Add(this.label1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(596, 46);
			this.panel1.TabIndex = 3;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(197, 7);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(179, 31);
			this.label1.TabIndex = 0;
			this.label1.Text = "Chi tiết hóa đơn";
			// 
			// panel3
			// 
			this.panel3.BackColor = System.Drawing.Color.White;
			this.panel3.Controls.Add(this.cmbMaHang);
			this.panel3.Controls.Add(this.txtGiamGia);
			this.panel3.Controls.Add(this.txtThanhTien);
			this.panel3.Controls.Add(this.txtGiaBan);
			this.panel3.Controls.Add(this.txtSoLuong);
			this.panel3.Controls.Add(this.label5);
			this.panel3.Controls.Add(this.label6);
			this.panel3.Controls.Add(this.label7);
			this.panel3.Controls.Add(this.label4);
			this.panel3.Controls.Add(this.label2);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new System.Drawing.Point(0, 0);
			this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(596, 346);
			this.panel3.TabIndex = 5;
			// 
			// cmbMaHang
			// 
			this.cmbMaHang.AllowDrop = true;
			this.cmbMaHang.BackColor = System.Drawing.Color.Transparent;
			this.cmbMaHang.BorderRadius = 10;
			this.cmbMaHang.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cmbMaHang.DropDownHeight = 200;
			this.cmbMaHang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbMaHang.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
			this.cmbMaHang.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
			this.cmbMaHang.Font = new System.Drawing.Font("Segoe UI", 10F);
			this.cmbMaHang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
			this.cmbMaHang.IntegralHeight = false;
			this.cmbMaHang.ItemHeight = 30;
			this.cmbMaHang.Location = new System.Drawing.Point(133, 65);
			this.cmbMaHang.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.cmbMaHang.Name = "cmbMaHang";
			this.cmbMaHang.Size = new System.Drawing.Size(433, 36);
			this.cmbMaHang.TabIndex = 36;
			this.cmbMaHang.SelectedValueChanged += new System.EventHandler(this.cmbMaHang_SelectedValueChanged);
			// 
			// txtGiamGia
			// 
			this.txtGiamGia.BorderRadius = 10;
			this.txtGiamGia.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtGiamGia.DefaultText = "";
			this.txtGiamGia.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
			this.txtGiamGia.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
			this.txtGiamGia.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
			this.txtGiamGia.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
			this.txtGiamGia.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
			this.txtGiamGia.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.txtGiamGia.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
			this.txtGiamGia.Location = new System.Drawing.Point(433, 126);
			this.txtGiamGia.Margin = new System.Windows.Forms.Padding(4);
			this.txtGiamGia.Name = "txtGiamGia";
			this.txtGiamGia.PasswordChar = '\0';
			this.txtGiamGia.PlaceholderText = "";
			this.txtGiamGia.SelectedText = "";
			this.txtGiamGia.Size = new System.Drawing.Size(133, 30);
			this.txtGiamGia.TabIndex = 35;
			// 
			// txtThanhTien
			// 
			this.txtThanhTien.BorderRadius = 10;
			this.txtThanhTien.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtThanhTien.DefaultText = "";
			this.txtThanhTien.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
			this.txtThanhTien.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
			this.txtThanhTien.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
			this.txtThanhTien.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
			this.txtThanhTien.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
			this.txtThanhTien.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.txtThanhTien.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
			this.txtThanhTien.Location = new System.Drawing.Point(433, 185);
			this.txtThanhTien.Margin = new System.Windows.Forms.Padding(4);
			this.txtThanhTien.Name = "txtThanhTien";
			this.txtThanhTien.PasswordChar = '\0';
			this.txtThanhTien.PlaceholderText = "";
			this.txtThanhTien.SelectedText = "";
			this.txtThanhTien.Size = new System.Drawing.Size(133, 30);
			this.txtThanhTien.TabIndex = 34;
			// 
			// txtGiaBan
			// 
			this.txtGiaBan.BorderRadius = 10;
			this.txtGiaBan.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtGiaBan.DefaultText = "";
			this.txtGiaBan.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
			this.txtGiaBan.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
			this.txtGiaBan.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
			this.txtGiaBan.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
			this.txtGiaBan.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
			this.txtGiaBan.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.txtGiaBan.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
			this.txtGiaBan.Location = new System.Drawing.Point(133, 185);
			this.txtGiaBan.Margin = new System.Windows.Forms.Padding(4);
			this.txtGiaBan.Name = "txtGiaBan";
			this.txtGiaBan.PasswordChar = '\0';
			this.txtGiaBan.PlaceholderText = "";
			this.txtGiaBan.SelectedText = "";
			this.txtGiaBan.Size = new System.Drawing.Size(137, 30);
			this.txtGiaBan.TabIndex = 33;
			// 
			// txtSoLuong
			// 
			this.txtSoLuong.BorderRadius = 10;
			this.txtSoLuong.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtSoLuong.DefaultText = "";
			this.txtSoLuong.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
			this.txtSoLuong.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
			this.txtSoLuong.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
			this.txtSoLuong.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
			this.txtSoLuong.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
			this.txtSoLuong.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.txtSoLuong.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
			this.txtSoLuong.Location = new System.Drawing.Point(133, 126);
			this.txtSoLuong.Margin = new System.Windows.Forms.Padding(4);
			this.txtSoLuong.Name = "txtSoLuong";
			this.txtSoLuong.PasswordChar = '\0';
			this.txtSoLuong.PlaceholderText = "";
			this.txtSoLuong.SelectedText = "";
			this.txtSoLuong.Size = new System.Drawing.Size(137, 30);
			this.txtSoLuong.TabIndex = 32;
			this.txtSoLuong.TextChanged += new System.EventHandler(this.txtSoLuong_TextChanged);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(326, 136);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(76, 20);
			this.label5.TabIndex = 31;
			this.label5.Text = "Giảm giá";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(317, 195);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(87, 20);
			this.label6.TabIndex = 30;
			this.label6.Text = "Thành tiền";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.Location = new System.Drawing.Point(26, 195);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(67, 20);
			this.label7.TabIndex = 29;
			this.label7.Text = "Giá bán";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(26, 136);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(74, 20);
			this.label4.TabIndex = 28;
			this.label4.Text = "Số lượng";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(27, 73);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(78, 20);
			this.label2.TabIndex = 27;
			this.label2.Text = "Mặt hàng";
			// 
			// frmCapNhatCTHD
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(596, 346);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.panel3);
			this.Name = "frmCapNhatCTHD";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "frmCapNhatCTHD";
			this.Load += new System.EventHandler(this.frmCapNhatCTHD_Load);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel2;
		private Guna.UI2.WinForms.Guna2Button btnBoQua;
		private Guna.UI2.WinForms.Guna2Button btnCapNhat;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel3;
		private Guna.UI2.WinForms.Guna2ComboBox cmbMaHang;
		private Guna.UI2.WinForms.Guna2TextBox txtGiamGia;
		private Guna.UI2.WinForms.Guna2TextBox txtThanhTien;
		private Guna.UI2.WinForms.Guna2TextBox txtGiaBan;
		private Guna.UI2.WinForms.Guna2TextBox txtSoLuong;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label2;
	}
}
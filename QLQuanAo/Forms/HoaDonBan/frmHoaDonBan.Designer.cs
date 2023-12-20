namespace QLQuanAo.Forms.HoaDonBan
{
	partial class frmHoaDonBan
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHoaDonBan));
			this.btnLoc = new Guna.UI2.WinForms.Guna2Button();
			this.txtMaxTongTien = new Guna.UI2.WinForms.Guna2TextBox();
			this.txtMinTongTien = new Guna.UI2.WinForms.Guna2TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.guna2ContainerControl3 = new Guna.UI2.WinForms.Guna2ContainerControl();
			this.label4 = new System.Windows.Forms.Label();
			this.conTuyChonNgay = new Guna.UI2.WinForms.Guna2ContainerControl();
			this.label9 = new System.Windows.Forms.Label();
			this.dateFrom = new Guna.UI2.WinForms.Guna2DateTimePicker();
			this.dateTo = new Guna.UI2.WinForms.Guna2DateTimePicker();
			this.label8 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.rdoTuyChonNgay = new System.Windows.Forms.RadioButton();
			this.cboNgayTao = new Guna.UI2.WinForms.Guna2ComboBox();
			this.rdoComboBox = new System.Windows.Forms.RadioButton();
			this.guna2ContainerControl1 = new Guna.UI2.WinForms.Guna2ContainerControl();
			this.btnPrePage = new Guna.UI2.WinForms.Guna2Button();
			this.btnNextPage = new Guna.UI2.WinForms.Guna2Button();
			this.dgvHoaDon = new Guna.UI2.WinForms.Guna2DataGridView();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
			this.rdoChuyenKhoan = new System.Windows.Forms.RadioButton();
			this.rdoTienMat = new System.Windows.Forms.RadioButton();
			this.rdoPhuongThucAll = new System.Windows.Forms.RadioButton();
			this.guna2GroupBox2 = new Guna.UI2.WinForms.Guna2GroupBox();
			this.cboNguoiTao = new Guna.UI2.WinForms.Guna2ComboBox();
			this.btnThemHDB = new Guna.UI2.WinForms.Guna2Button();
			this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
			this.lblPage = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.btnXoaPN = new Guna.UI2.WinForms.Guna2Button();
			this.guna2ContainerControl3.SuspendLayout();
			this.conTuyChonNgay.SuspendLayout();
			this.guna2ContainerControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).BeginInit();
			this.flowLayoutPanel1.SuspendLayout();
			this.guna2GroupBox1.SuspendLayout();
			this.guna2GroupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnLoc
			// 
			this.btnLoc.BorderRadius = 10;
			this.btnLoc.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnLoc.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			this.btnLoc.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			this.btnLoc.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.btnLoc.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
			this.btnLoc.Font = new System.Drawing.Font("Segoe UI", 12F);
			this.btnLoc.ForeColor = System.Drawing.Color.White;
			this.btnLoc.Location = new System.Drawing.Point(3, 706);
			this.btnLoc.Name = "btnLoc";
			this.btnLoc.Size = new System.Drawing.Size(274, 45);
			this.btnLoc.TabIndex = 17;
			this.btnLoc.Text = "Lọc";
			this.btnLoc.Click += new System.EventHandler(this.btnLoc_Click);
			// 
			// txtMaxTongTien
			// 
			this.txtMaxTongTien.BackColor = System.Drawing.Color.White;
			this.txtMaxTongTien.BorderRadius = 10;
			this.txtMaxTongTien.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtMaxTongTien.DefaultText = "999999999";
			this.txtMaxTongTien.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
			this.txtMaxTongTien.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
			this.txtMaxTongTien.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
			this.txtMaxTongTien.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
			this.txtMaxTongTien.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
			this.txtMaxTongTien.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.txtMaxTongTien.ForeColor = System.Drawing.Color.Black;
			this.txtMaxTongTien.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
			this.txtMaxTongTien.Location = new System.Drawing.Point(67, 95);
			this.txtMaxTongTien.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.txtMaxTongTien.Name = "txtMaxTongTien";
			this.txtMaxTongTien.PasswordChar = '\0';
			this.txtMaxTongTien.PlaceholderText = "";
			this.txtMaxTongTien.SelectedText = "";
			this.txtMaxTongTien.Size = new System.Drawing.Size(152, 42);
			this.txtMaxTongTien.TabIndex = 8;
			this.txtMaxTongTien.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMinTongTien_KeyPress);
			// 
			// txtMinTongTien
			// 
			this.txtMinTongTien.BackColor = System.Drawing.Color.White;
			this.txtMinTongTien.BorderRadius = 10;
			this.txtMinTongTien.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtMinTongTien.DefaultText = "0";
			this.txtMinTongTien.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
			this.txtMinTongTien.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
			this.txtMinTongTien.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
			this.txtMinTongTien.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
			this.txtMinTongTien.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
			this.txtMinTongTien.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.txtMinTongTien.ForeColor = System.Drawing.Color.Black;
			this.txtMinTongTien.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
			this.txtMinTongTien.Location = new System.Drawing.Point(67, 46);
			this.txtMinTongTien.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.txtMinTongTien.Name = "txtMinTongTien";
			this.txtMinTongTien.PasswordChar = '\0';
			this.txtMinTongTien.PlaceholderText = "";
			this.txtMinTongTien.SelectedText = "";
			this.txtMinTongTien.Size = new System.Drawing.Size(152, 42);
			this.txtMinTongTien.TabIndex = 8;
			this.txtMinTongTien.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMinTongTien_KeyPress);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.BackColor = System.Drawing.Color.White;
			this.label5.Font = new System.Drawing.Font("Segoe UI", 9.2F);
			this.label5.Location = new System.Drawing.Point(7, 102);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(38, 21);
			this.label5.TabIndex = 7;
			this.label5.Text = "Đến";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.BackColor = System.Drawing.Color.White;
			this.label7.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.Location = new System.Drawing.Point(8, 11);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(91, 23);
			this.label7.TabIndex = 7;
			this.label7.Text = "Tổng bán:";
			// 
			// guna2ContainerControl3
			// 
			this.guna2ContainerControl3.BorderRadius = 10;
			this.guna2ContainerControl3.Controls.Add(this.txtMaxTongTien);
			this.guna2ContainerControl3.Controls.Add(this.txtMinTongTien);
			this.guna2ContainerControl3.Controls.Add(this.label5);
			this.guna2ContainerControl3.Controls.Add(this.label7);
			this.guna2ContainerControl3.Controls.Add(this.label4);
			this.guna2ContainerControl3.Location = new System.Drawing.Point(3, 529);
			this.guna2ContainerControl3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 15);
			this.guna2ContainerControl3.Name = "guna2ContainerControl3";
			this.guna2ContainerControl3.Size = new System.Drawing.Size(271, 159);
			this.guna2ContainerControl3.TabIndex = 0;
			this.guna2ContainerControl3.Text = "guna2ContainerControl1";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.BackColor = System.Drawing.Color.White;
			this.label4.Font = new System.Drawing.Font("Segoe UI", 9.2F);
			this.label4.Location = new System.Drawing.Point(8, 53);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(27, 21);
			this.label4.TabIndex = 7;
			this.label4.Text = "Từ";
			// 
			// conTuyChonNgay
			// 
			this.conTuyChonNgay.Controls.Add(this.label9);
			this.conTuyChonNgay.Controls.Add(this.dateFrom);
			this.conTuyChonNgay.Controls.Add(this.dateTo);
			this.conTuyChonNgay.Controls.Add(this.label8);
			this.conTuyChonNgay.Location = new System.Drawing.Point(8, 119);
			this.conTuyChonNgay.Name = "conTuyChonNgay";
			this.conTuyChonNgay.Size = new System.Drawing.Size(262, 88);
			this.conTuyChonNgay.TabIndex = 8;
			this.conTuyChonNgay.Text = "guna2ContainerControl4";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.BackColor = System.Drawing.Color.White;
			this.label9.Font = new System.Drawing.Font("Segoe UI", 9.2F);
			this.label9.Location = new System.Drawing.Point(1, 9);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(65, 21);
			this.label9.TabIndex = 7;
			this.label9.Text = "Từ ngày";
			// 
			// dateFrom
			// 
			this.dateFrom.BackColor = System.Drawing.Color.White;
			this.dateFrom.BorderRadius = 10;
			this.dateFrom.Checked = true;
			this.dateFrom.Cursor = System.Windows.Forms.Cursors.Default;
			this.dateFrom.CustomFormat = "yyyy-MM-dd";
			this.dateFrom.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(198)))), ((int)(((byte)(231)))));
			this.dateFrom.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dateFrom.ForeColor = System.Drawing.Color.White;
			this.dateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateFrom.Location = new System.Drawing.Point(80, 2);
			this.dateFrom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.dateFrom.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
			this.dateFrom.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
			this.dateFrom.Name = "dateFrom";
			this.dateFrom.Size = new System.Drawing.Size(179, 36);
			this.dateFrom.TabIndex = 5;
			this.dateFrom.Value = new System.DateTime(2023, 11, 9, 10, 26, 51, 838);
			this.dateFrom.ValueChanged += new System.EventHandler(this.dateFrom_ValueChanged);
			// 
			// dateTo
			// 
			this.dateTo.BackColor = System.Drawing.Color.White;
			this.dateTo.BorderRadius = 10;
			this.dateTo.Checked = true;
			this.dateTo.Cursor = System.Windows.Forms.Cursors.Default;
			this.dateTo.CustomFormat = "yyyy-MM-dd";
			this.dateTo.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(198)))), ((int)(((byte)(231)))));
			this.dateTo.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dateTo.ForeColor = System.Drawing.Color.White;
			this.dateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateTo.Location = new System.Drawing.Point(81, 42);
			this.dateTo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.dateTo.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
			this.dateTo.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
			this.dateTo.Name = "dateTo";
			this.dateTo.Size = new System.Drawing.Size(177, 36);
			this.dateTo.TabIndex = 5;
			this.dateTo.Value = new System.DateTime(2023, 11, 9, 10, 26, 51, 838);
			this.dateTo.ValueChanged += new System.EventHandler(this.dateTo_ValueChanged);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.BackColor = System.Drawing.Color.White;
			this.label8.Font = new System.Drawing.Font("Segoe UI", 9.2F);
			this.label8.Location = new System.Drawing.Point(-2, 51);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(76, 21);
			this.label8.TabIndex = 7;
			this.label8.Text = "Đến ngày";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.BackColor = System.Drawing.Color.White;
			this.label3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(45, 85);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(80, 23);
			this.label3.TabIndex = 7;
			this.label3.Text = "Tùy chọn";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.Color.White;
			this.label2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(8, 5);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(83, 23);
			this.label2.TabIndex = 7;
			this.label2.Text = "Ngày tạo";
			// 
			// rdoTuyChonNgay
			// 
			this.rdoTuyChonNgay.AutoSize = true;
			this.rdoTuyChonNgay.BackColor = System.Drawing.Color.White;
			this.rdoTuyChonNgay.Location = new System.Drawing.Point(12, 90);
			this.rdoTuyChonNgay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.rdoTuyChonNgay.Name = "rdoTuyChonNgay";
			this.rdoTuyChonNgay.Size = new System.Drawing.Size(17, 16);
			this.rdoTuyChonNgay.TabIndex = 3;
			this.rdoTuyChonNgay.UseVisualStyleBackColor = false;
			// 
			// cboNgayTao
			// 
			this.cboNgayTao.BackColor = System.Drawing.Color.Transparent;
			this.cboNgayTao.BorderRadius = 10;
			this.cboNgayTao.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cboNgayTao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboNgayTao.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
			this.cboNgayTao.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
			this.cboNgayTao.Font = new System.Drawing.Font("Segoe UI", 10F);
			this.cboNgayTao.ForeColor = System.Drawing.Color.Black;
			this.cboNgayTao.ItemHeight = 30;
			this.cboNgayTao.Items.AddRange(new object[] {
            "Toàn thời gian",
            "Hôm nay",
            "Hôm qua",
            "Tuần này",
            "Tuần trước",
            "Tháng này",
            "Tháng trước",
            "Quý này",
            "Quý trước",
            "Năm nay",
            "Năm trước"});
			this.cboNgayTao.Location = new System.Drawing.Point(40, 34);
			this.cboNgayTao.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.cboNgayTao.Name = "cboNgayTao";
			this.cboNgayTao.Size = new System.Drawing.Size(212, 36);
			this.cboNgayTao.StartIndex = 0;
			this.cboNgayTao.TabIndex = 2;
			// 
			// rdoComboBox
			// 
			this.rdoComboBox.AutoSize = true;
			this.rdoComboBox.BackColor = System.Drawing.Color.White;
			this.rdoComboBox.Checked = true;
			this.rdoComboBox.Location = new System.Drawing.Point(12, 47);
			this.rdoComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.rdoComboBox.Name = "rdoComboBox";
			this.rdoComboBox.Size = new System.Drawing.Size(17, 16);
			this.rdoComboBox.TabIndex = 1;
			this.rdoComboBox.TabStop = true;
			this.rdoComboBox.UseVisualStyleBackColor = false;
			// 
			// guna2ContainerControl1
			// 
			this.guna2ContainerControl1.BorderRadius = 10;
			this.guna2ContainerControl1.Controls.Add(this.conTuyChonNgay);
			this.guna2ContainerControl1.Controls.Add(this.label3);
			this.guna2ContainerControl1.Controls.Add(this.label2);
			this.guna2ContainerControl1.Controls.Add(this.rdoTuyChonNgay);
			this.guna2ContainerControl1.Controls.Add(this.cboNgayTao);
			this.guna2ContainerControl1.Controls.Add(this.rdoComboBox);
			this.guna2ContainerControl1.Location = new System.Drawing.Point(3, 2);
			this.guna2ContainerControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 15);
			this.guna2ContainerControl1.Name = "guna2ContainerControl1";
			this.guna2ContainerControl1.Size = new System.Drawing.Size(271, 208);
			this.guna2ContainerControl1.TabIndex = 0;
			this.guna2ContainerControl1.Text = "guna2ContainerControl1";
			// 
			// btnPrePage
			// 
			this.btnPrePage.BorderRadius = 10;
			this.btnPrePage.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			this.btnPrePage.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			this.btnPrePage.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.btnPrePage.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
			this.btnPrePage.FillColor = System.Drawing.Color.CornflowerBlue;
			this.btnPrePage.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.btnPrePage.ForeColor = System.Drawing.Color.White;
			this.btnPrePage.Image = global::QLQuanAo.Properties.Resources.back_single;
			this.btnPrePage.Location = new System.Drawing.Point(343, 569);
			this.btnPrePage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnPrePage.Name = "btnPrePage";
			this.btnPrePage.Size = new System.Drawing.Size(40, 39);
			this.btnPrePage.TabIndex = 22;
			this.btnPrePage.Click += new System.EventHandler(this.btnPrePage_Click);
			// 
			// btnNextPage
			// 
			this.btnNextPage.BorderRadius = 10;
			this.btnNextPage.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			this.btnNextPage.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			this.btnNextPage.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.btnNextPage.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
			this.btnNextPage.FillColor = System.Drawing.Color.CornflowerBlue;
			this.btnNextPage.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.btnNextPage.ForeColor = System.Drawing.Color.White;
			this.btnNextPage.Image = global::QLQuanAo.Properties.Resources.next_single;
			this.btnNextPage.Location = new System.Drawing.Point(528, 569);
			this.btnNextPage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnNextPage.Name = "btnNextPage";
			this.btnNextPage.Size = new System.Drawing.Size(40, 39);
			this.btnNextPage.TabIndex = 23;
			this.btnNextPage.Click += new System.EventHandler(this.btnNextPage_Click);
			// 
			// dgvHoaDon
			// 
			this.dgvHoaDon.AllowUserToAddRows = false;
			this.dgvHoaDon.AllowUserToDeleteRows = false;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
			dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(10, 5, 0, 5);
			this.dgvHoaDon.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
			dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(10, 5, 0, 5);
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvHoaDon.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
			this.dgvHoaDon.ColumnHeadersHeight = 35;
			this.dgvHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
			dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(10, 5, 0, 5);
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgvHoaDon.DefaultCellStyle = dataGridViewCellStyle3;
			this.dgvHoaDon.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
			this.dgvHoaDon.Location = new System.Drawing.Point(343, 86);
			this.dgvHoaDon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.dgvHoaDon.Name = "dgvHoaDon";
			this.dgvHoaDon.ReadOnly = true;
			this.dgvHoaDon.RowHeadersVisible = false;
			this.dgvHoaDon.RowHeadersWidth = 51;
			this.dgvHoaDon.RowTemplate.Height = 35;
			this.dgvHoaDon.Size = new System.Drawing.Size(966, 464);
			this.dgvHoaDon.TabIndex = 21;
			this.dgvHoaDon.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
			this.dgvHoaDon.ThemeStyle.AlternatingRowsStyle.Font = null;
			this.dgvHoaDon.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
			this.dgvHoaDon.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
			this.dgvHoaDon.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
			this.dgvHoaDon.ThemeStyle.BackColor = System.Drawing.Color.White;
			this.dgvHoaDon.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
			this.dgvHoaDon.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.CornflowerBlue;
			this.dgvHoaDon.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			this.dgvHoaDon.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dgvHoaDon.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
			this.dgvHoaDon.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
			this.dgvHoaDon.ThemeStyle.HeaderStyle.Height = 35;
			this.dgvHoaDon.ThemeStyle.ReadOnly = true;
			this.dgvHoaDon.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
			this.dgvHoaDon.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
			this.dgvHoaDon.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dgvHoaDon.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
			this.dgvHoaDon.ThemeStyle.RowsStyle.Height = 35;
			this.dgvHoaDon.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
			this.dgvHoaDon.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
			this.dgvHoaDon.DoubleClick += new System.EventHandler(this.dgvHoaDon_DoubleClick);
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.AutoScroll = true;
			this.flowLayoutPanel1.AutoSize = true;
			this.flowLayoutPanel1.Controls.Add(this.guna2ContainerControl1);
			this.flowLayoutPanel1.Controls.Add(this.guna2GroupBox1);
			this.flowLayoutPanel1.Controls.Add(this.guna2GroupBox2);
			this.flowLayoutPanel1.Controls.Add(this.guna2ContainerControl3);
			this.flowLayoutPanel1.Controls.Add(this.btnLoc);
			this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(15, 88);
			this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.flowLayoutPanel1.MaximumSize = new System.Drawing.Size(0, 520);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 0, 25, 0);
			this.flowLayoutPanel1.Size = new System.Drawing.Size(305, 520);
			this.flowLayoutPanel1.TabIndex = 20;
			this.flowLayoutPanel1.WrapContents = false;
			// 
			// guna2GroupBox1
			// 
			this.guna2GroupBox1.BorderRadius = 10;
			this.guna2GroupBox1.Controls.Add(this.rdoChuyenKhoan);
			this.guna2GroupBox1.Controls.Add(this.rdoTienMat);
			this.guna2GroupBox1.Controls.Add(this.rdoPhuongThucAll);
			this.guna2GroupBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.guna2GroupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
			this.guna2GroupBox1.Location = new System.Drawing.Point(3, 228);
			this.guna2GroupBox1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
			this.guna2GroupBox1.Name = "guna2GroupBox1";
			this.guna2GroupBox1.Size = new System.Drawing.Size(274, 175);
			this.guna2GroupBox1.TabIndex = 18;
			this.guna2GroupBox1.Text = "Phương thức thanh toán";
			// 
			// rdoChuyenKhoan
			// 
			this.rdoChuyenKhoan.AutoSize = true;
			this.rdoChuyenKhoan.BackColor = System.Drawing.Color.White;
			this.rdoChuyenKhoan.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rdoChuyenKhoan.Location = new System.Drawing.Point(18, 136);
			this.rdoChuyenKhoan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.rdoChuyenKhoan.Name = "rdoChuyenKhoan";
			this.rdoChuyenKhoan.Size = new System.Drawing.Size(141, 27);
			this.rdoChuyenKhoan.TabIndex = 6;
			this.rdoChuyenKhoan.Text = "Chuyển khoản";
			this.rdoChuyenKhoan.UseVisualStyleBackColor = false;
			// 
			// rdoTienMat
			// 
			this.rdoTienMat.AutoSize = true;
			this.rdoTienMat.BackColor = System.Drawing.Color.White;
			this.rdoTienMat.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rdoTienMat.Location = new System.Drawing.Point(18, 93);
			this.rdoTienMat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.rdoTienMat.Name = "rdoTienMat";
			this.rdoTienMat.Size = new System.Drawing.Size(98, 27);
			this.rdoTienMat.TabIndex = 5;
			this.rdoTienMat.Text = "Tiền mặt";
			this.rdoTienMat.UseVisualStyleBackColor = false;
			// 
			// rdoPhuongThucAll
			// 
			this.rdoPhuongThucAll.AutoSize = true;
			this.rdoPhuongThucAll.BackColor = System.Drawing.Color.White;
			this.rdoPhuongThucAll.Checked = true;
			this.rdoPhuongThucAll.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rdoPhuongThucAll.Location = new System.Drawing.Point(18, 51);
			this.rdoPhuongThucAll.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.rdoPhuongThucAll.Name = "rdoPhuongThucAll";
			this.rdoPhuongThucAll.Size = new System.Drawing.Size(77, 27);
			this.rdoPhuongThucAll.TabIndex = 4;
			this.rdoPhuongThucAll.TabStop = true;
			this.rdoPhuongThucAll.Text = "Tất cả";
			this.rdoPhuongThucAll.UseVisualStyleBackColor = false;
			// 
			// guna2GroupBox2
			// 
			this.guna2GroupBox2.BorderRadius = 10;
			this.guna2GroupBox2.Controls.Add(this.cboNguoiTao);
			this.guna2GroupBox2.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.guna2GroupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
			this.guna2GroupBox2.Location = new System.Drawing.Point(3, 421);
			this.guna2GroupBox2.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
			this.guna2GroupBox2.Name = "guna2GroupBox2";
			this.guna2GroupBox2.Size = new System.Drawing.Size(274, 91);
			this.guna2GroupBox2.TabIndex = 19;
			this.guna2GroupBox2.Text = "Người tạo hóa đơn";
			// 
			// cboNguoiTao
			// 
			this.cboNguoiTao.BackColor = System.Drawing.Color.Transparent;
			this.cboNguoiTao.BorderRadius = 10;
			this.cboNguoiTao.BorderThickness = 0;
			this.cboNguoiTao.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cboNguoiTao.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cboNguoiTao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboNguoiTao.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
			this.cboNguoiTao.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
			this.cboNguoiTao.Font = new System.Drawing.Font("Segoe UI", 11F);
			this.cboNguoiTao.ForeColor = System.Drawing.Color.Black;
			this.cboNguoiTao.ItemHeight = 30;
			this.cboNguoiTao.Location = new System.Drawing.Point(0, 40);
			this.cboNguoiTao.Name = "cboNguoiTao";
			this.cboNguoiTao.Size = new System.Drawing.Size(274, 36);
			this.cboNguoiTao.TabIndex = 0;
			this.cboNguoiTao.TextOffset = new System.Drawing.Point(8, 0);
			// 
			// btnThemHDB
			// 
			this.btnThemHDB.BorderRadius = 10;
			this.btnThemHDB.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			this.btnThemHDB.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			this.btnThemHDB.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.btnThemHDB.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
			this.btnThemHDB.FillColor = System.Drawing.Color.CornflowerBlue;
			this.btnThemHDB.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.btnThemHDB.ForeColor = System.Drawing.Color.White;
			this.btnThemHDB.Image = global::QLQuanAo.Properties.Resources.add_white;
			this.btnThemHDB.Location = new System.Drawing.Point(1129, 27);
			this.btnThemHDB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnThemHDB.Name = "btnThemHDB";
			this.btnThemHDB.Size = new System.Drawing.Size(180, 46);
			this.btnThemHDB.TabIndex = 19;
			this.btnThemHDB.Text = "Thêm hóa đơn ";
			this.btnThemHDB.Click += new System.EventHandler(this.btnThemHDB_Click);
			// 
			// txtSearch
			// 
			this.txtSearch.BorderRadius = 10;
			this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtSearch.DefaultText = "";
			this.txtSearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
			this.txtSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
			this.txtSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
			this.txtSearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
			this.txtSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
			this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
			this.txtSearch.ForeColor = System.Drawing.Color.Black;
			this.txtSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
			this.txtSearch.IconLeft = global::QLQuanAo.Properties.Resources.find;
			this.txtSearch.Location = new System.Drawing.Point(343, 23);
			this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.txtSearch.Name = "txtSearch";
			this.txtSearch.PasswordChar = '\0';
			this.txtSearch.PlaceholderText = "Theo mã hóa đơn";
			this.txtSearch.SelectedText = "";
			this.txtSearch.Size = new System.Drawing.Size(417, 50);
			this.txtSearch.TabIndex = 18;
			this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
			// 
			// lblPage
			// 
			this.lblPage.AutoSize = true;
			this.lblPage.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblPage.Location = new System.Drawing.Point(402, 577);
			this.lblPage.Name = "lblPage";
			this.lblPage.Size = new System.Drawing.Size(64, 23);
			this.lblPage.TabIndex = 24;
			this.lblPage.Text = "label10";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold);
			this.label1.Location = new System.Drawing.Point(22, 30);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(166, 30);
			this.label1.TabIndex = 17;
			this.label1.Text = "Hóa đơn bán";
			// 
			// btnXoaPN
			// 
			this.btnXoaPN.Animated = true;
			this.btnXoaPN.BorderRadius = 10;
			this.btnXoaPN.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			this.btnXoaPN.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			this.btnXoaPN.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.btnXoaPN.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
			this.btnXoaPN.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
			this.btnXoaPN.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnXoaPN.ForeColor = System.Drawing.Color.Black;
			this.btnXoaPN.Image = ((System.Drawing.Image)(resources.GetObject("btnXoaPN.Image")));
			this.btnXoaPN.Location = new System.Drawing.Point(1113, 562);
			this.btnXoaPN.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnXoaPN.Name = "btnXoaPN";
			this.btnXoaPN.Size = new System.Drawing.Size(196, 46);
			this.btnXoaPN.TabIndex = 25;
			this.btnXoaPN.Text = "Xóa hóa đơn";
			this.btnXoaPN.TextOffset = new System.Drawing.Point(3, 0);
			this.btnXoaPN.Click += new System.EventHandler(this.btnXoaPN_Click);
			// 
			// frmHoaDonBan
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1325, 630);
			this.Controls.Add(this.btnXoaPN);
			this.Controls.Add(this.btnPrePage);
			this.Controls.Add(this.btnNextPage);
			this.Controls.Add(this.dgvHoaDon);
			this.Controls.Add(this.flowLayoutPanel1);
			this.Controls.Add(this.btnThemHDB);
			this.Controls.Add(this.txtSearch);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lblPage);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "frmHoaDonBan";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "frmHoaDonBan";
			this.Load += new System.EventHandler(this.frmHoaDonBan_Load);
			this.guna2ContainerControl3.ResumeLayout(false);
			this.guna2ContainerControl3.PerformLayout();
			this.conTuyChonNgay.ResumeLayout(false);
			this.conTuyChonNgay.PerformLayout();
			this.guna2ContainerControl1.ResumeLayout(false);
			this.guna2ContainerControl1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).EndInit();
			this.flowLayoutPanel1.ResumeLayout(false);
			this.guna2GroupBox1.ResumeLayout(false);
			this.guna2GroupBox1.PerformLayout();
			this.guna2GroupBox2.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Guna.UI2.WinForms.Guna2Button btnLoc;
		private Guna.UI2.WinForms.Guna2TextBox txtMaxTongTien;
		private Guna.UI2.WinForms.Guna2TextBox txtMinTongTien;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label7;
		private Guna.UI2.WinForms.Guna2ContainerControl guna2ContainerControl3;
		private System.Windows.Forms.Label label4;
		private Guna.UI2.WinForms.Guna2ContainerControl conTuyChonNgay;
		private System.Windows.Forms.Label label9;
		private Guna.UI2.WinForms.Guna2DateTimePicker dateFrom;
		private Guna.UI2.WinForms.Guna2DateTimePicker dateTo;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.RadioButton rdoTuyChonNgay;
		private Guna.UI2.WinForms.Guna2ComboBox cboNgayTao;
		private System.Windows.Forms.RadioButton rdoComboBox;
		private Guna.UI2.WinForms.Guna2ContainerControl guna2ContainerControl1;
		private Guna.UI2.WinForms.Guna2Button btnPrePage;
		private Guna.UI2.WinForms.Guna2Button btnNextPage;
		private Guna.UI2.WinForms.Guna2DataGridView dgvHoaDon;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private Guna.UI2.WinForms.Guna2Button btnThemHDB;
		private Guna.UI2.WinForms.Guna2TextBox txtSearch;
		private System.Windows.Forms.Label lblPage;
		private System.Windows.Forms.Label label1;
		private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
		private System.Windows.Forms.RadioButton rdoChuyenKhoan;
		private System.Windows.Forms.RadioButton rdoTienMat;
		private System.Windows.Forms.RadioButton rdoPhuongThucAll;
		private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox2;
		private Guna.UI2.WinForms.Guna2ComboBox cboNguoiTao;
		private Guna.UI2.WinForms.Guna2Button btnXoaPN;
	}
}
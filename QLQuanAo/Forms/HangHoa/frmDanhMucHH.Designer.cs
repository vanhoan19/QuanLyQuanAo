namespace QLQuanAo.Forms.HangHoa
{
    partial class frmDanhMucHH
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
			this.lblPage = new System.Windows.Forms.Label();
			this.btnPrePage = new Guna.UI2.WinForms.Guna2Button();
			this.btnNextPage = new Guna.UI2.WinForms.Guna2Button();
			this.dgvHangHoa = new Guna.UI2.WinForms.Guna2DataGridView();
			this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
			this.btnLoc = new Guna.UI2.WinForms.Guna2Button();
			this.btnThemHH = new Guna.UI2.WinForms.Guna2Button();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.guna2ContainerControl1 = new Guna.UI2.WinForms.Guna2ContainerControl();
			this.cboTheLoai = new Guna.UI2.WinForms.Guna2ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.guna2ContainerControl3 = new Guna.UI2.WinForms.Guna2ContainerControl();
			this.cboNCC = new Guna.UI2.WinForms.Guna2ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.guna2ContainerControl2 = new Guna.UI2.WinForms.Guna2ContainerControl();
			this.txtSize = new Guna.UI2.WinForms.Guna2TextBox();
			this.txtMau = new Guna.UI2.WinForms.Guna2TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.guna2ContainerControl5 = new Guna.UI2.WinForms.Guna2ContainerControl();
			this.rdoHetHang = new System.Windows.Forms.RadioButton();
			this.rdoConHang = new System.Windows.Forms.RadioButton();
			this.rdoTonKhoAll = new System.Windows.Forms.RadioButton();
			this.label6 = new System.Windows.Forms.Label();
			this.guna2ContainerControl4 = new Guna.UI2.WinForms.Guna2ContainerControl();
			this.rdoNgungKinhDoanh = new System.Windows.Forms.RadioButton();
			this.rdoDangKinhDoanh = new System.Windows.Forms.RadioButton();
			this.rdoKinhDoanhAll = new System.Windows.Forms.RadioButton();
			this.label5 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dgvHangHoa)).BeginInit();
			this.flowLayoutPanel1.SuspendLayout();
			this.guna2ContainerControl1.SuspendLayout();
			this.guna2ContainerControl3.SuspendLayout();
			this.guna2ContainerControl2.SuspendLayout();
			this.guna2ContainerControl5.SuspendLayout();
			this.guna2ContainerControl4.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblPage
			// 
			this.lblPage.AutoSize = true;
			this.lblPage.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblPage.Location = new System.Drawing.Point(406, 578);
			this.lblPage.Name = "lblPage";
			this.lblPage.Size = new System.Drawing.Size(64, 23);
			this.lblPage.TabIndex = 24;
			this.lblPage.Text = "label10";
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
			this.btnPrePage.Location = new System.Drawing.Point(347, 570);
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
			this.btnNextPage.Location = new System.Drawing.Point(532, 570);
			this.btnNextPage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnNextPage.Name = "btnNextPage";
			this.btnNextPage.Size = new System.Drawing.Size(40, 39);
			this.btnNextPage.TabIndex = 23;
			this.btnNextPage.Click += new System.EventHandler(this.btnNextPage_Click);
			// 
			// dgvHangHoa
			// 
			this.dgvHangHoa.AllowUserToAddRows = false;
			this.dgvHangHoa.AllowUserToDeleteRows = false;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
			this.dgvHangHoa.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
			dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(10, 5, 0, 5);
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvHangHoa.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
			this.dgvHangHoa.ColumnHeadersHeight = 35;
			this.dgvHangHoa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
			dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(10, 5, 0, 5);
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgvHangHoa.DefaultCellStyle = dataGridViewCellStyle3;
			this.dgvHangHoa.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
			this.dgvHangHoa.Location = new System.Drawing.Point(340, 87);
			this.dgvHangHoa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.dgvHangHoa.Name = "dgvHangHoa";
			this.dgvHangHoa.ReadOnly = true;
			this.dgvHangHoa.RowHeadersVisible = false;
			this.dgvHangHoa.RowHeadersWidth = 51;
			this.dgvHangHoa.RowTemplate.Height = 35;
			this.dgvHangHoa.Size = new System.Drawing.Size(966, 464);
			this.dgvHangHoa.TabIndex = 21;
			this.dgvHangHoa.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
			this.dgvHangHoa.ThemeStyle.AlternatingRowsStyle.Font = null;
			this.dgvHangHoa.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
			this.dgvHangHoa.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
			this.dgvHangHoa.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
			this.dgvHangHoa.ThemeStyle.BackColor = System.Drawing.Color.White;
			this.dgvHangHoa.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
			this.dgvHangHoa.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.CornflowerBlue;
			this.dgvHangHoa.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			this.dgvHangHoa.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dgvHangHoa.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
			this.dgvHangHoa.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
			this.dgvHangHoa.ThemeStyle.HeaderStyle.Height = 35;
			this.dgvHangHoa.ThemeStyle.ReadOnly = true;
			this.dgvHangHoa.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
			this.dgvHangHoa.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
			this.dgvHangHoa.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dgvHangHoa.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
			this.dgvHangHoa.ThemeStyle.RowsStyle.Height = 35;
			this.dgvHangHoa.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
			this.dgvHangHoa.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
			this.dgvHangHoa.DoubleClick += new System.EventHandler(this.dgvHangHoa_DoubleClick);
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
			this.txtSearch.Location = new System.Drawing.Point(340, 24);
			this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.txtSearch.Name = "txtSearch";
			this.txtSearch.PasswordChar = '\0';
			this.txtSearch.PlaceholderText = "Theo mã, tên hàng";
			this.txtSearch.SelectedText = "";
			this.txtSearch.Size = new System.Drawing.Size(417, 50);
			this.txtSearch.TabIndex = 18;
			this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
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
			this.btnLoc.Location = new System.Drawing.Point(3, 759);
			this.btnLoc.Name = "btnLoc";
			this.btnLoc.Size = new System.Drawing.Size(274, 45);
			this.btnLoc.TabIndex = 17;
			this.btnLoc.Text = "Lọc";
			this.btnLoc.Click += new System.EventHandler(this.btnLoc_Click);
			// 
			// btnThemHH
			// 
			this.btnThemHH.BorderRadius = 10;
			this.btnThemHH.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			this.btnThemHH.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			this.btnThemHH.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.btnThemHH.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
			this.btnThemHH.FillColor = System.Drawing.Color.CornflowerBlue;
			this.btnThemHH.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.btnThemHH.ForeColor = System.Drawing.Color.White;
			this.btnThemHH.Image = global::QLQuanAo.Properties.Resources.add_white;
			this.btnThemHH.Location = new System.Drawing.Point(1135, 26);
			this.btnThemHH.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnThemHH.Name = "btnThemHH";
			this.btnThemHH.Size = new System.Drawing.Size(173, 46);
			this.btnThemHH.TabIndex = 19;
			this.btnThemHH.Text = "Thêm hàng hóa";
			this.btnThemHH.Click += new System.EventHandler(this.btnThemHH_Click);
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.AutoScroll = true;
			this.flowLayoutPanel1.AutoSize = true;
			this.flowLayoutPanel1.Controls.Add(this.guna2ContainerControl1);
			this.flowLayoutPanel1.Controls.Add(this.guna2ContainerControl3);
			this.flowLayoutPanel1.Controls.Add(this.guna2ContainerControl2);
			this.flowLayoutPanel1.Controls.Add(this.guna2ContainerControl5);
			this.flowLayoutPanel1.Controls.Add(this.guna2ContainerControl4);
			this.flowLayoutPanel1.Controls.Add(this.btnLoc);
			this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(17, 86);
			this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.flowLayoutPanel1.MaximumSize = new System.Drawing.Size(0, 520);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 0, 25, 0);
			this.flowLayoutPanel1.Size = new System.Drawing.Size(305, 520);
			this.flowLayoutPanel1.TabIndex = 20;
			this.flowLayoutPanel1.WrapContents = false;
			// 
			// guna2ContainerControl1
			// 
			this.guna2ContainerControl1.BorderRadius = 10;
			this.guna2ContainerControl1.Controls.Add(this.cboTheLoai);
			this.guna2ContainerControl1.Controls.Add(this.label2);
			this.guna2ContainerControl1.Location = new System.Drawing.Point(0, 0);
			this.guna2ContainerControl1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
			this.guna2ContainerControl1.Name = "guna2ContainerControl1";
			this.guna2ContainerControl1.Size = new System.Drawing.Size(280, 108);
			this.guna2ContainerControl1.TabIndex = 0;
			this.guna2ContainerControl1.Text = "guna2ContainerControl1";
			// 
			// cboTheLoai
			// 
			this.cboTheLoai.BackColor = System.Drawing.Color.Transparent;
			this.cboTheLoai.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
			this.cboTheLoai.BorderRadius = 10;
			this.cboTheLoai.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cboTheLoai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboTheLoai.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
			this.cboTheLoai.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
			this.cboTheLoai.Font = new System.Drawing.Font("Segoe UI", 10F);
			this.cboTheLoai.ForeColor = System.Drawing.Color.Black;
			this.cboTheLoai.ItemHeight = 30;
			this.cboTheLoai.Location = new System.Drawing.Point(13, 47);
			this.cboTheLoai.Name = "cboTheLoai";
			this.cboTheLoai.Size = new System.Drawing.Size(245, 36);
			this.cboTheLoai.TabIndex = 9;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.Color.White;
			this.label2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(9, 12);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(73, 23);
			this.label2.TabIndex = 8;
			this.label2.Text = "Thể loại";
			// 
			// guna2ContainerControl3
			// 
			this.guna2ContainerControl3.BorderRadius = 10;
			this.guna2ContainerControl3.Controls.Add(this.cboNCC);
			this.guna2ContainerControl3.Controls.Add(this.label4);
			this.guna2ContainerControl3.Location = new System.Drawing.Point(0, 118);
			this.guna2ContainerControl3.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
			this.guna2ContainerControl3.Name = "guna2ContainerControl3";
			this.guna2ContainerControl3.Size = new System.Drawing.Size(280, 108);
			this.guna2ContainerControl3.TabIndex = 0;
			this.guna2ContainerControl3.Text = "guna2ContainerControl1";
			// 
			// cboNCC
			// 
			this.cboNCC.BackColor = System.Drawing.Color.Transparent;
			this.cboNCC.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
			this.cboNCC.BorderRadius = 10;
			this.cboNCC.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cboNCC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboNCC.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
			this.cboNCC.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
			this.cboNCC.Font = new System.Drawing.Font("Segoe UI", 10F);
			this.cboNCC.ForeColor = System.Drawing.Color.Black;
			this.cboNCC.ItemHeight = 30;
			this.cboNCC.Location = new System.Drawing.Point(13, 47);
			this.cboNCC.Name = "cboNCC";
			this.cboNCC.Size = new System.Drawing.Size(244, 36);
			this.cboNCC.TabIndex = 9;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.BackColor = System.Drawing.Color.White;
			this.label4.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(9, 12);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(119, 23);
			this.label4.TabIndex = 8;
			this.label4.Text = "Nhà cung cấp";
			// 
			// guna2ContainerControl2
			// 
			this.guna2ContainerControl2.BorderRadius = 10;
			this.guna2ContainerControl2.Controls.Add(this.txtSize);
			this.guna2ContainerControl2.Controls.Add(this.txtMau);
			this.guna2ContainerControl2.Controls.Add(this.label3);
			this.guna2ContainerControl2.Location = new System.Drawing.Point(0, 236);
			this.guna2ContainerControl2.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
			this.guna2ContainerControl2.Name = "guna2ContainerControl2";
			this.guna2ContainerControl2.Size = new System.Drawing.Size(280, 174);
			this.guna2ContainerControl2.TabIndex = 0;
			this.guna2ContainerControl2.Text = "guna2ContainerControl1";
			// 
			// txtSize
			// 
			this.txtSize.BackColor = System.Drawing.Color.White;
			this.txtSize.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
			this.txtSize.BorderRadius = 10;
			this.txtSize.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtSize.DefaultText = "";
			this.txtSize.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
			this.txtSize.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
			this.txtSize.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
			this.txtSize.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
			this.txtSize.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
			this.txtSize.Font = new System.Drawing.Font("Segoe UI", 10F);
			this.txtSize.ForeColor = System.Drawing.Color.Black;
			this.txtSize.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
			this.txtSize.Location = new System.Drawing.Point(16, 105);
			this.txtSize.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtSize.Name = "txtSize";
			this.txtSize.PasswordChar = '\0';
			this.txtSize.PlaceholderText = "Size";
			this.txtSize.SelectedText = "";
			this.txtSize.Size = new System.Drawing.Size(243, 42);
			this.txtSize.TabIndex = 9;
			// 
			// txtMau
			// 
			this.txtMau.BackColor = System.Drawing.Color.White;
			this.txtMau.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
			this.txtMau.BorderRadius = 10;
			this.txtMau.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtMau.DefaultText = "";
			this.txtMau.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
			this.txtMau.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
			this.txtMau.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
			this.txtMau.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
			this.txtMau.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
			this.txtMau.Font = new System.Drawing.Font("Segoe UI", 10F);
			this.txtMau.ForeColor = System.Drawing.Color.Black;
			this.txtMau.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
			this.txtMau.Location = new System.Drawing.Point(16, 49);
			this.txtMau.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtMau.Name = "txtMau";
			this.txtMau.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.txtMau.PasswordChar = '\0';
			this.txtMau.PlaceholderText = "Màu";
			this.txtMau.SelectedText = "";
			this.txtMau.Size = new System.Drawing.Size(243, 46);
			this.txtMau.TabIndex = 9;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.BackColor = System.Drawing.Color.White;
			this.label3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(9, 12);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(95, 23);
			this.label3.TabIndex = 8;
			this.label3.Text = "Thuộc tính";
			// 
			// guna2ContainerControl5
			// 
			this.guna2ContainerControl5.BorderRadius = 10;
			this.guna2ContainerControl5.Controls.Add(this.rdoHetHang);
			this.guna2ContainerControl5.Controls.Add(this.rdoConHang);
			this.guna2ContainerControl5.Controls.Add(this.rdoTonKhoAll);
			this.guna2ContainerControl5.Controls.Add(this.label6);
			this.guna2ContainerControl5.Location = new System.Drawing.Point(0, 420);
			this.guna2ContainerControl5.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
			this.guna2ContainerControl5.Name = "guna2ContainerControl5";
			this.guna2ContainerControl5.Size = new System.Drawing.Size(280, 158);
			this.guna2ContainerControl5.TabIndex = 0;
			this.guna2ContainerControl5.Text = "guna2ContainerControl1";
			// 
			// rdoHetHang
			// 
			this.rdoHetHang.AutoSize = true;
			this.rdoHetHang.BackColor = System.Drawing.Color.White;
			this.rdoHetHang.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rdoHetHang.Location = new System.Drawing.Point(16, 115);
			this.rdoHetHang.Name = "rdoHetHang";
			this.rdoHetHang.Size = new System.Drawing.Size(102, 27);
			this.rdoHetHang.TabIndex = 9;
			this.rdoHetHang.TabStop = true;
			this.rdoHetHang.Text = "Hết hàng";
			this.rdoHetHang.UseVisualStyleBackColor = false;
			// 
			// rdoConHang
			// 
			this.rdoConHang.AutoSize = true;
			this.rdoConHang.BackColor = System.Drawing.Color.White;
			this.rdoConHang.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rdoConHang.Location = new System.Drawing.Point(16, 82);
			this.rdoConHang.Name = "rdoConHang";
			this.rdoConHang.Size = new System.Drawing.Size(106, 27);
			this.rdoConHang.TabIndex = 9;
			this.rdoConHang.TabStop = true;
			this.rdoConHang.Text = "Còn hàng";
			this.rdoConHang.UseVisualStyleBackColor = false;
			// 
			// rdoTonKhoAll
			// 
			this.rdoTonKhoAll.AutoSize = true;
			this.rdoTonKhoAll.BackColor = System.Drawing.Color.White;
			this.rdoTonKhoAll.Checked = true;
			this.rdoTonKhoAll.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rdoTonKhoAll.Location = new System.Drawing.Point(15, 49);
			this.rdoTonKhoAll.Name = "rdoTonKhoAll";
			this.rdoTonKhoAll.Size = new System.Drawing.Size(77, 27);
			this.rdoTonKhoAll.TabIndex = 9;
			this.rdoTonKhoAll.TabStop = true;
			this.rdoTonKhoAll.Text = "Tất cả";
			this.rdoTonKhoAll.UseVisualStyleBackColor = false;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.BackColor = System.Drawing.Color.White;
			this.label6.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(9, 12);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(75, 23);
			this.label6.TabIndex = 8;
			this.label6.Text = "Tồn kho";
			// 
			// guna2ContainerControl4
			// 
			this.guna2ContainerControl4.BorderRadius = 10;
			this.guna2ContainerControl4.Controls.Add(this.rdoNgungKinhDoanh);
			this.guna2ContainerControl4.Controls.Add(this.rdoDangKinhDoanh);
			this.guna2ContainerControl4.Controls.Add(this.rdoKinhDoanhAll);
			this.guna2ContainerControl4.Controls.Add(this.label5);
			this.guna2ContainerControl4.Location = new System.Drawing.Point(0, 588);
			this.guna2ContainerControl4.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
			this.guna2ContainerControl4.Name = "guna2ContainerControl4";
			this.guna2ContainerControl4.Size = new System.Drawing.Size(280, 158);
			this.guna2ContainerControl4.TabIndex = 0;
			this.guna2ContainerControl4.Text = "guna2ContainerControl1";
			// 
			// rdoNgungKinhDoanh
			// 
			this.rdoNgungKinhDoanh.AutoSize = true;
			this.rdoNgungKinhDoanh.BackColor = System.Drawing.Color.White;
			this.rdoNgungKinhDoanh.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rdoNgungKinhDoanh.Location = new System.Drawing.Point(16, 115);
			this.rdoNgungKinhDoanh.Name = "rdoNgungKinhDoanh";
			this.rdoNgungKinhDoanh.Size = new System.Drawing.Size(175, 27);
			this.rdoNgungKinhDoanh.TabIndex = 9;
			this.rdoNgungKinhDoanh.TabStop = true;
			this.rdoNgungKinhDoanh.Text = "Ngừng kinh doanh";
			this.rdoNgungKinhDoanh.UseVisualStyleBackColor = false;
			// 
			// rdoDangKinhDoanh
			// 
			this.rdoDangKinhDoanh.AutoSize = true;
			this.rdoDangKinhDoanh.BackColor = System.Drawing.Color.White;
			this.rdoDangKinhDoanh.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rdoDangKinhDoanh.Location = new System.Drawing.Point(16, 82);
			this.rdoDangKinhDoanh.Name = "rdoDangKinhDoanh";
			this.rdoDangKinhDoanh.Size = new System.Drawing.Size(163, 27);
			this.rdoDangKinhDoanh.TabIndex = 9;
			this.rdoDangKinhDoanh.TabStop = true;
			this.rdoDangKinhDoanh.Text = "Đang kinh doanh";
			this.rdoDangKinhDoanh.UseVisualStyleBackColor = false;
			// 
			// rdoKinhDoanhAll
			// 
			this.rdoKinhDoanhAll.AutoSize = true;
			this.rdoKinhDoanhAll.BackColor = System.Drawing.Color.White;
			this.rdoKinhDoanhAll.Checked = true;
			this.rdoKinhDoanhAll.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rdoKinhDoanhAll.Location = new System.Drawing.Point(15, 49);
			this.rdoKinhDoanhAll.Name = "rdoKinhDoanhAll";
			this.rdoKinhDoanhAll.Size = new System.Drawing.Size(77, 27);
			this.rdoKinhDoanhAll.TabIndex = 9;
			this.rdoKinhDoanhAll.TabStop = true;
			this.rdoKinhDoanhAll.Text = "Tất cả";
			this.rdoKinhDoanhAll.UseVisualStyleBackColor = false;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.BackColor = System.Drawing.Color.White;
			this.label5.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(9, 12);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(148, 23);
			this.label5.TabIndex = 8;
			this.label5.Text = "Lựa chọn hiển thị";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(27, 34);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(119, 27);
			this.label1.TabIndex = 17;
			this.label1.Text = "Hàng hóa";
			// 
			// frmDanhMucHH
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1325, 630);
			this.Controls.Add(this.lblPage);
			this.Controls.Add(this.btnPrePage);
			this.Controls.Add(this.btnNextPage);
			this.Controls.Add(this.dgvHangHoa);
			this.Controls.Add(this.txtSearch);
			this.Controls.Add(this.btnThemHH);
			this.Controls.Add(this.flowLayoutPanel1);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "frmDanhMucHH";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "frmDanhMucHH";
			this.Load += new System.EventHandler(this.frmDanhMucHH_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgvHangHoa)).EndInit();
			this.flowLayoutPanel1.ResumeLayout(false);
			this.guna2ContainerControl1.ResumeLayout(false);
			this.guna2ContainerControl1.PerformLayout();
			this.guna2ContainerControl3.ResumeLayout(false);
			this.guna2ContainerControl3.PerformLayout();
			this.guna2ContainerControl2.ResumeLayout(false);
			this.guna2ContainerControl2.PerformLayout();
			this.guna2ContainerControl5.ResumeLayout(false);
			this.guna2ContainerControl5.PerformLayout();
			this.guna2ContainerControl4.ResumeLayout(false);
			this.guna2ContainerControl4.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPage;
        private Guna.UI2.WinForms.Guna2Button btnPrePage;
        private Guna.UI2.WinForms.Guna2Button btnNextPage;
        private Guna.UI2.WinForms.Guna2DataGridView dgvHangHoa;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private Guna.UI2.WinForms.Guna2Button btnLoc;
        private Guna.UI2.WinForms.Guna2Button btnThemHH;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
		private Guna.UI2.WinForms.Guna2ContainerControl guna2ContainerControl1;
		private Guna.UI2.WinForms.Guna2ComboBox cboTheLoai;
		private System.Windows.Forms.Label label2;
		private Guna.UI2.WinForms.Guna2ContainerControl guna2ContainerControl2;
		private Guna.UI2.WinForms.Guna2TextBox txtSize;
		private Guna.UI2.WinForms.Guna2TextBox txtMau;
		private System.Windows.Forms.Label label3;
		private Guna.UI2.WinForms.Guna2ContainerControl guna2ContainerControl3;
		private Guna.UI2.WinForms.Guna2ComboBox cboNCC;
		private System.Windows.Forms.Label label4;
		private Guna.UI2.WinForms.Guna2ContainerControl guna2ContainerControl4;
		private System.Windows.Forms.Label label5;
		private Guna.UI2.WinForms.Guna2ContainerControl guna2ContainerControl5;
		private System.Windows.Forms.RadioButton rdoHetHang;
		private System.Windows.Forms.RadioButton rdoConHang;
		private System.Windows.Forms.RadioButton rdoTonKhoAll;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.RadioButton rdoNgungKinhDoanh;
		private System.Windows.Forms.RadioButton rdoDangKinhDoanh;
		private System.Windows.Forms.RadioButton rdoKinhDoanhAll;
	}
}
namespace QLQuanAo.Forms.NhaCungCap
{
	partial class frmDanhMucNCC
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
			this.label1 = new System.Windows.Forms.Label();
			this.lblPage = new System.Windows.Forms.Label();
			this.dgvNhaCungCap = new Guna.UI2.WinForms.Guna2DataGridView();
			this.btnPrePage = new Guna.UI2.WinForms.Guna2Button();
			this.btnNextPage = new Guna.UI2.WinForms.Guna2Button();
			this.btnThemNCC = new Guna.UI2.WinForms.Guna2Button();
			this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
			((System.ComponentModel.ISupportInitialize)(this.dgvNhaCungCap)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(16, 33);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(166, 27);
			this.label1.TabIndex = 25;
			this.label1.Text = "Nhà cung cấp";
			// 
			// lblPage
			// 
			this.lblPage.AutoSize = true;
			this.lblPage.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblPage.Location = new System.Drawing.Point(82, 574);
			this.lblPage.Name = "lblPage";
			this.lblPage.Size = new System.Drawing.Size(64, 23);
			this.lblPage.TabIndex = 32;
			this.lblPage.Text = "label10";
			// 
			// dgvNhaCungCap
			// 
			this.dgvNhaCungCap.AllowUserToAddRows = false;
			this.dgvNhaCungCap.AllowUserToDeleteRows = false;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
			this.dgvNhaCungCap.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvNhaCungCap.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
			this.dgvNhaCungCap.ColumnHeadersHeight = 35;
			this.dgvNhaCungCap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
			dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(10, 5, 0, 5);
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgvNhaCungCap.DefaultCellStyle = dataGridViewCellStyle3;
			this.dgvNhaCungCap.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
			this.dgvNhaCungCap.Location = new System.Drawing.Point(19, 86);
			this.dgvNhaCungCap.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.dgvNhaCungCap.Name = "dgvNhaCungCap";
			this.dgvNhaCungCap.ReadOnly = true;
			this.dgvNhaCungCap.RowHeadersVisible = false;
			this.dgvNhaCungCap.RowHeadersWidth = 51;
			this.dgvNhaCungCap.RowTemplate.Height = 35;
			this.dgvNhaCungCap.Size = new System.Drawing.Size(1289, 464);
			this.dgvNhaCungCap.TabIndex = 29;
			this.dgvNhaCungCap.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
			this.dgvNhaCungCap.ThemeStyle.AlternatingRowsStyle.Font = null;
			this.dgvNhaCungCap.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
			this.dgvNhaCungCap.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
			this.dgvNhaCungCap.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
			this.dgvNhaCungCap.ThemeStyle.BackColor = System.Drawing.Color.White;
			this.dgvNhaCungCap.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
			this.dgvNhaCungCap.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.CornflowerBlue;
			this.dgvNhaCungCap.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			this.dgvNhaCungCap.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dgvNhaCungCap.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
			this.dgvNhaCungCap.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
			this.dgvNhaCungCap.ThemeStyle.HeaderStyle.Height = 35;
			this.dgvNhaCungCap.ThemeStyle.ReadOnly = true;
			this.dgvNhaCungCap.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
			this.dgvNhaCungCap.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
			this.dgvNhaCungCap.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dgvNhaCungCap.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
			this.dgvNhaCungCap.ThemeStyle.RowsStyle.Height = 35;
			this.dgvNhaCungCap.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
			this.dgvNhaCungCap.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
			this.dgvNhaCungCap.DoubleClick += new System.EventHandler(this.dgvNhaCungCap_DoubleClick);
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
			this.btnPrePage.Location = new System.Drawing.Point(23, 566);
			this.btnPrePage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnPrePage.Name = "btnPrePage";
			this.btnPrePage.Size = new System.Drawing.Size(40, 39);
			this.btnPrePage.TabIndex = 30;
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
			this.btnNextPage.Location = new System.Drawing.Point(208, 566);
			this.btnNextPage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnNextPage.Name = "btnNextPage";
			this.btnNextPage.Size = new System.Drawing.Size(40, 39);
			this.btnNextPage.TabIndex = 31;
			this.btnNextPage.Click += new System.EventHandler(this.btnNextPage_Click);
			// 
			// btnThemNCC
			// 
			this.btnThemNCC.BorderRadius = 10;
			this.btnThemNCC.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			this.btnThemNCC.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			this.btnThemNCC.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.btnThemNCC.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
			this.btnThemNCC.FillColor = System.Drawing.Color.CornflowerBlue;
			this.btnThemNCC.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.btnThemNCC.ForeColor = System.Drawing.Color.White;
			this.btnThemNCC.Image = global::QLQuanAo.Properties.Resources.add_white;
			this.btnThemNCC.Location = new System.Drawing.Point(1117, 25);
			this.btnThemNCC.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnThemNCC.Name = "btnThemNCC";
			this.btnThemNCC.Size = new System.Drawing.Size(186, 46);
			this.btnThemNCC.TabIndex = 27;
			this.btnThemNCC.Text = "Thêm nhà cung cấp";
			this.btnThemNCC.Click += new System.EventHandler(this.btnThemNCC_Click);
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
			this.txtSearch.Location = new System.Drawing.Point(327, 23);
			this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.txtSearch.Name = "txtSearch";
			this.txtSearch.PasswordChar = '\0';
			this.txtSearch.PlaceholderText = "Theo mã, tên, địa chỉ, số điện thoại nhà cung cấp";
			this.txtSearch.SelectedText = "";
			this.txtSearch.Size = new System.Drawing.Size(501, 50);
			this.txtSearch.TabIndex = 26;
			this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
			// 
			// frmDanhMucNCC
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1325, 630);
			this.Controls.Add(this.btnPrePage);
			this.Controls.Add(this.btnNextPage);
			this.Controls.Add(this.btnThemNCC);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lblPage);
			this.Controls.Add(this.dgvNhaCungCap);
			this.Controls.Add(this.txtSearch);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "frmDanhMucNCC";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "frmDanhMucNCC";
			this.Load += new System.EventHandler(this.frmDanhMucNCC_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgvNhaCungCap)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Guna.UI2.WinForms.Guna2Button btnPrePage;
		private Guna.UI2.WinForms.Guna2Button btnNextPage;
		private Guna.UI2.WinForms.Guna2Button btnThemNCC;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lblPage;
		private Guna.UI2.WinForms.Guna2DataGridView dgvNhaCungCap;
		private Guna.UI2.WinForms.Guna2TextBox txtSearch;
	}
}
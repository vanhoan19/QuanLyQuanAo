namespace QLQuanAo.Forms.DoanhThu
{
    partial class frmDoanhThu
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDoanhThu));
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
			this.guna2ContainerControl1 = new Guna.UI2.WinForms.Guna2ContainerControl();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel3 = new System.Windows.Forms.Panel();
			this.cmbThoiGian = new Guna.UI2.WinForms.Guna2ComboBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.dgvDoanhThu = new Guna.UI2.WinForms.Guna2DataGridView();
			this.chartTopSP = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.chartDoanhThu = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.lblTieuDe = new System.Windows.Forms.Label();
			this.guna2ContainerControl1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvDoanhThu)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.chartTopSP)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.chartDoanhThu)).BeginInit();
			this.SuspendLayout();
			// 
			// guna2ContainerControl1
			// 
			this.guna2ContainerControl1.Controls.Add(this.panel1);
			this.guna2ContainerControl1.Dock = System.Windows.Forms.DockStyle.Top;
			this.guna2ContainerControl1.Location = new System.Drawing.Point(0, 0);
			this.guna2ContainerControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.guna2ContainerControl1.Name = "guna2ContainerControl1";
			this.guna2ContainerControl1.Size = new System.Drawing.Size(1325, 54);
			this.guna2ContainerControl1.TabIndex = 0;
			this.guna2ContainerControl1.Text = "guna2ContainerControl1";
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.White;
			this.panel1.Controls.Add(this.panel3);
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1325, 54);
			this.panel1.TabIndex = 4;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.cmbThoiGian);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
			this.panel3.Location = new System.Drawing.Point(1113, 0);
			this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(212, 54);
			this.panel3.TabIndex = 3;
			// 
			// cmbThoiGian
			// 
			this.cmbThoiGian.BackColor = System.Drawing.Color.Transparent;
			this.cmbThoiGian.BorderRadius = 4;
			this.cmbThoiGian.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cmbThoiGian.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbThoiGian.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
			this.cmbThoiGian.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
			this.cmbThoiGian.Font = new System.Drawing.Font("Segoe UI", 10F);
			this.cmbThoiGian.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
			this.cmbThoiGian.ItemHeight = 25;
			this.cmbThoiGian.Location = new System.Drawing.Point(15, 10);
			this.cmbThoiGian.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.cmbThoiGian.Name = "cmbThoiGian";
			this.cmbThoiGian.Size = new System.Drawing.Size(181, 31);
			this.cmbThoiGian.TabIndex = 1;
			this.cmbThoiGian.SelectedValueChanged += new System.EventHandler(this.cmbThoiGian_SelectedValueChanged);
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.label1);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(249, 54);
			this.panel2.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.White;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
			this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label1.Location = new System.Drawing.Point(27, 7);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(200, 37);
			this.label1.TabIndex = 1;
			this.label1.Text = "     Doanh thu";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// dgvDoanhThu
			// 
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
			this.dgvDoanhThu.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvDoanhThu.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
			this.dgvDoanhThu.ColumnHeadersHeight = 30;
			this.dgvDoanhThu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgvDoanhThu.DefaultCellStyle = dataGridViewCellStyle3;
			this.dgvDoanhThu.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
			this.dgvDoanhThu.Location = new System.Drawing.Point(805, 72);
			this.dgvDoanhThu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.dgvDoanhThu.Name = "dgvDoanhThu";
			this.dgvDoanhThu.RowHeadersVisible = false;
			this.dgvDoanhThu.RowHeadersWidth = 62;
			this.dgvDoanhThu.RowTemplate.Height = 28;
			this.dgvDoanhThu.Size = new System.Drawing.Size(395, 96);
			this.dgvDoanhThu.TabIndex = 1;
			this.dgvDoanhThu.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
			this.dgvDoanhThu.ThemeStyle.AlternatingRowsStyle.Font = null;
			this.dgvDoanhThu.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
			this.dgvDoanhThu.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
			this.dgvDoanhThu.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
			this.dgvDoanhThu.ThemeStyle.BackColor = System.Drawing.Color.White;
			this.dgvDoanhThu.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
			this.dgvDoanhThu.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
			this.dgvDoanhThu.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			this.dgvDoanhThu.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dgvDoanhThu.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
			this.dgvDoanhThu.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
			this.dgvDoanhThu.ThemeStyle.HeaderStyle.Height = 30;
			this.dgvDoanhThu.ThemeStyle.ReadOnly = false;
			this.dgvDoanhThu.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
			this.dgvDoanhThu.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
			this.dgvDoanhThu.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dgvDoanhThu.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
			this.dgvDoanhThu.ThemeStyle.RowsStyle.Height = 28;
			this.dgvDoanhThu.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
			this.dgvDoanhThu.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
			// 
			// chartTopSP
			// 
			chartArea1.Name = "ChartArea1";
			this.chartTopSP.ChartAreas.Add(chartArea1);
			legend1.Name = "Legend1";
			this.chartTopSP.Legends.Add(legend1);
			this.chartTopSP.Location = new System.Drawing.Point(750, 214);
			this.chartTopSP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.chartTopSP.Name = "chartTopSP";
			series1.ChartArea = "ChartArea1";
			series1.Legend = "Legend1";
			series1.LegendText = "Số lượng";
			series1.Name = "topsp";
			this.chartTopSP.Series.Add(series1);
			this.chartTopSP.Size = new System.Drawing.Size(507, 316);
			this.chartTopSP.TabIndex = 2;
			title1.Name = "Biểu đồ thống kê về loại hàng";
			title1.Text = "Biểu đồ thống kê về loại hàng";
			this.chartTopSP.Titles.Add(title1);
			// 
			// chartDoanhThu
			// 
			chartArea2.Name = "ChartArea1";
			this.chartDoanhThu.ChartAreas.Add(chartArea2);
			legend2.Name = "Legend1";
			this.chartDoanhThu.Legends.Add(legend2);
			this.chartDoanhThu.Location = new System.Drawing.Point(32, 202);
			this.chartDoanhThu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.chartDoanhThu.Name = "chartDoanhThu";
			this.chartDoanhThu.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SemiTransparent;
			series2.ChartArea = "ChartArea1";
			series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			series2.Legend = "Legend1";
			series2.LegendText = "Tổng tiền";
			series2.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
			series2.Name = "doanhthu";
			this.chartDoanhThu.Series.Add(series2);
			this.chartDoanhThu.Size = new System.Drawing.Size(631, 340);
			this.chartDoanhThu.TabIndex = 3;
			this.chartDoanhThu.Text = "chart1";
			title2.Alignment = System.Drawing.ContentAlignment.BottomCenter;
			title2.Name = "ttDoanhThu";
			title2.Text = "Biểu đồ doanh thu";
			this.chartDoanhThu.Titles.Add(title2);
			// 
			// lblTieuDe
			// 
			this.lblTieuDe.AutoSize = true;
			this.lblTieuDe.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTieuDe.Location = new System.Drawing.Point(64, 91);
			this.lblTieuDe.Name = "lblTieuDe";
			this.lblTieuDe.Size = new System.Drawing.Size(92, 31);
			this.lblTieuDe.TabIndex = 4;
			this.lblTieuDe.Text = "label2";
			this.lblTieuDe.Click += new System.EventHandler(this.lblTieuDe_Click);
			// 
			// frmDoanhThu
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(1325, 630);
			this.Controls.Add(this.lblTieuDe);
			this.Controls.Add(this.chartDoanhThu);
			this.Controls.Add(this.chartTopSP);
			this.Controls.Add(this.dgvDoanhThu);
			this.Controls.Add(this.guna2ContainerControl1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.Name = "frmDoanhThu";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "frmDoanhThu";
			this.Load += new System.EventHandler(this.frmDoanhThu_Load);
			this.guna2ContainerControl1.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvDoanhThu)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.chartTopSP)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.chartDoanhThu)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ContainerControl guna2ContainerControl1;
        private Guna.UI2.WinForms.Guna2ComboBox cmbThoiGian;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private Guna.UI2.WinForms.Guna2DataGridView dgvDoanhThu;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTopSP;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDoanhThu;
        private System.Windows.Forms.Label lblTieuDe;
    }
}
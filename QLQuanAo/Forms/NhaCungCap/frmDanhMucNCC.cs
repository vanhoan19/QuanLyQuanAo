using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLQuanAo.Forms.NhaCungCap
{
	public partial class frmDanhMucNCC : Form
	{
		Classes.DataProcesser dataProcesser = new Classes.DataProcesser();
		Classes.CommonFunc func = new Classes.CommonFunc();
		int PgSize = 9;
		int CurrentPageIndex = 1;
		int TotalPage = 0;
		DataTable dt = new DataTable();
		string sqlCondition = "";

		public frmDanhMucNCC()
		{
			InitializeComponent();
		}

		private void btnThemNCC_Click(object sender, EventArgs e)
		{
			Forms.NhaCungCap.frmCapNhatNCC frmCapNhatNCC = new frmCapNhatNCC();
			frmCapNhatNCC.ShowDialog();
		}

		private void LoadData()
		{
			TotalPage = func.CalculateTotalPages("tNhaCungCap", sqlCondition, PgSize);
			CurrentPageIndex = 1;
			dgvNhaCungCap.DataSource = func.GetCurrentRecords(CurrentPageIndex, PgSize, "tNhaCungCap", sqlCondition, "MaNCC", "MaNCC");
			SetColumnNCC();
			btnPrePage.Enabled = CurrentPageIndex > 1;
			btnNextPage.Enabled = TotalPage > CurrentPageIndex;
			lblPage.Text = string.Format("Page: {0}/{1}", CurrentPageIndex, TotalPage);
		}

		private void SetColumnNCC()
		{
			dgvNhaCungCap.Columns["MaNCC"].HeaderText = "Mã nhà cung cấp";
			dgvNhaCungCap.Columns["TenNCC"].HeaderText = "Tên nhà cung cấp";
			dgvNhaCungCap.Columns["SDT"].HeaderText = "Số điện thoại";
			dgvNhaCungCap.Columns["DiaChi"].HeaderText = "Địa chỉ";
			dgvNhaCungCap.Columns["GhiChu"].Visible = false;
		}

		private void frmDanhMucNCC_Load(object sender, EventArgs e)
		{
			LoadData();
		}

		private void btnPrePage_Click(object sender, EventArgs e)
		{
			dgvNhaCungCap.DataSource = func.GetCurrentRecords(--CurrentPageIndex, PgSize, "tNhaCungCap", sqlCondition, "MaNCC", "MaNCC");
			SetColumnNCC();
			btnPrePage.Enabled = CurrentPageIndex > 1;
			btnNextPage.Enabled = TotalPage > CurrentPageIndex;
			lblPage.Text = string.Format("Page: {0}/{1}", CurrentPageIndex, TotalPage);
		}

		private void btnNextPage_Click(object sender, EventArgs e)
		{
			dgvNhaCungCap.DataSource = func.GetCurrentRecords(++CurrentPageIndex, PgSize, "tNhaCungCap", sqlCondition, "MaNCC", "MaNCC");
			SetColumnNCC();
			btnPrePage.Enabled = CurrentPageIndex > 1;
			btnNextPage.Enabled = TotalPage > CurrentPageIndex;
			lblPage.Text = string.Format("Page: {0}/{1}", CurrentPageIndex, TotalPage);
		}

		private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				string searchText = txtSearch.Text.Trim();
				sqlCondition = string.Format(" where TenNCC like N'%{0}%' or MaNCC like N'%{0}%' or SDT like N'%{0}%' " +
					"or DiaChi like N'%{0}%'", searchText);
				LoadData();
			}
		}

		private void dgvNhaCungCap_DoubleClick(object sender, EventArgs e)
		{
			string MaNCC = dgvNhaCungCap.CurrentRow.Cells["MaNCC"].Value.ToString();
			Forms.NhaCungCap.frmCapNhatNCC frmCapNhatNCC = new frmCapNhatNCC(MaNCC);
			frmCapNhatNCC.ShowDialog();
			this.LoadData();
		}
	}
}

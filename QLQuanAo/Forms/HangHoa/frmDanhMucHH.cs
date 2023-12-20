using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLQuanAo.Forms.HangHoa
{
    public partial class frmDanhMucHH : Form
    {
		Classes.DataProcesser dataProcesser = new Classes.DataProcesser();
		Classes.CommonFunc func = new Classes.CommonFunc();
		int PgSize = 9;
		int CurrentPageIndex = 1;
		int TotalPage = 0;
		DataTable dt = new DataTable();
		string sqlCondition = "";
		public frmDanhMucHH()
        {
            InitializeComponent();

			// Fill data cho combobox thể loại
			DataTable theLoais = dataProcesser.ReadData("select * from tTheLoai");
			DataRow allRow = theLoais.NewRow();
			allRow["TenTheLoai"] = "Tất cả";
			allRow["MaTheLoai"] = "";
			theLoais.Rows.InsertAt(allRow, 0);

			func.FillComboBox(cboTheLoai, theLoais, "TenTheLoai", "MaTheLoai");

			// Fill data cho combobox nhà cung cấp
			DataTable NCCs = dataProcesser.ReadData("select * from tNhaCungCap");
			DataRow allRowNCC = NCCs.NewRow();
			allRowNCC["TenNCC"] = "Tất cả";
			allRowNCC["MaNCC"] = "";
			NCCs.Rows.InsertAt(allRowNCC, 0);
			func.FillComboBox(cboNCC, NCCs, "TenNCC", "MaNCC");
		}

		private void btnThemHH_Click(object sender, EventArgs e)
		{
            this.Hide();
            Forms.HangHoa.frmThemHH frmThemHH = new frmThemHH();
            frmThemHH.ShowDialog();
            frmThemHH = null;
            this.Show();
		}
		private void LoadData()
		{
			TotalPage = func.CalculateTotalPages("tMatHang", sqlCondition, PgSize);
			CurrentPageIndex = 1;
			dgvHangHoa.DataSource = func.GetCurrentRecords(CurrentPageIndex, PgSize, "tMatHang", sqlCondition, "MaMH", "MaMH");
			SetColumnHH();
			btnPrePage.Enabled = CurrentPageIndex > 1;
			btnNextPage.Enabled = TotalPage > CurrentPageIndex;
			lblPage.Text = string.Format("Page: {0}/{1}", CurrentPageIndex, TotalPage);
		}

		private void SetColumnHH()
		{
			dgvHangHoa.Columns["MaMH"].HeaderText = "Mã mặt hàng";
			dgvHangHoa.Columns["TenMH"].HeaderText = "Tên mặt hàng";
			dgvHangHoa.Columns["MaTheLoai"].Visible = false;
			dgvHangHoa.Columns["Mau"].Visible = false;
			dgvHangHoa.Columns["Size"].Visible = false;
			dgvHangHoa.Columns["MaNCC"].Visible = false;
			dgvHangHoa.Columns["GiaBan"].DefaultCellStyle.Format = "N0";
			dgvHangHoa.Columns["GiaBan"].HeaderText = "Giá bán";
			dgvHangHoa.Columns["GiaNhap"].DefaultCellStyle.Format = "N0";
			dgvHangHoa.Columns["GiaNhap"].HeaderText = "Giá nhập";
			dgvHangHoa.Columns["MaNCC"].Visible = false;
			dgvHangHoa.Columns["SLTon"].HeaderText = "Tồn kho";
			dgvHangHoa.Columns["Anh"].Visible = false;
			dgvHangHoa.Columns["GhiChu"].Visible = false;
			dgvHangHoa.Columns["DonVi"].Visible = false;
			dgvHangHoa.Columns["IsDangBan"].Visible = false;
		}

		private void frmDanhMucHH_Load(object sender, EventArgs e)
		{
			LoadData();
		}

		private void btnPrePage_Click(object sender, EventArgs e)
		{
			dgvHangHoa.DataSource = func.GetCurrentRecords(--CurrentPageIndex, PgSize, "tMatHang", sqlCondition, "MaMH", "MaMH");
			SetColumnHH();
			btnPrePage.Enabled = CurrentPageIndex > 1;
			btnNextPage.Enabled = TotalPage > CurrentPageIndex;
			lblPage.Text = string.Format("Page: {0}/{1}", CurrentPageIndex, TotalPage);
		}

		private void btnNextPage_Click(object sender, EventArgs e)
		{
			dgvHangHoa.DataSource = func.GetCurrentRecords(++CurrentPageIndex, PgSize, "tMatHang", sqlCondition, "MaMH", "MaMH");
			SetColumnHH();
			btnPrePage.Enabled = CurrentPageIndex > 1;
			btnNextPage.Enabled = TotalPage > CurrentPageIndex;
			lblPage.Text = string.Format("Page: {0}/{1}", CurrentPageIndex, TotalPage);
		}

		private void btnLoc_Click(object sender, EventArgs e)
		{
			sqlCondition = " where ";

			// tìm theo điều kiện ở ô textbox
			sqlCondition += string.Format(" (MaMH like N'%{0}%' or TenMH like N'%{0}%') ", txtSearch.Text.Trim());

			// tìm theo thể loại
			var selectedTheLoai = cboTheLoai.SelectedValue.ToString();
			if (selectedTheLoai != "")
				sqlCondition += string.Format(" and MaTheLoai = N'{0}' ", selectedTheLoai);

			// Tìm theo nhà cung cấp
			var selectedNCC = cboNCC.SelectedValue.ToString();
			if (selectedNCC != "")
				sqlCondition += string.Format(" and MaNCC = N'{0}' ", selectedNCC);

			// Tìm theo mau
			var mau = txtMau.Text.Trim();
			if (mau != "") sqlCondition += string.Format(" and Mau = N'{0}' ", mau);

			// Tìm theo size
			var size = txtSize.Text.Trim();
			if (size != "") sqlCondition += string.Format(" and Size = N'{0}' ", size);

			// Tìm theo tồn kho
			if (rdoConHang.Checked == true) sqlCondition += " and (SLTon > 0) ";
			else if (rdoHetHang.Checked == true) sqlCondition +=  " and (SLTon <= 0) ";

			// Tìm theo trạng thái kinh doanh
			if (rdoDangKinhDoanh.Checked == true) sqlCondition += " and (IsDangBan = 1) ";
			else if (rdoNgungKinhDoanh.Checked == true) sqlCondition += " and (IsDangBan = 0) ";
			//MessageBox.Show(sqlCondition);

			LoadData();
		}

		private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter) btnLoc.PerformClick();
		}

		private void dgvHangHoa_DoubleClick(object sender, EventArgs e)
		{
			string MaMH = dgvHangHoa.CurrentRow.Cells["MaMH"].Value.ToString();
			this.Hide();
			Forms.HangHoa.frmCapNhatHH frmCapNhatHH = new frmCapNhatHH(MaMH);
			frmCapNhatHH.ShowDialog();
			frmCapNhatHH = null;
			this.Show();
		}
	}
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using TheArtOfDevHtmlRenderer.Adapters;

namespace QLQuanAo.Forms.HoaDonBan
{
	public partial class frmHoaDonBan : Form
	{
		Classes.DataProcesser dataProcesser = new Classes.DataProcesser();
		Classes.CommonFunc func = new Classes.CommonFunc();
		int PgSize = 9;
		int CurrentPageIndex = 1;
		int TotalPage = 0;
		DataTable dt = new DataTable();
		List<string> displayList = new List<string>() { "Toàn thời gian", "Hôm nay", "Hôm qua", "Tuần này", "Tuần trước", "Tháng này", "Tháng trước", "Năm nay", "Năm trước" };
		List<string> valueList = new List<string>() {
			   "",
			   " and CONVERT(date, ThoiGianTT) = CONVERT(date, GETDATE()) ",
			   " and CONVERT(date, ThoiGianTT) = CONVERT(date, DATEADD(DAY, -1, GETDATE())) ",
			   " and (CONVERT(date, ThoiGianTT) between dbo.FirstDayOfWeek() and GETDATE()) ",
			   " and (CONVERT(date, ThoiGianTT) between dbo.FirstDayOfLastWeek() and dbo.LastDayOfLastWeek()) ",
			   " and MONTH(ThoiGianTT) = MONTH(GETDATE()) and YEAR(ThoiGianTT) = YEAR(GETDATE()) ",
			   " and MONTH(ThoiGianTT) = MONTH(DATEADD(MONTH, -1, GETDATE())) and YEAR(ThoiGianTT) = YEAR(DATEADD(MONTH, -1, GETDATE())) ",
			   " and YEAR(ThoiGianTT) = YEAR(GETDATE()) ",
			   " and YEAR(ThoiGianTT) = YEAR(GETDATE()) - 1 "
		};
		string sqlCondition = "";
		public frmHoaDonBan()
		{
			InitializeComponent();
			List<ListItem> items = new List<ListItem>();
			for (int i = 0; i < displayList.Count; i++)
			{
				ListItem item = new ListItem(displayList[i], valueList[i]);
				items.Add(item);
			}

			// Thiết lập danh sách ListItem cho ComboBox
			cboNgayTao.DisplayMember = "Text";
			cboNgayTao.ValueMember = "Value";
			cboNgayTao.DataSource = items;
			cboNgayTao.StartIndex = 0;

			// Set ngày max cho dateNgayDen = ngày hôm nay
			dateTo.MaxDate = DateTime.Now;
			dateFrom.MaxDate = DateTime.Now;

			// Fill data cho combobox người tạo
			DataTable nhanViens = dataProcesser.ReadData("select * from tNhanVien");
			DataRow allRow = nhanViens.NewRow();
			allRow["TenNV"] = "Tất cả";
			allRow["MaNV"] = "";
			nhanViens.Rows.InsertAt(allRow, 0);

			func.FillComboBox(cboNguoiTao, nhanViens, "TenNV", "MaNV");

			if (Classes.ConstVar.Role == false) btnXoaPN.Enabled = false;
		}

		private void frmHoaDonBan_Load(object sender, EventArgs e)
		{
			LoadData();
		}
		private void LoadData()
		{
			TotalPage = func.CalculateTotalPages("tHoaDonBan", sqlCondition, PgSize);
			CurrentPageIndex = 1;
			dgvHoaDon.DataSource = func.GetCurrentRecords(CurrentPageIndex, PgSize, "tHoaDonBan", sqlCondition, "MaHDB", "ThoiGianTT");
			SetColumn();
			btnPrePage.Enabled = CurrentPageIndex > 1;
			btnNextPage.Enabled = TotalPage > CurrentPageIndex;
			lblPage.Text = string.Format("Page: {0}/{1}", CurrentPageIndex, TotalPage);
		}

		private void SetColumn()
		{
			dgvHoaDon.Columns["MaHDB"].HeaderText = "Mã hóa đơn";
			dgvHoaDon.Columns["MaHDB"].DisplayIndex = 0;
			dgvHoaDon.Columns["MaNV"].Visible = false;
			dgvHoaDon.Columns["ThanhToan"].HeaderText = "Tổng cộng";
			dgvHoaDon.Columns["ThanhToan"].DisplayIndex = 5;
			dgvHoaDon.Columns["ThanhToan"].DefaultCellStyle.Format = "N0";
			dgvHoaDon.Columns["ThoiGianTT"].HeaderText = "Thời gian";
			dgvHoaDon.Columns["ThoiGianTT"].DisplayIndex = 1;
			dgvHoaDon.Columns["ThoiGianTT"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
			dgvHoaDon.Columns["PhuongThucTT"].Visible = false;
			for (int i = 0; i < dgvHoaDon.Rows.Count; i++)
			{
				string MaKH = dgvHoaDon.Rows[i].Cells["MaKH"].Value.ToString();
				DataTable KH = dataProcesser.ReadData("select MaKH, TenKH from tKhachHang where MaKH = N'" + MaKH+ "'");
				dgvHoaDon.Rows[i].Cells["MaKH"].Value = KH.Rows[0]["TenKH"].ToString();
			}
			dgvHoaDon.Columns["MaKH"].HeaderText = "Tên khách hàng";
			dgvHoaDon.Columns["MaKH"].DisplayIndex = 2;
			dgvHoaDon.Columns["TongTien"].Visible = false;
			dgvHoaDon.Columns["GiamGia"].Visible = false;
			dgvHoaDon.Columns["GhiChu"].Visible = false;

		}

		private void dateFrom_ValueChanged(object sender, EventArgs e)
		{
			dateTo.MinDate = dateFrom.Value;
		}

		private void dateTo_ValueChanged(object sender, EventArgs e)
		{
			dateFrom.MaxDate = dateTo.Value;
		}

		private void btnThemHDB_Click(object sender, EventArgs e)
		{
			this.Hide();
			Forms.BanHang.frmBanHang frmBanHang = new BanHang.frmBanHang();
			frmBanHang.Show();
		}

		private void txtMinTongTien_KeyPress(object sender, KeyPressEventArgs e)
		{
			func.textBox_SoThuc_KeyPress(sender, e);
		}

		private void btnPrePage_Click(object sender, EventArgs e)
		{
			dgvHoaDon.DataSource = func.GetCurrentRecords(--CurrentPageIndex, PgSize, "tHoaDonBan", sqlCondition, "MaHDB", "ThoiGianTT");
			SetColumn();
			btnPrePage.Enabled = CurrentPageIndex > 1;
			btnNextPage.Enabled = TotalPage > CurrentPageIndex;
			lblPage.Text = string.Format("Page: {0}/{1}", CurrentPageIndex, TotalPage);
		}

		private void btnNextPage_Click(object sender, EventArgs e)
		{
			dgvHoaDon.DataSource = func.GetCurrentRecords(++CurrentPageIndex, PgSize, "tHoaDonBan", sqlCondition, "MaHDB", "ThoiGianTT");
			SetColumn();
			btnPrePage.Enabled = CurrentPageIndex > 1;
			btnNextPage.Enabled = TotalPage > CurrentPageIndex;
			lblPage.Text = string.Format("Page: {0}/{1}", CurrentPageIndex, TotalPage);
		}

		private void dgvHoaDon_DoubleClick(object sender, EventArgs e)
		{
			string MaHDB = dgvHoaDon.CurrentRow.Cells["MaHDB"].Value.ToString();
			this.Hide();
			Forms.HoaDonBan.frmChiTietHDB frmChiTietHDB = new frmChiTietHDB(MaHDB);
			frmChiTietHDB.ShowDialog();
			frmChiTietHDB = null;
			this.Show();
			this.LoadData();
		}

		private void btnLoc_Click(object sender, EventArgs e)
		{
			sqlCondition = " where ";
			// tìm theo điều kiện ở ô textbox
			sqlCondition += string.Format(" (MaHDB like N'%{0}%') ", txtSearch.Text.Trim());

			// tìm theo điều kiện Ngày Tạo
			if (rdoComboBox.Checked == true)
			{
				sqlCondition += cboNgayTao.SelectedValue.ToString();
			}
			else
			{
				sqlCondition += string.Format(" and (ThoiGianTT between '{0}' and '{1}') ", dateFrom.Text, dateTo.Text);
			}

			// Tìm theo phương thức thanh toán
			if (rdoTienMat.Checked == true)
			{
				sqlCondition += " and (PhuongThucTT = 0) ";
			}
			else if (rdoChuyenKhoan.Checked == true)
			{
				sqlCondition += " and (PhuongThucTT = 1) ";
			}

			// Tìm theo nhân viên bán
			var selectedNV = cboNguoiTao.SelectedValue.ToString();
			if (selectedNV != "") sqlCondition += string.Format(" and (MaNV = N'{0}') ", selectedNV);

			// Tìm theo Tổng bán
			float tongTienMin = float.Parse(txtMinTongTien.Text);
			float tongTienMax = float.Parse(txtMaxTongTien.Text);
			if (tongTienMin <= tongTienMax)
			{
				sqlCondition += string.Format(" and (ThanhToan between {0} and {1}) ", tongTienMin, tongTienMax);
			}
			LoadData();
		}

		private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)(Keys.Enter))
			{
				btnLoc.PerformClick();
			}
		}

		private void btnXoaPN_Click(object sender, EventArgs e)
		{
			string MaHDB = dgvHoaDon.CurrentRow.Cells[0].Value.ToString();
			DataTable dtChiTietHDB = dataProcesser.ReadData("select MaMH, SLBan from tChiTietHDB where MaHDB= '" + MaHDB + "'");

			if (MessageBox.Show("Hóa đơn này có " + dtChiTietHDB.Rows.Count + " mặt hàng.Bạn có muốn xóa  hóa đơn có mã hóa đơn " + MaHDB + " này không?", "Xác nhận",
				MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				for (int i = 0; i < dtChiTietHDB.Rows.Count; i++)
				{
					string MaMH = dtChiTietHDB.Rows[i]["MaMH"].ToString();
					int SLBan = int.Parse(dtChiTietHDB.Rows[i]["SLBan"].ToString());
					//cập nhật vào bảng mặt hàng
					dataProcesser.ChangeData("update tMatHang set SLTon = SLTon + " + SLBan + " where MaMH= N'" + MaMH + "'");
				}

				// xóa bảng chi tiết
				dataProcesser.ChangeData("delete tChiTietHDB where MaHDB= '" + MaHDB + "'");
				//xóa bảng hóa đơn
				dataProcesser.ChangeData("delete tHoaDonBan where MaHDB= '" + MaHDB + "'");
			}
			LoadData();
		}
	}
}

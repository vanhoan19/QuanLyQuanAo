using QLQuanAo.Classes;
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

namespace QLQuanAo.Forms.HoaDonNhap
{
    public partial class frmHoaDonNhap : Form
    {
        Classes.DataProcesser dtBase= new Classes.DataProcesser();
		Classes.CommonFunc func = new Classes.CommonFunc();
		int PgSize = 9;
		int CurrentPageIndex = 1;
		int TotalPage = 0;
		DataTable dt = new DataTable();
		List<string> displayList = new List<string>() { "Toàn thời gian", "Hôm nay", "Hôm qua", "Tuần này", "Tuần trước", "Tháng này", "Tháng trước", "Năm nay", "Năm trước" };
		List<string> valueList = new List<string>() {
			   "",
			   " and CONVERT(date, NgayNhap) = CONVERT(date, GETDATE()) ",
			   " and CONVERT(date, NgayNhap) = CONVERT(date, DATEADD(DAY, -1, GETDATE())) ",
			   " and (CONVERT(date, NgayNhap) between dbo.FirstDayOfWeek() and GETDATE()) ",
			   " and (CONVERT(date, NgayNhap) between dbo.FirstDayOfLastWeek() and dbo.LastDayOfLastWeek()) ",
			   " and MONTH(NgayNhap) = MONTH(GETDATE()) and YEAR(NgayNhap) = YEAR(GETDATE()) ",
			   " and MONTH(NgayNhap) = MONTH(DATEADD(MONTH, -1, GETDATE())) and YEAR(NgayNhap) = YEAR(DATEADD(MONTH, -1, GETDATE())) ",
			   " and YEAR(NgayNhap) = YEAR(GETDATE()) ",
			   " and YEAR(NgayNhap) = YEAR(GETDATE()) - 1 "
		};
		string sqlCondition = "";
		public frmHoaDonNhap()
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
			DataTable nhanViens = dtBase.ReadData("select * from tNhanVien");
			DataRow allRow = nhanViens.NewRow();
			allRow["TenNV"] = "Tất cả";
			allRow["MaNV"] = "";
			nhanViens.Rows.InsertAt(allRow, 0);

			func.FillComboBox(cboNguoiTao, nhanViens, "TenNV", "MaNV");
		}
        private void setDgvHoaDon()
        {
            dgvHoaDonNhap.Columns[0].HeaderText = "Mã HDN";
            dgvHoaDonNhap.Columns[1].HeaderText = "Mã NV";
            dgvHoaDonNhap.Columns[2].HeaderText = "Ngày nhập";
            dgvHoaDonNhap.Columns[3].Visible = false;
            dgvHoaDonNhap.Columns[4].HeaderText = "Tổng tiền";
			dgvHoaDonNhap.Columns[4].DefaultCellStyle.Format = "N0";

			dgvHoaDonNhap.Columns[5].Visible = false;
            dgvHoaDonNhap.Columns[6].Visible = false;
            dgvHoaDonNhap.Columns["TrangThai"].HeaderText = "Trạng thái";

			this.dgvHoaDonNhap.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);

        }
        private void frmHoaDonNhap_Load(object sender, EventArgs e)
        {
            LoadData();

		}


        private void btnLoc_Click(object sender, EventArgs e)
        {
			sqlCondition = " where ";
			// tìm theo điều kiện ở ô textbox
			sqlCondition += string.Format(" (MaPN like N'%{0}%') ", txtSearch.Text.Trim());

			// tìm theo điều kiện Ngày Tạo
			if (rdoComboBox.Checked == true)
			{
				sqlCondition += cboNgayTao.SelectedValue.ToString();
			}
			else
			{
				sqlCondition += string.Format(" and (NgayNhap between '{0}' and '{1}') ", dateFrom.Text, dateTo.Text);
			}

			// Tìm theo phương thức thanh toán
			if (rdoTienMat.Checked == true)
			{
				sqlCondition += " and (PhuongThucTT = N'Tiền mặt') ";
			}
			else if (rdoChuyenKhoan.Checked == true)
			{
				sqlCondition += " and (PhuongThucTT = N'Chuyển khoản') ";
			}

			// Tìm theo trạng thái hóa đơn
			if (rdoHoanThanh.Checked == true)
			{
				sqlCondition += " and (TrangThai = N'Đã hoàn thành') ";
			}
			else if (rdoChuaHoanThanh.Checked == true)
			{
				sqlCondition += " and (TrangThai = N'Chưa hoàn thành') ";
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

        private void dgvHoaDonNhap_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string MaPN = dgvHoaDonNhap.CurrentRow.Cells[0].Value.ToString();
            string TrangThai = dgvHoaDonNhap.CurrentRow.Cells["TrangThai"].Value.ToString();
            if (TrangThai == "Chưa hoàn thành")
            {
                frmNhapHang frmNhapHang = new frmNhapHang(MaPN);
                frmNhapHang.ShowDialog();
                frmNhapHang = null;
			}
            else
            {
				frmChiTietHDN frm = new frmChiTietHDN(MaPN);
				frm.ShowDialog();
                frm = null;
			}
            frmHoaDonNhap_Load(sender, e);
        }

        private void btnNhapHang_Click(object sender, EventArgs e)
        {
            frmNhapHang frm = new frmNhapHang();
            frm.ShowDialog();
            frm = null;
            string sql = "select * from phieuNhap_select";
            DataTable dtHDN = dtBase.ReadData(sql);
            dgvHoaDonNhap.DataSource = dtHDN;
            setDgvHoaDon();
            
        }

        private void btnXoaPN_Click(object sender, EventArgs e)
        {
            string MaPN= dgvHoaDonNhap.CurrentRow.Cells[0].Value.ToString();
            DataTable dtNhapHang = dtBase.ReadData("select MaMH, SLNhap from tChiTietPN where MaPN= '" + MaPN+"'");

            if (MessageBox.Show("Hóa đơn này có " + dtNhapHang.Rows.Count + " mặt hàng.Bạn có muốn xóa  hóa đơn có mã hóa đơn " + MaPN + " này không?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                for(int i=0; i<dtNhapHang.Rows.Count; i++)
                {
                    string MaMH= dtNhapHang.Rows[i]["MaMH"].ToString();
                    int SlNhap = int.Parse(dtNhapHang.Rows[i]["SLNhap"].ToString());
                    // cập nhật lại số lượng tồn của MaMH
                    DataTable dtMH = dtBase.ReadData("select SLTon from tMatHang where MaMH= N'" + MaMH + "'"); // lấy ra slton của mặt hàng
                                                                                                                // cập nhật lại
                    int soluongton = int.Parse(dtMH.Rows[0]["SLTon"].ToString()) - SlNhap;
                    //cập nhật vào bảng mặt hàng
                    dtBase.ChangeData("update tMatHang set SLTon ='" + soluongton + "' where MaMH= N'"+MaMH+"'");
                    

                }

                // xóa bảng chi tiết
                dtBase.ChangeData("delete tChiTietPN where MaPN= '" + MaPN + "'");
                //xóa bảng hóa đơn
                dtBase.ChangeData("delete tPhieuNhap where MaPN= '" + MaPN + "'");
            }
            LoadData();
		}

		private void LoadData()
		{
			TotalPage = func.CalculateTotalPages("phieuNhap_select", sqlCondition, PgSize);
			CurrentPageIndex = 1;
			dgvHoaDonNhap.DataSource = func.GetCurrentRecords(CurrentPageIndex, PgSize, "phieuNhap_select", sqlCondition, "MaPN", "MaPN");
            setDgvHoaDon();
			btnPrePage.Enabled = CurrentPageIndex > 1;
			btnNextPage.Enabled = TotalPage > CurrentPageIndex;
			lblPage.Text = string.Format("Page: {0}/{1}", CurrentPageIndex, TotalPage);
		}

		private void btnPrePage_Click(object sender, EventArgs e)
		{
			dgvHoaDonNhap.DataSource = func.GetCurrentRecords(--CurrentPageIndex, PgSize, "phieuNhap_select", sqlCondition, "MaPN", "MaPN");
			setDgvHoaDon();
			btnPrePage.Enabled = CurrentPageIndex > 1;
			btnNextPage.Enabled = TotalPage > CurrentPageIndex;
			lblPage.Text = string.Format("Page: {0}/{1}", CurrentPageIndex, TotalPage);
		}

		private void btnNextPage_Click(object sender, EventArgs e)
		{
			dgvHoaDonNhap.DataSource = func.GetCurrentRecords(++CurrentPageIndex, PgSize, "phieuNhap_select", sqlCondition, "MaPN", "MaPN");
			setDgvHoaDon();
			btnPrePage.Enabled = CurrentPageIndex > 1;
			btnNextPage.Enabled = TotalPage > CurrentPageIndex;
			lblPage.Text = string.Format("Page: {0}/{1}", CurrentPageIndex, TotalPage);
		}

		private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				btnLoc.PerformClick();
			}
		}
	}
}

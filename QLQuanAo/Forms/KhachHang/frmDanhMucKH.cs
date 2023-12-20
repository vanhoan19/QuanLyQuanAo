using PagedList;
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

namespace QLQuanAo.Forms.KhachHang
{
    public partial class frmDanhMucKH : Form
    {
        Classes.DataProcesser dataProcesser = new Classes.DataProcesser();
        Classes.CommonFunc func = new Classes.CommonFunc();
        int PgSize = 9;
        int CurrentPageIndex = 1;
        int TotalPage = 0;
        DataTable dt = new DataTable();
        List<string> displayList = new List<string>(){ "Toàn thời gian", "Hôm nay", "Hôm qua", "Tuần này", "Tuần trước", "Tháng này", "Tháng trước", "Năm nay", "Năm trước" };
        List<string> valueList = new List<string>() { 
               "",
               " and CONVERT(date, NgayTaoKH) = CONVERT(date, GETDATE()) ",
               " and CONVERT(date, NgayTaoKH) = CONVERT(date, DATEADD(DAY, -1, GETDATE())) ",
               " and (CONVERT(date, NgayTaoKH) between dbo.FirstDayOfWeek() and GETDATE()) ",
               " and (CONVERT(date, NgayTaoKH) between dbo.FirstDayOfLastWeek() and dbo.LastDayOfLastWeek()) ",
               " and MONTH(NgayTaoKH) = MONTH(GETDATE()) and YEAR(NgayTaoKH) = YEAR(GETDATE()) ",
               " and MONTH(NgayTaoKH) = MONTH(DATEADD(MONTH, -1, GETDATE())) and YEAR(NgayTaoKH) = YEAR(DATEADD(MONTH, -1, GETDATE())) ",
               " and YEAR(NgayTaoKH) = YEAR(GETDATE()) ",
               " and YEAR(NgayTaoKH) = YEAR(GETDATE()) - 1 "
        };
        string sqlCondition = "";
        public frmDanhMucKH()
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
        }

        private void frmDanhMucKH_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnPrePage_Click(object sender, EventArgs e)
        {
            dgvKhachHang.DataSource = func.GetCurrentRecords(--CurrentPageIndex, PgSize, "tKhachHang", sqlCondition, "MaKH", "MaKH");
            setColumnKH();
            btnPrePage.Enabled = CurrentPageIndex > 1;
            btnNextPage.Enabled = TotalPage > CurrentPageIndex;
            lblPage.Text = string.Format("Page: {0}/{1}", CurrentPageIndex, TotalPage);
        }

        private async void btnNextPage_Click(object sender, EventArgs e)
        {
            dgvKhachHang.DataSource = func.GetCurrentRecords(++CurrentPageIndex, PgSize, "tKhachHang", sqlCondition, "MaKH", "MaKH");
            setColumnKH();
            btnPrePage.Enabled = CurrentPageIndex > 1;
            btnNextPage.Enabled = TotalPage > CurrentPageIndex;
            lblPage.Text = string.Format("Page: {0}/{1}", CurrentPageIndex, TotalPage);
        }
        private void setColumnKH()
        {
            dgvKhachHang.Columns["MaKH"].HeaderText = "Mã khách hàng";
            dgvKhachHang.Columns["TenKH"].HeaderText = "Tên khách hàng";
            dgvKhachHang.Columns["SDT"].HeaderText = "Số điện thoại";
            dgvKhachHang.Columns["TongBan"].HeaderText = "Tổng bán";
            dgvKhachHang.Columns["TongBan"].DefaultCellStyle.Format = "N0";
			dgvKhachHang.Columns["GioiTinh"].Visible = false;
            dgvKhachHang.Columns["DiaChi"].Visible = false;
            dgvKhachHang.Columns["Anh"].Visible = false;
            dgvKhachHang.Columns["GhiChu"].Visible = false;
            dgvKhachHang.Columns["NgaySinh"].Visible = false;
            dgvKhachHang.Columns["MaNV"].Visible = false;
            dgvKhachHang.Columns["NgayTaoKH"].Visible = false;
        }

        private void btnThemKH_Click(object sender, EventArgs e)
        {
            this.Hide();
            Forms.KhachHang.frmCapNhatKH frmCapNhatKH = new frmCapNhatKH();
            frmCapNhatKH.ShowDialog();
            frmCapNhatKH = null;
            this.Show();
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            Search();
            //MessageBox.Show(sqlCondition);
            LoadData();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter)) btnLoc.PerformClick();
        }

        private void Search()
        {
            sqlCondition = " where ";
            // tìm theo điều kiện ở ô textbox
            sqlCondition += string.Format(" (MaKH like N'%{0}%' or TenKH like N'%{0}%' or SDT like N'%{0}%') ", txtSearch.Text.Trim());

            // tìm theo điều kiện Ngày Tạo
            if (rdoComboBox.Checked == true)
            {
                sqlCondition += cboNgayTao.SelectedValue.ToString();
            }
            else
            {
                sqlCondition += string.Format(" and (NgayTaoKH between '{0}' and '{1}') ", dateFrom.Text, dateTo.Text);
            }

            // Tìm theo Giới tính
            if (rdoNam.Checked == true)
            {
                sqlCondition += " and GioiTinh = 1 ";
            }
            else if (rdoNu.Checked == true) {
                sqlCondition += " and GioiTinh = 0 ";
            }

            // Tìm theo Tổng bán
            float tongBanMin = float.Parse(txtMinTongBan.Text);
            float tongBanMax = float.Parse(txtMaxTongBan.Text);
            if (tongBanMin <= tongBanMax)
            {
                sqlCondition += string.Format(" and (TongBan between {0} and {1}) ", tongBanMin, tongBanMax);
            }
        }

        private void dateFrom_ValueChanged(object sender, EventArgs e)
        {
            dateTo.MinDate = dateFrom.Value;
        }

        private void dateTo_ValueChanged(object sender, EventArgs e)
        {
            dateFrom.MaxDate = dateTo.Value;
        }

        private void txtMinTongBan_KeyPress(object sender, KeyPressEventArgs e)
        {
            func.textBox_SoNguyen_KeyPress(sender, e);
        }
        private void LoadData()
        {
            TotalPage = func.CalculateTotalPages("tKhachHang", sqlCondition, PgSize);
            CurrentPageIndex = 1;
			dgvKhachHang.DataSource = func.GetCurrentRecords(CurrentPageIndex, PgSize, "tKhachHang", sqlCondition, "MaKH", "MaKH");
            setColumnKH();
            btnPrePage.Enabled = CurrentPageIndex > 1;
            btnNextPage.Enabled = TotalPage > CurrentPageIndex;
            lblPage.Text = string.Format("Page: {0}/{1}", CurrentPageIndex, TotalPage);
        }

		private void rdoTuyChonNgay_CheckedChanged(object sender, EventArgs e)
		{
            conTuyChonNgay.Visible = rdoTuyChonNgay.Checked;
		}

		private void dgvKhachHang_DoubleClick(object sender, EventArgs e)
		{
			string MaKH = dgvKhachHang.CurrentRow.Cells[0].Value.ToString();
			this.Hide();
			Forms.KhachHang.frmKhachHang frmKhachHang = new frmKhachHang(MaKH);
			frmKhachHang.ShowDialog();
			frmKhachHang = null;
			this.Show();
		}
	}
}

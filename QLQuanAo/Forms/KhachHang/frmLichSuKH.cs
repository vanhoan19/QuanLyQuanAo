using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLQuanAo.Forms.KhachHang
{
	public partial class frmLichSuKH : Form
	{
		Classes.CommonFunc commonFunc = new Classes.CommonFunc();
		Classes.DataProcesser dataProcesser = new Classes.DataProcesser();
		string MaKH;
		public frmLichSuKH()
		{
			InitializeComponent();
		}

		public frmLichSuKH(string MaKH)
		{
			InitializeComponent();
			this.MaKH = MaKH;
			string sql = string.Format("SELECT MaHDB, ThoiGianTT, ThanhToan, " +
				"IIF(PhuongThucTT = 0, N'Tiền mặt', N'Chuyển khoản') as PhuongThucTT " +
				"from tHoaDonBan where MaKH = N'{0}'", MaKH);
			DataTable dt = dataProcesser.ReadData(sql);
			dgvLichSuKH.DataSource = dt;

			SetColumn();
		}

		private void SetColumn()
		{
			dgvLichSuKH.Columns["MaHDB"].HeaderText = "Mã hóa đơn";
			dgvLichSuKH.Columns["ThanhToan"].HeaderText = "Tổng cộng";
			dgvLichSuKH.Columns["ThanhToan"].DefaultCellStyle.Format = "N0";
			dgvLichSuKH.Columns["ThoiGianTT"].HeaderText = "Thời gian";
			dgvLichSuKH.Columns["ThoiGianTT"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
			dgvLichSuKH.Columns["PhuongThucTT"].HeaderText = "Phương thức";
		}

		private void dgvLichSuKH_DoubleClick(object sender, EventArgs e)
		{
			string MaHDB = dgvLichSuKH.CurrentRow.Cells["MaHDB"].Value.ToString();
			this.Hide();
			Forms.HoaDonBan.frmChiTietHDB frmChiTietHDB = new HoaDonBan.frmChiTietHDB(MaHDB);
			frmChiTietHDB.ShowDialog();
			frmChiTietHDB = null;
			this.Show();
		}
	}
}

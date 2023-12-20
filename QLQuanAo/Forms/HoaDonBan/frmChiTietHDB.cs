using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace QLQuanAo.Forms.HoaDonBan
{
	public partial class frmChiTietHDB : Form
	{
		Classes.DataProcesser dtBase = new Classes.DataProcesser();
		string MaHDB;
		string MaKH;
		public frmChiTietHDB()
		{
			InitializeComponent();
		}
		public frmChiTietHDB(string ma)
		{
			this.MaHDB = ma;
			InitializeComponent();
		}

		private void lblDuongThang_Click(object sender, EventArgs e)
		{
			lblDuongThang.Height = 2;
			lblDuongThang.Width = 3;
		}

		private void frmChiTietHDB_Load(object sender, EventArgs e)
		{
			DataTable dtCTHDB = dtBase.ReadData("select MaMH, GiaBan, SLBan, GiamGia, ThanhTien from tChiTietHDB where MaHDB= N'" + MaHDB + "'");
			dgvChiTietHDB.DataSource = dtCTHDB;
			setDgvChiTietHoaDon();
			XuLyThongTin();
		}
		private void XuLyThongTin()
		{

			string sql = "select * from tHoaDonBan where MaHDB='" + MaHDB + "'";
			DataTable dtTT = dtBase.ReadData(sql);

			DataTable NV = new DataTable();
			DataTable KH = new DataTable();
			if (dtTT.Rows.Count > 0)
			{
				lblMaHDB.Text = dtTT.Rows[0]["MaHDB"].ToString();
				string MaNV = dtTT.Rows[0]["MaNV"].ToString();
				NV = dtBase.ReadData("select TenNV from tNhanVien where MaNV ='" + MaNV + "'");
				llblNhanVien.Text = NV.Rows[0]["TenNV"].ToString();
				MaKH = dtTT.Rows[0]["MaKH"].ToString();
				KH = dtBase.ReadData("select MaKH,TenKH from tKhachHang where MaKH ='" + MaKH + "'");
				llblKhachHang.Text = KH.Rows[0]["TenKH"].ToString();
				lblThoiGianTT.Text = dtTT.Rows[0]["ThoiGianTT"].ToString();
				lblTongTien.Text = dtTT.Rows[0]["TongTien"].ToString();
				lblGiamGia.Text = dtTT.Rows[0]["GiamGia"].ToString();
				lblThanhToan.Text = dtTT.Rows[0]["ThanhToan"].ToString();
				int phuongthuc = dtTT.Rows[0]["PhuongThucTT"].ToString() == "True" ? 1 : 0;
				if (phuongthuc == 1)
				{
					lblPhuongThuc.Text = "Chuyển khoản";
				}
				else
				{
					lblPhuongThuc.Text = "Tiền mặt";
				}
			}
		}
		private void setDgvChiTietHoaDon()
		{
			dgvChiTietHDB.Columns["MaMH"].HeaderText = "Mã hàng";
			dgvChiTietHDB.Columns["SLBan"].HeaderText = "Số lượng";
			dgvChiTietHDB.Columns["GiaBan"].HeaderText = "Giá bán";
			dgvChiTietHDB.Columns["GiamGia"].HeaderText = "Giảm giá";
			dgvChiTietHDB.Columns["ThanhTien"].HeaderText = "Thành tiền";
			this.dgvChiTietHDB.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);
			dgvChiTietHDB.Columns["MaMH"].Width = 150;

		}

		private void btnXoaCTHD_Click(object sender, EventArgs e)
		{
			String maHD = dgvChiTietHDB.CurrentRow.Cells[0].Value.ToString();
			string masp = dgvChiTietHDB.CurrentRow.Cells[1].Value.ToString();
			if (MessageBox.Show("Bạn có muốn xóa chi tiết hóa đơn có mã hóa đơn :" + maHD + ", mã sản phẩm: " + masp + " này không?", "Xác nhận",
				MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				DataTable dt = dtBase.ReadData("select * from tMatHang where MaMH= N'" + masp + "'");
				//tính lại số lượng tồn
				int soluongcon = int.Parse(dt.Rows[0]["SLTon"].ToString()) +
								int.Parse(dgvChiTietHDB.CurrentRow.Cells[2].Value.ToString());
				dtBase.ChangeData("update tMatHang set SLTon= '" + soluongcon + "' where MaMH=N'" + masp + "'");
				// tính lại tổng tiền
				double tongtien = double.Parse(lblTongTien.Text) - double.Parse(dgvChiTietHDB.CurrentRow.Cells[4].Value.ToString());
				lblTongTien.Text = tongtien.ToString();
				//cập nhật thanh toán
				DataTable dtHD = dtBase.ReadData("select ThanhToan,GiamGia from tHoaDonBan where MaHDB= '" + maHD + "'");
				double thanhtoan = double.Parse(lblThanhToan.Text) - (tongtien - tongtien * double.Parse(dtHD.Rows[0]["GiamGia"].ToString()));
				lblThanhToan.Text = thanhtoan.ToString();
				dtBase.ChangeData("update tHoaDonBan set TongTien= '" + tongtien + "', ThanhToan='" + thanhtoan + "' where MaHDB = '" + maHD + "'");
				// xóa chi tiết
				dtBase.ChangeData("delete from tChiTietHDB where MaHDB= '" + maHD + "' and MaMH= N'" + masp + "'");
				frmChiTietHDB_Load(sender, e);
			}
		}

		private void dgvChiTietHDB_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (Classes.ConstVar.Role)
			{
				string MaH = dgvChiTietHDB.CurrentRow.Cells["MaMH"].Value.ToString();
				frmCapNhatCTHD frmCN = new frmCapNhatCTHD(MaHDB, MaH);
				frmCN.ShowDialog();
				frmCN = null;
				frmChiTietHDB_Load(sender, e);
			}
		}

		private void btnThoat_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnXuatHD_Click(object sender, EventArgs e)
		{
			SaveFileDialog file = new SaveFileDialog();
			Excel.Application exApp = new Excel.Application();
			Excel.Workbook exBook = exApp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
			Excel.Worksheet exSheet = (Excel.Worksheet)exBook.Worksheets[1];
			Excel.Range tenTruong = (Excel.Range)exSheet.Cells[1, 1];
			//Đưa dữ liệu vào Excel
			tenTruong.Range["A1:B1"].MergeCells = true;
			tenTruong.Range["A1:B1"].Font.Size = 20;
			tenTruong.Range["A1:B1"].Font.FontStyle = FontStyle.Bold;
			tenTruong.Range["A1"].Value = "HH Boutique";
			tenTruong.Range["A2:F2"].MergeCells = true;
			tenTruong.Range["A2"].Value = "Địa chỉ: Chung cư Gemek 2, An Khánh, Hoài Đức,Hà Nội";
			tenTruong.Range["A3:C3"].MergeCells = true;
			tenTruong.Range["A3"].Value = "Điện thoại: 0337629441";
			// tiêu đề
			tenTruong.Range["C5:F5"].MergeCells = true;
			tenTruong.Range["C5"].Value = "HÓA ĐƠN BÁN";
			// dữ liệu
			//Thông tin chung 
			tenTruong.Range["A7"].Value = "Mã hóa đơn : " + lblMaHDB.Text;
			string sql = "select * from tHoaDonBan where MaHDB='" + MaHDB + "'";
			DataTable dtTT = dtBase.ReadData(sql);
			string MaKH = dtTT.Rows[0]["MaKH"].ToString();
			DataTable dtKH = dtBase.ReadData("select * from tKhachHang where MaKH= '" + MaKH + "'");
			tenTruong.Range["A8"].Value = "Khách Hàng : " + MaKH + " - " + llblKhachHang.Text;
			tenTruong.Range["A9"].Value = "Số điện thoại khách hàng: " + dtKH.Rows[0]["SDT"].ToString();
			tenTruong.Range["A10"].Value = "Thời gian thanh toán: " + lblThoiGianTT.Text;
			// thong tin riênhg
			tenTruong.Range["A11"].Value = "Mã hàng";
			tenTruong.Range["B11"].Value = "Số lượng";
			tenTruong.Range["C11"].Value = "Giá bán";
			tenTruong.Range["D11"].Value = "Giảm giá";
			tenTruong.Range["E11"].Value = "Thành tiền";
			tenTruong.Range["A11:E11"].ColumnWidth = new int[] { 8, 8, 8, 8, 8 };
			int hang = 11;
			for (int i = 0; i < dgvChiTietHDB.Rows.Count - 1; i++)
			{
				hang++;
				tenTruong.Range["A" + hang.ToString()].Value = dgvChiTietHDB.Rows[i].Cells[1].Value.ToString();
				tenTruong.Range["B" + hang.ToString()].Value = dgvChiTietHDB.Rows[i].Cells[2].Value.ToString();
				tenTruong.Range["C" + hang.ToString()].Value = dgvChiTietHDB.Rows[i].Cells[3].Value.ToString();
				tenTruong.Range["D" + hang.ToString()].Value = dgvChiTietHDB.Rows[i].Cells[4].Value.ToString();
				tenTruong.Range["E" + hang.ToString()].Value = dgvChiTietHDB.Rows[i].Cells[5].Value.ToString();
			}
			tenTruong.Range["D" + (hang + 1)].Value = "Phương thức thanh toán : " + lblPhuongThuc.Text;
			tenTruong.Range["D" + (hang + 2)].Value = "Tổng tiền : " + lblTongTien.Text;
			tenTruong.Range["D" + (hang + 3)].Value = "Giảm giá : " + lblGiamGia.Text;
			tenTruong.Range["D" + (hang + 4)].Value = "Thanh toán : " + lblThanhToan.Text;
			tenTruong.Range["C" + (hang + 5)].Value = "Nhân viên  : " + llblNhanVien.Text;

			exSheet.Name = "HoaDonBan";
			exBook.Activate();
			if (file.ShowDialog() == DialogResult.OK)
				exBook.SaveAs(file.FileName.ToString());
			exApp.Quit();
		}

		private void llblKhachHang_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			this.Hide();
			Forms.KhachHang.frmKhachHang frmKhachHang = new KhachHang.frmKhachHang(MaKH);
			frmKhachHang.ShowDialog();
			frmKhachHang = null;
			this.Show();
		}
	}
}

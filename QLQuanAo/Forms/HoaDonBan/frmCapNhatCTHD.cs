using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLQuanAo.Forms.HoaDonBan
{
	public partial class frmCapNhatCTHD : Form
	{
		string MaHDB, MaH;
		int soluong;
		double thanhtienCu;
		double GiaBanCu;
		Classes.DataProcesser dtBase = new Classes.DataProcesser();
		Classes.CommonFunc CommonFunc = new Classes.CommonFunc();
		public frmCapNhatCTHD(string mahd, string mah)
		{
			MaHDB = mahd;
			MaH = mah;
			InitializeComponent();
		}
		private void frmCapNhatCTHD_Load(object sender, EventArgs e)
		{
			string MaHang = MaH.Substring(0, MaH.IndexOf(".", 1));
			string sql = String.Format("select * from tMatHang where MaMH like '%{0}%'", MaHang);
			DataTable dt = dtBase.ReadData(sql);
			CommonFunc.FillComboBox(cmbMaHang, dt, "TenMH", "MaMH");
			XuLyThongTin();
			//cmbMaHang.SelectedValue = MaH;
		}
		private void XuLyThongTin()
		{
			DataTable dtCN = dtBase.ReadData("select * from tChiTietHDB where MaHDB= '" + MaHDB + "' and MaMH= N'" + MaH + "'");
			txtSoLuong.Text = dtCN.Rows[0]["SLBan"].ToString();
			soluong = int.Parse(dtCN.Rows[0]["SLBan"].ToString());
			txtGiaBan.Text = dtCN.Rows[0]["GiaBan"].ToString();
			GiaBanCu = double.Parse(dtCN.Rows[0]["GiaBan"].ToString());
			txtThanhTien.Text = dtCN.Rows[0]["ThanhTien"].ToString();
			txtGiamGia.Text = dtCN.Rows[0]["GiamGia"].ToString();
			cmbMaHang.SelectedValue = dtCN.Rows[0]["MaMH"].ToString();
			txtGiaBan.ReadOnly = true;
			txtThanhTien.ReadOnly = true;
			thanhtienCu = double.Parse(dtCN.Rows[0]["ThanhTien"].ToString());
		}

		private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
		{
			CommonFunc.textBox_SoNguyen_KeyPress(sender, e);
		}

		private void txtGiaBan_KeyPress(object sender, KeyPressEventArgs e)
		{
			CommonFunc.textBox_SoThuc_KeyPress(sender, e);
		}

		private void cmbMaHang_SelectedValueChanged(object sender, EventArgs e)
		{
			DataTable dtGG = dtBase.ReadData("Select GiaBan from tMatHang  where  MaMH= N'" + cmbMaHang.SelectedValue + "'");
			if (dtGG.Rows.Count > 0)
			{
				txtGiaBan.Text = dtGG.Rows[0]["GiaBan"].ToString();

			}


		}

		private void btnBoQua_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void txtSoLuong_TextChanged(object sender, EventArgs e)
		{
			DataTable dtSLT = dtBase.ReadData("select SLTon from tMatHang where MaMH= N'" + MaH + "'");
			if (txtSoLuong.Text.Length > 0)
			{

				bool success1 = int.TryParse(txtSoLuong.Text, out int soLuong);
				bool success2 = double.TryParse(txtGiaBan.Text, out double giaBan);
				double tien;
				double thanhtien;

				if (success1 && success2)
				{
					tien = soLuong * giaBan;
					if (!string.IsNullOrEmpty(txtGiamGia.Text))
					{
						bool success3 = double.TryParse(txtGiamGia.Text, out double giamGia);
						thanhtien = tien - tien * giamGia / 100;
						txtThanhTien.Text = thanhtien.ToString();
					}
					else
					{
						thanhtien = tien;
						txtThanhTien.Text = thanhtien.ToString();
					}
				}
			}
		}

		private void btnCapNhat_Click(object sender, EventArgs e)
		{
			DataTable dtMH = dtBase.ReadData("select SLTon from tMatHang   where MaMH= N'" + MaH + "' ");
			DataTable dtHD = dtBase.ReadData("select TongTien, ThanhToan,GiamGia, MaKH from tHoaDonBan where MaHDB='" + MaHDB + "'");
			if (cmbMaHang.Text == "")
			{
				MessageBox.Show("Bạn không được để trống mặt hàng. Vui lòng chọn!");

			}
			else
			{
				if (txtSoLuong.Text == "")
				{
					MessageBox.Show("Bạn không được để trống số lượng mặt hàng.\n Vui lòng nhập!");
					txtSoLuong.Focus();
				}
				else
				{
					bool success1 = int.TryParse(txtSoLuong.Text, out int soLuongMoi);
					bool success3 = int.TryParse(txtGiamGia.Text, out int giamGiaMoi);
					bool success4 = double.TryParse(txtGiaBan.Text, out double giaBanMoi);
					double TongTienMoi = soLuongMoi * giaBanMoi;
					double ThanhTienMoi = TongTienMoi * (100 - giamGiaMoi) / 100;
					// xử lý, nếu thay đổi mặt hàng 
					if (cmbMaHang.SelectedValue.ToString() != MaH)
					{
						//tính lại số lượng tồn của mã cũ


						// số lượng tồn của mã mới
						DataTable dtMHmoi = dtBase.ReadData("select SLTon from tMatHang  where MaMH = N'" + cmbMaHang.SelectedValue + "' ");
						if (soLuongMoi > int.Parse(dtMHmoi.Rows[0]["SLTon"].ToString()))
						{
							MessageBox.Show("Số lượng của sản phẩm " + cmbMaHang.SelectedValue + " này này chỉ còn lại " + int.Parse(dtMH.Rows[0]["SLTon"].ToString()) + " !");
						}
						else
						{
							int soluongconCu = int.Parse(dtMH.Rows[0]["SLTon"].ToString()) + soluong;
							dtBase.ChangeData("update tMatHang set SLTon= '" + soluongconCu + "' where MaMH=N'" + MaH + "'");

							dtBase.ChangeData("delete tChiTietHDB where MaHDB= '" + MaHDB + "' and MaMH= N'" + MaH + "'");
							string sql = "insert into tChiTietHDB values ( ";
							sql += "'" + MaHDB + "',";
							sql += " N'" + cmbMaHang.SelectedValue + "',";
							sql += soLuongMoi + ",  '" + giaBanMoi + "', ";
							sql += ThanhTienMoi + ", " + giamGiaMoi + " )";
							int soluongM = int.Parse(dtMHmoi.Rows[0]["SLTon"].ToString()) - soLuongMoi;
							dtBase.ChangeData("update tMatHang set SLTon= '" + soluongM + "' where MaMH=N'" + MaH + "'");

							// tính lại tổng tiền
							double tongtien = double.Parse(dtHD.Rows[0]["TongTien"].ToString()) - soluong * GiaBanCu + TongTienMoi;
							//cập nhật thanh toán 
							double thanhtoan = double.Parse(dtHD.Rows[0]["ThanhToan"].ToString()) - thanhtienCu + ThanhTienMoi;
							// Cập nhật lại giảm giá
							double giamgia = tongtien - thanhtoan;

							dtBase.ChangeData("update tHoaDonBan set TongTien= " + tongtien + ", ThanhToan=" + thanhtoan + ", GiamGia=" + giamgia + " where MaHDB = '" + MaHDB + "'");
							dtBase.ChangeData(sql);
							this.Close();
						}

					}
					else
					{
						string sql = "update tChiTietHDB set SLBan= " + soLuongMoi + ", GiamGia=" + giamGiaMoi + ", ThanhTien= " + ThanhTienMoi + " " +
							"where MaHDB= '" + MaHDB + "' and MaMH= N'" + MaH + "'";

						//tính lại số lượng tồn
						if (soLuongMoi - soluong > int.Parse(dtMH.Rows[0]["SLTon"].ToString()))
						{
							MessageBox.Show("Số lượng của sản phẩm " + MaH + " này chỉ còn lại " + int.Parse(dtMH.Rows[0]["SLTon"].ToString()) + "!");
						}
						else
						{
							int soluongcon = int.Parse(dtMH.Rows[0]["SLTon"].ToString()) + soluong - soLuongMoi;
							dtBase.ChangeData("update tMatHang set SLTon= '" + soluongcon + "' where MaMH=N'" + MaH + "'");
							// tính lại tổng tiền
							double tongtien = double.Parse(dtHD.Rows[0]["TongTien"].ToString()) - soluong * GiaBanCu + TongTienMoi;
							//cập nhật thanh toán 
							double thanhtoan = double.Parse(dtHD.Rows[0]["ThanhToan"].ToString()) - thanhtienCu + ThanhTienMoi;
							// Cập nhật lại giảm giá
							double giamgia = tongtien - thanhtoan;

							dtBase.ChangeData("update tHoaDonBan set TongTien= " + tongtien + ", ThanhToan=" + thanhtoan + ", GiamGia=" + giamgia + " where MaHDB = '" + MaHDB + "'");
							dtBase.ChangeData(sql);
							this.Close();
						}


					}
				}
			}
		}
	}
}

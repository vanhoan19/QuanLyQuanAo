using QLQuanAo.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLQuanAo.Forms.HangHoa
{
	public partial class frmCapNhatHH : Form
	{
		Classes.DataProcesser dataProcesser = new Classes.DataProcesser();
		Classes.CommonFunc comFunc = new CommonFunc();
		string filePath = ""; // Đường dẫn ảnh
		string fileName = "";
		string destinationPath;
		public frmCapNhatHH()
		{
			InitializeComponent();
		}
		public frmCapNhatHH(string MaMH)
		{
			InitializeComponent();
			string sqlSelect = string.Format("select * from tMatHang where MaMH = N'{0}'", MaMH);
			DataTable dt = dataProcesser.ReadData(sqlSelect);
			txtMaMH.Text = MaMH;
			lblTenSP.Text = dt.Rows[0]["TenMH"].ToString() + " (" + dt.Rows[0]["DonVi"].ToString() + ")";

			// Fill Combobox
			comFunc.FillComboBox(cboTheLoai, dataProcesser.ReadData("select * from tTheLoai"), "TenTheLoai", "MaTheLoai");
			cboTheLoai.SelectedValue = dt.Rows[0]["MaTheLoai"].ToString();

			comFunc.FillComboBox(cboNCC, dataProcesser.ReadData("select * from tNhaCungCap"), "TenNCC", "MaNCC");
			cboNCC.SelectedValue = dt.Rows[0]["MaNCC"].ToString();

			// Ảnh
			try
			{
				fileName = dt.Rows[0]["Anh"].ToString();
				picAnhSP.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Images", "Hàng hóa", fileName));
			}
			catch { }

			// Màu, size 
			txtMau.Text = dt.Rows[0]["Mau"].ToString();
			txtSize.Text = dt.Rows[0]["Size"].ToString();

			// Số lượng tồn
			txtSLTon.Text = dt.Rows[0]["SLTon"].ToString();

			// Ghi chú
			txtGhiChu.Text = dt.Rows[0]["GhiChu"].ToString();

			// Giá bán, giá nhập
			float GiaBan = float.Parse(dt.Rows[0]["GiaBan"].ToString());
			txtGiaBan.Text = GiaBan.ToString("N0");
			float GiaNhap = float.Parse(dt.Rows[0]["GiaNhap"].ToString());
			txtGiaNhap.Text = GiaNhap.ToString("N0");

			var isDangBan = dt.Rows[0]["IsDangBan"].ToString();

			if (isDangBan == "True") rdoDangBan.Checked = true;
			else rdoNgungBan.Checked = true;
		}

		private void txtGiaBan_KeyPress(object sender, KeyPressEventArgs e)
		{
			comFunc.textBox_SoThuc_KeyPress(sender, e);
		}

		private void btnChonAnh_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Title = "Chọn ảnh sản phẩm";
			openFileDialog.Filter = "JPEG images|*.jpg|PNG images|*.png";
			openFileDialog.FilterIndex = 1;

			// Nếu người dùng chọn ảnh 
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				// Lấy đường dẫn đầy đủ của tệp tin đã chọn
				filePath = openFileDialog.FileName;

				// Hiển thị ảnh trong PictureBox
				picAnhSP.Image = Image.FromFile(filePath);

				// Cập nhật filName ảnh
				fileName = Path.GetFileName(filePath);

				destinationPath = Path.Combine(Application.StartupPath, "Images", "Hàng hóa", Path.GetFileName(filePath));
			}
		}


		private void btnExit_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnLuuSP_Click(object sender, EventArgs e)
		{
			// Kiểm tra dữ liệu
			if (txtMau.Text.Trim() == "")
			{
				MessageBox.Show("Bạn chưa nhập màu");
				return;
			}
			if (txtSize.Text.Trim() == "")
			{
				MessageBox.Show("Bạn chưa nhập size");
				return;
			}
			if (txtGiaBan.Text.Trim() == "")
			{
				MessageBox.Show("Bạn chưa nhập giá bán");
				return;
			}
			if (txtGiaNhap.Text.Trim() == "")
			{
				MessageBox.Show("Bạn chưa nhập giá nhập");
				return;
			}

			// Copy ảnh vào thư mục Hàng hóa
			if (fileName != "")
			{
				try
				{
					File.Copy(filePath, destinationPath);
				}
				catch
				{

				}
			}

			string sqlUpdate = string.Format("update tMatHang " +
				"set MaTheLoai = N'{0}', MaNCC = {1}, Mau = N'{2}', Size = N'{3}', " +
				"GiaBan = {4}, GiaNhap = {5}, Anh = N'{6}', GhiChu  = N'{7}', IsDangBan = {8} where " +
				"MaMH = N'{9}'", cboTheLoai.SelectedValue.ToString(), int.Parse(cboNCC.SelectedValue.ToString()),
				txtMau.Text.Trim(), txtSize.Text.Trim(), float.Parse(txtGiaBan.Text), float.Parse(txtGiaNhap.Text),
				fileName, txtGhiChu.Text, rdoDangBan.Checked == true ? 1 : 0, txtMaMH.Text);
			dataProcesser.ChangeData(sqlUpdate);
			this.Close();
		}
	}
}

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

namespace QLQuanAo.Forms.KhachHang
{
    public partial class frmCapNhatKH : Form
    {
        Classes.DataProcesser dataProcesser = new Classes.DataProcesser();
        Classes.CommonFunc comFunc = new CommonFunc();
        string filePath = ""; // Đường dẫn ảnh
        string fileName = "";
        string destinationPath;
        public bool isThemKH = false;
        public string MaKH = "";
        public string linkKH = "";
		public frmCapNhatKH()
        {
            InitializeComponent();
        }

        public frmCapNhatKH(string MaKH)
        {
            InitializeComponent();
            string sql = string.Format("SELECT MaKH, TenKH, SDT, GioiTinh, NgaySinh, DiaChi, GhiChu, Anh " +
            "from tKhachHang where MaKH = N'{0}'", MaKH);
            DataTable dt = dataProcesser.ReadData(sql);
            txtMaKH.Text = MaKH;
            txtTenKH.Text = dt.Rows[0][1].ToString();
            txtSDTKH.Text = dt.Rows[0][2].ToString();
            if (dt.Rows[0][3].ToString() == "True") rdoNam.Checked = true;
            else rdoNu.Checked = false;
            dateNgaySinh.Text = dt.Rows[0][4] == null ? "" : dt.Rows[0][4].ToString();
            txtDiaChiKH.Text = dt.Rows[0][5].ToString();
            txtGhiChuKH.Text = dt.Rows[0][6].ToString();
            try
            {
                fileName = dt.Rows[0][7].ToString();
                picAnh.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Images", "Khách hàng", fileName));
            }
            catch { }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Chọn ảnh khách hàng";
            openFileDialog.Filter = "JPEG images|*.jpg|PNG images|*.png";
            openFileDialog.FilterIndex = 1;

            // Nếu người dùng chọn ảnh 
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Lấy đường dẫn đầy đủ của tệp tin đã chọn
                filePath = openFileDialog.FileName;

                // Hiển thị ảnh trong PictureBox
                picAnh.Image = Image.FromFile(filePath);

                // Cập nhật filName ảnh
                fileName = Path.GetFileName(filePath);

                destinationPath = Path.Combine(Application.StartupPath, "Images", "Khách hàng", Path.GetFileName(filePath));
            }
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            if (txtMaKH.Text == "") this.Close();
        }

        private void btnLuuKH_Click(object sender, EventArgs e)
        {
            if (txtTenKH.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên khách hàng");
                return;
            }
            if (txtSDTKH.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập số điện thoại khách hàng");
                return;
            }


			linkKH = txtTenKH.Text + " - ..." + txtSDTKH.Text.Substring(txtSDTKH.Text.Length - 3) + " - MaKH: " + MaKH;
			isThemKH = true;

			// Nếu MaKH rỗng => form thêm mới khách hàng
			if (txtMaKH.Text == "")
            {
                DataTable dsachKH = dataProcesser.ReadData(string.Format("select * from tKhachHang where SDT = N'{0}'", txtSDTKH.Text.Trim()));
                if (dsachKH.Rows.Count > 0)
                {
                    MessageBox.Show("Số điện thoại đã được sử dụng");
                    return;
                }
                if (filePath != "")
                {
                    try
                    {
                        File.Copy(filePath, destinationPath);
                    }
                    catch
                    {

                    }
                }
                this.MaKH = comFunc.Sinhmatudong("tKhachHang", "KH", "MaKH");

				int gioiTinh = rdoNam.Checked ? 1 : 0;
                string sqlInsert = string.Format("INSERT INTO tKhachHang(MaKH, TenKH, SDT, GioiTinh, NgaySinh, DiaChi, Anh, GhiChu, MaNV, NgayTaoKH, TongBan) " +
					"values(N'{0}', N'{1}', N'{2}', {3}, '{4}', N'{5}', N'{6}', N'{7}', N'{8}', GETDATE(), 0)",
					MaKH, txtTenKH.Text.Trim(), txtSDTKH.Text.Trim(), gioiTinh,
                    dateNgaySinh.Text, txtDiaChiKH.Text.Trim(),
                    Path.GetFileName(filePath), txtGhiChuKH.Text, Classes.ConstVar.MaNV);
                dataProcesser.ChangeData(sqlInsert);
				this.Close();
			}
            else
            {
                DataTable dsachKH = dataProcesser.ReadData(string.Format("select * from tKhachHang where SDT = N'{0}'", txtSDTKH.Text.Trim()));
                if (dsachKH.Rows.Count > 1)
                {
                    MessageBox.Show("Số điện thoại đã được sử dụng");
                    return;
                }
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
                int gioiTinh = rdoNam.Checked ? 1 : 0;
                string sqlUpdate = string.Format("update tKhachHang " +
                    "set TenKH = N'{1}', SDT = N'{2}', GioiTinh = {3}, NgaySinh = N'{4}', " +
                    "DiaChi = N'{5}', Anh = N'{6}', GhiChu = N'{7}' " +
                    " where MaKH = N'{0}'",
                    txtMaKH.Text, txtTenKH.Text.Trim(), txtSDTKH.Text.Trim(), gioiTinh,
                    dateNgaySinh.Text, txtDiaChiKH.Text.Trim(),
                    fileName, txtGhiChuKH.Text);
                dataProcesser.ChangeData(sqlUpdate);
            }
        }

        private void txtSDTKH_KeyPress(object sender, KeyPressEventArgs e)
        {
            comFunc.textBox_SoNguyen_KeyPress(sender, e);
        }
    }
}

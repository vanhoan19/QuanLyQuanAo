using Guna.UI2.WinForms;
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
    public partial class frmThemHH : Form
    {
        Classes.DataProcesser dataProcesser = new Classes.DataProcesser();
        Classes.CommonFunc func = new Classes.CommonFunc();

        string[] fileAnhs = new string[7]; // lưu đường dẫn của ảnh
        Guna2TextBox[] txtMaus = new Guna2TextBox[7];  // các text box của màu
        Guna2PictureBox[] picAnhs = new Guna2PictureBox[7]; // Các picture box của màu tương ứng
        Guna2Button[] btnXoas = new Guna2Button[7]; // Các button xóa ảnh
        DataTable dt = new DataTable(); // lưu các chi tiết sản phẩm

        public frmThemHH()
        {
            InitializeComponent();
            for (int i = 1; i <= 6; i++)
            {
                txtMaus[i] = Controls.Find("txtMau" + i.ToString(), true).FirstOrDefault() as Guna2TextBox;
                picAnhs[i] = Controls.Find("picAnhSP" + i.ToString(), true).FirstOrDefault() as Guna2PictureBox;
                btnXoas[i] = Controls.Find("btnXoaAnh" + i.ToString(), true).FirstOrDefault() as Guna2Button;
            }

            // Thêm dữ liệu vào combobox Nhà Cung Cấp
            DataTable dtNCC = dataProcesser.ReadData("select * from tNhaCungCap");
            func.FillComboBox(cboNCC, dtNCC, "TenNCC", "MaNCC");
            cboNCC.SelectedIndex = 0;

			// Thêm dữ liệu vào combobox Thể loại
			DataTable dtTheLoai = dataProcesser.ReadData("select * from tTheLoai");
            func.FillComboBox(cboTheLoai, dtTheLoai, "TenTheLoai", "MaTheLoai");
			cboTheLoai.SelectedIndex = 0;

		}

        private void btnExit_Click(object sender, EventArgs e)
        {
            XacNhanThoat();
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            XacNhanThoat();
        }

        private void XacNhanThoat()
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnChiTietMH_Click(object sender, EventArgs e)
        {
            if (txtMaMH.Text == "")
            {
                MessageBox.Show("Bạn cần nhập mã hàng");
                return;
            }
            if (txtTenSP.Text == "")
            {
                MessageBox.Show("Bạn cần nhập tên hàng");
                return;
            }

            HashSet<string> cacSizes = new HashSet<string>(); // Lưu các size
            string[] cacSize = txtCacSize.Text.Split(',');
            foreach (string size in cacSize)
            {
                if (size.Trim() != "") cacSizes.Add(size.Trim());
            }
            SetDataHeader();
            
            // Giá bán và giá nhập
            float GiaBan = 0;
            float GiaNhap = 0;
            if (txtGiaBan.Text == "") GiaBan = 0;
            else GiaBan = float.Parse(txtGiaBan.Text);
            if (txtGiaNhap.Text == "") GiaNhap = 0;
            else GiaNhap = float.Parse(txtGiaNhap.Text);

            // Thêm dữ liệu vào datatable
            for (int i = 1; i <= 6; i++)
            {
                string mau = txtMaus[i].Text;
                if (mau != "")
                {
                    foreach (string size in cacSizes)
                    {
                        dt.Rows.Add(txtMaMH.Text + "." + mau + "." + size, 
                            txtTenSP.Text + " màu " + mau + " - " + size, cboTheLoai.SelectedValue, mau, size, 
                            cboNCC.SelectedValue, GiaBan, GiaNhap, fileAnhs[i], cboDonViTinh.SelectedItem);
                    }    
                }    
            }

            if (dt.Rows.Count > 0)
            {
                dgvChiTietSP.DataSource = dt;
                dgvChiTietSP.Columns["Tên hàng"].Visible = false;
                dgvChiTietSP.Columns["Mã thể loại"].Visible = false;
                dgvChiTietSP.Columns["Mã NCC"].Visible = false;
                dgvChiTietSP.Columns["Ảnh"].Visible = false;
                dgvChiTietSP.Columns["Đơn vị tính"].Visible = false;
                dgvChiTietSP.Columns["Màu sắc"].ReadOnly = true;
                dgvChiTietSP.Columns["Size"].ReadOnly = true;
            }    
        }

        private void picAnhSP_Click(object sender, EventArgs e)
        {
            Guna2PictureBox picAnhSP = sender as Guna2PictureBox;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Chọn ảnh sản phẩm ứng với màu";
            openFileDialog.Filter = "JPEG images|*.jpg|PNG images|*.png";
            openFileDialog.FilterIndex = 1;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                picAnhSP.Image = Image.FromFile(filePath);
                int index = int.Parse(picAnhSP.Name[picAnhSP.Name.Length - 1].ToString());
                btnXoas[index].Visible = true;
                fileAnhs[index] = filePath;
            }
        }

        private void btnXoaAnh_Click(object sender, EventArgs e)
        {
            Guna2Button btnXoaAnh = sender as Guna2Button;
            int index = int.Parse(btnXoaAnh.Name[btnXoaAnh.Name.Length - 1].ToString());
            picAnhs[index].Image = null;
            fileAnhs[index] = null;
            btnXoaAnh.Visible = false;
        }

        private void txtGiaNhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            func.textBox_SoThuc_KeyPress(sender, e);
        }

        private void txtGiaBan_KeyPress(object sender, KeyPressEventArgs e)
        {
            func.textBox_SoThuc_KeyPress(sender, e);
        }

        private void SetDataHeader()
        {
            dt = new DataTable();
            // Thêm các cột và datatable chi tiết sản phẩm
            dt.Columns.Add("Mã hàng", typeof(string));
            dt.Columns.Add("Tên hàng", typeof(string));
            dt.Columns.Add("Mã thể loại", typeof(string));
            dt.Columns.Add("Màu sắc", typeof(string));
            dt.Columns.Add("Size", typeof(string));
            dt.Columns.Add("Mã NCC", typeof(string));
            dt.Columns.Add("Giá bán", typeof(float));
            dt.Columns.Add("Giá nhập", typeof(float));
            dt.Columns.Add("Ảnh", typeof(string));
            dt.Columns.Add("Đơn vị tính", typeof(string));

        }

        private void btnLuuSP_Click(object sender, EventArgs e)
        {
            int soSPinserted = 0;
            foreach(DataGridViewRow row in dgvChiTietSP.Rows)
            {
                // Đặt biến cho các ô trong hàng
                string MaMH = row.Cells["Mã hàng"].Value.ToString();
                string TenMH = row.Cells["Tên hàng"].Value.ToString();
                string MaTheLoai = row.Cells["Mã thể loại"].Value.ToString();
                string MauSac = row.Cells["Màu sắc"].Value.ToString();
                string Size = row.Cells["Size"].Value.ToString();
                string MaNCC = row.Cells["Mã NCC"].Value.ToString();
                float GiaBan = float.Parse(row.Cells["Giá bán"].Value.ToString());
                float GiaNhap = float.Parse(row.Cells["Giá nhập"].Value.ToString());
                string Anh = row.Cells["Ảnh"].Value.ToString();
                if (Anh != string.Empty)
                {
                    string destinationPath = Path.Combine(Application.StartupPath, "Images", "Hàng hóa", Path.GetFileName(Anh)); 
                    try
                    {
                        File.Copy(Anh, destinationPath);
                    }
                    catch
                    {

                    }
                }    
                string DonViTinh = row.Cells["Đơn vị tính"].Value.ToString();

                // insert vào CSDL
                string sqlInsert = string.Format("INSERT INTO tMatHang(MaMH, TenMH, MaTheLoai, Mau, Size, " +
                    "MaNCC, GiaBan, GiaNhap, SLTon, Anh, DonVi, IsDangBan) " +
                    "values(N'{0}', N'{1}', N'{2}', N'{3}', N'{4}', N'{5}', {6}, {7}, 0, N'{8}', N'{9}', 1)",
                    MaMH, TenMH, MaTheLoai, MauSac, Size, MaNCC, GiaBan, GiaNhap, Path.GetFileName(Anh), DonViTinh);
                try
                {
                    dataProcesser.ChangeData(sqlInsert);
                    soSPinserted += 1;
                }
                catch
                {

                }
            }    
            MessageBox.Show("Có " + soSPinserted.ToString() + " mặt hàng đã được tạo");
            this.Close();
        }

		private void btnThemTheLoai_Click(object sender, EventArgs e)
		{
            Forms.TheLoai.frmTheLoai frmTheLoai = new TheLoai.frmTheLoai();
            frmTheLoai.ShowDialog();
            frmTheLoai = null;
			DataTable dtTheLoai = dataProcesser.ReadData("select * from tTheLoai");
			func.FillComboBox(cboTheLoai, dtTheLoai, "TenTheLoai", "MaTheLoai");
		}

		private void btnThemNCC_Click(object sender, EventArgs e)
		{
            Forms.NhaCungCap.frmCapNhatNCC frmmNCC = new NhaCungCap.frmCapNhatNCC();
            frmmNCC.ShowDialog();
            frmmNCC = null;
			// Thêm dữ liệu vào combobox Nhà Cung Cấp
			DataTable dtNCC = dataProcesser.ReadData("select * from tNhaCungCap");
			func.FillComboBox(cboNCC, dtNCC, "TenNCC", "MaNCC");
		}
	}
}

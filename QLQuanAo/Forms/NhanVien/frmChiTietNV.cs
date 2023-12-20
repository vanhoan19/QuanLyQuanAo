using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLQuanAo.Forms.NhanVien
{
    public partial class frmChiTietNV : Form
    {
        private Classes.DataProcesser dtBase= new Classes.DataProcesser();  
        Classes.CommonFunc commonFunc = new Classes.CommonFunc();
        private string MaNV;
        public frmChiTietNV(string MaNv)
        {
            this.MaNV=MaNv;
            InitializeComponent();
        }
        private const string DefaultFolderPath = "E:\\Lập trình trực quan C#\\QLQuanAo\\Images";
        private void frmChiTietNV_Load(object sender, EventArgs e)
        {
            XuLy();
        }
        private void XuLy()
        {
            string sql = "select * from tNhanVien where MaNV= '" + MaNV + "'";
            DataTable dtCTNV = dtBase.ReadData(sql);
            if (dtCTNV.Rows.Count > 0)
            {
                txtTenNV.Text = dtCTNV.Rows[0]["TenNV"].ToString();
                // giới tính
                if (string.Compare(dtCTNV.Rows[0]["GioiTinh"].ToString(), "true", true) == 0)
                {
                    rdoNam.Checked = true;
                }
                else
                {
                    rdoNu.Checked = true;
                }
                dtNgaySinh.Value = DateTime.Parse(dtCTNV.Rows[0]["NgaySinh"].ToString());
                dtNgayLV.Value = DateTime.Parse(dtCTNV.Rows[0]["NgayBD"].ToString());
                // chức vụ
                txtSDT.Text = dtCTNV.Rows[0]["SDT"].ToString();
                if (string.Compare(dtCTNV.Rows[0]["Role"].ToString(), "true", true) == 0)
                {
                    rdoQL.Checked = true;
                }
                else
                {
                    rdoNV.Checked = true;
                }
                
                if (string.Compare(dtCTNV.Rows[0]["IsDangLam"].ToString(), "true", true) == 0)
                {
                    rdoDangLam.Checked = true;
                }
                else
                {
                    rdoNghiLam.Checked = true;
                }
                txtTenTK.Text = dtCTNV.Rows[0]["UserName"].ToString();
                txtMatKhau.Text = dtCTNV.Rows[0]["PassWord"].ToString();
                // xử lý đẩy Ảnh
                string tenfileAnh = dtCTNV.Rows[0]["Anh"].ToString();
                string targetPath = Path.Combine(DefaultFolderPath, "NhanVien", tenfileAnh);
                if (File.Exists(targetPath))
                {
                    ptbAnh.Image = Image.FromFile(targetPath);
                }
                else
                {
                    ptbAnh.Image = null;
                }

            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (txtTenNV.Text == "")
            {
                MessageBox.Show("Bạn phải nhập tên nhân viên!");
                txtTenNV.Focus();
            }
            else
            {
                if (rdoNam.Checked == false && rdoNu.Checked == false)
                {
                    MessageBox.Show("Bạn phải chọn giới tính cho nhân viên!");
                }
                else
                {
                    if((dtNgayLV.Value.Year- dtNgaySinh.Value.Year)< 18)
                    {
                        MessageBox.Show("Người dùng phải đủ 18 tuổi trở lên mới được làm việc", "Lỗi");
                    }
                    else
                    {
                        if (rdoQL.Checked == false & rdoNV.Checked == false)
                        {
                            MessageBox.Show("Bạn phải chọn chức vụ!");
                        }
                        else
                        {
                            if (txtSDT.Text == "")
                            {
                                MessageBox.Show("Bạn phải nhập số điện thoại!");
                                txtSDT.Focus();
                            }
                            else
                            {
                                int gioitinh, chucvu, trangthai;
                                gioitinh = rdoNam.Checked ? 1 : 0;
                                chucvu = rdoQL.Checked ? 1 : 0;
                                trangthai = rdoDangLam.Checked ? 1 : 0;
                                string ngaysinh = dtNgaySinh.Value.ToString("yyyy-MM-dd");
                                string ngaylamviec = DateTime.Now.ToString("yyyy-MM-dd");
                                string password = CalculateSHA256Hash(txtMatKhau.Text);
								string sql = "update tNhanVien set ";
                                sql += "TenNV= N'" + txtTenNV.Text + "',";
                                sql += "GioiTinh = '" + gioitinh + "',";
                                sql += "NgaySinh = '" + ngaysinh + "',";
                                sql += "NgayBD= '" + ngaylamviec + "',";
                                sql += "SDT='" + txtSDT.Text + "',";
                                sql += "UserName= '" + txtTenTK.Text + "',";
                                sql += "PassWord= '" + password + "',";
                                sql += "Role='" + chucvu + "',";
                                sql += "IsDangLam='" + trangthai + "',";
                                sql += "Anh='" + LuuAnh + "' ";
                                sql += "Where MaNV= '" + MaNV + "'";
                                dtBase.ChangeData(sql);
                                this.Close();
                            }
                        }
                    }
                   
                }
            }
            
        }
        string LuuAnh;
        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            string[] image;
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.Filter = "JPEG images|*.jpg|Bitmap images|*.bmp|All Files|*.*";
            openfile.FilterIndex = 1;
            openfile.InitialDirectory = DefaultFolderPath;
            if (openfile.ShowDialog() == DialogResult.OK)
            {

                ptbAnh.Image = Image.FromFile(openfile.FileName);
                image = openfile.FileName.ToString().Split('\\');
                LuuAnh = image[image.Length - 1];
            }
        }
        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) )
            {
                e.Handled = true;
                MessageBox.Show("Số điện thoại chỉ là số nguyên !","Lỗi");
            }

            if (txtSDT.Text.Length+1 >10)
            {
                e.Handled = true;
                MessageBox.Show("Số điện thoạicó độ dài là 10!", "Lỗi");
            }



        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

		public static string CalculateSHA256Hash(string input)
		{
			// Chuyển đổi chuỗi đầu vào thành mảng byte
			byte[] inputBytes = Encoding.UTF8.GetBytes(input);

			// Tạo đối tượng MD5
			using (SHA256 md5 = SHA256.Create())
			{
				// Mã hóa mảng byte thành mảng byte mã hóa MD5
				byte[] hashBytes = md5.ComputeHash(inputBytes);

				// Chuyển đổi mảng byte thành chuỗi hexa
				StringBuilder str = new StringBuilder();
				for (int i = 0; i < hashBytes.Length; i++)
				{
					str.Append(hashBytes[i].ToString("x2")); // x2: viết thường các kí tự mã hóa
				}
				return str.ToString();
			}
		}

	}
}

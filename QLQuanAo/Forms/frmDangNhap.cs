using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace QLQuanAo.Forms
{
    public partial class frmDangNhap : Form
    {
        Classes.DataProcesser dtBase = new Classes.DataProcesser();
        public frmDangNhap()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

		}

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text.Trim() == "")
            {
                MessageBox.Show("Bạn phải nhập tên tài khoản!");
                txtUserName.Focus();
                return;
            }
            if (txtPassword.Text.Trim() == "")
            {
                MessageBox.Show("Bạn phải nhập mật khẩu!");
                txtPassword.Focus();
                return;
            }
            string userName = txtUserName.Text;
            string passWord = CalculateSHA256Hash(txtPassword.Text);

            DataTable dt = new DataTable();
            string sql =
                string.Format("select * from tNhanVien where " +
                "UserName=N'{0}' and PassWord=N'{1}' and IsDangLam=1", userName, passWord);
            //MessageBox.Show(sql);
            dt = dtBase.ReadData(sql);
            if (dt.Rows.Count > 0)
            {
                // MessageBox.Show("Đăng nhập thành công!");
                Classes.ConstVar.MaNV = dt.Rows[0]["MaNV"].ToString();
                Classes.ConstVar.TenNV = dt.Rows[0]["TenNV"].ToString();
                Classes.ConstVar.Role = bool.Parse(dt.Rows[0]["Role"].ToString());
				this.Hide();
                Forms.BanHang.frmBanHang frmBanHang = new BanHang.frmBanHang();
                frmBanHang.Show();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!");
                Reset();
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Nhấn Enter trong TextBox PassWỏd sẽ kích hoạt nút btnLogin
                btnLogin.PerformClick();
            }
        }

        void Reset()
        {
            txtUserName.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtUserName.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Reset();
        }

        // Mã hóa mật khẩu
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
                for(int i = 0; i < hashBytes.Length; i++)
                {
                    str.Append(hashBytes[i].ToString("x2")); // x2: viết thường các kí tự mã hóa
                }
                return str.ToString();
			}
		}

	}
}

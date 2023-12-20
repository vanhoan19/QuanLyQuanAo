using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLQuanAo.Forms.NhanVien
{
    public partial class frmThemNV : Form
    {
        Classes.DataProcesser dtBase= new Classes.DataProcesser();
        Classes.CommonFunc cmF= new Classes.CommonFunc();
        public frmThemNV()
        {
            InitializeComponent();
        }

       

        private void frmThemNV_Load(object sender, EventArgs e)
        {
            txtTenNV.Text = "";
            txtSDT.Text = "";
        }
        string LuuAnh;
        private const string DefaultFolderPath = "E:\\Lập trình trực quan C#\\QLQuanAo\\Images";
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

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtTenNV.Text == "")
            {
                MessageBox.Show("Bạn phải nhập tên nhân viên!");
                txtTenNV.Focus();
            }
            else
            {
                if(rdoNam.Checked==false && rdoNu.Checked == false)
                {
                    MessageBox.Show("Bạn phải chọn giới tính cho nhân viên!");
                }
                else
                {
                    if ((DateTime.Today.Year - dtNgaySinh.Value.Year) < 18)
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
                                string MaNV = cmF.Sinhmatudong("tNhanVien", "NV", "MaNV");
                                int gioitinh, chucvu, trangthai = 1;
                                gioitinh = rdoNam.Checked ? 1 : 0;
                                chucvu = rdoQL.Checked ? 1 : 0;
                                string ngaysinh = dtNgaySinh.Value.ToString("yyyy-MM-dd");
                                string ngaylamviec = DateTime.Now.ToString("yyyy-MM-dd");
                                string sql = "insert into tNhanVien values( '"+MaNV+"',";
                                sql += "N'" + txtTenNV.Text + "', '" + gioitinh + "', '" + ngaysinh + "','" + ngaylamviec + "','" + txtSDT.Text + "','" + null + "','" + null + "','" + chucvu + "','" + trangthai + "','" + LuuAnh + "')";
                                dtBase.ChangeData(sql);
                                this.Close();
                            }
                        }
                    }
                }
            }
            
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có muốn thoát không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

      

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Số điện thoại chỉ là số!");
            }
            if(txtSDT.Text.Length +1 > 10)
            {
                e.Handled=true;
                MessageBox.Show("Độ dài của số điện thoại là 10!");
            }
        }
    }
}

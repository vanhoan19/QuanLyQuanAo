using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLQuanAo.Forms
{
    public partial class frmQuanLy : Form
    {
        Classes.CommonFunc commonFunc = new Classes.CommonFunc();
        public frmQuanLy()
        {
            InitializeComponent();
			foreach (ToolStripMenuItem menuItem in menuStripQuanLi.Items)
			{
				menuItem.Click += MenuStripItem_Click;
			}

		}

        private void frmBanHang_Load(object sender, EventArgs e)
        {
            btnTaiKhoan.Text = Classes.ConstVar.TenNV;
            commonFunc.ResizeButton(btnTaiKhoan, 45);
        }

        private void khachHangToolStripMenuItem_Click(object sender, EventArgs e)
        {
			DisplayForm(new KhachHang.frmDanhMucKH(), true);
		}

        private void btnBanHang_Click(object sender, EventArgs e)
        {
            this.Close();
        }

		private void hangHoaToolStripMenuItem_Click(object sender, EventArgs e)
		{
			DisplayForm(new HangHoa.frmDanhMucHH(), true);
		}

		private void nhaCungCapToolStripMenuItem_Click(object sender, EventArgs e)
		{
            DisplayForm(new NhaCungCap.frmDanhMucNCC(), true);
		}

        private void DisplayForm(Form form, bool role)
        {
			if (role == true)
			{
				conChildQuanLy.Controls.Clear();
				form.TopLevel = false;
				conChildQuanLy.Controls.Add(form);
				form.Show();
			}
		}

        private void MenuStripItem_Click(object sender, EventArgs e)
        {
			ToolStripMenuItem clickedMenuItem = sender as ToolStripMenuItem;
            clickedMenuItem.BackColor = Color.CornflowerBlue;

			// Đặt màu nền của các ToolStripMenuItem khác về màu ban đầu
			foreach (ToolStripMenuItem menuItem in menuStripQuanLi.Items)
			{
				if (menuItem != clickedMenuItem)
				{
					menuItem.BackColor = Color.FromArgb(185, 243, 252); // Màu ban đầu của ToolStripMenuItem
				}
			}

		}

		private void nhanVienToolStripMenuItem_Click(object sender, EventArgs e)
		{
			DisplayForm(new NhanVien.frmNhanVien(), Classes.ConstVar.Role);

		}

		private void hoaDonToolStripMenuItem_Click(object sender, EventArgs e)
		{
			DisplayForm(new Forms.HoaDonBan.frmHoaDonBan(), true);
		}

		private void HDNToolStripMenuItem_Click(object sender, EventArgs e)
		{
			DisplayForm(new Forms.HoaDonNhap.frmHoaDonNhap(), Classes.ConstVar.Role);
		}

		private void doanhThuToolStripMenuItem_Click(object sender, EventArgs e)
		{
			DisplayForm(new Forms.DoanhThu.frmDoanhThu(), Classes.ConstVar.Role);
		}

		private void frmQuanLy_KeyDown(object sender, KeyEventArgs e)
		{
			commonFunc.exit_Aplication(sender, e);
		}
	}
}

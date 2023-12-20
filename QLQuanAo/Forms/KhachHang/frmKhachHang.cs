using QLQuanAo.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows.Forms;

namespace QLQuanAo.Forms.KhachHang
{
	public partial class frmKhachHang : Form
	{
		Classes.CommonFunc commonFunc = new Classes.CommonFunc();
		Classes.DataProcesser dataProcesser = new Classes.DataProcesser();
		public string MaKH;
		public string linkKH = "";
		public bool isThemKH = false;
		public frmKhachHang()
		{
			InitializeComponent();
		}

		public frmKhachHang(string MaKH)
		{
			InitializeComponent();
			this.MaKH = MaKH;
			string sql = string.Format("SELECT * " +
			"from tKhachHang where MaKH = N'{0}'", MaKH);
			DataTable dt = dataProcesser.ReadData(sql);

			lblTongTien.Text = dt.Rows[0]["TongBan"].ToString();
			lblTenKH.Text = dt.Rows[0]["TenKH"].ToString() + " - " + dt.Rows[0]["MaKH"].ToString();
			thongTinToolStripMenuItem.PerformClick();
		}

		private void btnExit_Click(object sender, EventArgs e)
		{
			if (thongTinToolStripMenuItem.ForeColor == Color.FromArgb(100, 88, 255))
			{
				frmCapNhatKH control = conKH.Controls[0] as frmCapNhatKH;
				if (control.isThemKH == true)
				{
					this.isThemKH = true;
					this.linkKH = control.linkKH;
				}
			}
			this.Close();
		}

		private void thongTinToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (thongTinToolStripMenuItem.ForeColor != Color.FromArgb(100, 88, 255))
			{
				thongTinToolStripMenuItem.ForeColor = Color.FromArgb(100, 88, 255);
				lichSuToolStripMenuItem.ForeColor = Color.Black;
				conKH.Controls.Clear();
				Forms.KhachHang.frmCapNhatKH frmThongTin = new frmCapNhatKH(MaKH);
				frmThongTin.FormBorderStyle = FormBorderStyle.None;
				frmThongTin.TopLevel = false;
				conKH.Controls.Add(frmThongTin);
				frmThongTin.Show();
			}
		}

		private void lichSuToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (thongTinToolStripMenuItem.ForeColor != Color.Black)
			{
				thongTinToolStripMenuItem.ForeColor = Color.Black;
				lichSuToolStripMenuItem.ForeColor = Color.FromArgb(100, 88, 255);
				frmCapNhatKH control = conKH.Controls[0] as frmCapNhatKH;
				if (control.isThemKH == true)
				{
					this.isThemKH = true;
					this.linkKH = control.linkKH;
				}
				conKH.Controls.Clear();
				Forms.KhachHang.frmLichSuKH frmLichSuKH = new frmLichSuKH(MaKH);
				frmLichSuKH.TopLevel = false;
				conKH.Controls.Add(frmLichSuKH);
				frmLichSuKH.Show();
			}	
		}

		private void frmKhachHang_Load(object sender, EventArgs e)
		{

		}
	}
}

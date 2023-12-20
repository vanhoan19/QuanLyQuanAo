using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLQuanAo.Forms.NhaCungCap
{
	public partial class frmCapNhatNCC : Form
	{
		Classes.DataProcesser dataProcesser = new Classes.DataProcesser();
		Classes.CommonFunc func = new Classes.CommonFunc();
		public frmCapNhatNCC()
		{
			InitializeComponent();
		}

		public frmCapNhatNCC(string MaNCC)
		{
			InitializeComponent();
			txtMaNCC.Text = MaNCC;
			string sqlSelect = string.Format("select * from tNhaCungCap where MaNCC = N'{0}'", MaNCC);
			DataTable dt = dataProcesser.ReadData(sqlSelect);
			txtTenNCC.Text = dt.Rows[0]["TenNCC"].ToString();
			txtSDT.Text = dt.Rows[0]["SDT"].ToString();
			txtDiaChi.Text = dt.Rows[0]["DiaChi"].ToString();
			txtGhiChu.Text = dt.Rows[0]["GhiChu"].ToString();
		}

		private void btnBoQua_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnExit_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnLuuSP_Click(object sender, EventArgs e)
		{
			string TenNCC = txtTenNCC.Text.Trim();
			string SDT = txtSDT.Text.Trim();
			string DiaChi = txtDiaChi.Text.Trim();
			string GhiChu = txtGhiChu.Text.Trim();
			if (TenNCC == "")
			{
				MessageBox.Show("Bạn chưa nhập tên nhà cung cấp");
				return;
			}
			if (SDT == "")
			{
				MessageBox.Show("Bạn chưa nhập số điện thoại nhà cung cấp");
				return;
			}
			string sqlChange;
			if (txtMaNCC.Text == "")
			{
				// Insert
				string MaNCC = func.Sinhmatudong("tNhaCungCap", "NCC", "MaNCC");
				sqlChange = string.Format("INSERT INTO tNhaCungCap(MaNCC, TenNCC, SDT, DiaChi, GhiChu) " +
					"values(N'{0}', N'{1}', N'{2}', N'{3}', N'{4}')", MaNCC, TenNCC, SDT, DiaChi, GhiChu);
			}
			else
			{
				// UPDATE
				sqlChange = string.Format("UPDATE tNhaCungCap set TenNCC = N'{0}', SDT = N'{1}', " +
					"DiaChi = N'{2}', GhiChu = N'{3}' where MaNCC = N'{4}'", TenNCC, SDT, DiaChi, GhiChu, txtMaNCC.Text);
			}
			dataProcesser.ChangeData(sqlChange);
			this.Close();
		}
	}
}

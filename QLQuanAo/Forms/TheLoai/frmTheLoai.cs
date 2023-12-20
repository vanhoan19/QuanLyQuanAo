using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLQuanAo.Forms.TheLoai
{
	public partial class frmTheLoai : Form
	{
		Classes.CommonFunc commonFunc = new Classes.CommonFunc();
		Classes.DataProcesser dataProcesser = new Classes.DataProcesser();
		public frmTheLoai()
		{
			InitializeComponent();
		}

		private void btnBoQua_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnExit_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnLuu_Click(object sender, EventArgs e)
		{
			if (txtTheLoai.Text.Trim() != "")
			{
				string MaTheLoai = commonFunc.Sinhmatudong("tTheLoai", "TL", "MaTheLoai");
				string sqlInsert = string.Format("insert into tTheLoai values(N'{0}', N'{1}')", MaTheLoai, txtTheLoai.Text.Trim());
				dataProcesser.ChangeData(sqlInsert);
				this.Close();
			}
		}
	}
}

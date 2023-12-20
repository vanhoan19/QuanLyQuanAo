using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLQuanAo.Classes
{
    public class CommonFunc
    {
        public void FillComboBox(ComboBox cbo, DataTable dt, string displayName, string valueMemnber) 
        { 
            cbo.DisplayMember = displayName;
            cbo.ValueMember = valueMemnber;
            cbo.DataSource = dt;
        }
        public void textBox_SoThuc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; // Hủy bỏ ký tự không phải số hoặc dấu chấm thập phân
            }

            // Chỉ cho phép một dấu chấm thập phân
            Guna2TextBox textBox = sender as Guna2TextBox;
            if (e.KeyChar == '.' && textBox.Text.Contains('.'))
            {
                e.Handled = true; // Hủy bỏ ký tự dấu chấm thập phân nếu đã tồn tại một dấu chấm thập phân
            }
        }

        public void textBox_SoNguyen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Hủy bỏ ký tự không phải số
            }
        }
        public void ResizeButton(Guna2Button button, int distance)
        {
            Size textSize = TextRenderer.MeasureText(button.Text, button.Font);
            button.Width = textSize.Width + distance;
        }

        // Tính số trang
        public int CalculateTotalPages(string tableName, string sqlCondition, int PgSize)
        {
            int rowCount = new Classes.DataProcesser().ReadData("select * from " + tableName + " " + sqlCondition).Rows.Count;
            int TotalPage = rowCount / PgSize;
            // if any row left after calculated pages, add one more page 
            if (rowCount % PgSize > 0)
                TotalPage += 1;
            return TotalPage;
        }

        public DataTable GetCurrentRecords(int page, int PgSize, string tableName, string sqlCondition, string colSelect, string orderByName)
        {
            string sqlSelect;
            if (page == 1)
            {
                //sqlSelect = "select TOP " + PgSize + " * from tKhachHang order by MaKH DESC";
                sqlSelect = string.Format("select top {0} * from {1} {2} order by {3} DESC", PgSize, tableName, sqlCondition, orderByName);
                
            }
            else
            {
                int PreviousPageOffSet = (page - 1) * PgSize;
                //sqlSelect = "select TOP " + PgSize + " * from tKhachHang " +
                //    "where MaKH not in (SELECT TOP " + PreviousPageOffSet + " MaKH from tKhachHang order by MaKH DESC) " +
                //    "order by MaKH DESC";
                if (sqlCondition.Trim() == "")
                    sqlSelect = string.Format("select top {0} * from {1} {2} where {3} not in " +
                    "(select TOP {4} {3} from {1} {2} order by {5} DESC) order by {5} DESC", PgSize, tableName, sqlCondition, colSelect, PreviousPageOffSet, orderByName);
                else sqlSelect = string.Format("select top {0} * from {1} {2} and {3} not in " +
                    "(select TOP {4} {3} from {1} {2} order by {5} DESC) order by {5} DESC", PgSize, tableName, sqlCondition, colSelect, PreviousPageOffSet, orderByName);
            }
            DataTable dt = new Classes.DataProcesser().ReadData(sqlSelect);
            return dt;
        }

        // sinh mã tự động
		public string Sinhmatudong(string tenBang, string mabatdau, string TruongMa)
		{
			int id = 1;
			bool dung = false;
			string ma = "";
			DataTable dt = new DataTable();
			while (dung == false)
			{
				int len = mabatdau.Length + id.ToString().Length;

				if (len < 8) ma = mabatdau + new string('0', 8 - len) + id.ToString();
				else ma = mabatdau + id.ToString();
				dt = new Classes.DataProcesser().ReadData("select * from " + tenBang + " where " + TruongMa + "= N'" + ma + "'");
				if (dt.Rows.Count == 0)
				{
					dung = true;
				}
				else
				{
					id++;
					dung = false;
				}
			}
			return ma;
		}

		public void exit_Aplication(object sender, KeyEventArgs e)
		{
			if (e.Control && e.KeyCode == Keys.E)
			{
				if (MessageBox.Show("Bạn có chắc chắn muốn đóng ứng dụng không", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					Environment.Exit(0);
				}
			}
		}
	}
}

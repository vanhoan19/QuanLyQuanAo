using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace QLQuanAo.Forms.HoaDonNhap
{
    public partial class frmChiTietHDN : Form
    {
        Classes.DataProcesser dtBase= new Classes.DataProcesser();
        String MaPN;
        public frmChiTietHDN(string MaPN)
        {
            this.MaPN = MaPN;
            InitializeComponent();
        }

        private void frmChiTietHDN_Load(object sender, EventArgs e)
        {
            DataTable dtCTHDB = dtBase.ReadData("select * from tChiTietPN where MaPN= '" + MaPN + "'");
            dgvChiTietPN.DataSource = dtCTHDB;
            setDgvChiTietPhieuNhap();
            XuLyThongTin();
            
        }
        private void XuLyThongTin()
        {

            string sql = "select * from tPhieuNhap where MaPN='" + MaPN + "'";
            DataTable dtTT = dtBase.ReadData(sql);

            DataTable NV = new DataTable();
            DataTable KH = new DataTable();
            if (dtTT.Rows.Count > 0)
            {
                lblMaPN.Text = dtTT.Rows[0]["MaPN"].ToString();
                string MaNV = dtTT.Rows[0]["MaNV"].ToString();
                NV = dtBase.ReadData("select TenNV from tNhanVien where MaNV ='" + MaNV + "'");
                llblNhanVien.Text = NV.Rows[0]["TenNV"].ToString();
                
                lblNgayNhap.Text = DateTime.Parse(dtTT.Rows[0]["NgayNhap"].ToString()).ToString("dd/MM/yyyy");
                lblTongTien.Text = dtTT.Rows[0]["TongTien"].ToString();
                lblGiamGia.Text = dtTT.Rows[0]["GiamGia"].ToString();
                lblThanhToan.Text = dtTT.Rows[0]["ThanhToan"].ToString();
                int phuongthuc = dtTT.Rows[0]["PhuongThucTT"].ToString() == "True" ? 1 : 0;
                if (phuongthuc == 1)
                {
                    lblPhuongThuc.Text = "Chuyển khoản";
                }
                else
                {
                    lblPhuongThuc.Text = "Tiền mặt";
                }

            }

        }

        private void btnXuatPN_Click(object sender, EventArgs e)
        {
            SaveFileDialog file = new SaveFileDialog();
            Excel.Application exApp = new Excel.Application();
            Excel.Workbook exBook = exApp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            Excel.Worksheet exSheet = (Excel.Worksheet)exBook.Worksheets[1];
            Excel.Range tenTruong = (Excel.Range)exSheet.Cells[1, 1];
            //Đưa dữ liệu vào Excel
            tenTruong.Range["A1:B1"].MergeCells = true;
            tenTruong.Range["A1:B1"].Font.Size = 24;
            tenTruong.Range["A1:B1"].Font.FontStyle = FontStyle.Bold;
            tenTruong.Range["A1"].Value = "HH Boutique";

            tenTruong.Range["A2:F2"].MergeCells = true;
            tenTruong.Range["A2:F2"].Font.Size = 20;
            tenTruong.Range["A2:F2"].Font.FontStyle = FontStyle.Bold;
            tenTruong.Range["A2"].Value = "Địa chỉ: Chung cư Gemek 2, An Khánh, Hoài Đức,Hà Nội";
            tenTruong.Range["A3:C3"].MergeCells = true;
            tenTruong.Range["A3:C3"].Font.Size = 20;
            tenTruong.Range["A3:C3"].Font.FontStyle = FontStyle.Bold;
            tenTruong.Range["A3"].Value = "Điện thoại: 0337629441";
            // tiêu đề
            tenTruong.Range["C5:F5"].MergeCells = true;
            tenTruong.Range["C5:F5"].Font.Size = 30;
            tenTruong.Range["C5:F5"].Font.FontStyle = FontStyle.Bold;
            tenTruong.Range["C5"].Value = "Phiếu Nhập";
            // dữ liệu
            tenTruong.Range["A7"].Value = "Mã phiếu nhập : " + lblMaPN.Text;
            string sql = "select * from tPhieuNhap where MaPN='" + MaPN + "'";
            DataTable dtTT = dtBase.ReadData(sql);
           
            tenTruong.Range["A8"].Value = "Ngày nhập: " + lblNgayNhap.Text;
            // thong tin riênhg
            tenTruong.Range["A9"].Value = "Mã hàng";
            tenTruong.Range["B9"].Value = "Số lượng";
            tenTruong.Range["C9"].Value = "Giá nhập";
           
            tenTruong.Range["A9:C9"].ColumnWidth = new int[] { 10, 8, 8, };
            int hang = 11;
            for (int i = 0; i < dgvChiTietPN.Rows.Count - 1; i++)
            {
                hang++;
                tenTruong.Range["A" + hang.ToString()].Value = dgvChiTietPN.Rows[i].Cells[1].Value.ToString();
                tenTruong.Range["B" + hang.ToString()].Value = dgvChiTietPN.Rows[i].Cells[2].Value.ToString();
                tenTruong.Range["C" + hang.ToString()].Value = dgvChiTietPN.Rows[i].Cells[3].Value.ToString();
                
            }
            tenTruong.Range["B" + (hang + 1)].Value = "Phương thức thanh toán : " + lblPhuongThuc.Text;
            tenTruong.Range["B" + (hang + 2)].Value = "Tổng tiền : " + lblTongTien.Text;
            tenTruong.Range["B" + (hang + 3)].Value = "Giảm giá : " + lblGiamGia.Text;
            tenTruong.Range["B" + (hang + 4)].Value = "Thanh toán : " + lblThanhToan.Text;
            tenTruong.Range["B" + (hang + 5)].Value = "Nhân viên  : " + llblNhanVien.Text;

            exSheet.Name = "HoaDonNhap";
            exBook.Activate();
            if (file.ShowDialog() == DialogResult.OK)
                exBook.SaveAs(file.FileName.ToString());
            exApp.Quit();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void setDgvChiTietPhieuNhap()
        {
            dgvChiTietPN.Columns[0].HeaderText = "Mã phiếu nhập";
            dgvChiTietPN.Columns[1].HeaderText = "Mã hàng";
            dgvChiTietPN.Columns[2].HeaderText = "Số lượng";
            dgvChiTietPN.Columns[3].HeaderText = "Giá nhập";

            this.dgvChiTietPN.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);
            dgvChiTietPN.Columns[1].Width = 150;

        }

       




    }
}

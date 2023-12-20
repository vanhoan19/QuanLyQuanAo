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

namespace QLQuanAo.Forms.NhanVien
{
    public partial class frmNhanVien : Form
    {
        Classes.DataProcesser dtBase= new Classes.DataProcesser();
        public frmNhanVien()
        {
            InitializeComponent();
        }

        public void frmNhanVien_Load(object sender, EventArgs e)
        {
            string sql = "select tNhanVien.MaNV, TenNV,iif(GioiTinh=0,N'Nữ',N'Nam'), NgaySinh,NgayBD,SDT,iif(Role=1,N'Quản lý',N'Nhân Viên'), Anh, sum(TongTien) " +
                "from tNhanVien left join tHoaDonBan on tNhanVien.MaNV= tHoaDonBan.MaNV" +
                " group by tNhanVien.MaNV, TenNV,iif(GioiTinh=0,N'Nữ',N'Nam'), NgaySinh,NgayBD,SDT,iif(Role=1,N'Quản lý',N'Nhân Viên'), Anh ";
            DataTable  dtNV= dtBase.ReadData(sql);
            dgvNhanVien.DataSource = dtNV;
            setDgvNhanVien();
            
        }
        private void setDgvNhanVien()
        {
            
            dgvNhanVien.Columns[0].HeaderText = "Mã NV";
            dgvNhanVien.Columns[1].HeaderText = "Tên nhân viên";
            dgvNhanVien.Columns[2].HeaderText = "Giới tính";
            dgvNhanVien.Columns[3].HeaderText = "Ngày sinh";
            dgvNhanVien.Columns[4].HeaderText = "Ngày làm";
            dgvNhanVien.Columns[5].HeaderText = "Điện thoại";
            dgvNhanVien.Columns[6].HeaderText = "Chức vụ";
            dgvNhanVien.Columns[7].HeaderText = "Ảnh";
            dgvNhanVien.Columns[8].HeaderText = "Tổng bán";
            this.dgvNhanVien.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);
            dgvNhanVien.Columns[0].Width = 60;
            dgvNhanVien.Columns[1].Width = 140;
            dgvNhanVien.Columns[2].Width = 70;
            dgvNhanVien.Columns[7].Width = 60;
        }

        private void btnThemNV_Click(object sender, EventArgs e)
        {

            frmThemNV frm = new frmThemNV();
            frm.ShowDialog();
            frmNhanVien_Load(sender, e);
            
        }

        private void dgvNhanVien_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string MaNV= dgvNhanVien.CurrentRow.Cells[0].Value.ToString();
            frmChiTietNV frm = new frmChiTietNV(MaNV);
            frm.ShowDialog();
            frmNhanVien_Load(sender, e);
          
        }

        private void btnCapNhapNV_Click(object sender, EventArgs e)
        {
            string MaNV = dgvNhanVien.CurrentRow.Cells[0].Value.ToString();
            frmChiTietNV frm = new frmChiTietNV(MaNV);
            frm.ShowDialog();
            frmNhanVien_Load(sender, e);
        }

        
       

        private void txtTimNhanVien_TextChanged(object sender, EventArgs e)
        {
            string timkiem =  txtTimNhanVien.Text ;
            string  sql = String.Format("select tNhanVien.MaNV, TenNV,iif(GioiTinh=0,N'Nữ',N'Nam'), NgaySinh,NgayBD,SDT,iif(Role=1,N'Quản lý',N'Nhân Viên'), Anh, sum(TongTien) " +
                "from tNhanVien left join tHoaDonBan on tNhanVien.MaNV= tHoaDonBan.MaNV      where   TenNV like N'%{0}%' or SDT like '%{1}%' or MaNV like '%{2}%'" +
                " group by tNhanVien.MaNV, TenNV,iif(GioiTinh=0,N'Nữ',N'Nam'), NgaySinh,NgayBD,SDT,iif(Role=1,N'Quản lý',N'Nhân Viên'), Anh ", timkiem, timkiem,timkiem);
            
            DataTable dtTNV = dtBase.ReadData(sql);
            dgvNhanVien.DataSource = dtTNV;
        }

        private void ChonLoc(object sender, EventArgs e)
        {
            string sql1 = "select tNhanVien.MaNV,TenNV,iif(GioiTinh=0,N'Nữ',N'Nam'), NgaySinh,NgayBD,SDT,iif(Role=1,N'Quản lý',N'Nhân Viên'), Anh, sum(TongTien) from tNhanVien left join tHoaDonBan on tNhanVien.MaNV= tHoaDonBan.MaNV  ";
            string sqlc2 = " group by tNhanVien.MaNV, TenNV,iif(GioiTinh=0,N'Nữ',N'Nam'), NgaySinh,NgayBD,SDT,iif(Role=1,N'Quản lý',N'Nhân Viên'), Anh";
            string sql="";
            int trangthai, gioitinh, chucvu;
            // Lọc tranhg thái
            if(rdoGTAll.Checked )
            {
                // Trạng thái all
                if (rdoQuanLy.Checked) // quản lý
                {
                     if (rdoDangLam.Checked)
                    {
                        sql = sql1 + " where Role=1 and IsDangLam=1 " + sqlc2;
                    }
                    else if (rdoNghilam.Checked)
                    {
                        sql = sql1 + " where Role=1 and IsDangLam=0 " + sqlc2;
                    }
                    else
                    {
                        sql = sql1 + " where Role=1 " + sqlc2;
                    }
                }
                else if (rdoNhanVien.Checked)
                {
                    if (rdoDangLam.Checked)
                    {
                        sql = sql1 + " where Role=0 and IsDangLam=1 " + sqlc2;
                    }
                    else if (rdoNghilam.Checked)
                    {
                        sql = sql1 + " where Role=0 and IsDangLam=0 " + sqlc2;
                    }
                    else
                    {
                        sql = sql1 + " where Role=0 " + sqlc2;
                    }
                }
                else
                {
                    if (rdoDangLam.Checked)
                    {
                        sql = sql1 + " where IsDangLam=1 " + sqlc2;
                    }
                    else if (rdoNghilam.Checked)
                    {
                        sql = sql1 + " where IsDangLam=0 " + sqlc2;
                    }
                    else
                    {
                        sql = sql1 + sqlc2;
                    }
                }
            }
            else if (rdoNam.Checked)
            {
                
                 if (rdoQuanLy.Checked) // quản lý
                 {
                     if (rdoDangLam.Checked)
                    {
                        sql = sql1 + " where GioiTinh=1 and Role=1 and IsDangLam=1 " + sqlc2;
                    }
                    else if (rdoNghilam.Checked)
                    {
                        sql = sql1 + " where GioiTinh=1 and Role=1 and IsDangLam=0 " + sqlc2;
                    }
                    else
                    {
                        sql = sql1 + " where GioiTinh=1 and  Role=1 " + sqlc2;
                    }
                 }
                else if (rdoNhanVien.Checked)
                {
                   if (rdoDangLam.Checked)
                    {
                        sql = sql1 + " where GioiTinh=1 and Role=0 and IsDangLam=1 " + sqlc2;
                    }
                    else if (rdoNghilam.Checked)
                    {
                        sql = sql1 + " where GioiTinh=1 and Role=0 and IsDangLam=0 " + sqlc2;
                    }
                    else
                    {
                        sql = sql1 + " where GioiTinh=1 and Role=0 " + sqlc2;
                    }
                }
                else
                {
                    if (rdoDangLam.Checked)
                    {
                        sql = sql1 + " where GioiTinh=1 and IsDangLam=1 " + sqlc2;
                    }
                    else if (rdoNghilam.Checked)
                    {
                        sql = sql1 + " where GioiTinh=1 and IsDangLam=0 " + sqlc2;
                    }
                    else
                    {
                        sql = sql1 + " where GioiTinh=1" + sqlc2;
                    }
                }
            }
            else if (rdoNu.Checked)
            {
                if (rdoQuanLy.Checked) // quản lý
                {
                    if (rdoDangLam.Checked)
                    {
                        sql = sql1 + " where GioiTinh=0 and Role=1 and IsDangLam=1 " + sqlc2;
                    }
                    else if (rdoNghilam.Checked)
                    {
                        sql = sql1 + " where GioiTinh=0 and Role=1 and IsDangLam=0 " + sqlc2;
                    }
                    else
                    {
                        sql = sql1 + " where GioiTinh=0 and  Role=1 " + sqlc2;
                    }
                }
                else if (rdoNhanVien.Checked)
                {
                    if (rdoDangLam.Checked)
                    {
                        sql = sql1 + " where GioiTinh=0 and Role=0 and IsDangLam=1 " + sqlc2;
                    }
                    else if (rdoNghilam.Checked)
                    {
                        sql = sql1 + " where GioiTinh=0 and Role=0 and IsDangLam=0 " + sqlc2;
                    }
                    else
                    {
                        sql = sql1 + " where GioiTinh=0 and Role=0 " + sqlc2;
                    }
                }
                else
                {
                    if (rdoDangLam.Checked)
                    {
                        sql = sql1 + " where GioiTinh=0 and IsDangLam=1 " + sqlc2;
                    }
                    else if (rdoNghilam.Checked)
                    {
                        sql = sql1 + " where GioiTinh=0 and IsDangLam=0 " + sqlc2;
                    }
                    else
                    {
                        sql = sql1 + " where GioiTinh=0" + sqlc2;
                    }
                }
            }
            else
            {
                if (rdoQuanLy.Checked) // quản lý
                {
                    if (rdoDangLam.Checked)
                    {
                        sql = sql1 + " where Role=1 and IsDangLam=1 " + sqlc2;
                    }
                    else if (rdoNghilam.Checked)
                    {
                        sql = sql1 + " where Role=1 and IsDangLam=0 " + sqlc2;
                    }
                    else
                    {
                        sql = sql1 + " where Role=1 " + sqlc2;
                    }
                }
                else if (rdoNhanVien.Checked)
                {
                    if (rdoDangLam.Checked)
                    {
                        sql = sql1 + " where Role=0 and IsDangLam=1 " + sqlc2;
                    }
                    else if (rdoNghilam.Checked)
                    {
                        sql = sql1 + " where Role=0 and IsDangLam=0 " + sqlc2;
                    }
                    else
                    {
                        sql = sql1 + " where Role=0 " + sqlc2;
                    }
                }
                else
                {
                    if (rdoDangLam.Checked)
                    {
                        sql = sql1 + " where IsDangLam=1 " + sqlc2;
                    }
                    else if (rdoNghilam.Checked)
                    {
                        sql = sql1 + " where IsDangLam=0 " + sqlc2;
                    }
                    else
                    {
                        sql = sql1 + sqlc2;
                    }
                }
            }

            DataTable dtLNV = dtBase.ReadData(sql);
            dgvNhanVien.DataSource = dtLNV;
            setDgvNhanVien();
            
        }

        private void btnXuatNV_Click(object sender, EventArgs e)
        {

            SaveFileDialog file = new SaveFileDialog();
            Excel.Application exApp = new Excel.Application();
            Excel.Workbook exBook = exApp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            Excel.Worksheet exSheet = (Excel.Worksheet)exBook.Worksheets[1];
            Excel.Range tenTruong = (Excel.Range)exSheet.Cells[1, 1];
            //Đưa dữ liệu vào Excel
            tenTruong.Range["A1:B1"].MergeCells = true;
            tenTruong.Range["A1:B1"].Font.Size = 20; 
            tenTruong.Range["A1:B1"].Font.FontStyle = FontStyle.Bold;
            tenTruong.Range["A1"].Value = "HH Boutique";
            tenTruong.Range["A2:F2"].MergeCells = true;
            tenTruong.Range["A2"].Value = "Địa chỉ: Chung cư Gemek 2, An Khánh, Hoài Đức,Hà Nội";
            tenTruong.Range["A3:C3"].MergeCells = true;
            tenTruong.Range["A3"].Value = "Điện thoại: 0337629441";
            // tiêu đề
            tenTruong.Range["C5:F5"].MergeCells = true;
            tenTruong.Range["C5"].Value = "DANH SÁCH NHÂN VIÊN";
            // dữ liệu vào bảng
            tenTruong.Range["A7"].Value = "Mã NV";
            tenTruong.Range["B7"].Value = "Tên nhân viên";
            tenTruong.Range["C7"].Value = "Giới tính";
            tenTruong.Range["D7"].Value = "Ngày sinh  ";
            tenTruong.Range["E7"].Value = "Ngày làm việc";
            tenTruong.Range["F7"].Value = "Số điện thoại";
            tenTruong.Range["G7"].Value = "Chức vụ";
            tenTruong.Range["H7"].Value = "Trạng Thái";
            tenTruong.Range["I7"].Value = "Ảnh";
            tenTruong.Range["A7:I7"].ColumnWidth = new int[] { 8, 18,10, 10, 10, 10, 10, 10, 10 };
            int hang = 7;

            for(int i=0; i<dgvNhanVien.Rows.Count-1; i++)
            {
                hang++;
                string maNV= dgvNhanVien.Rows[i].Cells[0].Value.ToString();
                //exSheet.Range["A" + hang.ToString()].Resize[20,20];
                
                tenTruong.Range["A" + hang.ToString()].Value =dgvNhanVien.Rows[i].Cells[0].Value.ToString();
                tenTruong.Range["B" + hang.ToString()].Value = dgvNhanVien.Rows[i].Cells[1].Value.ToString();
                int gioitinh, chucvu;
                gioitinh =dgvNhanVien.Rows[i].Cells[2].Value.Equals("Nam") ? 1 : 0;
                if (gioitinh == 1)
                {
                    tenTruong.Range["C" + hang.ToString()].Value = "Nam";
                }
                else
                {
                    tenTruong.Range["C" + hang.ToString()].Value = "Nữ";
                }
                string ngaysinh = dgvNhanVien.Rows[i].Cells[3].Value.ToString();
                if (DateTime.TryParse(ngaysinh, out DateTime ngaysinhParsed))
                {
                    tenTruong.Range["D" + hang.ToString()].Value = ngaysinhParsed.ToString("yyyy-MM-dd");
                }
                string ngayLamViec = dgvNhanVien.Rows[i].Cells[4].Value.ToString();
                if (DateTime.TryParse(ngayLamViec, out DateTime ngayLamViecParsed))
                {
                    tenTruong.Range["E" + hang.ToString()].Value = ngayLamViecParsed.ToString("yyyy-MM-dd");
                }
                tenTruong.Range["F" + hang.ToString()].Value = "'"+dgvNhanVien.Rows[i].Cells[5].Value.ToString();
                chucvu = dgvNhanVien.Rows[i].Cells[6].Value.Equals("Quản lý") ? 1 : 0;
                if(chucvu == 1)
                {
                    tenTruong.Range["G" + hang.ToString()].Value = "Quản lý";
                }
                else
                {
                    tenTruong.Range["G" + hang.ToString()].Value = "Nhân Viên";
                }
                string sql = "select IsDangLam from tNhanVien where MaNV= '" + maNV + "'";
                DataTable dt = dtBase.ReadData(sql);
                int trangthai;
                trangthai= dt.Rows[0]["IsDangLam"].ToString() =="True" ?1:0;
                if(trangthai == 1)
                {
                    tenTruong.Range["H" + hang.ToString()].Value = "Đang làm";
                }
                else
                {
                    tenTruong.Range["H" + hang.ToString()].Value = "Nghỉ làm";
                }
                tenTruong.Range["H"+hang.ToString()].Value = 
                tenTruong.Range["I" + hang.ToString()].Value = dgvNhanVien.Rows[i].Cells[7].Value.ToString();

               
            }
            exSheet.Name = "NhanVien";

            exBook.Activate(); //Kích hoạt file Excel
                               //Thiết lập các thuộc tính của SaveFileDialog

            if (file.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                exBook.SaveAs(file.FileName.ToString());//Lưu file Excel
            exBook.Save();
            exBook.Close();
            // exSheet.Dispose();
            exApp.Quit();
        }

        
    }
}

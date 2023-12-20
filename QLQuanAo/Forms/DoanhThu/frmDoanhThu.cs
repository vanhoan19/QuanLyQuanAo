using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace QLQuanAo.Forms.DoanhThu
{
    public partial class frmDoanhThu : Form
    {
        Classes.DataProcesser dtBase= new Classes.DataProcesser();

        public frmDoanhThu()
        {
            InitializeComponent();
        }

        private void frmDoanhThu_Load(object sender, EventArgs e)
        {
         
            
            cmbThoiGian.Items.Add("Tháng nay");
            cmbThoiGian.Items.Add("6 tháng qua");
            cmbThoiGian.Items.Add("Năm nay");
            chartTopSP.Visible = false;
            chartDoanhThu.Visible = false;
            lblTieuDe.Visible = false;
            SetBieuDo_Nam();

        }
        private void SetBieuDo_Nam()
        {
            lblTieuDe.Visible = true;
            lblTieuDe.Text = "Doanh thu năm nay";
            DataTable dtTB = dtBase.ReadData("select '" + 0 + "',sum(ThanhToan) as TongBan,'" + 0 + "' from tHoaDonBan where year(ThoiGianTT)= year(GetDate())");
            dgvDoanhThu.Visible = true;
            dgvDoanhThu.DataSource = dtTB;
            DataTable dtTN = dtBase.ReadData("select sum(ThanhToan) as TongNhap from tPhieuNhap where  year(NgayNhap)= year(GetDate())");
            //dgvDoanhThu.Location = new Point(450, 65);
            dgvDoanhThu.Rows[0].Cells[0].Value = "Năm nay";
            dgvDoanhThu.Rows[0].Cells[1].Value = dtTB.Rows[0]["TongBan"].ToString();
            dgvDoanhThu.Rows[0].Cells[2].Value = dtTN.Rows[0]["TongNhap"].ToString();
            setDGV();

            // biểu đồ về loại hàng
            chartTopSP.Visible = true;
            DataTable dtTop = dtBase.ReadData("select* from DoanhThu_NhomHang_Nam(GETDATE())");
            chartTopSP.DataSource = dtTop;
            chartTopSP.Series["topsp"].XValueMember = "TenTheLoai";
            chartTopSP.Series["topsp"].XValueType = ChartValueType.String;
            chartTopSP.Series["topsp"].YValueMembers = "SLBan";
            chartTopSP.Series["topsp"].YValueType = ChartValueType.Int32;
            // biểu đồ về doanh thu
            chartDoanhThu.Visible = true;
            DataTable dtDT = dtBase.ReadData("select  month(ThoiGianTT) as thang, sum(ThanhToan) as TongBan " +
                                     "from  tMatHang  join tChiTietHDB on tMatHang.MaMH= tChiTietHDB.MaMH " +
                                     " join tHoaDonBan on tHoaDonBan.MaHDB= tChiTietHDB.MaHDB  where year(ThoiGianTT)= year(GetDate())" +
                                     "group by rollup(month(ThoiGianTT)) " +
                                     "having month(ThoiGianTT) is not null");
            chartDoanhThu.DataSource = dtDT;
            chartDoanhThu.Series["doanhthu"].XValueMember = "thang";
            chartDoanhThu.Series["doanhthu"].XValueType = ChartValueType.String;
            chartDoanhThu.Series["doanhthu"].YValueMembers = "Tongban";
            chartDoanhThu.Series["doanhthu"].YValueType = ChartValueType.Int32;
        }
        
        private void setDGV()
        {
            dgvDoanhThu.Columns[0].HeaderText = "Thời gian";
            dgvDoanhThu.Columns[1].HeaderText = "Tổng bán";
            dgvDoanhThu.Columns[2].HeaderText = "Tổng nhập";
            this.dgvDoanhThu.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);
        }

        private void cmbThoiGian_SelectedValueChanged(object sender, EventArgs e)
        {
            

            if (cmbThoiGian.Text == "Tháng nay")
            {
                lblTieuDe.Visible = true;
                lblTieuDe.Text = "Doanh thu tháng này";
                DataTable dtTB = dtBase.ReadData("select '"+0+"',sum(ThanhToan) as TongBan,'"+0+"' from tHoaDonBan where Month(ThoiGianTT)=  month(GetDate()) and year(ThoiGianTT)= year(GetDate())");
                dgvDoanhThu.Visible = true;
               // dgvDoanhThu.Location = new Point(400, 209);
                dgvDoanhThu.DataSource = dtTB;
                DataTable dtTN = dtBase.ReadData("select sum(ThanhToan) as TongNhap from tPhieuNhap where  Month(NgayNhap)=(month(GetDate())) and year(NgayNhap)= year(GetDate())");
                
                dgvDoanhThu.Rows[0].Cells[0].Value = "Tháng nay";
                dgvDoanhThu.Rows[0].Cells[1].Value = dtTB.Rows[0]["TongBan"].ToString();
                dgvDoanhThu.Rows[0].Cells[2].Value = dtTN.Rows[0]["TongNhap"].ToString();
                setDGV();
                //biểu đồ về loại hàng
                chartTopSP.Visible = true ;
                //chartTopSP.Size = new Size(350, 300);
                //chartTopSP.Location = new Point(40, 133);
                DataTable dtTop = dtBase.ReadData("select * from DoanhThu_NhomHang(GETDATE(), GETDATE())");
                chartTopSP.DataSource = dtTop;
                chartTopSP.Series["topsp"].XValueMember = "TenTheLoai";
                chartTopSP.Series["topsp"].XValueType = ChartValueType.String;
                chartTopSP.Series["topsp"].YValueMembers = "SLBan";
                chartTopSP.Series["topsp"].YValueType = ChartValueType.Int32;
                // biểu đồ về doanh thu
                chartDoanhThu.Visible = true;
                DataTable dtDT = dtBase.ReadData("select  day(ThoiGianTT) as ngay, sum(ThanhToan) as TongBan " +
                    "from tMatHang  join tChiTietHDB on tMatHang.MaMH = tChiTietHDB.MaMH " +
                    "join tHoaDonBan on tHoaDonBan.MaHDB = tChiTietHDB.MaHDB " +
                    "where year(ThoiGianTT) = year(GetDate()) and MONTH(ThoiGianTT) = month(GetDate())  " +  //and day(ThoiGianTT) % 2 = 0
                    "group by rollup(day(ThoiGianTT)) " +
                    "having day(ThoiGianTT) is not null ");
                chartDoanhThu.DataSource = dtDT;
                chartDoanhThu.Series["doanhthu"].XValueMember = "ngay";
                chartDoanhThu.Series["doanhthu"].XValueType = ChartValueType.String;
                chartDoanhThu.Series["doanhthu"].YValueMembers = "Tongban";
                chartDoanhThu.Series["doanhthu"].YValueType = ChartValueType.Int32;

            }


            if (cmbThoiGian.Text == "Năm nay")
            {

                SetBieuDo_Nam();

            }
            if (cmbThoiGian.Text == "6 tháng qua")
            {
                lblTieuDe.Visible = true;
                lblTieuDe.Text = "Doanh thu 6 tháng  qua";
                DataTable dtTB = dtBase.ReadData("select '" + 0 + "',sum(ThanhToan) as TongBan,'" + 0 + "' from tHoaDonBan where Month(ThoiGianTT)-6 between 0 and 6");
                dgvDoanhThu.Visible = true;
                // dgvDoanhThu.Location = new Point(400, 209);
                dgvDoanhThu.DataSource = dtTB;
                DataTable dtTN = dtBase.ReadData("select sum(ThanhToan) as TongNhap from tPhieuNhap where  Month(NgayNhap)-6 between 0 and 6");

                dgvDoanhThu.Rows[0].Cells[0].Value = "Tháng nay";
                dgvDoanhThu.Rows[0].Cells[1].Value = dtTB.Rows[0]["TongBan"].ToString();
                dgvDoanhThu.Rows[0].Cells[2].Value = dtTN.Rows[0]["TongNhap"].ToString();
                setDGV();
                //biểu đồ về loại hàng
                chartTopSP.Visible = true;
                //chartTopSP.Size = new Size(350, 300);
                //chartTopSP.Location = new Point(40, 133);
                DataTable dtTop = dtBase.ReadData("select * from DoanhThu_NhomHang_6thang()");
                chartTopSP.DataSource = dtTop;
                chartTopSP.Series["topsp"].XValueMember = "TenTheLoai";
                chartTopSP.Series["topsp"].XValueType = ChartValueType.String;
                chartTopSP.Series["topsp"].YValueMembers = "SLBan";
                chartTopSP.Series["topsp"].YValueType = ChartValueType.Int32;
                // biểu đồ về doanh thu
                chartDoanhThu.Visible = true;
                DataTable dtDT = dtBase.ReadData("select  month(ThoiGianTT) as thang, sum(ThanhToan) as TongBan " +
                    "from tMatHang  join tChiTietHDB on tMatHang.MaMH = tChiTietHDB.MaMH " +
                    "join tHoaDonBan on tHoaDonBan.MaHDB = tChiTietHDB.MaHDB " +
                    "where year(ThoiGianTT) = year(GetDate()) " +
                    "group by rollup(month(ThoiGianTT)) " +
                    "having month(ThoiGianTT) is not null and month(ThoiGianTT) - 6 between 0 and 6 ");
                chartDoanhThu.DataSource = dtDT;
                chartDoanhThu.Series["doanhthu"].XValueMember = "thang";
                chartDoanhThu.Series["doanhthu"].XValueType = ChartValueType.String;
                chartDoanhThu.Series["doanhthu"].YValueMembers = "Tongban";
                chartDoanhThu.Series["doanhthu"].YValueType = ChartValueType.Int32;

            }



        }

		private void lblTieuDe_Click(object sender, EventArgs e)
		{

		}
	}
}

using Guna.UI2.WinForms;
using QLQuanAo.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QLQuanAo.Forms.HoaDonNhap
{
    public partial class frmNhapHang : Form
    {
        Classes.DataProcesser dtBase= new Classes.DataProcesser();
        Classes.CommonFunc cmF= new Classes.CommonFunc();
        public bool isThanhToan = false;
        string MaPN;
		double TongTien = 0;
        private Timer debounceTimer;
		public frmNhapHang()
        {
            InitializeComponent();
            //MaPN
			this.MaPN = cmF.Sinhmatudong("tPhieuNhap", "PN", "MaPN");
			string MaNV = Classes.ConstVar.MaNV;

			string sql = "insert tPhieuNhap values('" + this.MaPN + "','" + MaNV + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "',Null,'" + DateTime.Now.ToString("yyyy-MM-dd") + "', 0)";
			dtBase.ChangeData(sql);
            dgvNhapHang.Visible = false;
		}

		public frmNhapHang(string MaPN)
		{
			InitializeComponent();
            this.MaPN = MaPN;

            DataTable dtMH = dtBase.ReadData(string.Format("select * from tChiTietPN where MaPN = '{0}'", MaPN));
			dgvNhapHang.DataSource = dtMH;
            setDgvNhapHang();
			dgvNhapHang.Visible = true;

            // Tính lại tông tiền
            foreach(DataGridViewRow dtr in dgvNhapHang.Rows)
            {
                bool slNhap = double.TryParse(dtr.Cells["SLNhap"].Value.ToString(), out double SLNhap);
                bool giaNhap = double.TryParse(dtr.Cells["GiaNhap"].Value.ToString(), out double GiaNhap);
                if (slNhap && giaNhap) TongTien += SLNhap * GiaNhap;
			}
			lblTongTien.Text = TongTien.ToString();
			lblThanhToan.Text = TongTien.ToString();
		}

		private void frmNhapHang_Load(object sender, EventArgs e)
        {
			DataTable dtSP = dtBase.ReadData("select * from tMatHang ");
			cmF.FillComboBox(cmbTimSP, dtSP, "TenMH", "MaMH");

			cmbTimSP.SelectedIndex = -1;
            panel2.Visible = false;
            txtGiaNhap.Enabled = false;
            
            
            lblMaPN.Text = MaPN;
			lblNhanVien.Text = "     " + Classes.ConstVar.TenNV;
			lblNgayNhap.Text= "        " + DateTime.Now.ToString("dd/MM/yyy HH:ss");

        }
        
       
        private void cmbTimSP_SelectedValueChanged(object sender, EventArgs e)
        {
            DataTable dtMH= dtBase.ReadData("select * from tMatHang where MaMH= N'"+ cmbTimSP.SelectedValue + "'");
            if(dtMH.Rows.Count > 0 ) {
                lblMaSP.Text = dtMH.Rows[0]["MaMH"].ToString();
                lblTenSP.Text = dtMH.Rows[0]["TenMH"].ToString();
                txtGiaNhap.Text = dtMH.Rows[0]["GiaNhap"].ToString();
            }
            panel2.Visible = true;
        }
        private void txtSoLuongNhap_TextChanged(object sender, EventArgs e)
        {
            if (txtSoLuongNhap.Text.Length > 0)
            {

                bool success1 = int.TryParse(txtSoLuongNhap.Text, out int SLNhap);
                bool success2 = double.TryParse(txtGiaNhap.Text, out double giaNhap);
                
                double thanhtien;
                
                if (success1 && success2)
                {
                        thanhtien = SLNhap * giaNhap;
                    //txtThanhTien.Text = thanhtien.ToString();
                   
                    TongTien += thanhtien;
                }

            }
        }
        private void setDgvNhapHang()
        {
            dgvNhapHang.Columns[0].HeaderText = "Mã hàng";
            dgvNhapHang.Columns[1].HeaderText = "Tên hàng";
            dgvNhapHang.Columns[2].HeaderText = "SL Nhập";
            dgvNhapHang.Columns[3].HeaderText = "Giá nhập";
            this.dgvNhapHang.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);
            dgvNhapHang.Columns[1].Width = 200;
            
        }
     
        private void btnLuu_Click(object sender, EventArgs e)
        {
                if (txtSoLuongNhap.Text.Length > 0)
                {

                    dgvNhapHang.Visible = true;
                    string MaPhieuNhap = lblMaPN.Text;
                    
                    bool kt = false;


				    bool success2 = double.TryParse(lblTongTien.Text, out double tongTien);
				    bool success3 = double.TryParse(txtGiaNhap.Text, out double giaNhap);
				foreach (DataGridViewRow dtr in dgvNhapHang.Rows)
                    {
                        if (dtr.Cells["MaMH"].Value!=null && dtr.Cells["MaMH"].Value.ToString() == lblMaSP.Text)
                        {
                            bool success1 = int.TryParse(txtSoLuongNhap.Text, out int SLNhap);
                            dtr.Cells["SLNhap"].Value= SLNhap;
                            TongTien =  SLNhap * double.Parse(dtr.Cells["GiaNhap"].Value.ToString());

                            dtBase.ChangeData("update tChiTietPN set SLNhap='" + dtr.Cells["SLNhap"].Value + "' where MaPN ='" + lblMaPN.Text + "' and MaMH= N'" + lblMaSP.Text + "'");
                                kt = true; break;
                        }
                    }
                    if (!kt)
                    {
					string sql1 = "insert into tChiTietPN values('" + MaPN + "',N'" + lblMaSP.Text + "', '" + txtSoLuongNhap.Text + "'," + giaNhap + ")";
                    //MessageBox.Show(sql1);
                        dtBase.ChangeData(sql1);
                    }

                    // hiện ra dgvNhapHang
                    dgvNhapHang.Visible = true;
                    DataTable dtHang = dtBase.ReadData("select tMatHang.MaMH, TenMH,SLNhap,tMatHang.GiaNhap from tChiTietPN join tMatHang on tChiTietPN.MaMH= tMatHang.MaMH  where MaPN='" + MaPhieuNhap + "'");
                    dgvNhapHang.DataSource = dtHang;
                    setDgvNhapHang();

                    lblTongTien.Text = (float.Parse(TongTien.ToString()) + tongTien).ToString("N0");
                    lblThanhToan.Text = (float.Parse(TongTien.ToString()) + tongTien).ToString("N0");
				    txtGiaNhap.Text = "";
                    txtSoLuongNhap.Text = "";
                    panel2.Visible = false;
                }
                else
                {
                    MessageBox.Show("Bạn phải nhập số lượng nhập của mặt hàng!");
                    txtSoLuongNhap.Focus();
                }
           
        }

        private void txtGiamGia_TextChanged(object sender, EventArgs e)
        {
            bool success1 = double.TryParse(txtGiamGia.Text, out double giamGia);
            bool success2 = double.TryParse(lblTongTien.Text, out double tongTien);
            bool success3 = double.TryParse(lblThanhToan.Text, out double thanhToan);
            if(txtGiamGia.Text.Length > 0 )
            {
                if (0 <= giamGia && giamGia <= 100)
                {
                    thanhToan = tongTien - giamGia/100 * tongTien;
                    lblThanhToan.Text = thanhToan.ToString();
                }
                else
                {
                    MessageBox.Show("Giảm giá chỉ ở trong pham vi từ 0-100%. \nVui lòng nhập lại!");
                    txtGiamGia.Focus();
                }
            }

            
        }

        private void txtSoLuongNhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            cmF.textBox_SoNguyen_KeyPress(sender, e);
        }

        private void txtGiamGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            cmF.textBox_SoThuc_KeyPress(sender, e);
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if(!rdoChuyenKhoan.Checked && !rdoTienMat.Checked )
            {
                MessageBox.Show("Bạn phải chọn phương thức thanh toán. \nVui lòng chọn!");
            }
            //cập nhật số lượng
            //MessageBox.Show(lblMaPN.Text);

				DataTable dtCapNhat = dtBase.ReadData("select  * from tChiTietPN where MaPN ='" + lblMaPN.Text + "' ");
				for (int i = 0; i < dtCapNhat.Rows.Count; i++)
				{
					string masp = dtCapNhat.Rows[i]["MaMH"].ToString();
					//MessageBox.Show(masp);
					DataTable dtSP = dtBase.ReadData("select SLTon from tMatHang where MaMH= N'" + masp + "'");
					int slnhap = int.Parse(dtCapNhat.Rows[i]["SLNhap"].ToString());
					//if()
					int soluongton = int.Parse(dtSP.Rows[0]["SLTon"].ToString()) + slnhap;

					// cập nhật số lượng vào bảng mặt hàng
					dtBase.ChangeData("update tMatHang set SLTon ='" + soluongton + "' where MaMH= N'" + masp + "'");
				}
				bool success1 = double.TryParse(txtGiamGia.Text, out double giamGia);
				bool success2 = double.TryParse(lblTongTien.Text, out double tongTien);
				bool success3 = double.TryParse(lblThanhToan.Text, out double thanhToan);
				// cập nhật tổng tiền, thanh toán
				int pt = rdoChuyenKhoan.Checked ? 1 : 0;
				string sql = "update tPhieuNhap set TongTien= " + tongTien + ",";
				sql += "GiamGia= " + giamGia + " ,";
				sql += "ThanhToan=" + thanhToan + ",";
                sql += "TrangThai = 1, ";
				sql += "PhuongThucTT='" + pt + "', GhiChu='" + rtbGhiChu.Text + "'  where MaPN= '" + MaPN + "'";
				dtBase.ChangeData(sql);

		        checkChiTietCount();
                this.Close();
        }

        private void dgvNhapHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblTenSP.Text= dgvNhapHang.CurrentRow.Cells[1].Value.ToString();
            lblMaSP.Text= dgvNhapHang.CurrentRow.Cells[0].Value.ToString();
            txtSoLuongNhap.Text= dgvNhapHang.CurrentRow.Cells[2].Value.ToString();
            txtGiaNhap.Text= dgvNhapHang.CurrentRow.Cells[3].Value.ToString();
            cmbTimSP.SelectedValue = lblMaSP.Text;
            panel2.Visible = true;
        }

        private void dgvNhapHang_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string masp = dgvNhapHang.CurrentRow.Cells[1].Value.ToString();
            if (MessageBox.Show("Bạn có muốn xóa  hàng : "+masp+" không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // bảng hàng
                DataTable dtMH = dtBase.ReadData("select * from tMatHang where MaMH= N'" + masp + "'");
                
                // cập nhật tổng tiền, thanh toán
                bool success2 = double.TryParse(lblTongTien.Text, out double tongTien);
                tongTien = tongTien - double.Parse(dgvNhapHang.CurrentRow.Cells[2].Value.ToString()) * double.Parse(dgvNhapHang.CurrentRow.Cells[3].Value.ToString());
                lblTongTien.Text= tongTien.ToString();
                lblThanhToan.Text= tongTien.ToString();

                // xóa
                dtBase.ChangeData("delete tChiTietPN where MaPN ='" + lblMaPN.Text + "' and MaMH=N'" + masp + "'");
            }
        }

		private void btnThemSanPham_Click(object sender, EventArgs e)
		{
            // Thêm form thêm hàng hóa ở đây
            Forms.HangHoa.frmThemHH frmThemHH = new HangHoa.frmThemHH();
			frmThemHH.ShowDialog();
            frmThemHH = null;

			DataTable dtSP = dtBase.ReadData("select * from tMatHang ");
			cmF.FillComboBox(cmbTimSP, dtSP, "TenMH", "MaMH");
		}

        private bool checkChiTietCount()
        {
            if (dgvNhapHang.Rows.Count == 0)
            {
                string sqlDelete = string.Format("delete from tPhieuNhap where MaPN = N'{0}'", this.MaPN);
                //MessageBox.Show(sqlDelete);
                dtBase.ChangeData(sqlDelete);
                return false;
            }
            return true;
        }

        // nút lưu tạm
		private void btnLuuTam_Click(object sender, EventArgs e)
		{
            if (checkChiTietCount())
            {
				bool success1 = double.TryParse(txtGiamGia.Text, out double giamGia);
				bool success2 = double.TryParse(lblTongTien.Text, out double tongTien);
				bool success3 = double.TryParse(lblThanhToan.Text, out double thanhToan);
				// cập nhật tổng tiền, thanh toán
				int pt = rdoChuyenKhoan.Checked ? 1 : 0;
				string sql = "update tPhieuNhap set TongTien= " + tongTien + ",";
				sql += "GiamGia= " + giamGia + " ,";
				sql += "ThanhToan=" + thanhToan + ",";
				sql += "TrangThai = 0, ";
				sql += "PhuongThucTT='" + pt + "', GhiChu='" + rtbGhiChu.Text + "'  where MaPN= '" + MaPN + "'";
				dtBase.ChangeData(sql);
			}
			this.Close();
		}
        // 
		private void txtHangHoa_TextChanged(object sender, EventArgs e)
		{
			if (debounceTimer == null)
			{
				debounceTimer = new Timer();
				debounceTimer.Interval = 500;
				debounceTimer.Tick += debounceTimer_Tick;
			}
			else
			{
				debounceTimer.Start();
			}
		}
		private void debounceTimer_Tick(object sender, EventArgs e)
		{
			debounceTimer.Stop();

			// Xử lí sự kiện ở đây
			// Fill lại combobox
            if (txtTimSP.Text != "")
            {
				DataTable dtSP = dtBase.ReadData(string.Format("select * from tMatHang where MaMH like N'%{0}%' or TenMH like N'%{0}%'", txtTimSP.Text));
				cmF.FillComboBox(cmbTimSP, dtSP, "TenMH", "MaMH");
			}

			cmbTimSP.DroppedDown = true;
		}
	}
}

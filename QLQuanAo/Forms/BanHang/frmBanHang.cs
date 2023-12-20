using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace QLQuanAo.Forms.BanHang
{
    public partial class frmBanHang : Form
    {
        Classes.CommonFunc commonFunc = new Classes.CommonFunc();
        Classes.DataProcesser dataProcesser = new Classes.DataProcesser();
        string MaKH = null; // Luuw mã khách hàng hiện tại
        List<string> MaMHs = new List<string>(); // Lưu các mã hàng trongg chi tiết hóa đơn
        private Timer debounceTimer; // đảm bảo 1 độ trễ cho việc load dữ liệu sau khi người dùng nhập textbox
        bool isThemHoaDonBan = true;
        public frmBanHang()
        {
            InitializeComponent();
            lblTenNV.Text = Classes.ConstVar.TenNV;
            panHoaDon.HorizontalScroll.Enabled = false;
            panDSMatHang.HorizontalScroll.Enabled = false;
        }

        // Sự kiện click vào nút xóa chi tiết hóa đơn
        private void btnDelete_Click(object sender, EventArgs e)
        {
            Guna2CircleButton btnDelete = (Guna2CircleButton)sender;
            string indexString = new string(btnDelete.Name.Where(char.IsDigit).ToArray());
            Guna2ContainerControl containerControl = 
                panHoaDon.Controls.Find("containerItem" + indexString, true).FirstOrDefault() as Guna2ContainerControl;
            if (containerControl != null)
            {
                System.Windows.Forms.TextBox txtMaSP =
                       containerControl.Controls.Find("txtMaMH" + indexString, true).FirstOrDefault() as System.Windows.Forms.TextBox;
                
                System.Windows.Forms.Label lblDonGiaBan =
                    containerControl.Controls.Find("lblDonGiaBan" + indexString, true).FirstOrDefault() as System.Windows.Forms.Label;

                System.Windows.Forms.TextBox txtSoLuong =
                        containerControl.Controls.Find("txtSoLuong" + indexString, true).FirstOrDefault() as System.Windows.Forms.TextBox;

                System.Windows.Forms.Label lblThanhTien =
                    containerControl.Controls.Find("lblThanhTien" + indexString, true).FirstOrDefault() as System.Windows.Forms.Label;

                int SLBan = 0;
                float GiamGiaCu = 0;
                if (txtGiamGia.Text != "") GiamGiaCu = float.Parse(txtGiamGia.Text);

                if (txtSoLuong.Text != "") SLBan = int.Parse(txtSoLuong.Text);

                txtTongTienHang.Text = (float.Parse(txtTongTienHang.Text) - SLBan * float.Parse(lblDonGiaBan.Text)).ToString("N0");
                txtGiamGia.Text = Math.Max(GiamGiaCu - (SLBan * float.Parse(lblDonGiaBan.Text) - float.Parse(lblThanhTien.Text)), 0).ToString("N0");
                txtKhachCanTra.Text = Math.Max(float.Parse(txtKhachCanTra.Text) - float.Parse(lblThanhTien.Text), 0).ToString("N0");

                MaMHs.Remove(txtMaSP.Text);
                containerControl.Dispose();
            }
            if (panHoaDon.Controls.Count == 0) grbPhuongThucTT.Visible = false;
        }

        private void containerSanPham_MouseHover(object sender, EventArgs e)
        {
            Control control = sender as Control;
            string indexString = new string(control.Name.Where(char.IsDigit).ToArray());
            Guna2ContainerControl containerSanPham =
                panDSMatHang.Controls.Find("containerSanPham" + indexString, true).FirstOrDefault() as Guna2ContainerControl;
            if (containerSanPham != null)
            {
                foreach (Control item in containerSanPham.Controls)
                {
                    item.BackColor = Color.FromArgb(185, 243, 252); 
                }    
                containerSanPham.FillColor = Color.FromArgb(185, 243, 252);
            }
        }

        private void containerSanPham_MouseLeave(object sender, EventArgs e)
        {
            Control control = sender as Control;
            string indexString = new string(control.Name.Where(char.IsDigit).ToArray());
            Guna2ContainerControl containerSanPham =
                panDSMatHang.Controls.Find("containerSanPham" + indexString, true).FirstOrDefault() as Guna2ContainerControl;
            if (containerSanPham != null)
            {
                foreach (Control item in containerSanPham.Controls)
                {
                    item.BackColor = Color.White;
                }
                containerSanPham.FillColor = Color.White;
            }
        }

        private void containerSanPham_Click(object sender, EventArgs e)
        {
            Control control = sender as Control;
            string indexString = new string(control.Name.Where(char.IsDigit).ToArray());
            Guna2ContainerControl containerSanPham =
                panDSMatHang.Controls.Find("containerSanPham" + indexString, true).FirstOrDefault() as Guna2ContainerControl;
            try
            {
                if (containerSanPham != null)
                {
                    System.Windows.Forms.TextBox txtTenSP =
                        containerSanPham.Controls.Find("txtTenSP" + indexString, true).FirstOrDefault() as System.Windows.Forms.TextBox;
                    System.Windows.Forms.TextBox txtMaSP =
                        containerSanPham.Controls.Find("txtMaSP" + indexString, true).FirstOrDefault() as System.Windows.Forms.TextBox;
                    System.Windows.Forms.Label lblGiaSP =
                        containerSanPham.Controls.Find("lblValueGiaSP" + indexString, true).FirstOrDefault() as System.Windows.Forms.Label;
                    System.Windows.Forms.Label lblValueTonSP =
                        containerSanPham.Controls.Find("lblValueTonSP" + indexString, true).FirstOrDefault() as System.Windows.Forms.Label;

                    // Tạo thêm containerItem và thêm nó vào panHoaDon
                    for (int i = 1; i <= panHoaDon.Controls.Count + 1; i++)
                    {
                        Guna2ContainerControl containerControl =
                    panHoaDon.Controls.Find("containerItem" + i.ToString(), true).FirstOrDefault() as Guna2ContainerControl;
                        if (containerControl == null)
                        {
                            ThemContainerItem(i, txtTenSP.Text, txtMaSP.Text, lblGiaSP.Text, lblValueTonSP.Text);
                            panDSMatHang.Visible = false;
                            txtHangHoa.Text = "";
                            txtHangHoa.Focus();
                            break;
                        }
                    }
                    if (grbPhuongThucTT.Visible == false) grbPhuongThucTT.Visible = true;
                }
            }
            catch(Exception ex) {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ThemContainerItem(int i, string TenMH, string MaMH, string GiaBan, string SLTon)
        {
            float DonGiaBan = float.Parse(GiaBan);
            int slTon = int.Parse(SLTon);
            if (MaMHs.Contains(MaMH)) return;
            MaMHs.Add(MaMH);
            Guna2ContainerControl containerItem = new Guna2ContainerControl();
            containerItem.Name = "containerItem" + i.ToString();
            containerItem.BorderRadius = 12;
            containerItem.BorderThickness = 0;
            containerItem.Size = new Size(690, 87);

            // Tạo button xóa
            Guna2CircleButton btnDelete = new Guna2CircleButton();
            btnDelete.Name = "btnDelete" + i.ToString();
            btnDelete.Size = new Size(30, 30);
            btnDelete.Image = global::QLQuanAo.Properties.Resources.bin;
            btnDelete.BackColor = Color.White;
            btnDelete.FillColor = Color.White;
            btnDelete.Location = new Point(12, 23);
            btnDelete.BorderThickness = 0;
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.Click += btnDelete_Click;

            // Tạo textbox tên mặt hàng
            System.Windows.Forms.TextBox txtTenMH = new System.Windows.Forms.TextBox();
            txtTenMH.Name = "txtTenMH" + i.ToString();
            txtTenMH.Location = new Point(56, 12);
            txtTenMH.Multiline = true;
            txtTenMH.Size = new Size(240, 44);
            txtTenMH.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);
            txtTenMH.Text = TenMH;
            txtTenMH.BorderStyle = System.Windows.Forms.BorderStyle.None;

            // Tạo textbox mã mặt hàng
            System.Windows.Forms.TextBox txtMaMH = new System.Windows.Forms.TextBox();
            txtMaMH.Name = "txtMaMH" + i.ToString();
            txtMaMH.Location = new Point(56, 59);
            txtMaMH.Size = new Size(240, 20);
            txtMaMH.Font = new Font("Microsoft Sans Serif", 11);
            txtMaMH.Text = MaMH;
            txtMaMH.BorderStyle = System.Windows.Forms.BorderStyle.None;

            // Tạo textbox số lượng bán
            System.Windows.Forms.TextBox txtSoLuong = new System.Windows.Forms.TextBox();
            txtSoLuong.Name = "txtSoLuong" + i.ToString();
            txtSoLuong.Location = new Point(320, 26);
            txtSoLuong.Name = "txtSoLuong" + i.ToString();
            txtSoLuong.Font = new Font("Microsoft Sans Serif", 12);
            txtSoLuong.Size = new Size(40, 30);
            txtSoLuong.TextAlign = HorizontalAlignment.Center;
            txtSoLuong.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            txtSoLuong.Text = "1";
            txtSoLuong.KeyPress += commonFunc.textBox_SoNguyen_KeyPress;
            txtSoLuong.KeyUp += txtSoLuong_KeyUp;
            if (slTon == 0) txtSoLuong.ForeColor = Color.Red;
			toolTip.SetToolTip(txtSoLuong, "Tồn: " + SLTon);

            // Tạo label số lượng tồn
            System.Windows.Forms.Label lblSLTon = new System.Windows.Forms.Label();
            lblSLTon.Name = "lblSLTon" + i.ToString();
            lblSLTon.Text = SLTon;
            lblSLTon.Visible = false;

            // Tạo label đơn giá bán
            System.Windows.Forms.Label lblDonGiaBan = new System.Windows.Forms.Label();
            lblDonGiaBan.Name = "lblDonGiaBan" + i.ToString();
            lblDonGiaBan.Location = new Point(390, 28);
            lblDonGiaBan.Font = new Font("Microsoft Sans Serif", 12);
            lblDonGiaBan.Text = DonGiaBan.ToString("N0");
            lblDonGiaBan.BackColor = Color.White;
            toolTip.SetToolTip(lblDonGiaBan, "Đơn giá");

            // Tạo textbox giảm giá
            System.Windows.Forms.TextBox txtGiamGiaMH = new System.Windows.Forms.TextBox();
            txtGiamGiaMH.Name = "txtGiamGiaMH" + i.ToString();
            txtGiamGiaMH.Location = new Point(500, 26);
            txtGiamGiaMH.Font = new Font("Microsoft Sans Serif", 12);
            txtGiamGiaMH.Size = new Size(40, 30);
            txtGiamGiaMH.TextAlign = HorizontalAlignment.Center;
            txtGiamGiaMH.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            txtGiamGiaMH.Text = "0";
            txtGiamGiaMH.KeyPress += commonFunc.textBox_SoNguyen_KeyPress;
            txtGiamGiaMH.KeyUp += txtGiamGiaMH_KeyUp;
            toolTip.SetToolTip(txtGiamGiaMH, "Giảm giá(%)");

            // Tạo label Thành tiền
            System.Windows.Forms.Label lblThanhTien = new System.Windows.Forms.Label();
            lblThanhTien.Name = "lblThanhTien" + i.ToString();
            lblThanhTien.Location = new Point(575, 28);
            lblThanhTien.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);
            lblThanhTien.Text = DonGiaBan.ToString("N0"); ;
            lblThanhTien.BackColor = Color.White;
            toolTip.SetToolTip(lblThanhTien, "Thành tiền");

            containerItem.Controls.Add(btnDelete);
            containerItem.Controls.Add(txtTenMH);
            containerItem.Controls.Add(txtMaMH);
            containerItem.Controls.Add(txtSoLuong);
            containerItem.Controls.Add(lblSLTon);
            containerItem.Controls.Add(lblDonGiaBan);
            containerItem.Controls.Add(txtGiamGiaMH);
            containerItem.Controls.Add(lblThanhTien);

            txtTongTienHang.Text = (float.Parse(txtTongTienHang.Text) + float.Parse(lblDonGiaBan.Text)).ToString("N0");
            txtKhachCanTra.Text = (float.Parse(txtKhachCanTra.Text) + float.Parse(lblDonGiaBan.Text)).ToString("N0");

            panHoaDon.Controls.Add(containerItem);
        }

        private void SPTimKiem(int i, string fileName, string TenMH, string MaMH, string SLTon, string GiaBan)
        {
            Guna2ContainerControl containerSanPham = new Guna2ContainerControl();
            containerSanPham.Name = "containerSanPham" + i.ToString();
            containerSanPham.BorderRadius = 10;
			containerSanPham.BorderThickness = 0;
            containerSanPham.Size = new Size(368, 97);

            // Tạo picturebox ảnh mặt hàng
            Guna2PictureBox picAnhSanPham = new Guna2PictureBox();
            picAnhSanPham.SizeMode = PictureBoxSizeMode.StretchImage;
            picAnhSanPham.Name = "picAnhSanPham" + i.ToString();
            picAnhSanPham.Size = new Size(50, 50);
            picAnhSanPham.Location = new Point(11, 20);
            try
            {
                picAnhSanPham.Image = System.Drawing.Image.FromFile(
                    Path.Combine(Application.StartupPath, "Images", "Hàng hóa", fileName));
            }
            catch { }

            // Tạo textbox tên mặt hàng
            System.Windows.Forms.TextBox txtTenSP = new System.Windows.Forms.TextBox();
            txtTenSP.Name = "txtTenSP" + i.ToString();
            txtTenSP.Location = new Point(73, 8);
            txtTenSP.Multiline = true;
            txtTenSP.Size = new Size(300, 34);
            txtTenSP.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
            txtTenSP.Text = TenMH;
            txtTenSP.BorderStyle = System.Windows.Forms.BorderStyle.None;
            toolTip.SetToolTip(txtTenSP, TenMH);


            // Tạo textBox mã mặt hàng
            System.Windows.Forms.TextBox txtMaSP = new System.Windows.Forms.TextBox();
            txtMaSP.Name = "txtMaSP" + i.ToString();
            txtMaSP.Location = new Point(73, 48);
            txtMaSP.Size = new Size(300, 15);
            txtMaSP.Font = new Font("Microsoft Sans Serif", 9);
            txtMaSP.Text = MaMH;
            txtMaSP.BorderStyle = System.Windows.Forms.BorderStyle.None;

            // Tạo Label Tồn
            System.Windows.Forms.Label lblTonSP = new System.Windows.Forms.Label();
            lblTonSP.Name = "lblTonSP" + i.ToString();
            lblTonSP.Location = new Point(71, 72);
            lblTonSP.Font = new Font("Microsoft Sans Serif", 10);
            lblTonSP.BackColor = Color.White;
            lblTonSP.Text = "Tồn:";
            lblTonSP.Width = 37;

            // Tạo value Tôn
            System.Windows.Forms.Label lblValueTonSP = new System.Windows.Forms.Label();
            lblValueTonSP.Name = "lblValueTonSP" + i.ToString();
            lblValueTonSP.Location = new Point(110, 72);
            lblValueTonSP.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
            lblValueTonSP.BackColor = Color.White;
            lblValueTonSP.Text = SLTon;
            lblValueTonSP.Width = 35;

            // Tạo Label Giá
            System.Windows.Forms.Label lblGiaSP = new System.Windows.Forms.Label();
            lblGiaSP.Name = "lblGiaSP" + i.ToString();
            lblGiaSP.Location = new Point(180, 72);
            lblGiaSP.Font = new Font("Microsoft Sans Serif", 10);
            lblGiaSP.BackColor = Color.White;
            lblGiaSP.Text = "Giá:";
            lblGiaSP.Width = 35;

            // Tạo value Giá
            System.Windows.Forms.Label lblValueGiaSP = new System.Windows.Forms.Label();
            lblValueGiaSP.Name = "lblValueGiaSP" + i.ToString();
            lblValueGiaSP.Location = new Point(217, 72);
            lblValueGiaSP.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
            lblValueGiaSP.BackColor = Color.White;
            float DonGiaBan = float.Parse(GiaBan);
            lblValueGiaSP.Text = DonGiaBan.ToString("N0");


			containerSanPham.Controls.Add(picAnhSanPham);
            containerSanPham.Controls.Add(txtTenSP);
            containerSanPham.Controls.Add(txtMaSP);
            containerSanPham.Controls.Add(lblTonSP);
            containerSanPham.Controls.Add(lblValueTonSP);
            containerSanPham.Controls.Add(lblGiaSP);
            containerSanPham.Controls.Add(lblValueGiaSP);

            foreach (Control control in containerSanPham.Controls)
            {
                control.MouseHover += containerSanPham_MouseHover;
                control.MouseLeave += containerSanPham_MouseLeave;
                control.Click += containerSanPham_Click;
                control.Cursor = Cursors.Hand;
            }
            containerSanPham.MouseHover += containerSanPham_MouseHover;
            containerSanPham.MouseLeave += containerSanPham_MouseLeave;
            containerSanPham.Click += containerSanPham_Click;

            panDSMatHang.Controls.Add(containerSanPham);
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            if (conMenu.Visible == false)
            {
                conMenu.Height = 0;
                conMenu.Height = 105;
                transacTK.ShowSync(conMenu);
            }
            else
            {
                conMenu.Visible = false;
                conMenu.Height = 0;
            }
        }

        private void frmBanHang_Load(object sender, EventArgs e)
        {
            conMenu.Visible = false;

            // Load các nhân viên
            DataTable dataTable = dataProcesser.ReadData("select * from tNhanVien where IsDangLam=1");
            commonFunc.FillComboBox(cboNguoiBan, dataTable, "TenNV", "MaNV");
            cboNguoiBan.SelectedValue = Classes.ConstVar.MaNV;

		}

        private void frmBanHang_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem vị trí click có nằm ngoài GroupBox hay không
            Point clickPoint = PointToClient(MousePosition);
            if (!conMenu.Bounds.Contains(clickPoint))
            {
                conMenu.Visible = false;
                conMenu.Height = 0;
            }
        }

        private void btnThemKH_Click(object sender, EventArgs e)
        {
            Forms.KhachHang.frmCapNhatKH frmCapNhatKH = new KhachHang.frmCapNhatKH();
            frmCapNhatKH.ShowDialog();
            if (frmCapNhatKH.isThemKH == true)
            {
				this.Show();
                MaKH = frmCapNhatKH.MaKH;
				linkKH.Text = frmCapNhatKH.linkKH;

				txtKhachHang.Visible = false;
				btnThemKH.Visible = false;
				conKhachHang.Visible = true;
			}    
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            this.Hide();
            Forms.frmDangNhap frmDangNhap = new Forms.frmDangNhap();
            frmDangNhap.Show();
        }

        private void txtKhachHang_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtKhachHang.Text == "")
            {
                lstKhachHang.Visible = false;
                return;
            }

            string sql = string.Format("SELECT MaKH, TenKH, SUBSTRING(SDT , LEN(SDT) - 3, LEN(SDT)) SDT " +
                "from tKhachHang where MaKH like N'%{0}%' " +
                "or TenKH like N'%{0}%' or SDT like N'%{0}%'", txtKhachHang.Text);
            DataTable dt = dataProcesser.ReadData(sql);
            int countKH = dt.Rows.Count;
            if (countKH == 0)
            {
                lstKhachHang.DataSource = null;
                if (!lstKhachHang.Items.Contains("Không có khách hàng nào"))
                {
                    lstKhachHang.Items.Add("Không có khách hàng nào");
                    lstKhachHang.Height = 40;
                    lstKhachHang.Cursor = DefaultCursor;
                    transacKH.ShowSync(lstKhachHang);
                }
                return;
            }
            dt.Columns.Add("HienThi", typeof(string), "TenKH + ' - ...' + SDT + ' - MaKH:'  + MaKH");
            lstKhachHang.DataSource = dt;
            lstKhachHang.DisplayMember = "HienThi";
            lstKhachHang.ValueMember = "MaKH";

            lstKhachHang.Height = 0;
            int Max_height = 500;
            if (countKH * lstKhachHang.ItemHeight > Max_height)
            {
                lstKhachHang.Height = Max_height;
                lstKhachHang.ScrollAlwaysVisible = true;
            }
            else lstKhachHang.Height = (countKH + 1) * 20;
            transacKH.ShowSync(lstKhachHang);
        }

        private void lstKhachHang_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (lstKhachHang.SelectedItem.ToString() == "Không có khách hàng nào")
                {
                    lstKhachHang.Visible = false;
                    return;
                }
                if (lstKhachHang.SelectedItem != null)
                {
                    MaKH = lstKhachHang.SelectedValue.ToString();
                    linkKH.Text = ((DataRowView)lstKhachHang.SelectedItem)["HienThi"].ToString();    

                    txtKhachHang.Visible = false;
                    btnThemKH.Visible = false;
                    conKhachHang.Visible = true;
                }
            }
            catch { }
            finally
            {
                lstKhachHang.Visible = false;
            }
        }

        private void btnXoaKH_Click(object sender, EventArgs e)
        {
            MaKH = null;
            txtKhachHang.Visible = true;
            btnThemKH.Visible = true;
            conKhachHang.Visible = false;
            txtKhachHang.Text = "";
        }

        private void linkKH_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (MaKH != null)
                {
                    //Forms.KhachHang.frmCapNhatKH frmCapNhatKH = new KhachHang.frmCapNhatKH(MaKH);
                    Forms.KhachHang.frmKhachHang frmKhachHang = new KhachHang.frmKhachHang(MaKH);
					frmKhachHang.ShowDialog();
                    if (frmKhachHang.isThemKH == true)
                    {
                        linkKH.Text = frmKhachHang.linkKH;
					}
					frmKhachHang = null;
                    this.Show();
                }
            }
            catch { }

        }
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
            // Xóa tát cả các phẩn tử trong flowLayoutPanel DS
            panDSMatHang.Controls.Clear();
            panDSMatHang.Visible = false;
            string textTimKiem = txtHangHoa.Text.Trim();
            if (textTimKiem != "")
            {
                string sqlSelect = string.Format("select Anh, TenMH, MaMH, SLTon, GiaBan from tMatHang where " +
                "(MaMH like N'%{0}%' or TenMH like N'%{0}%') and IsDangBan=1", textTimKiem);
                DataTable dt = dataProcesser.ReadData(sqlSelect);
                // tạo các container bên trong panDSMatHang
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string fileName = dt.Rows[i]["Anh"].ToString();
                    string TenMH = dt.Rows[i]["TenMH"].ToString();
                    string MaMH = dt.Rows[i]["MaMH"].ToString();
                    string SLTon = dt.Rows[i]["SLTon"].ToString();
                    string GiaBan = dt.Rows[i]["GiaBan"].ToString();
                    SPTimKiem(i, fileName, TenMH, MaMH, SLTon, GiaBan);
                }
                panDSMatHang.Visible = true;
            }
        }

        private void txtSoLuong_KeyUp(object sender, KeyEventArgs e)
        {
            System.Windows.Forms.TextBox control = sender as System.Windows.Forms.TextBox;

            int SLBan = 0;
            int SLTon = 0;
            if (control.Text != "") SLBan = int.Parse(control.Text);
            string indexString = new string(control.Name.Where(char.IsDigit).ToArray());

            Guna2ContainerControl containerItem =
            panHoaDon.Controls.Find("containerItem" + indexString, true).FirstOrDefault() as Guna2ContainerControl;

            System.Windows.Forms.Label lblSLTon =
                containerItem.Controls.Find("lblSLTon" + indexString, true).FirstOrDefault() as System.Windows.Forms.Label;

            System.Windows.Forms.Label lblThanhTien =
                    containerItem.Controls.Find("lblThanhTien" + indexString, true).FirstOrDefault() as System.Windows.Forms.Label;

            System.Windows.Forms.Label lblDonGiaBan =
                    containerItem.Controls.Find("lblDonGiaBan" + indexString, true).FirstOrDefault() as System.Windows.Forms.Label;

            System.Windows.Forms.TextBox txtGiamGiaMH =
                    containerItem.Controls.Find("txtGiamGiaMH" + indexString, true).FirstOrDefault() as System.Windows.Forms.TextBox;


            SLTon = int.Parse(lblSLTon.Text);
            if (SLBan > SLTon)
            {
                control.ForeColor = Color.Red;
            }
            else control.ForeColor = Color.Black;

            float DonGiaBan = float.Parse(lblDonGiaBan.Text);
            int GiamGia = 0;

            if (txtGiamGiaMH.Text != "") GiamGia = int.Parse(txtGiamGiaMH.Text);

            float ThanhTienCu = float.Parse(lblThanhTien.Text);

            int SLBanCu = (int)(ThanhTienCu/ DonGiaBan / (100 - GiamGia) * 100);

            float GiamGiaCu = 0;
            if (txtGiamGia.Text != "") GiamGiaCu = float.Parse(txtGiamGia.Text);

            lblThanhTien.Text = (SLBan * DonGiaBan * (100 - GiamGia) / 100).ToString("N0");

            float TongTien = float.Parse(txtTongTienHang.Text) - ThanhTienCu/(100 - GiamGia)*100 + SLBan * DonGiaBan ;
            float GiamGiaMoi = GiamGiaCu + (SLBan - SLBanCu) * DonGiaBan * GiamGia / 100;
            txtTongTienHang.Text = TongTien.ToString("N0");
            txtGiamGia.Text = GiamGiaMoi.ToString("N0");
            txtKhachCanTra.Text = (TongTien - GiamGiaMoi).ToString("N0");
        }

        private void txtGiamGiaMH_KeyUp(object sender, KeyEventArgs e)
        {
            System.Windows.Forms.TextBox control = sender as System.Windows.Forms.TextBox;

            int GiamGia = 0;
            if (control.Text != "") GiamGia = int.Parse(control.Text);

            string indexString = new string(control.Name.Where(char.IsDigit).ToArray());
            Guna2ContainerControl containerItem =
            panHoaDon.Controls.Find("containerItem" + indexString, true).FirstOrDefault() as Guna2ContainerControl;

            System.Windows.Forms.Label lblThanhTien =
                    containerItem.Controls.Find("lblThanhTien" + indexString, true).FirstOrDefault() as System.Windows.Forms.Label;

            System.Windows.Forms.Label lblDonGiaBan =
                    containerItem.Controls.Find("lblDonGiaBan" + indexString, true).FirstOrDefault() as System.Windows.Forms.Label;

            System.Windows.Forms.TextBox txtSoLuong =
                    containerItem.Controls.Find("txtSoLuong" + indexString, true).FirstOrDefault() as System.Windows.Forms.TextBox;

            float DonGiaBan = float.Parse(lblDonGiaBan.Text);
            int SLBan = 0;
            if (txtSoLuong.Text != "") SLBan = int.Parse(txtSoLuong.Text);
            if (GiamGia > 100)
            {
                control.ForeColor = Color.Red;
            }
            else control.ForeColor = Color.Black;

            float ThanhTienCu = float.Parse(lblThanhTien.Text);
            float ThanhTienMoi = SLBan * DonGiaBan * (100 - GiamGia) / 100;
            float GiamGiaCu = 0;
            if (txtGiamGia.Text != "") GiamGiaCu = float.Parse(txtGiamGia.Text);
            float GiamGiaMoi = Math.Max(GiamGiaCu + (ThanhTienCu - ThanhTienMoi), 0);

            lblThanhTien.Text = ThanhTienMoi.ToString("N0");

            txtGiamGia.Text =  GiamGiaMoi.ToString("N0");

            txtKhachCanTra.Text = (float.Parse(txtTongTienHang.Text) - GiamGiaMoi).ToString("N0");
        }



		private void btnThanhToan_Click(object sender, EventArgs e)
		{
            if (panHoaDon.Controls.Count == 0) return;
            if (MaKH == null)
            {
                MessageBox.Show("Bạn chưa chọn khách hàng");
                return;
            }
            string MaHDB = commonFunc.Sinhmatudong("tHoaDonBan", "HDB", "MaHDB");
            string MaNVBan = cboNguoiBan.SelectedValue.ToString();
            int PhuongThucTT = (rdoTienMat.Checked == true ? 0 : 1);
            float TongTien = float.Parse(txtTongTienHang.Text);
            float GiamGia = 0;
            if (txtGiamGia.Text.Trim() != "") GiamGia = float.Parse(txtGiamGia.Text);
            float ThanhToan = float.Parse(txtKhachCanTra.Text);

			// Thêm hóa đơn bán
			string sqlInsertHDB = string.Format("insert into tHoaDonBan(MaHDB, MaNV, MaKH, TongTien, GiamGia, ThanhToan, PhuongThucTT, ThoiGianTT, GhiChu) " +
                "values(N'{0}', N'{1}', N'{2}', {3}, {4}, {5}, {6}, GETDATE(), N'{7}')", MaHDB, MaNVBan, MaKH, TongTien, GiamGia, ThanhToan, PhuongThucTT, txtGhiChuHD.Text);
            dataProcesser.ChangeData(sqlInsertHDB);
            //MessageBox.Show(sqlInsertHDB);

            // Thêm các chi tiết hóa đơn bán
            foreach (Guna2ContainerControl con in panHoaDon.Controls)
            {
                string indexString = new string(con.Name.Where(char.IsDigit).ToArray());

				System.Windows.Forms.TextBox txtSoLuong =
						con.Controls.Find("txtSoLuong" + indexString, true).FirstOrDefault() as System.Windows.Forms.TextBox;

				System.Windows.Forms.TextBox txtMaSP =
					   con.Controls.Find("txtMaMH" + indexString, true).FirstOrDefault() as System.Windows.Forms.TextBox;

				System.Windows.Forms.Label lblDonGiaBan =
					con.Controls.Find("lblDonGiaBan" + indexString, true).FirstOrDefault() as System.Windows.Forms.Label;

				System.Windows.Forms.Label lblThanhTien =
					con.Controls.Find("lblThanhTien" + indexString, true).FirstOrDefault() as System.Windows.Forms.Label;
				
				System.Windows.Forms.TextBox txtGiamGia =
					con.Controls.Find("txtGiamGiaMH" + indexString, true).FirstOrDefault() as System.Windows.Forms.TextBox;

				string MaMH = txtMaSP.Text;
                int SLBan = 0;
                if (txtSoLuong.Text.Trim() != "") SLBan = int.Parse(txtSoLuong.Text);
                float GiaBan = float.Parse(lblDonGiaBan.Text);
                float ThanhTien = float.Parse(lblThanhTien.Text);
                int GiamGiaMH = 0;
                if (txtGiamGia.Text.Trim() != "") GiamGiaMH = int.Parse(txtGiamGia.Text);

				if (txtSoLuong.ForeColor == Color.Red)
                {
                    MessageBox.Show("Mã hàng " + MaMH + " đã vượt quá số lượng tồn nên không thể thêm vào hóa đơn", "Thông báo", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (SLBan == 0)
                {
                    continue;
				}
                else
                {
                    string sqlUpdateSLTon = string.Format("update tMatHang set SLTon = SLTon - {0} where MaMH = N'{1}'", SLBan, MaMH);
                    string sqlInsertChiTietHDB = string.Format("insert into tChiTietHDB(MaHDB, MaMH, SLBan, GiaBan, GiamGia, ThanhTien) " +
                        "values(N'{0}', N'{1}', {2}, {3}, {4}, {5})", MaHDB, MaMH, SLBan, GiaBan, GiamGiaMH, ThanhTien);
                    //MessageBox.Show(sqlInsertChiTietHDB);
					dataProcesser.ChangeData(sqlInsertChiTietHDB);
					dataProcesser.ChangeData(sqlUpdateSLTon);
				}
			}
            // Hiện chi tiết hóa đơn bán
            Forms.HoaDonBan.frmChiTietHDB frmChiTiet = new HoaDonBan.frmChiTietHDB(MaHDB);
            frmChiTiet.ShowDialog();

            // Xóa các control hiện tại
            MaKH = null;
			panHoaDon.Controls.Clear();
            btnXoaKH.PerformClick();
            grbPhuongThucTT.Visible = false;
            txtGhiChuHD.Text = "";
            txtTongTienHang.Text = "0";
            txtGiamGia.Text = "0";
            txtKhachCanTra.Text = "0";
        }

		private void btnQuanLy_Click(object sender, EventArgs e)
		{
            this.Hide();
            Forms.frmQuanLy frmQuanLy = new frmQuanLy();
            frmQuanLy.ShowDialog();
            frmQuanLy = null;
			conMenu.Visible = false;
			this.Show();
		}

		private void frmBanHang_KeyDown(object sender, KeyEventArgs e)
		{
            commonFunc.exit_Aplication(sender, e);
		}
	}
}

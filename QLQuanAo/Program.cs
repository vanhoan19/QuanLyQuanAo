using QLQuanAo.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLQuanAo
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
			//Application.Run(new Forms.BanHang.frmBanHang());
			//Application.Run(new Forms.HangHoa.frmThemHH());
			Application.Run(new Forms.frmDangNhap());
			//Application.Run(new Forms.frmQuanLy());
			//Application.Run(new Forms.KhachHang.frmDanhMucKH());
			//Application.Run(new Forms.HangHoa.frmDanhMucHH());
			//Application.Run(new Forms.HangHoa.frmCapNhatHH("AHD0511231.đen.L"));
			//Application.Run(new Forms.NhaCungCap.frmCapNhatNCC());
			//Application.Run(new Forms.NhaCungCap.frmDanhMucNCC());
			//Application.Run(new Forms.KhachHang.frmKhachHang());
			//Application.Run(new Forms.HoaDonBan.frmChiTietHDB());
			//Application.Run(new Forms.HoaDonBan.frmHoaDonBan());
			//Application.Run(new Forms.HoaDonNhap.frmHoaDonNhap());
			//Application.Run(new Forms.NhanVien.frmNhanVien());
		}
	}
}

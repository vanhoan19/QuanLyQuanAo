USE [QuanLyQuanAo]
GO
/****** Object:  UserDefinedFunction [dbo].[FirstDayOfLastWeek]    Script Date: 20/12/2023 19:10:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[FirstDayOfLastWeek]() returns date
as
begin
	DECLARE @FirstDayOfLastWeek date;
	SET @FirstDayOfLastWeek = DATEADD(WEEK, -1, dbo.FirstDayOfWeek());
	return @FirstDayOfLastWeek
end
GO
/****** Object:  UserDefinedFunction [dbo].[FirstDayOfWeek]    Script Date: 20/12/2023 19:10:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[FirstDayOfWeek]() returns date
as
begin
	DECLARE @FirstDayOfWeek date;
	SET @FirstDayOfWeek = DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), 0);		
	return @FirstDayOfWeek
end
GO
/****** Object:  UserDefinedFunction [dbo].[LastDayOfLastWeek]    Script Date: 20/12/2023 19:10:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[LastDayOfLastWeek]() returns date
as
begin
	DECLARE @LastDayOfLastWeek date;
	SET @LastDayOfLastWeek = DATEADD(DAY, 6, dbo.FirstDayOfLastWeek());
	return @LastDayOfLastWeek
end
GO
/****** Object:  Table [dbo].[tPhieuNhap]    Script Date: 20/12/2023 19:10:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tPhieuNhap](
	[MaPN] [nvarchar](50) NOT NULL,
	[MaNV] [nvarchar](50) NOT NULL,
	[TongTien] [decimal](18, 2) NOT NULL,
	[GiamGia] [decimal](18, 2) NULL,
	[ThanhToan] [decimal](18, 2) NOT NULL,
	[PhuongThucTT] [bit] NOT NULL,
	[GhiChu] [nvarchar](500) NULL,
	[NgayNhap] [datetime] NOT NULL,
	[TrangThai] [bit] NULL,
 CONSTRAINT [PK_tPhieuNhap] PRIMARY KEY CLUSTERED 
(
	[MaPN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[phieuNhap_select]    Script Date: 20/12/2023 19:10:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE view [dbo].[phieuNhap_select]
as
select MaPN, MaNV,NgayNhap,iif(PhuongThucTT=1,N'Chuyển khoản',N'Tiền mặt') as PhuongThucTT, 
		TongTien,GiamGia,ThanhToan, iif(TrangThai=1,N'Đã hoàn thành',N'Chưa hoàn thành') as TrangThai 
from tPhieuNhap
GO
/****** Object:  Table [dbo].[tChiTietHDB]    Script Date: 20/12/2023 19:10:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tChiTietHDB](
	[MaHDB] [nvarchar](50) NOT NULL,
	[MaMH] [nvarchar](100) NOT NULL,
	[SLBan] [int] NOT NULL,
	[GiaBan] [decimal](18, 2) NOT NULL,
	[ThanhTien] [decimal](18, 2) NULL,
	[GiamGia] [int] NULL,
 CONSTRAINT [PK_tChiTietHDB] PRIMARY KEY CLUSTERED 
(
	[MaHDB] ASC,
	[MaMH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tHoaDonBan]    Script Date: 20/12/2023 19:10:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tHoaDonBan](
	[MaHDB] [nvarchar](50) NOT NULL,
	[MaNV] [nvarchar](50) NOT NULL,
	[MaKH] [nvarchar](50) NOT NULL,
	[TongTien] [decimal](18, 2) NULL,
	[GiamGia] [decimal](18, 2) NULL,
	[ThanhToan] [decimal](18, 2) NULL,
	[PhuongThucTT] [bit] NOT NULL,
	[ThoiGianTT] [datetime] NOT NULL,
	[GhiChu] [nvarchar](500) NULL,
 CONSTRAINT [PK_tHoaDonBan] PRIMARY KEY CLUSTERED 
(
	[MaHDB] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tTheLoai]    Script Date: 20/12/2023 19:10:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tTheLoai](
	[MaTheLoai] [nvarchar](50) NOT NULL,
	[TenTheLoai] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_tTheLoai] PRIMARY KEY CLUSTERED 
(
	[MaTheLoai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tMatHang]    Script Date: 20/12/2023 19:10:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tMatHang](
	[MaMH] [nvarchar](100) NOT NULL,
	[TenMH] [nvarchar](200) NOT NULL,
	[MaTheLoai] [nvarchar](50) NOT NULL,
	[Mau] [nvarchar](50) NULL,
	[Size] [nvarchar](50) NOT NULL,
	[MaNCC] [nvarchar](50) NOT NULL,
	[GiaBan] [decimal](18, 2) NOT NULL,
	[GiaNhap] [decimal](18, 2) NULL,
	[SLTon] [int] NULL,
	[Anh] [nvarchar](200) NULL,
	[GhiChu] [nvarchar](1000) NULL,
	[DonVi] [nvarchar](50) NULL,
	[IsDangBan] [bit] NULL,
 CONSTRAINT [PK_tMatHang] PRIMARY KEY CLUSTERED 
(
	[MaMH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  UserDefinedFunction [dbo].[DoanhThu_NhomHang]    Script Date: 20/12/2023 19:10:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[DoanhThu_NhomHang] (@thang date, @nam date)
returns table
as return(
	select TenTheLoai, isnull(sum(SLBan),0) as SLBan
	from tMatHang right join tChiTietHDB on tMatHang.MaMH= tChiTietHDB.MaMH 
					 join tHoaDonBan on tHoaDonBan.MaHDB= tChiTietHDB.MaHDB
					right join tTheLoai on tMatHang.MaTheLoai= tTheLoai.MaTheLoai
	where year(ThoiGianTT)= year(@nam) and MONTH(ThoiGianTT)=month(@thang)
	group by TenTheLoai
)
GO
/****** Object:  UserDefinedFunction [dbo].[DoanhThu_NhomHang_Nam]    Script Date: 20/12/2023 19:10:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[DoanhThu_NhomHang_Nam] ( @nam date)
returns table
as return(
	select TenTheLoai, isnull(sum(SLBan),0) as SLBan
	from tMatHang right join tChiTietHDB on tMatHang.MaMH= tChiTietHDB.MaMH 
					 join tHoaDonBan on tHoaDonBan.MaHDB= tChiTietHDB.MaHDB
					right join tTheLoai on tMatHang.MaTheLoai= tTheLoai.MaTheLoai
	where year(ThoiGianTT)= year(@nam) 
	group by TenTheLoai
)
GO
/****** Object:  UserDefinedFunction [dbo].[DoanhThu_NhomHang_6thang]    Script Date: 20/12/2023 19:10:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[DoanhThu_NhomHang_6thang] ()
returns table
as return(
	select TenTheLoai, isnull(sum(SLBan),0) as SLBan
	from tMatHang right join tChiTietHDB on tMatHang.MaMH= tChiTietHDB.MaMH 
					 join tHoaDonBan on tHoaDonBan.MaHDB= tChiTietHDB.MaHDB
					right join tTheLoai on tMatHang.MaTheLoai= tTheLoai.MaTheLoai
	where  month(ThoiGianTT)-6 between 0 and 6
	group by TenTheLoai
)
GO
/****** Object:  Table [dbo].[tChiTietPN]    Script Date: 20/12/2023 19:10:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tChiTietPN](
	[MaPN] [nvarchar](50) NOT NULL,
	[MaMH] [nvarchar](100) NOT NULL,
	[SLNhap] [int] NOT NULL,
	[GiaNhap] [decimal](18, 2) NULL,
 CONSTRAINT [PK_ttChiTietPN] PRIMARY KEY CLUSTERED 
(
	[MaPN] ASC,
	[MaMH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tKhachHang]    Script Date: 20/12/2023 19:10:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tKhachHang](
	[MaKH] [nvarchar](50) NOT NULL,
	[TenKH] [nvarchar](100) NULL,
	[SDT] [nvarchar](100) NOT NULL,
	[GioiTinh] [bit] NOT NULL,
	[DiaChi] [nvarchar](100) NULL,
	[Anh] [nvarchar](100) NULL,
	[GhiChu] [nvarchar](1000) NULL,
	[NgaySinh] [datetime] NULL,
	[MaNV] [nvarchar](50) NOT NULL,
	[NgayTaoKH] [datetime] NOT NULL,
	[TongBan] [decimal](18, 2) NULL,
 CONSTRAINT [PK_tKhachHang] PRIMARY KEY CLUSTERED 
(
	[MaKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tNhaCungCap]    Script Date: 20/12/2023 19:10:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tNhaCungCap](
	[MaNCC] [nvarchar](50) NOT NULL,
	[TenNCC] [nvarchar](100) NOT NULL,
	[SDT] [nvarchar](50) NOT NULL,
	[DiaChi] [nvarchar](150) NULL,
	[GhiChu] [nvarchar](1000) NULL,
 CONSTRAINT [PK_tNhaCungCap] PRIMARY KEY CLUSTERED 
(
	[MaNCC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tNhanVien]    Script Date: 20/12/2023 19:10:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tNhanVien](
	[MaNV] [nvarchar](50) NOT NULL,
	[TenNV] [nvarchar](100) NOT NULL,
	[GioiTinh] [bit] NOT NULL,
	[NgaySinh] [date] NOT NULL,
	[NgayBD] [date] NOT NULL,
	[SDT] [nvarchar](50) NULL,
	[UserName] [nvarchar](50) NULL,
	[PassWord] [nvarchar](100) NULL,
	[Role] [bit] NULL,
	[IsDangLam] [bit] NULL,
	[Anh] [nvarchar](100) NULL,
 CONSTRAINT [PK_tNhanVien] PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[tChiTietHDB] ([MaHDB], [MaMH], [SLBan], [GiaBan], [ThanhTien], [GiamGia]) VALUES (N'HDB00001', N'APL230001.ghi.M', 1, CAST(450000.00 AS Decimal(18, 2)), CAST(450000.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[tChiTietHDB] ([MaHDB], [MaMH], [SLBan], [GiaBan], [ThanhTien], [GiamGia]) VALUES (N'HDB00002', N'QJM5005.xanh đậm.32', 1, CAST(400000.00 AS Decimal(18, 2)), CAST(320000.00 AS Decimal(18, 2)), 20)
INSERT [dbo].[tChiTietHDB] ([MaHDB], [MaMH], [SLBan], [GiaBan], [ThanhTien], [GiamGia]) VALUES (N'HDB00003', N'AHD0511231.đen.L', 1, CAST(3250000.00 AS Decimal(18, 2)), CAST(2925000.00 AS Decimal(18, 2)), 10)
INSERT [dbo].[tChiTietHDB] ([MaHDB], [MaMH], [SLBan], [GiaBan], [ThanhTien], [GiamGia]) VALUES (N'HDB00003', N'AHD0511231.đen.M', 1, CAST(3250000.00 AS Decimal(18, 2)), CAST(2925000.00 AS Decimal(18, 2)), 10)
INSERT [dbo].[tChiTietHDB] ([MaHDB], [MaMH], [SLBan], [GiaBan], [ThanhTien], [GiamGia]) VALUES (N'HDB00004', N'QS230001.be.M', 1, CAST(500000.00 AS Decimal(18, 2)), CAST(450000.00 AS Decimal(18, 2)), 10)
INSERT [dbo].[tChiTietHDB] ([MaHDB], [MaMH], [SLBan], [GiaBan], [ThanhTien], [GiamGia]) VALUES (N'HDB00004', N'QS230001.be.S', 1, CAST(500000.00 AS Decimal(18, 2)), CAST(450000.00 AS Decimal(18, 2)), 10)
INSERT [dbo].[tChiTietHDB] ([MaHDB], [MaMH], [SLBan], [GiaBan], [ThanhTien], [GiamGia]) VALUES (N'HDB00005', N'APL230001.ghi.L', 2, CAST(450000.00 AS Decimal(18, 2)), CAST(810000.00 AS Decimal(18, 2)), 10)
INSERT [dbo].[tChiTietHDB] ([MaHDB], [MaMH], [SLBan], [GiaBan], [ThanhTien], [GiamGia]) VALUES (N'HDB00005', N'QJM5005.xanh đậm.33', 1, CAST(400000.00 AS Decimal(18, 2)), CAST(320000.00 AS Decimal(18, 2)), 20)
INSERT [dbo].[tChiTietHDB] ([MaHDB], [MaMH], [SLBan], [GiaBan], [ThanhTien], [GiamGia]) VALUES (N'HDB00006', N'AHD0511231.đen.L', 1, CAST(3250000.00 AS Decimal(18, 2)), CAST(2600000.00 AS Decimal(18, 2)), 20)
INSERT [dbo].[tChiTietHDB] ([MaHDB], [MaMH], [SLBan], [GiaBan], [ThanhTien], [GiamGia]) VALUES (N'HDB00006', N'AHD0511231.đen.S', 2, CAST(3250000.00 AS Decimal(18, 2)), CAST(5200000.00 AS Decimal(18, 2)), 20)
INSERT [dbo].[tChiTietHDB] ([MaHDB], [MaMH], [SLBan], [GiaBan], [ThanhTien], [GiamGia]) VALUES (N'HDB00007', N'AHD0511231.đen.M', 1, CAST(3250000.00 AS Decimal(18, 2)), CAST(2925000.00 AS Decimal(18, 2)), 10)
INSERT [dbo].[tChiTietHDB] ([MaHDB], [MaMH], [SLBan], [GiaBan], [ThanhTien], [GiamGia]) VALUES (N'HDB00008', N'AHD0511231.đen.S', 1, CAST(3250000.00 AS Decimal(18, 2)), CAST(2600000.00 AS Decimal(18, 2)), 20)
INSERT [dbo].[tChiTietHDB] ([MaHDB], [MaMH], [SLBan], [GiaBan], [ThanhTien], [GiamGia]) VALUES (N'HDB00009', N'AHD0511231.đen.L', 1, CAST(3250000.00 AS Decimal(18, 2)), CAST(2925000.00 AS Decimal(18, 2)), 10)
INSERT [dbo].[tChiTietHDB] ([MaHDB], [MaMH], [SLBan], [GiaBan], [ThanhTien], [GiamGia]) VALUES (N'HDB00009', N'AHD0511231.đen.XL', 1, CAST(3250000.00 AS Decimal(18, 2)), CAST(2925000.00 AS Decimal(18, 2)), 10)
INSERT [dbo].[tChiTietHDB] ([MaHDB], [MaMH], [SLBan], [GiaBan], [ThanhTien], [GiamGia]) VALUES (N'HDB00010', N'AHD0511231.đen.M', 1, CAST(3250000.00 AS Decimal(18, 2)), CAST(2275000.00 AS Decimal(18, 2)), 30)
INSERT [dbo].[tChiTietHDB] ([MaHDB], [MaMH], [SLBan], [GiaBan], [ThanhTien], [GiamGia]) VALUES (N'HDB00011', N'AHD0511231.đen.M', 1, CAST(3250000.00 AS Decimal(18, 2)), CAST(2925000.00 AS Decimal(18, 2)), 10)
INSERT [dbo].[tChiTietHDB] ([MaHDB], [MaMH], [SLBan], [GiaBan], [ThanhTien], [GiamGia]) VALUES (N'HDB00012', N'AHD0511231.đen.L', 2, CAST(3250000.00 AS Decimal(18, 2)), CAST(5850000.00 AS Decimal(18, 2)), 10)
INSERT [dbo].[tChiTietHDB] ([MaHDB], [MaMH], [SLBan], [GiaBan], [ThanhTien], [GiamGia]) VALUES (N'HDB00014', N'AHD0511231.đen.L', 1, CAST(3250000.00 AS Decimal(18, 2)), CAST(3250000.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[tChiTietHDB] ([MaHDB], [MaMH], [SLBan], [GiaBan], [ThanhTien], [GiamGia]) VALUES (N'HDB00014', N'QJM5005.xanh đậm.30', 2, CAST(400000.00 AS Decimal(18, 2)), CAST(720000.00 AS Decimal(18, 2)), 10)
INSERT [dbo].[tChiTietHDB] ([MaHDB], [MaMH], [SLBan], [GiaBan], [ThanhTien], [GiamGia]) VALUES (N'HDB00015', N'AHD0511231.đen.M', 1, CAST(3250000.00 AS Decimal(18, 2)), CAST(2762500.00 AS Decimal(18, 2)), 15)
GO
INSERT [dbo].[tChiTietPN] ([MaPN], [MaMH], [SLNhap], [GiaNhap]) VALUES (N'PN000001', N'APL230001.ghi.L', 5, CAST(300000.00 AS Decimal(18, 2)))
INSERT [dbo].[tChiTietPN] ([MaPN], [MaMH], [SLNhap], [GiaNhap]) VALUES (N'PN000001', N'APL230001.ghi.M', 5, CAST(300000.00 AS Decimal(18, 2)))
INSERT [dbo].[tChiTietPN] ([MaPN], [MaMH], [SLNhap], [GiaNhap]) VALUES (N'PN000001', N'APL230001.ghi.S', 5, CAST(300000.00 AS Decimal(18, 2)))
INSERT [dbo].[tChiTietPN] ([MaPN], [MaMH], [SLNhap], [GiaNhap]) VALUES (N'PN000001', N'APL230001.ghi.XL', 5, CAST(300000.00 AS Decimal(18, 2)))
INSERT [dbo].[tChiTietPN] ([MaPN], [MaMH], [SLNhap], [GiaNhap]) VALUES (N'PN000002', N'AHD0511231.đen.L', 10, CAST(2000000.00 AS Decimal(18, 2)))
INSERT [dbo].[tChiTietPN] ([MaPN], [MaMH], [SLNhap], [GiaNhap]) VALUES (N'PN000002', N'AHD0511231.đen.M', 10, CAST(2000000.00 AS Decimal(18, 2)))
INSERT [dbo].[tChiTietPN] ([MaPN], [MaMH], [SLNhap], [GiaNhap]) VALUES (N'PN000002', N'AHD0511231.đen.S', 5, CAST(2000000.00 AS Decimal(18, 2)))
INSERT [dbo].[tChiTietPN] ([MaPN], [MaMH], [SLNhap], [GiaNhap]) VALUES (N'PN000002', N'AHD0511231.trắng.L', 10, CAST(2000000.00 AS Decimal(18, 2)))
INSERT [dbo].[tChiTietPN] ([MaPN], [MaMH], [SLNhap], [GiaNhap]) VALUES (N'PN000002', N'AHD0511231.trắng.M', 10, CAST(2000000.00 AS Decimal(18, 2)))
INSERT [dbo].[tChiTietPN] ([MaPN], [MaMH], [SLNhap], [GiaNhap]) VALUES (N'PN000003', N'AHD061120232.Đen.L', 10, CAST(500000.00 AS Decimal(18, 2)))
INSERT [dbo].[tChiTietPN] ([MaPN], [MaMH], [SLNhap], [GiaNhap]) VALUES (N'PN000003', N'AHD061120232.Đen.S', 10, CAST(500000.00 AS Decimal(18, 2)))
INSERT [dbo].[tChiTietPN] ([MaPN], [MaMH], [SLNhap], [GiaNhap]) VALUES (N'PN000003', N'AHD061120232.Đen.XL', 10, CAST(500000.00 AS Decimal(18, 2)))
INSERT [dbo].[tChiTietPN] ([MaPN], [MaMH], [SLNhap], [GiaNhap]) VALUES (N'PN000003', N'QJM5005.xanh đậm.30', 10, CAST(250000.00 AS Decimal(18, 2)))
INSERT [dbo].[tChiTietPN] ([MaPN], [MaMH], [SLNhap], [GiaNhap]) VALUES (N'PN000003', N'QJM5005.xanh đậm.31', 10, CAST(250000.00 AS Decimal(18, 2)))
INSERT [dbo].[tChiTietPN] ([MaPN], [MaMH], [SLNhap], [GiaNhap]) VALUES (N'PN000003', N'QJM5005.xanh đậm.32', 10, CAST(250000.00 AS Decimal(18, 2)))
INSERT [dbo].[tChiTietPN] ([MaPN], [MaMH], [SLNhap], [GiaNhap]) VALUES (N'PN000003', N'QJM5005.xanh đậm.33', 10, CAST(250000.00 AS Decimal(18, 2)))
INSERT [dbo].[tChiTietPN] ([MaPN], [MaMH], [SLNhap], [GiaNhap]) VALUES (N'PN000003', N'qjm6005.Xanh nhạt.29', 10, CAST(350000.00 AS Decimal(18, 2)))
INSERT [dbo].[tChiTietPN] ([MaPN], [MaMH], [SLNhap], [GiaNhap]) VALUES (N'PN000003', N'qjm6005.Xanh nhạt.30', 10, CAST(350000.00 AS Decimal(18, 2)))
INSERT [dbo].[tChiTietPN] ([MaPN], [MaMH], [SLNhap], [GiaNhap]) VALUES (N'PN000003', N'qjm6005.Xanh nhạt.33', 10, CAST(350000.00 AS Decimal(18, 2)))
INSERT [dbo].[tChiTietPN] ([MaPN], [MaMH], [SLNhap], [GiaNhap]) VALUES (N'PN000004', N'AHD0511231.đen.L', 10, CAST(2000000.00 AS Decimal(18, 2)))
INSERT [dbo].[tChiTietPN] ([MaPN], [MaMH], [SLNhap], [GiaNhap]) VALUES (N'PN000004', N'AHD0511231.đen.M', 10, CAST(2000000.00 AS Decimal(18, 2)))
INSERT [dbo].[tChiTietPN] ([MaPN], [MaMH], [SLNhap], [GiaNhap]) VALUES (N'PN000004', N'AHD0511231.đen.S', 10, CAST(2000000.00 AS Decimal(18, 2)))
INSERT [dbo].[tChiTietPN] ([MaPN], [MaMH], [SLNhap], [GiaNhap]) VALUES (N'PN000005', N'AHD0511231.đen.XL', 10, CAST(2000000.00 AS Decimal(18, 2)))
INSERT [dbo].[tChiTietPN] ([MaPN], [MaMH], [SLNhap], [GiaNhap]) VALUES (N'PN000005', N'AHD0511231.trắng.L', 10, CAST(2000000.00 AS Decimal(18, 2)))
INSERT [dbo].[tChiTietPN] ([MaPN], [MaMH], [SLNhap], [GiaNhap]) VALUES (N'PN000005', N'AHD0511231.trắng.S', 10, CAST(2000000.00 AS Decimal(18, 2)))
INSERT [dbo].[tChiTietPN] ([MaPN], [MaMH], [SLNhap], [GiaNhap]) VALUES (N'PN000005', N'AHD0611231.Ghi.M', 10, CAST(1000000.00 AS Decimal(18, 2)))
INSERT [dbo].[tChiTietPN] ([MaPN], [MaMH], [SLNhap], [GiaNhap]) VALUES (N'PN000006', N'QS230001.be.L', 10, CAST(300000.00 AS Decimal(18, 2)))
INSERT [dbo].[tChiTietPN] ([MaPN], [MaMH], [SLNhap], [GiaNhap]) VALUES (N'PN000006', N'QS230001.be.M', 10, CAST(300000.00 AS Decimal(18, 2)))
INSERT [dbo].[tChiTietPN] ([MaPN], [MaMH], [SLNhap], [GiaNhap]) VALUES (N'PN000006', N'QS230001.be.S', 10, CAST(300000.00 AS Decimal(18, 2)))
INSERT [dbo].[tChiTietPN] ([MaPN], [MaMH], [SLNhap], [GiaNhap]) VALUES (N'PN000007', N'QS230001.be.L', 5, CAST(300000.00 AS Decimal(18, 2)))
INSERT [dbo].[tChiTietPN] ([MaPN], [MaMH], [SLNhap], [GiaNhap]) VALUES (N'PN000008', N'AHD0511231.đen.S', 10, CAST(2000000.00 AS Decimal(18, 2)))
INSERT [dbo].[tChiTietPN] ([MaPN], [MaMH], [SLNhap], [GiaNhap]) VALUES (N'PN000008', N'AHD0611231.Ghi.XS', 10, CAST(1000000.00 AS Decimal(18, 2)))
INSERT [dbo].[tChiTietPN] ([MaPN], [MaMH], [SLNhap], [GiaNhap]) VALUES (N'PN000009', N'AHD0511231.đen.M', 10, CAST(2000000.00 AS Decimal(18, 2)))
INSERT [dbo].[tChiTietPN] ([MaPN], [MaMH], [SLNhap], [GiaNhap]) VALUES (N'PN000009', N'AHD0611231.Tím.M', 5, CAST(1000000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[tHoaDonBan] ([MaHDB], [MaNV], [MaKH], [TongTien], [GiamGia], [ThanhToan], [PhuongThucTT], [ThoiGianTT], [GhiChu]) VALUES (N'HDB00001', N'NV000001', N'KH000004', CAST(450000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(450000.00 AS Decimal(18, 2)), 0, CAST(N'2022-11-15T11:47:03.113' AS DateTime), N'')
INSERT [dbo].[tHoaDonBan] ([MaHDB], [MaNV], [MaKH], [TongTien], [GiamGia], [ThanhToan], [PhuongThucTT], [ThoiGianTT], [GhiChu]) VALUES (N'HDB00002', N'NV000002', N'KH000002', CAST(400000.00 AS Decimal(18, 2)), CAST(80000.00 AS Decimal(18, 2)), CAST(320000.00 AS Decimal(18, 2)), 1, CAST(N'2023-10-15T10:46:50.560' AS DateTime), N'ck')
INSERT [dbo].[tHoaDonBan] ([MaHDB], [MaNV], [MaKH], [TongTien], [GiamGia], [ThanhToan], [PhuongThucTT], [ThoiGianTT], [GhiChu]) VALUES (N'HDB00003', N'NV000001', N'KH000001', CAST(6500000.00 AS Decimal(18, 2)), CAST(650000.00 AS Decimal(18, 2)), CAST(5850000.00 AS Decimal(18, 2)), 1, CAST(N'2023-11-14T10:47:42.847' AS DateTime), N'ck 15/11')
INSERT [dbo].[tHoaDonBan] ([MaHDB], [MaNV], [MaKH], [TongTien], [GiamGia], [ThanhToan], [PhuongThucTT], [ThoiGianTT], [GhiChu]) VALUES (N'HDB00004', N'NV000001', N'KH000002', CAST(1000000.00 AS Decimal(18, 2)), CAST(100000.00 AS Decimal(18, 2)), CAST(900000.00 AS Decimal(18, 2)), 1, CAST(N'2023-11-14T11:47:42.107' AS DateTime), N'')
INSERT [dbo].[tHoaDonBan] ([MaHDB], [MaNV], [MaKH], [TongTien], [GiamGia], [ThanhToan], [PhuongThucTT], [ThoiGianTT], [GhiChu]) VALUES (N'HDB00005', N'NV000001', N'KH000009', CAST(1300000.00 AS Decimal(18, 2)), CAST(170000.00 AS Decimal(18, 2)), CAST(1130000.00 AS Decimal(18, 2)), 0, CAST(N'2023-11-07T11:15:58.850' AS DateTime), N'tm')
INSERT [dbo].[tHoaDonBan] ([MaHDB], [MaNV], [MaKH], [TongTien], [GiamGia], [ThanhToan], [PhuongThucTT], [ThoiGianTT], [GhiChu]) VALUES (N'HDB00006', N'NV000001', N'KH000001', CAST(9750000.00 AS Decimal(18, 2)), CAST(1950000.00 AS Decimal(18, 2)), CAST(7800000.00 AS Decimal(18, 2)), 0, CAST(N'2023-11-15T11:48:35.633' AS DateTime), N'')
INSERT [dbo].[tHoaDonBan] ([MaHDB], [MaNV], [MaKH], [TongTien], [GiamGia], [ThanhToan], [PhuongThucTT], [ThoiGianTT], [GhiChu]) VALUES (N'HDB00007', N'NV000001', N'KH000002', CAST(3250000.00 AS Decimal(18, 2)), CAST(325000.00 AS Decimal(18, 2)), CAST(2925000.00 AS Decimal(18, 2)), 0, CAST(N'2023-10-15T11:50:29.610' AS DateTime), N'')
INSERT [dbo].[tHoaDonBan] ([MaHDB], [MaNV], [MaKH], [TongTien], [GiamGia], [ThanhToan], [PhuongThucTT], [ThoiGianTT], [GhiChu]) VALUES (N'HDB00008', N'NV000001', N'KH000002', CAST(3250000.00 AS Decimal(18, 2)), CAST(650000.00 AS Decimal(18, 2)), CAST(2600000.00 AS Decimal(18, 2)), 0, CAST(N'2023-11-15T11:50:50.290' AS DateTime), N'')
INSERT [dbo].[tHoaDonBan] ([MaHDB], [MaNV], [MaKH], [TongTien], [GiamGia], [ThanhToan], [PhuongThucTT], [ThoiGianTT], [GhiChu]) VALUES (N'HDB00009', N'NV000001', N'KH000006', CAST(6500000.00 AS Decimal(18, 2)), CAST(650000.00 AS Decimal(18, 2)), CAST(5850000.00 AS Decimal(18, 2)), 1, CAST(N'2023-11-14T11:52:16.243' AS DateTime), N'')
INSERT [dbo].[tHoaDonBan] ([MaHDB], [MaNV], [MaKH], [TongTien], [GiamGia], [ThanhToan], [PhuongThucTT], [ThoiGianTT], [GhiChu]) VALUES (N'HDB00010', N'NV000003', N'KH000011', CAST(3250000.00 AS Decimal(18, 2)), CAST(975000.00 AS Decimal(18, 2)), CAST(2275000.00 AS Decimal(18, 2)), 0, CAST(N'2022-11-15T11:53:55.237' AS DateTime), N'')
INSERT [dbo].[tHoaDonBan] ([MaHDB], [MaNV], [MaKH], [TongTien], [GiamGia], [ThanhToan], [PhuongThucTT], [ThoiGianTT], [GhiChu]) VALUES (N'HDB00011', N'NV000004', N'KH000001', CAST(3250000.00 AS Decimal(18, 2)), CAST(325000.00 AS Decimal(18, 2)), CAST(2925000.00 AS Decimal(18, 2)), 0, CAST(N'2022-11-15T12:01:21.530' AS DateTime), N'')
INSERT [dbo].[tHoaDonBan] ([MaHDB], [MaNV], [MaKH], [TongTien], [GiamGia], [ThanhToan], [PhuongThucTT], [ThoiGianTT], [GhiChu]) VALUES (N'HDB00012', N'NV000004', N'KH000005', CAST(6500000.00 AS Decimal(18, 2)), CAST(650000.00 AS Decimal(18, 2)), CAST(5850000.00 AS Decimal(18, 2)), 0, CAST(N'2022-11-15T12:01:50.237' AS DateTime), N'')
INSERT [dbo].[tHoaDonBan] ([MaHDB], [MaNV], [MaKH], [TongTien], [GiamGia], [ThanhToan], [PhuongThucTT], [ThoiGianTT], [GhiChu]) VALUES (N'HDB00013', N'NV000003', N'KH000001', CAST(1000000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(1000000.00 AS Decimal(18, 2)), 0, CAST(N'2023-11-15T15:37:55.593' AS DateTime), N'')
INSERT [dbo].[tHoaDonBan] ([MaHDB], [MaNV], [MaKH], [TongTien], [GiamGia], [ThanhToan], [PhuongThucTT], [ThoiGianTT], [GhiChu]) VALUES (N'HDB00014', N'NV000002', N'KH000001', CAST(4050000.00 AS Decimal(18, 2)), CAST(80000.00 AS Decimal(18, 2)), CAST(3970000.00 AS Decimal(18, 2)), 0, CAST(N'2023-11-15T16:04:07.990' AS DateTime), N'')
INSERT [dbo].[tHoaDonBan] ([MaHDB], [MaNV], [MaKH], [TongTien], [GiamGia], [ThanhToan], [PhuongThucTT], [ThoiGianTT], [GhiChu]) VALUES (N'HDB00015', N'NV000002', N'KH000002', CAST(3250000.00 AS Decimal(18, 2)), CAST(500000.00 AS Decimal(18, 2)), CAST(2762500.00 AS Decimal(18, 2)), 0, CAST(N'2023-11-16T09:27:27.470' AS DateTime), N'')
GO
INSERT [dbo].[tKhachHang] ([MaKH], [TenKH], [SDT], [GioiTinh], [DiaChi], [Anh], [GhiChu], [NgaySinh], [MaNV], [NgayTaoKH], [TongBan]) VALUES (N'KH000001', N'Võ Hoàng Sơn', N'0345678914', 1, N'Cửa Lò - Nghệ An', N'VHS 1.jpg', N'khách vip', CAST(N'2003-11-11T00:00:00.000' AS DateTime), N'NV000001', CAST(N'2023-11-03T22:03:17.607' AS DateTime), CAST(21545000.00 AS Decimal(18, 2)))
INSERT [dbo].[tKhachHang] ([MaKH], [TenKH], [SDT], [GioiTinh], [DiaChi], [Anh], [GhiChu], [NgaySinh], [MaNV], [NgayTaoKH], [TongBan]) VALUES (N'KH000002', N'Nguyễn Thành Đạt', N'0456789455', 1, N'Thường Tín - Hà Nội', N'WIN_20231010_10_05_15_Pro.jpg', N'Nghịch tử Thường Tín', CAST(N'2023-11-07T00:00:00.000' AS DateTime), N'NV000001', CAST(N'2023-11-03T23:09:40.150' AS DateTime), CAST(9507500.00 AS Decimal(18, 2)))
INSERT [dbo].[tKhachHang] ([MaKH], [TenKH], [SDT], [GioiTinh], [DiaChi], [Anh], [GhiChu], [NgaySinh], [MaNV], [NgayTaoKH], [TongBan]) VALUES (N'KH000003', N'Phú Quốc', N'02233445566', 0, N'Phú Quốc', N'phú quốc.jpg', N'', NULL, N'NV000001', CAST(N'2023-11-04T13:54:22.087' AS DateTime), CAST(0.00 AS Decimal(18, 2)))
INSERT [dbo].[tKhachHang] ([MaKH], [TenKH], [SDT], [GioiTinh], [DiaChi], [Anh], [GhiChu], [NgaySinh], [MaNV], [NgayTaoKH], [TongBan]) VALUES (N'KH000004', N'Nguyễn Việt Hoàng', N'0369382135', 1, N'Thanh Thủy - Phú Thọ', N'Hoàng nổ.jpg', N'nổ to nhất Phú Thọ', CAST(N'2003-11-10T00:00:00.000' AS DateTime), N'NV000001', CAST(N'2023-11-08T19:57:31.180' AS DateTime), CAST(450000.00 AS Decimal(18, 2)))
INSERT [dbo].[tKhachHang] ([MaKH], [TenKH], [SDT], [GioiTinh], [DiaChi], [Anh], [GhiChu], [NgaySinh], [MaNV], [NgayTaoKH], [TongBan]) VALUES (N'KH000005', N'Lionel Messiuuu', N'02233555664', 1, N'Đông Triều - Quảng Ninh', N'Lionel Messi.jpg', N'', CAST(N'1987-07-19T00:00:00.000' AS DateTime), N'NV000001', CAST(N'2023-11-08T20:05:39.037' AS DateTime), CAST(5850000.00 AS Decimal(18, 2)))
INSERT [dbo].[tKhachHang] ([MaKH], [TenKH], [SDT], [GioiTinh], [DiaChi], [Anh], [GhiChu], [NgaySinh], [MaNV], [NgayTaoKH], [TongBan]) VALUES (N'KH000006', N'Nguyễn Đức Thắng', N'0936733182', 1, N'Quỳnh Phụ - Thái Bình', N'Đức Thắng.jpg', N'Thắng cá chép', CAST(N'2003-02-10T00:00:00.000' AS DateTime), N'NV000001', CAST(N'2023-11-08T20:07:44.280' AS DateTime), CAST(5850000.00 AS Decimal(18, 2)))
INSERT [dbo].[tKhachHang] ([MaKH], [TenKH], [SDT], [GioiTinh], [DiaChi], [Anh], [GhiChu], [NgaySinh], [MaNV], [NgayTaoKH], [TongBan]) VALUES (N'KH000007', N'Hoàng Hà', N'01919191919', 0, N'Hà Tĩnh', N'Hoàng Hà.jpg', N'', CAST(N'2003-11-07T00:00:00.000' AS DateTime), N'NV000001', CAST(N'2023-11-08T20:11:59.237' AS DateTime), CAST(0.00 AS Decimal(18, 2)))
INSERT [dbo].[tKhachHang] ([MaKH], [TenKH], [SDT], [GioiTinh], [DiaChi], [Anh], [GhiChu], [NgaySinh], [MaNV], [NgayTaoKH], [TongBan]) VALUES (N'KH000008', N'Nguyễn Hà Trường', N'0364574223', 1, N'Đông Hưng - Thái Bình', N'Hà Trường.jpg', N'Trường Gấu Korrea', CAST(N'2003-07-17T00:00:00.000' AS DateTime), N'NV000001', CAST(N'2023-11-08T20:17:49.263' AS DateTime), CAST(0.00 AS Decimal(18, 2)))
INSERT [dbo].[tKhachHang] ([MaKH], [TenKH], [SDT], [GioiTinh], [DiaChi], [Anh], [GhiChu], [NgaySinh], [MaNV], [NgayTaoKH], [TongBan]) VALUES (N'KH000009', N'Nguyễn Tiến Đạt', N'05566447788', 1, N'Thanh Hóa', N'', N'', CAST(N'2002-07-12T00:00:00.000' AS DateTime), N'NV000001', CAST(N'2023-11-08T20:18:24.170' AS DateTime), CAST(1130000.00 AS Decimal(18, 2)))
INSERT [dbo].[tKhachHang] ([MaKH], [TenKH], [SDT], [GioiTinh], [DiaChi], [Anh], [GhiChu], [NgaySinh], [MaNV], [NgayTaoKH], [TongBan]) VALUES (N'KH000010', N'Nguyễn Công Minh', N'09999999999', 1, N'Thái Bình', N'', N'Minh Sex IT5', CAST(N'2004-07-23T00:00:00.000' AS DateTime), N'NV000001', CAST(N'2023-11-08T20:18:59.907' AS DateTime), CAST(0.00 AS Decimal(18, 2)))
INSERT [dbo].[tKhachHang] ([MaKH], [TenKH], [SDT], [GioiTinh], [DiaChi], [Anh], [GhiChu], [NgaySinh], [MaNV], [NgayTaoKH], [TongBan]) VALUES (N'KH000011', N'Đỗ Xuân Tráng', N'01555446678', 1, N'', N'', N'', CAST(N'2023-11-03T00:00:00.000' AS DateTime), N'NV000001', CAST(N'2023-11-14T17:08:00.847' AS DateTime), CAST(2275000.00 AS Decimal(18, 2)))
INSERT [dbo].[tKhachHang] ([MaKH], [TenKH], [SDT], [GioiTinh], [DiaChi], [Anh], [GhiChu], [NgaySinh], [MaNV], [NgayTaoKH], [TongBan]) VALUES (N'KH000012', N'Hà Thế Trường', N'05566112233', 1, N'', N'', N'', CAST(N'2023-11-03T00:00:00.000' AS DateTime), N'NV000002', CAST(N'2023-11-14T17:10:17.810' AS DateTime), CAST(0.00 AS Decimal(18, 2)))
INSERT [dbo].[tKhachHang] ([MaKH], [TenKH], [SDT], [GioiTinh], [DiaChi], [Anh], [GhiChu], [NgaySinh], [MaNV], [NgayTaoKH], [TongBan]) VALUES (N'KH000013', N'Hiền', N'0337629441', 0, N'', N'Áo Polo Vải Dry Pique Ngắn Tay ghi.jpg', N'', CAST(N'2023-11-03T00:00:00.000' AS DateTime), N'NV000002', CAST(N'2023-11-15T16:13:36.920' AS DateTime), CAST(0.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'AD00333.đen.L', N'Aó gió màu đen - L', N'TL000001', N'đen', N'L', N'NCC00001', CAST(400000.00 AS Decimal(18, 2)), CAST(200000.00 AS Decimal(18, 2)), 0, N'Áo Polo Vải Dry Pique Ngắn Tay hồng.jpg', NULL, N'cái', 1)
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'AD00333.đen.M', N'Aó gió màu đen - M', N'TL000001', N'đen', N'M', N'NCC00001', CAST(400000.00 AS Decimal(18, 2)), CAST(200000.00 AS Decimal(18, 2)), 0, N'Áo Polo Vải Dry Pique Ngắn Tay hồng.jpg', NULL, N'cái', 1)
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'AD00333.đen.S', N'Aó gió màu đen - S', N'TL000001', N'đen', N'S', N'NCC00001', CAST(400000.00 AS Decimal(18, 2)), CAST(200000.00 AS Decimal(18, 2)), 0, N'Áo Polo Vải Dry Pique Ngắn Tay hồng.jpg', NULL, N'cái', 1)
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'AD00333.đen.XL', N'Aó gió màu đen - XL', N'TL000001', N'đen', N'XL', N'NCC00001', CAST(500000.00 AS Decimal(18, 2)), CAST(300000.00 AS Decimal(18, 2)), 0, N'Áo Polo Vải Dry Pique Ngắn Tay hồng.jpg', NULL, N'cái', 1)
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'AD00333.trắng.L', N'Aó gió màu trắng - L', N'TL000001', N'trắng', N'L', N'NCC00001', CAST(400000.00 AS Decimal(18, 2)), CAST(200000.00 AS Decimal(18, 2)), 0, N'Áo Polo Vải Dry Pique Ngắn Tay ghi.jpg', NULL, N'cái', 1)
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'AD00333.trắng.M', N'Aó gió màu trắng - M', N'TL000001', N'trắng', N'M', N'NCC00001', CAST(400000.00 AS Decimal(18, 2)), CAST(200000.00 AS Decimal(18, 2)), 0, N'Áo Polo Vải Dry Pique Ngắn Tay ghi.jpg', NULL, N'cái', 1)
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'AD00333.trắng.S', N'Aó gió màu trắng - S', N'TL000001', N'trắng', N'S', N'NCC00001', CAST(400000.00 AS Decimal(18, 2)), CAST(200000.00 AS Decimal(18, 2)), 0, N'Áo Polo Vải Dry Pique Ngắn Tay ghi.jpg', NULL, N'cái', 1)
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'AD00333.trắng.XL', N'Aó gió màu trắng - XL', N'TL000001', N'trắng', N'XL', N'NCC00001', CAST(400000.00 AS Decimal(18, 2)), CAST(200000.00 AS Decimal(18, 2)), 0, N'Áo Polo Vải Dry Pique Ngắn Tay ghi.jpg', NULL, N'cái', 1)
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'AHD0511231.đen.L', N'Áo hoodie unisex tay dài phối mũ Checkerboard Big Lux Mega màu đen - L', N'TL000001', N'đen', N'L', N'NCC00001', CAST(3250000.00 AS Decimal(18, 2)), CAST(2000000.00 AS Decimal(18, 2)), 14, N'Áo hoodie unisex tay dài phối mũ Checkerboard Big Lux Mega đen.jpg', N'abcd', N'chiếc', 1)
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'AHD0511231.đen.M', N'Áo hoodie unisex tay dài phối mũ Checkerboard Big Lux Mega màu đen - M', N'TL000001', N'đen', N'M', N'NCC00001', CAST(3250000.00 AS Decimal(18, 2)), CAST(2000000.00 AS Decimal(18, 2)), 15, N'Áo hoodie unisex tay dài phối mũ Checkerboard Big Lux Mega đen.jpg', NULL, N'chiếc', 1)
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'AHD0511231.đen.S', N'Áo hoodie unisex tay dài phối mũ Checkerboard Big Lux Mega màu đen - S', N'TL000001', N'đen', N'S', N'NCC00001', CAST(3250000.00 AS Decimal(18, 2)), CAST(2000000.00 AS Decimal(18, 2)), 12, N'Áo hoodie unisex tay dài phối mũ Checkerboard Big Lux Mega đen.jpg', NULL, N'chiếc', 1)
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'AHD0511231.đen.XL', N'Áo hoodie unisex tay dài phối mũ Checkerboard Big Lux Mega màu đen - XL', N'TL000001', N'đen', N'XL', N'NCC00001', CAST(3250000.00 AS Decimal(18, 2)), CAST(2000000.00 AS Decimal(18, 2)), 9, N'Áo hoodie unisex tay dài phối mũ Checkerboard Big Lux Mega đen.jpg', NULL, N'chiếc', 1)
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'AHD0511231.đen.XS', N'Áo hoodie unisex tay dài phối mũ Checkerboard Big Lux Mega màu đen - XS', N'TL000001', N'đen', N'XS', N'NCC00001', CAST(3250000.00 AS Decimal(18, 2)), CAST(2000000.00 AS Decimal(18, 2)), 0, N'Áo hoodie unisex tay dài phối mũ Checkerboard Big Lux Mega đen.jpg', NULL, N'chiếc', 1)
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'AHD0511231.trắng.L', N'Áo hoodie unisex tay dài phối mũ Checkerboard Big Lux Mega màu trắng - L', N'TL000001', N'trắng', N'L', N'NCC00001', CAST(3250000.00 AS Decimal(18, 2)), CAST(2000000.00 AS Decimal(18, 2)), 20, N'Áo hoodie unisex tay dài phối mũ Checkerboard Big Lux Mega trắng.jpg', NULL, N'chiếc', 1)
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'AHD0511231.trắng.M', N'Áo hoodie unisex tay dài phối mũ Checkerboard Big Lux Mega màu trắng - M', N'TL000001', N'trắng', N'M', N'NCC00001', CAST(3250000.00 AS Decimal(18, 2)), CAST(2000000.00 AS Decimal(18, 2)), 10, N'Áo hoodie unisex tay dài phối mũ Checkerboard Big Lux Mega trắng.jpg', NULL, N'chiếc', 1)
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'AHD0511231.trắng.S', N'Áo hoodie unisex tay dài phối mũ Checkerboard Big Lux Mega màu trắng - S', N'TL000001', N'trắng', N'S', N'NCC00001', CAST(3250000.00 AS Decimal(18, 2)), CAST(2000000.00 AS Decimal(18, 2)), 10, N'Áo hoodie unisex tay dài phối mũ Checkerboard Big Lux Mega trắng.jpg', NULL, N'chiếc', 1)
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'AHD0511231.trắng.XL', N'Áo hoodie unisex tay dài phối mũ Checkerboard Big Lux Mega màu trắng - XL', N'TL000001', N'trắng', N'XL', N'NCC00001', CAST(3250000.00 AS Decimal(18, 2)), CAST(2000000.00 AS Decimal(18, 2)), 0, N'Áo hoodie unisex tay dài phối mũ Checkerboard Big Lux Mega trắng.jpg', NULL, N'chiếc', 1)
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'AHD0511231.trắng.XS', N'Áo hoodie unisex tay dài phối mũ Checkerboard Big Lux Mega màu trắng - XS', N'TL000001', N'trắng', N'XS', N'NCC00001', CAST(3250000.00 AS Decimal(18, 2)), CAST(2000000.00 AS Decimal(18, 2)), 0, N'Áo hoodie unisex tay dài phối mũ Checkerboard Big Lux Mega trắng.jpg', NULL, N'chiếc', 1)
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'AHD061120232.Đen.L', N'Áo hoodie unisex tay dài phối mũ Checkerboard Big Logo Overfit màu Đen - L', N'TL000001', N'Đen', N'L', N'NCC00001', CAST(1000000.00 AS Decimal(18, 2)), CAST(500000.00 AS Decimal(18, 2)), 10, N'Áo hoodie unisex tay dài phối mũ Checkerboard Big Logo Overfit đen.jpg', NULL, N'chiếc', 1)
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'AHD061120232.Đen.M', N'Áo hoodie unisex tay dài phối mũ Checkerboard Big Logo Overfit màu Đen - M', N'TL000001', N'Đen', N'M', N'NCC00001', CAST(1000000.00 AS Decimal(18, 2)), CAST(500000.00 AS Decimal(18, 2)), 0, N'Áo hoodie unisex tay dài phối mũ Checkerboard Big Logo Overfit đen.jpg', NULL, N'chiếc', 1)
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'AHD061120232.Đen.S', N'Áo hoodie unisex tay dài phối mũ Checkerboard Big Logo Overfit màu Đen - S', N'TL000001', N'Đen', N'S', N'NCC00001', CAST(1000000.00 AS Decimal(18, 2)), CAST(500000.00 AS Decimal(18, 2)), 10, N'Áo hoodie unisex tay dài phối mũ Checkerboard Big Logo Overfit đen.jpg', NULL, N'chiếc', 1)
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'AHD061120232.Đen.XL', N'Áo hoodie unisex tay dài phối mũ Checkerboard Big Logo Overfit màu Đen - XL', N'TL000001', N'Đen', N'XL', N'NCC00001', CAST(1000000.00 AS Decimal(18, 2)), CAST(500000.00 AS Decimal(18, 2)), 10, N'Áo hoodie unisex tay dài phối mũ Checkerboard Big Logo Overfit đen.jpg', NULL, N'chiếc', 1)
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'AHD061120232.Đen.XS', N'Áo hoodie unisex tay dài phối mũ Checkerboard Big Logo Overfit màu Đen - XS', N'TL000001', N'Đen', N'XS', N'NCC00001', CAST(1000000.00 AS Decimal(18, 2)), CAST(500000.00 AS Decimal(18, 2)), 0, N'Áo hoodie unisex tay dài phối mũ Checkerboard Big Logo Overfit đen.jpg', NULL, N'chiếc', 1)
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'AHD061120232.Ghi.L', N'Áo hoodie unisex tay dài phối mũ Checkerboard Big Logo Overfit màu Ghi - L', N'TL000001', N'Ghi', N'L', N'NCC00001', CAST(1000000.00 AS Decimal(18, 2)), CAST(500000.00 AS Decimal(18, 2)), 0, N'Áo hoodie unisex tay dài phối mũ Checkerboard Big Logo Overfit xám.jpg', NULL, N'chiếc', 1)
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'AHD061120232.Ghi.M', N'Áo hoodie unisex tay dài phối mũ Checkerboard Big Logo Overfit màu Ghi - M', N'TL000001', N'Ghi', N'M', N'NCC00001', CAST(1000000.00 AS Decimal(18, 2)), CAST(500000.00 AS Decimal(18, 2)), 0, N'Áo hoodie unisex tay dài phối mũ Checkerboard Big Logo Overfit xám.jpg', NULL, N'chiếc', 1)
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'AHD061120232.Ghi.S', N'Áo hoodie unisex tay dài phối mũ Checkerboard Big Logo Overfit màu Ghi - S', N'TL000001', N'Ghi', N'S', N'NCC00001', CAST(1000000.00 AS Decimal(18, 2)), CAST(500000.00 AS Decimal(18, 2)), 0, N'Áo hoodie unisex tay dài phối mũ Checkerboard Big Logo Overfit xám.jpg', NULL, N'chiếc', 1)
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'AHD061120232.Ghi.XL', N'Áo hoodie unisex tay dài phối mũ Checkerboard Big Logo Overfit màu Ghi - XL', N'TL000001', N'Ghi', N'XL', N'NCC00001', CAST(1000000.00 AS Decimal(18, 2)), CAST(500000.00 AS Decimal(18, 2)), 0, N'Áo hoodie unisex tay dài phối mũ Checkerboard Big Logo Overfit xám.jpg', NULL, N'chiếc', 1)
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'AHD061120232.Ghi.XS', N'Áo hoodie unisex tay dài phối mũ Checkerboard Big Logo Overfit màu Ghi - XS', N'TL000001', N'Ghi', N'XS', N'NCC00001', CAST(1000000.00 AS Decimal(18, 2)), CAST(500000.00 AS Decimal(18, 2)), 0, N'Áo hoodie unisex tay dài phối mũ Checkerboard Big Logo Overfit xám.jpg', NULL, N'chiếc', 1)
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'AHD061120232.Trắng.L', N'Áo hoodie unisex tay dài phối mũ Checkerboard Big Logo Overfit màu Trắng - L', N'TL000001', N'Trắng', N'L', N'NCC00001', CAST(1000000.00 AS Decimal(18, 2)), CAST(500000.00 AS Decimal(18, 2)), 0, N'Áo hoodie unisex tay dài phối mũ Checkerboard Big Logo Overfit trắng.jpg', NULL, N'chiếc', 1)
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'AHD061120232.Trắng.M', N'Áo hoodie unisex tay dài phối mũ Checkerboard Big Logo Overfit màu Trắng - M', N'TL000001', N'Trắng', N'M', N'NCC00001', CAST(1000000.00 AS Decimal(18, 2)), CAST(500000.00 AS Decimal(18, 2)), 0, N'Áo hoodie unisex tay dài phối mũ Checkerboard Big Logo Overfit trắng.jpg', NULL, N'chiếc', 1)
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'AHD061120232.Trắng.S', N'Áo hoodie unisex tay dài phối mũ Checkerboard Big Logo Overfit màu Trắng - S', N'TL000001', N'Trắng', N'S', N'NCC00001', CAST(1000000.00 AS Decimal(18, 2)), CAST(500000.00 AS Decimal(18, 2)), 0, N'Áo hoodie unisex tay dài phối mũ Checkerboard Big Logo Overfit trắng.jpg', NULL, N'chiếc', 1)
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'AHD061120232.Trắng.XL', N'Áo hoodie unisex tay dài phối mũ Checkerboard Big Logo Overfit màu Trắng - XL', N'TL000001', N'Trắng', N'XL', N'NCC00001', CAST(1000000.00 AS Decimal(18, 2)), CAST(500000.00 AS Decimal(18, 2)), 0, N'Áo hoodie unisex tay dài phối mũ Checkerboard Big Logo Overfit trắng.jpg', NULL, N'chiếc', 1)
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'AHD061120232.Trắng.XS', N'Áo hoodie unisex tay dài phối mũ Checkerboard Big Logo Overfit màu Trắng - XS', N'TL000001', N'Trắng', N'XS', N'NCC00001', CAST(1000000.00 AS Decimal(18, 2)), CAST(500000.00 AS Decimal(18, 2)), 0, N'Áo hoodie unisex tay dài phối mũ Checkerboard Big Logo Overfit trắng.jpg', NULL, N'chiếc', 1)
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'AHD0611231.Ghi.L', N'Áo hoodie unisex phối mũ tay dài Clever Neddy Pullover màu Ghi - L', N'TL000001', N'Ghi', N'L', N'NCC00001', CAST(2000000.00 AS Decimal(18, 2)), CAST(1000000.00 AS Decimal(18, 2)), 0, N'Áo hoodie unisex phối mũ tay dài Clever Neddy Pullover ghi.jpg', NULL, N'chiếc', 1)
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'AHD0611231.Ghi.M', N'Áo hoodie unisex phối mũ tay dài Clever Neddy Pullover màu Ghi - M', N'TL000001', N'Ghi', N'M', N'NCC00001', CAST(2000000.00 AS Decimal(18, 2)), CAST(1000000.00 AS Decimal(18, 2)), 10, N'Áo hoodie unisex phối mũ tay dài Clever Neddy Pullover ghi.jpg', NULL, N'chiếc', 1)
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'AHD0611231.Ghi.S', N'Áo hoodie unisex phối mũ tay dài Clever Neddy Pullover màu Ghi - S', N'TL000001', N'Ghi', N'S', N'NCC00001', CAST(2000000.00 AS Decimal(18, 2)), CAST(1000000.00 AS Decimal(18, 2)), 0, N'Áo hoodie unisex phối mũ tay dài Clever Neddy Pullover ghi.jpg', NULL, N'chiếc', 1)
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'AHD0611231.Ghi.XL', N'Áo hoodie unisex phối mũ tay dài Clever Neddy Pullover màu Ghi - XL', N'TL000001', N'Ghi', N'XL', N'NCC00001', CAST(2000000.00 AS Decimal(18, 2)), CAST(1000000.00 AS Decimal(18, 2)), 0, N'Áo hoodie unisex phối mũ tay dài Clever Neddy Pullover ghi.jpg', NULL, N'chiếc', 1)
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'AHD0611231.Ghi.XS', N'Áo hoodie unisex phối mũ tay dài Clever Neddy Pullover màu Ghi - XS', N'TL000001', N'Ghi', N'XS', N'NCC00001', CAST(2000000.00 AS Decimal(18, 2)), CAST(1000000.00 AS Decimal(18, 2)), 0, N'Áo hoodie unisex phối mũ tay dài Clever Neddy Pullover ghi.jpg', NULL, N'chiếc', 1)
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'AHD0611231.Navy.L', N'Áo hoodie unisex phối mũ tay dài Clever Neddy Pullover màu Navy - L', N'TL000001', N'Navy', N'L', N'NCC00001', CAST(2000000.00 AS Decimal(18, 2)), CAST(1000000.00 AS Decimal(18, 2)), 0, N'Áo hoodie unisex phối mũ tay dài Clever Neddy Pullover navy.jpg', NULL, N'chiếc', 1)
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'AHD0611231.Navy.M', N'Áo hoodie unisex phối mũ tay dài Clever Neddy Pullover màu Navy - M', N'TL000001', N'Navy', N'M', N'NCC00001', CAST(2000000.00 AS Decimal(18, 2)), CAST(1000000.00 AS Decimal(18, 2)), 0, N'Áo hoodie unisex phối mũ tay dài Clever Neddy Pullover navy.jpg', NULL, N'chiếc', 1)
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'AHD0611231.Navy.S', N'Áo hoodie unisex phối mũ tay dài Clever Neddy Pullover màu Navy - S', N'TL000001', N'Navy', N'S', N'NCC00001', CAST(2000000.00 AS Decimal(18, 2)), CAST(1000000.00 AS Decimal(18, 2)), 0, N'Áo hoodie unisex phối mũ tay dài Clever Neddy Pullover navy.jpg', NULL, N'chiếc', 1)
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'AHD0611231.Navy.XL', N'Áo hoodie unisex phối mũ tay dài Clever Neddy Pullover màu Navy - XL', N'TL000001', N'Navy', N'XL', N'NCC00001', CAST(2000000.00 AS Decimal(18, 2)), CAST(1000000.00 AS Decimal(18, 2)), 0, N'Áo hoodie unisex phối mũ tay dài Clever Neddy Pullover navy.jpg', NULL, N'chiếc', 1)
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'AHD0611231.Navy.XS', N'Áo hoodie unisex phối mũ tay dài Clever Neddy Pullover màu Navy - XS', N'TL000001', N'Navy', N'XS', N'NCC00001', CAST(2000000.00 AS Decimal(18, 2)), CAST(1000000.00 AS Decimal(18, 2)), 0, N'Áo hoodie unisex phối mũ tay dài Clever Neddy Pullover navy.jpg', NULL, N'chiếc', 1)
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'AHD0611231.Tím.L', N'Áo hoodie unisex phối mũ tay dài Clever Neddy Pullover màu Tím - L', N'TL000001', N'Tím', N'L', N'NCC00001', CAST(2000000.00 AS Decimal(18, 2)), CAST(1000000.00 AS Decimal(18, 2)), 0, N'Áo hoodie unisex phối mũ tay dài Clever Neddy Pullover tím.jpg', NULL, N'chiếc', 1)
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'AHD0611231.Tím.M', N'Áo hoodie unisex phối mũ tay dài Clever Neddy Pullover màu Tím - M', N'TL000001', N'Tím', N'M', N'NCC00001', CAST(2000000.00 AS Decimal(18, 2)), CAST(1000000.00 AS Decimal(18, 2)), 0, N'Áo hoodie unisex phối mũ tay dài Clever Neddy Pullover tím.jpg', NULL, N'chiếc', 1)
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'AHD0611231.Tím.S', N'Áo hoodie unisex phối mũ tay dài Clever Neddy Pullover màu Tím - S', N'TL000001', N'Tím', N'S', N'NCC00001', CAST(2000000.00 AS Decimal(18, 2)), CAST(1000000.00 AS Decimal(18, 2)), 0, N'Áo hoodie unisex phối mũ tay dài Clever Neddy Pullover tím.jpg', NULL, N'chiếc', 1)
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'AHD0611231.Tím.XL', N'Áo hoodie unisex phối mũ tay dài Clever Neddy Pullover màu Tím - XL', N'TL000001', N'Tím', N'XL', N'NCC00001', CAST(2000000.00 AS Decimal(18, 2)), CAST(1000000.00 AS Decimal(18, 2)), 0, N'Áo hoodie unisex phối mũ tay dài Clever Neddy Pullover tím.jpg', NULL, N'chiếc', 1)
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'AHD0611231.Tím.XS', N'Áo hoodie unisex phối mũ tay dài Clever Neddy Pullover màu Tím - XS', N'TL000001', N'Tím', N'XS', N'NCC00001', CAST(2000000.00 AS Decimal(18, 2)), CAST(1000000.00 AS Decimal(18, 2)), 0, N'Áo hoodie unisex phối mũ tay dài Clever Neddy Pullover tím.jpg', NULL, N'chiếc', 1)
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'APL230001.ghi.2XL', N'Áo Polo Vải Dry Pique Ngắn Tay màu ghi - 2XL', N'TL000004', N'ghi', N'2XL', N'NCC00001', CAST(450000.00 AS Decimal(18, 2)), CAST(300000.00 AS Decimal(18, 2)), 0, N'Áo Polo Vải Dry Pique Ngắn Tay ghi.jpg', NULL, N'chiếc', 1)
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'APL230001.ghi.3XL', N'Áo Polo Vải Dry Pique Ngắn Tay màu ghi - 3XL', N'TL000004', N'ghi', N'3XL', N'NCC00001', CAST(450000.00 AS Decimal(18, 2)), CAST(300000.00 AS Decimal(18, 2)), 0, N'Áo Polo Vải Dry Pique Ngắn Tay ghi.jpg', NULL, N'chiếc', 1)
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'APL230001.ghi.L', N'Áo Polo Vải Dry Pique Ngắn Tay màu ghi - L', N'TL000004', N'ghi', N'L', N'NCC00001', CAST(450000.00 AS Decimal(18, 2)), CAST(300000.00 AS Decimal(18, 2)), 3, N'Áo Polo Vải Dry Pique Ngắn Tay ghi.jpg', NULL, N'chiếc', 1)
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'APL230001.ghi.M', N'Áo Polo Vải Dry Pique Ngắn Tay màu ghi - M', N'TL000004', N'ghi', N'M', N'NCC00001', CAST(450000.00 AS Decimal(18, 2)), CAST(300000.00 AS Decimal(18, 2)), 4, N'Áo Polo Vải Dry Pique Ngắn Tay ghi.jpg', NULL, N'chiếc', 1)
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'APL230001.ghi.S', N'Áo Polo Vải Dry Pique Ngắn Tay màu ghi - S', N'TL000004', N'ghi', N'S', N'NCC00001', CAST(450000.00 AS Decimal(18, 2)), CAST(300000.00 AS Decimal(18, 2)), 5, N'Áo Polo Vải Dry Pique Ngắn Tay ghi.jpg', NULL, N'chiếc', 1)
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'APL230001.ghi.XL', N'Áo Polo Vải Dry Pique Ngắn Tay màu ghi - XL', N'TL000004', N'ghi', N'XL', N'NCC00001', CAST(450000.00 AS Decimal(18, 2)), CAST(300000.00 AS Decimal(18, 2)), 5, N'Áo Polo Vải Dry Pique Ngắn Tay ghi.jpg', NULL, N'chiếc', 1)
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'APL230001.ghi.XS', N'Áo Polo Vải Dry Pique Ngắn Tay màu ghi - XS', N'TL000004', N'ghi', N'XS', N'NCC00001', CAST(450000.00 AS Decimal(18, 2)), CAST(300000.00 AS Decimal(18, 2)), 0, N'Áo Polo Vải Dry Pique Ngắn Tay ghi.jpg', NULL, N'chiếc', 1)
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'APL230001.hồng.2XL', N'Áo Polo Vải Dry Pique Ngắn Tay màu hồng - 2XL', N'TL000004', N'hồng', N'2XL', N'NCC00001', CAST(450000.00 AS Decimal(18, 2)), CAST(300000.00 AS Decimal(18, 2)), 0, N'Áo Polo Vải Dry Pique Ngắn Tay hồng.jpg', NULL, N'chiếc', 1)
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'APL230001.hồng.3XL', N'Áo Polo Vải Dry Pique Ngắn Tay màu hồng - 3XL', N'TL000004', N'hồng', N'3XL', N'NCC00001', CAST(450000.00 AS Decimal(18, 2)), CAST(300000.00 AS Decimal(18, 2)), 0, N'Áo Polo Vải Dry Pique Ngắn Tay hồng.jpg', NULL, N'chiếc', 1)
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'APL230001.hồng.L', N'Áo Polo Vải Dry Pique Ngắn Tay màu hồng - L', N'TL000004', N'hồng', N'L', N'NCC00001', CAST(450000.00 AS Decimal(18, 2)), CAST(300000.00 AS Decimal(18, 2)), 0, N'Áo Polo Vải Dry Pique Ngắn Tay hồng.jpg', NULL, N'chiếc', 1)
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'APL230001.hồng.M', N'Áo Polo Vải Dry Pique Ngắn Tay màu hồng - M', N'TL000004', N'hồng', N'M', N'NCC00001', CAST(450000.00 AS Decimal(18, 2)), CAST(300000.00 AS Decimal(18, 2)), 0, N'Áo Polo Vải Dry Pique Ngắn Tay hồng.jpg', NULL, N'chiếc', 1)
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'APL230001.hồng.S', N'Áo Polo Vải Dry Pique Ngắn Tay màu hồng - S', N'TL000004', N'hồng', N'S', N'NCC00001', CAST(450000.00 AS Decimal(18, 2)), CAST(300000.00 AS Decimal(18, 2)), 0, N'Áo Polo Vải Dry Pique Ngắn Tay hồng.jpg', NULL, N'chiếc', 1)
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'APL230001.hồng.XL', N'Áo Polo Vải Dry Pique Ngắn Tay màu hồng - XL', N'TL000004', N'hồng', N'XL', N'NCC00001', CAST(450000.00 AS Decimal(18, 2)), CAST(300000.00 AS Decimal(18, 2)), 0, N'Áo Polo Vải Dry Pique Ngắn Tay hồng.jpg', NULL, N'chiếc', 1)
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'APL230001.hồng.XS', N'Áo Polo Vải Dry Pique Ngắn Tay màu hồng - XS', N'TL000004', N'hồng', N'XS', N'NCC00001', CAST(450000.00 AS Decimal(18, 2)), CAST(300000.00 AS Decimal(18, 2)), 0, N'Áo Polo Vải Dry Pique Ngắn Tay hồng.jpg', NULL, N'chiếc', 1)
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'APL230001.navy.2XL', N'Áo Polo Vải Dry Pique Ngắn Tay màu navy - 2XL', N'TL000004', N'navy', N'2XL', N'NCC00001', CAST(450000.00 AS Decimal(18, 2)), CAST(300000.00 AS Decimal(18, 2)), 0, N'Áo Polo Vải Dry Pique Ngắn Tay navy.jpg', NULL, N'chiếc', 1)
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'APL230001.navy.3XL', N'Áo Polo Vải Dry Pique Ngắn Tay màu navy - 3XL', N'TL000004', N'navy', N'3XL', N'NCC00001', CAST(450000.00 AS Decimal(18, 2)), CAST(300000.00 AS Decimal(18, 2)), 0, N'Áo Polo Vải Dry Pique Ngắn Tay navy.jpg', NULL, N'chiếc', 1)
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'APL230001.navy.L', N'Áo Polo Vải Dry Pique Ngắn Tay màu navy - L', N'TL000004', N'navy', N'L', N'NCC00001', CAST(450000.00 AS Decimal(18, 2)), CAST(300000.00 AS Decimal(18, 2)), 0, N'Áo Polo Vải Dry Pique Ngắn Tay navy.jpg', NULL, N'chiếc', 1)
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'APL230001.navy.M', N'Áo Polo Vải Dry Pique Ngắn Tay màu navy - M', N'TL000004', N'navy', N'M', N'NCC00001', CAST(450000.00 AS Decimal(18, 2)), CAST(300000.00 AS Decimal(18, 2)), 0, N'Áo Polo Vải Dry Pique Ngắn Tay navy.jpg', NULL, N'chiếc', 1)
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'APL230001.navy.S', N'Áo Polo Vải Dry Pique Ngắn Tay màu navy - S', N'TL000004', N'navy', N'S', N'NCC00001', CAST(450000.00 AS Decimal(18, 2)), CAST(300000.00 AS Decimal(18, 2)), 0, N'Áo Polo Vải Dry Pique Ngắn Tay navy.jpg', NULL, N'chiếc', 1)
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'APL230001.navy.XL', N'Áo Polo Vải Dry Pique Ngắn Tay màu navy - XL', N'TL000004', N'navy', N'XL', N'NCC00001', CAST(450000.00 AS Decimal(18, 2)), CAST(300000.00 AS Decimal(18, 2)), 0, N'Áo Polo Vải Dry Pique Ngắn Tay navy.jpg', NULL, N'chiếc', 1)
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'APL230001.navy.XS', N'Áo Polo Vải Dry Pique Ngắn Tay màu navy - XS', N'TL000004', N'navy', N'XS', N'NCC00001', CAST(450000.00 AS Decimal(18, 2)), CAST(300000.00 AS Decimal(18, 2)), 0, N'Áo Polo Vải Dry Pique Ngắn Tay navy.jpg', NULL, N'chiếc', 1)
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'APL230001.trắng.2XL', N'Áo Polo Vải Dry Pique Ngắn Tay màu trắng - 2XL', N'TL000004', N'trắng', N'2XL', N'NCC00001', CAST(450000.00 AS Decimal(18, 2)), CAST(300000.00 AS Decimal(18, 2)), 0, N'Áo Polo Vải Dry Pique Ngắn Tay trắng.jpg', NULL, N'chiếc', 1)
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'APL230001.trắng.3XL', N'Áo Polo Vải Dry Pique Ngắn Tay màu trắng - 3XL', N'TL000004', N'trắng', N'3XL', N'NCC00001', CAST(450000.00 AS Decimal(18, 2)), CAST(300000.00 AS Decimal(18, 2)), 0, N'Áo Polo Vải Dry Pique Ngắn Tay trắng.jpg', NULL, N'chiếc', 1)
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'APL230001.trắng.L', N'Áo Polo Vải Dry Pique Ngắn Tay màu trắng - L', N'TL000004', N'trắng', N'L', N'NCC00001', CAST(450000.00 AS Decimal(18, 2)), CAST(300000.00 AS Decimal(18, 2)), 0, N'Áo Polo Vải Dry Pique Ngắn Tay trắng.jpg', NULL, N'chiếc', 1)
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'APL230001.trắng.M', N'Áo Polo Vải Dry Pique Ngắn Tay màu trắng - M', N'TL000004', N'trắng', N'M', N'NCC00001', CAST(450000.00 AS Decimal(18, 2)), CAST(300000.00 AS Decimal(18, 2)), 0, N'Áo Polo Vải Dry Pique Ngắn Tay trắng.jpg', NULL, N'chiếc', 1)
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'APL230001.trắng.S', N'Áo Polo Vải Dry Pique Ngắn Tay màu trắng - S', N'TL000004', N'trắng', N'S', N'NCC00001', CAST(450000.00 AS Decimal(18, 2)), CAST(300000.00 AS Decimal(18, 2)), 0, N'Áo Polo Vải Dry Pique Ngắn Tay trắng.jpg', NULL, N'chiếc', 1)
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'APL230001.trắng.XL', N'Áo Polo Vải Dry Pique Ngắn Tay màu trắng - XL', N'TL000004', N'trắng', N'XL', N'NCC00001', CAST(450000.00 AS Decimal(18, 2)), CAST(300000.00 AS Decimal(18, 2)), 0, N'Áo Polo Vải Dry Pique Ngắn Tay trắng.jpg', NULL, N'chiếc', 1)
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'APL230001.trắng.XS', N'Áo Polo Vải Dry Pique Ngắn Tay màu trắng - XS', N'TL000004', N'trắng', N'XS', N'NCC00001', CAST(450000.00 AS Decimal(18, 2)), CAST(300000.00 AS Decimal(18, 2)), 0, N'Áo Polo Vải Dry Pique Ngắn Tay trắng.jpg', NULL, N'chiếc', 1)
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'QJM5005.xanh đậm.29', N'Quần Jeans Nam Ống Suông Lưng Thun màu xanh đậm - 29', N'TL000002', N'xanh đậm', N'29', N'NCC00003', CAST(400000.00 AS Decimal(18, 2)), CAST(250000.00 AS Decimal(18, 2)), 0, N'qjm5005 xanh đậm.jpg', NULL, N'chiếc', 1)
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'QJM5005.xanh đậm.30', N'Quần Jeans Nam Ống Suông Lưng Thun màu xanh đậm - 30', N'TL000002', N'xanh đậm', N'30', N'NCC00003', CAST(400000.00 AS Decimal(18, 2)), CAST(250000.00 AS Decimal(18, 2)), 8, N'qjm5005 xanh đậm.jpg', NULL, N'chiếc', 1)
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'QJM5005.xanh đậm.31', N'Quần Jeans Nam Ống Suông Lưng Thun màu xanh đậm - 31', N'TL000002', N'xanh đậm', N'31', N'NCC00003', CAST(400000.00 AS Decimal(18, 2)), CAST(250000.00 AS Decimal(18, 2)), 10, N'qjm5005 xanh đậm.jpg', NULL, N'chiếc', 1)
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'QJM5005.xanh đậm.32', N'Quần Jeans Nam Ống Suông Lưng Thun màu xanh đậm - 32', N'TL000002', N'xanh đậm', N'32', N'NCC00003', CAST(400000.00 AS Decimal(18, 2)), CAST(250000.00 AS Decimal(18, 2)), 9, N'qjm5005 xanh đậm.jpg', NULL, N'chiếc', 1)
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'QJM5005.xanh đậm.33', N'Quần Jeans Nam Ống Suông Lưng Thun màu xanh đậm - 33', N'TL000002', N'xanh đậm', N'33', N'NCC00003', CAST(400000.00 AS Decimal(18, 2)), CAST(250000.00 AS Decimal(18, 2)), 9, N'qjm5005 xanh đậm.jpg', NULL, N'chiếc', 1)
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'QJM5005.xanh đậm.34', N'Quần Jeans Nam Ống Suông Lưng Thun màu xanh đậm - 34', N'TL000002', N'xanh đậm', N'34', N'NCC00003', CAST(400000.00 AS Decimal(18, 2)), CAST(250000.00 AS Decimal(18, 2)), 0, N'qjm5005 xanh đậm.jpg', NULL, N'chiếc', 1)
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'qjm6005.Xanh đậm.29', N'Quần Jeans Nam Slimfit Lycra Co Giãn Mác Dệt màu Xanh đậm - 29', N'TL000002', N'Xanh đậm', N'29', N'NCC00002', CAST(600000.00 AS Decimal(18, 2)), CAST(350000.00 AS Decimal(18, 2)), 0, N'qjm6005 xanh đậm.jpg', NULL, N'chiếc', 1)
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'qjm6005.Xanh đậm.30', N'Quần Jeans Nam Slimfit Lycra Co Giãn Mác Dệt màu Xanh đậm - 30', N'TL000002', N'Xanh đậm', N'30', N'NCC00002', CAST(600000.00 AS Decimal(18, 2)), CAST(350000.00 AS Decimal(18, 2)), 0, N'qjm6005 xanh đậm.jpg', NULL, N'chiếc', 1)
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'qjm6005.Xanh đậm.31', N'Quần Jeans Nam Slimfit Lycra Co Giãn Mác Dệt màu Xanh đậm - 31', N'TL000002', N'Xanh đậm', N'31', N'NCC00002', CAST(600000.00 AS Decimal(18, 2)), CAST(350000.00 AS Decimal(18, 2)), 0, N'qjm6005 xanh đậm.jpg', NULL, N'chiếc', 1)
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'qjm6005.Xanh đậm.32', N'Quần Jeans Nam Slimfit Lycra Co Giãn Mác Dệt màu Xanh đậm - 32', N'TL000002', N'Xanh đậm', N'32', N'NCC00002', CAST(600000.00 AS Decimal(18, 2)), CAST(350000.00 AS Decimal(18, 2)), 0, N'qjm6005 xanh đậm.jpg', NULL, N'chiếc', 1)
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'qjm6005.Xanh đậm.33', N'Quần Jeans Nam Slimfit Lycra Co Giãn Mác Dệt màu Xanh đậm - 33', N'TL000002', N'Xanh đậm', N'33', N'NCC00002', CAST(600000.00 AS Decimal(18, 2)), CAST(350000.00 AS Decimal(18, 2)), 0, N'qjm6005 xanh đậm.jpg', NULL, N'chiếc', 1)
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'qjm6005.Xanh đậm.34', N'Quần Jeans Nam Slimfit Lycra Co Giãn Mác Dệt màu Xanh đậm - 34', N'TL000002', N'Xanh đậm', N'34', N'NCC00002', CAST(600000.00 AS Decimal(18, 2)), CAST(350000.00 AS Decimal(18, 2)), 0, N'qjm6005 xanh đậm.jpg', NULL, N'chiếc', 1)
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'qjm6005.Xanh nhạt.29', N'Quần Jeans Nam Slimfit Lycra Co Giãn Mác Dệt màu Xanh nhạt - 29', N'TL000002', N'Xanh nhạt', N'29', N'NCC00002', CAST(600000.00 AS Decimal(18, 2)), CAST(350000.00 AS Decimal(18, 2)), 10, N'qjm6005 xanh nhạt.jpg', NULL, N'chiếc', 1)
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'qjm6005.Xanh nhạt.30', N'Quần Jeans Nam Slimfit Lycra Co Giãn Mác Dệt màu Xanh nhạt - 30', N'TL000002', N'Xanh nhạt', N'30', N'NCC00002', CAST(600000.00 AS Decimal(18, 2)), CAST(350000.00 AS Decimal(18, 2)), 10, N'qjm6005 xanh nhạt.jpg', NULL, N'chiếc', 1)
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'qjm6005.Xanh nhạt.31', N'Quần Jeans Nam Slimfit Lycra Co Giãn Mác Dệt màu Xanh nhạt - 31', N'TL000002', N'Xanh nhạt', N'31', N'NCC00002', CAST(600000.00 AS Decimal(18, 2)), CAST(350000.00 AS Decimal(18, 2)), 0, N'qjm6005 xanh nhạt.jpg', NULL, N'chiếc', 1)
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'qjm6005.Xanh nhạt.32', N'Quần Jeans Nam Slimfit Lycra Co Giãn Mác Dệt màu Xanh nhạt - 32', N'TL000002', N'Xanh nhạt', N'32', N'NCC00002', CAST(600000.00 AS Decimal(18, 2)), CAST(350000.00 AS Decimal(18, 2)), 0, N'qjm6005 xanh nhạt.jpg', NULL, N'chiếc', 1)
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'qjm6005.Xanh nhạt.33', N'Quần Jeans Nam Slimfit Lycra Co Giãn Mác Dệt màu Xanh nhạt - 33', N'TL000002', N'Xanh nhạt', N'33', N'NCC00002', CAST(600000.00 AS Decimal(18, 2)), CAST(350000.00 AS Decimal(18, 2)), 10, N'qjm6005 xanh nhạt.jpg', NULL, N'chiếc', 1)
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'qjm6005.Xanh nhạt.34', N'Quần Jeans Nam Slimfit Lycra Co Giãn Mác Dệt màu Xanh nhạt - 34', N'TL000002', N'Xanh nhạt', N'34', N'NCC00002', CAST(600000.00 AS Decimal(18, 2)), CAST(350000.00 AS Decimal(18, 2)), 0, N'qjm6005 xanh nhạt.jpg', NULL, N'chiếc', 1)
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'QS230001.be.2XL', N'Quần Shorts Co Giãn Dáng Slim Fit màu be - 2XL', N'TL000003', N'be', N'2XL', N'NCC00002', CAST(500000.00 AS Decimal(18, 2)), CAST(300000.00 AS Decimal(18, 2)), 0, N'Quần Shorts Co Giãn Dáng Slim Fit be.jpg', NULL, N'chiếc', 1)
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'QS230001.be.3XL', N'Quần Shorts Co Giãn Dáng Slim Fit màu be - 3XL', N'TL000003', N'be', N'3XL', N'NCC00002', CAST(500000.00 AS Decimal(18, 2)), CAST(300000.00 AS Decimal(18, 2)), 0, N'Quần Shorts Co Giãn Dáng Slim Fit be.jpg', NULL, N'chiếc', 1)
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'QS230001.be.L', N'Quần Shorts Co Giãn Dáng Slim Fit màu be - L', N'TL000003', N'be', N'L', N'NCC00002', CAST(500000.00 AS Decimal(18, 2)), CAST(300000.00 AS Decimal(18, 2)), 10, N'Quần Shorts Co Giãn Dáng Slim Fit be.jpg', NULL, N'chiếc', 1)
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'QS230001.be.M', N'Quần Shorts Co Giãn Dáng Slim Fit màu be - M', N'TL000003', N'be', N'M', N'NCC00002', CAST(500000.00 AS Decimal(18, 2)), CAST(300000.00 AS Decimal(18, 2)), 9, N'Quần Shorts Co Giãn Dáng Slim Fit be.jpg', NULL, N'chiếc', 1)
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'QS230001.be.S', N'Quần Shorts Co Giãn Dáng Slim Fit màu be - S', N'TL000003', N'be', N'S', N'NCC00002', CAST(500000.00 AS Decimal(18, 2)), CAST(300000.00 AS Decimal(18, 2)), 9, N'Quần Shorts Co Giãn Dáng Slim Fit be.jpg', NULL, N'chiếc', 1)
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'QS230001.be.XL', N'Quần Shorts Co Giãn Dáng Slim Fit màu be - XL', N'TL000003', N'be', N'XL', N'NCC00002', CAST(500000.00 AS Decimal(18, 2)), CAST(300000.00 AS Decimal(18, 2)), 0, N'Quần Shorts Co Giãn Dáng Slim Fit be.jpg', NULL, N'chiếc', 1)
GO
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'QS230001.be.XS', N'Quần Shorts Co Giãn Dáng Slim Fit màu be - XS', N'TL000003', N'be', N'XS', N'NCC00002', CAST(500000.00 AS Decimal(18, 2)), CAST(300000.00 AS Decimal(18, 2)), 0, N'Quần Shorts Co Giãn Dáng Slim Fit be.jpg', NULL, N'chiếc', 1)
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'QS230001.navy.2XL', N'Quần Shorts Co Giãn Dáng Slim Fit màu navy - 2XL', N'TL000003', N'navy', N'2XL', N'NCC00002', CAST(500000.00 AS Decimal(18, 2)), CAST(300000.00 AS Decimal(18, 2)), 0, N'Quần Shorts Co Giãn Dáng Slim Fit navy.jpg', NULL, N'chiếc', 1)
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'QS230001.navy.3XL', N'Quần Shorts Co Giãn Dáng Slim Fit màu navy - 3XL', N'TL000003', N'navy', N'3XL', N'NCC00002', CAST(500000.00 AS Decimal(18, 2)), CAST(300000.00 AS Decimal(18, 2)), 0, N'Quần Shorts Co Giãn Dáng Slim Fit navy.jpg', NULL, N'chiếc', 1)
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'QS230001.navy.L', N'Quần Shorts Co Giãn Dáng Slim Fit màu navy - L', N'TL000003', N'navy', N'L', N'NCC00002', CAST(500000.00 AS Decimal(18, 2)), CAST(300000.00 AS Decimal(18, 2)), 0, N'Quần Shorts Co Giãn Dáng Slim Fit navy.jpg', NULL, N'chiếc', 1)
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'QS230001.navy.M', N'Quần Shorts Co Giãn Dáng Slim Fit màu navy - M', N'TL000003', N'navy', N'M', N'NCC00002', CAST(500000.00 AS Decimal(18, 2)), CAST(300000.00 AS Decimal(18, 2)), 0, N'Quần Shorts Co Giãn Dáng Slim Fit navy.jpg', NULL, N'chiếc', 1)
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'QS230001.navy.S', N'Quần Shorts Co Giãn Dáng Slim Fit màu navy - S', N'TL000003', N'navy', N'S', N'NCC00002', CAST(500000.00 AS Decimal(18, 2)), CAST(300000.00 AS Decimal(18, 2)), 0, N'Quần Shorts Co Giãn Dáng Slim Fit navy.jpg', NULL, N'chiếc', 1)
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'QS230001.navy.XL', N'Quần Shorts Co Giãn Dáng Slim Fit màu navy - XL', N'TL000003', N'navy', N'XL', N'NCC00002', CAST(500000.00 AS Decimal(18, 2)), CAST(300000.00 AS Decimal(18, 2)), 0, N'Quần Shorts Co Giãn Dáng Slim Fit navy.jpg', NULL, N'chiếc', 1)
INSERT [dbo].[tMatHang] ([MaMH], [TenMH], [MaTheLoai], [Mau], [Size], [MaNCC], [GiaBan], [GiaNhap], [SLTon], [Anh], [GhiChu], [DonVi], [IsDangBan]) VALUES (N'QS230001.navy.XS', N'Quần Shorts Co Giãn Dáng Slim Fit màu navy - XS', N'TL000003', N'navy', N'XS', N'NCC00002', CAST(500000.00 AS Decimal(18, 2)), CAST(300000.00 AS Decimal(18, 2)), 0, N'Quần Shorts Co Giãn Dáng Slim Fit navy.jpg', NULL, N'chiếc', 1)
GO
INSERT [dbo].[tNhaCungCap] ([MaNCC], [TenNCC], [SDT], [DiaChi], [GhiChu]) VALUES (N'NCC00001', N'Boutique Lạc Trung', N'0345678921', N'62 đường Hoàng Mai - Trương Định - Hai Bà Trưng - Hà Nội', N'quần áo boutique')
INSERT [dbo].[tNhaCungCap] ([MaNCC], [TenNCC], [SDT], [DiaChi], [GhiChu]) VALUES (N'NCC00002', N'Boutique Trương Định', N'0123456789', N'62 đường Hoàng Mai - Trương Định - Hai Bà Trưng - Hà Nội', N'')
INSERT [dbo].[tNhaCungCap] ([MaNCC], [TenNCC], [SDT], [DiaChi], [GhiChu]) VALUES (N'NCC00003', N'Boutique Láng Hạ', N'0123456798', N'Trương Định - Hai Bà Trưng - Hà Nội', N'')
INSERT [dbo].[tNhaCungCap] ([MaNCC], [TenNCC], [SDT], [DiaChi], [GhiChu]) VALUES (N'NCC00004', N'Boutique Cầu Giấy', N'0123456745', N'số 3 Cầu Giấy - Hà Nội', N'')
INSERT [dbo].[tNhaCungCap] ([MaNCC], [TenNCC], [SDT], [DiaChi], [GhiChu]) VALUES (N'NCC00005', N'VietTien', N'0123456798', N'Hà Đông - Hà Nội', N'')
INSERT [dbo].[tNhaCungCap] ([MaNCC], [TenNCC], [SDT], [DiaChi], [GhiChu]) VALUES (N'NCC00006', N'Adidas Đông Triều', N'0123456700', N'Đông Triều - Quảng Ninh', N'')
INSERT [dbo].[tNhaCungCap] ([MaNCC], [TenNCC], [SDT], [DiaChi], [GhiChu]) VALUES (N'NCC00007', N'Boutique Đống Đa', N'0123456701', N'Trương Định - Hai Bà Trưng - Hà Nội', N'')
GO
INSERT [dbo].[tNhanVien] ([MaNV], [TenNV], [GioiTinh], [NgaySinh], [NgayBD], [SDT], [UserName], [PassWord], [Role], [IsDangLam], [Anh]) VALUES (N'NV000001', N'Vũ Văn Hoàn', 1, CAST(N'2003-07-19' AS Date), CAST(N'2023-11-15' AS Date), N'0382906626', N'vuvanhoan', N'8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', 1, 1, N'')
INSERT [dbo].[tNhanVien] ([MaNV], [TenNV], [GioiTinh], [NgaySinh], [NgayBD], [SDT], [UserName], [PassWord], [Role], [IsDangLam], [Anh]) VALUES (N'NV000002', N'Hoàng Thị Hà', 0, CAST(N'2003-11-07' AS Date), CAST(N'2021-11-07' AS Date), N'0975992399', N'hoangthiha', N'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 1, 1, NULL)
INSERT [dbo].[tNhanVien] ([MaNV], [TenNV], [GioiTinh], [NgaySinh], [NgayBD], [SDT], [UserName], [PassWord], [Role], [IsDangLam], [Anh]) VALUES (N'NV000003', N'Nguyễn Thành Đạt', 1, CAST(N'2003-11-21' AS Date), CAST(N'2022-11-21' AS Date), N'0382906666', N'nguyenthanhdat', N'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 0, 1, NULL)
INSERT [dbo].[tNhanVien] ([MaNV], [TenNV], [GioiTinh], [NgaySinh], [NgayBD], [SDT], [UserName], [PassWord], [Role], [IsDangLam], [Anh]) VALUES (N'NV000004', N'Nguyễn Việt Hoàng', 1, CAST(N'2003-11-10' AS Date), CAST(N'2021-11-10' AS Date), N'099988999', N'nguyenviethoang', N'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 0, 1, NULL)
INSERT [dbo].[tNhanVien] ([MaNV], [TenNV], [GioiTinh], [NgaySinh], [NgayBD], [SDT], [UserName], [PassWord], [Role], [IsDangLam], [Anh]) VALUES (N'NV000005', N'Nguyễn Đức Thắng', 1, CAST(N'2003-02-10' AS Date), CAST(N'2020-02-10' AS Date), N'0123456789', N'nguyenducthang', N'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 0, 1, NULL)
GO
INSERT [dbo].[tPhieuNhap] ([MaPN], [MaNV], [TongTien], [GiamGia], [ThanhToan], [PhuongThucTT], [GhiChu], [NgayNhap], [TrangThai]) VALUES (N'PN000001', N'NV000001', CAST(6000000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(6000000.00 AS Decimal(18, 2)), 1, N'', CAST(N'2023-11-15T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[tPhieuNhap] ([MaPN], [MaNV], [TongTien], [GiamGia], [ThanhToan], [PhuongThucTT], [GhiChu], [NgayNhap], [TrangThai]) VALUES (N'PN000002', N'NV000001', CAST(98000000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(98000000.00 AS Decimal(18, 2)), 0, N'', CAST(N'2023-11-15T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[tPhieuNhap] ([MaPN], [MaNV], [TongTien], [GiamGia], [ThanhToan], [PhuongThucTT], [GhiChu], [NgayNhap], [TrangThai]) VALUES (N'PN000003', N'NV000002', CAST(34700000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(34700000.00 AS Decimal(18, 2)), 1, N'', CAST(N'2023-11-15T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[tPhieuNhap] ([MaPN], [MaNV], [TongTien], [GiamGia], [ThanhToan], [PhuongThucTT], [GhiChu], [NgayNhap], [TrangThai]) VALUES (N'PN000004', N'NV000001', CAST(66000000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(66000000.00 AS Decimal(18, 2)), 1, N'', CAST(N'2023-11-15T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[tPhieuNhap] ([MaPN], [MaNV], [TongTien], [GiamGia], [ThanhToan], [PhuongThucTT], [GhiChu], [NgayNhap], [TrangThai]) VALUES (N'PN000005', N'NV000001', CAST(77000000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(77000000.00 AS Decimal(18, 2)), 1, N'', CAST(N'2023-11-15T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[tPhieuNhap] ([MaPN], [MaNV], [TongTien], [GiamGia], [ThanhToan], [PhuongThucTT], [GhiChu], [NgayNhap], [TrangThai]) VALUES (N'PN000006', N'NV000001', CAST(9000000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(9000000.00 AS Decimal(18, 2)), 1, N'', CAST(N'2023-11-15T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[tPhieuNhap] ([MaPN], [MaNV], [TongTien], [GiamGia], [ThanhToan], [PhuongThucTT], [GhiChu], [NgayNhap], [TrangThai]) VALUES (N'PN000007', N'NV000001', CAST(2500000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(2500000.00 AS Decimal(18, 2)), 1, N'', CAST(N'2023-11-15T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[tPhieuNhap] ([MaPN], [MaNV], [TongTien], [GiamGia], [ThanhToan], [PhuongThucTT], [GhiChu], [NgayNhap], [TrangThai]) VALUES (N'PN000008', N'NV000002', CAST(20000000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(20000000.00 AS Decimal(18, 2)), 1, N'', CAST(N'2023-11-15T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[tPhieuNhap] ([MaPN], [MaNV], [TongTien], [GiamGia], [ThanhToan], [PhuongThucTT], [GhiChu], [NgayNhap], [TrangThai]) VALUES (N'PN000009', N'NV000002', CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 0, NULL, CAST(N'2023-11-15T00:00:00.000' AS DateTime), 0)
GO
INSERT [dbo].[tTheLoai] ([MaTheLoai], [TenTheLoai]) VALUES (N'TL000001', N'Áo hoodie')
INSERT [dbo].[tTheLoai] ([MaTheLoai], [TenTheLoai]) VALUES (N'TL000002', N'Quần Jean Nam')
INSERT [dbo].[tTheLoai] ([MaTheLoai], [TenTheLoai]) VALUES (N'TL000003', N'Quần short nam')
INSERT [dbo].[tTheLoai] ([MaTheLoai], [TenTheLoai]) VALUES (N'TL000004', N'Áo polo nam')
INSERT [dbo].[tTheLoai] ([MaTheLoai], [TenTheLoai]) VALUES (N'TL000005', N'Áo sơ mi nam')
GO
ALTER TABLE [dbo].[tChiTietHDB]  WITH CHECK ADD  CONSTRAINT [FK_tChiTietHDB_tHoaDonBan] FOREIGN KEY([MaHDB])
REFERENCES [dbo].[tHoaDonBan] ([MaHDB])
GO
ALTER TABLE [dbo].[tChiTietHDB] CHECK CONSTRAINT [FK_tChiTietHDB_tHoaDonBan]
GO
ALTER TABLE [dbo].[tChiTietHDB]  WITH CHECK ADD  CONSTRAINT [FK_tChiTietHDB_tMatHang] FOREIGN KEY([MaMH])
REFERENCES [dbo].[tMatHang] ([MaMH])
GO
ALTER TABLE [dbo].[tChiTietHDB] CHECK CONSTRAINT [FK_tChiTietHDB_tMatHang]
GO
ALTER TABLE [dbo].[tChiTietPN]  WITH CHECK ADD  CONSTRAINT [FK_tChiTietPN_tMatHang] FOREIGN KEY([MaMH])
REFERENCES [dbo].[tMatHang] ([MaMH])
GO
ALTER TABLE [dbo].[tChiTietPN] CHECK CONSTRAINT [FK_tChiTietPN_tMatHang]
GO
ALTER TABLE [dbo].[tChiTietPN]  WITH CHECK ADD  CONSTRAINT [FK_tChiTietPN_tPhieuNhap] FOREIGN KEY([MaPN])
REFERENCES [dbo].[tPhieuNhap] ([MaPN])
GO
ALTER TABLE [dbo].[tChiTietPN] CHECK CONSTRAINT [FK_tChiTietPN_tPhieuNhap]
GO
ALTER TABLE [dbo].[tHoaDonBan]  WITH CHECK ADD  CONSTRAINT [FK_tHoaDonBan_tKhachHang] FOREIGN KEY([MaKH])
REFERENCES [dbo].[tKhachHang] ([MaKH])
GO
ALTER TABLE [dbo].[tHoaDonBan] CHECK CONSTRAINT [FK_tHoaDonBan_tKhachHang]
GO
ALTER TABLE [dbo].[tHoaDonBan]  WITH CHECK ADD  CONSTRAINT [FK_tHoaDonBan_tNhanVien] FOREIGN KEY([MaNV])
REFERENCES [dbo].[tNhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[tHoaDonBan] CHECK CONSTRAINT [FK_tHoaDonBan_tNhanVien]
GO
ALTER TABLE [dbo].[tKhachHang]  WITH CHECK ADD  CONSTRAINT [FK_tKhachHang_tNhanVien] FOREIGN KEY([MaNV])
REFERENCES [dbo].[tNhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[tKhachHang] CHECK CONSTRAINT [FK_tKhachHang_tNhanVien]
GO
ALTER TABLE [dbo].[tMatHang]  WITH CHECK ADD  CONSTRAINT [FK_tMatHang_tNhaCungCap] FOREIGN KEY([MaNCC])
REFERENCES [dbo].[tNhaCungCap] ([MaNCC])
GO
ALTER TABLE [dbo].[tMatHang] CHECK CONSTRAINT [FK_tMatHang_tNhaCungCap]
GO
ALTER TABLE [dbo].[tMatHang]  WITH CHECK ADD  CONSTRAINT [FK_tMatHang_tTheLoai] FOREIGN KEY([MaTheLoai])
REFERENCES [dbo].[tTheLoai] ([MaTheLoai])
GO
ALTER TABLE [dbo].[tMatHang] CHECK CONSTRAINT [FK_tMatHang_tTheLoai]
GO
ALTER TABLE [dbo].[tPhieuNhap]  WITH CHECK ADD  CONSTRAINT [FK_tPhieuNhap_tNhanVien] FOREIGN KEY([MaNV])
REFERENCES [dbo].[tNhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[tPhieuNhap] CHECK CONSTRAINT [FK_tPhieuNhap_tNhanVien]
GO

USE [MuaBanXeDap]
GO
/****** Object:  Table [dbo].[ChiTietDonHang]    Script Date: 6/14/2020 6:58:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietDonHang](
	[maChiTietDonHang] [nvarchar](20) NOT NULL,
	[soLuong] [int] NULL,
	[thanhTien] [bigint] NULL,
	[tenKH] [nvarchar](100) NULL,
	[SDT] [int] NULL,
	[gmail] [nchar](50) NULL,
 CONSTRAINT [PK_ChiTietDonHang] PRIMARY KEY CLUSTERED 
(
	[maChiTietDonHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DonHang]    Script Date: 6/14/2020 6:58:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DonHang](
	[maDonHang] [nvarchar](20) NOT NULL,
	[maKH] [nvarchar](20) NOT NULL,
	[maGioHang] [nvarchar](20) NULL,
 CONSTRAINT [PK_DonHang_1] PRIMARY KEY CLUSTERED 
(
	[maDonHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GioHang]    Script Date: 6/14/2020 6:58:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GioHang](
	[maGioHang] [nvarchar](20) NOT NULL,
	[soLuong] [int] NULL,
	[ngayTao] [date] NULL,
	[donGia] [bigint] NULL,
 CONSTRAINT [PK_GioHang] PRIMARY KEY CLUSTERED 
(
	[maGioHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 6/14/2020 6:58:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[maKH] [nvarchar](20) NOT NULL,
	[tenKH] [nvarchar](100) NULL,
	[tenDangNhap] [nchar](50) NULL,
	[matKhau] [nchar](50) NULL,
	[gmail] [nchar](50) NULL,
	[SDT] [int] NULL,
 CONSTRAINT [PK_KhachHang] PRIMARY KEY CLUSTERED 
(
	[maKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoaiMayTinh]    Script Date: 6/14/2020 6:58:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiMayTinh](
	[maLoai] [nvarchar](20) NOT NULL,
	[tenLoai] [nvarchar](20) NULL,
	[ghiChu] [nchar](100) NULL,
 CONSTRAINT [PK_LoaiMayTinh] PRIMARY KEY CLUSTERED 
(
	[maLoai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MayTinh]    Script Date: 6/14/2020 6:58:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MayTinh](
	[maMayTinh] [nvarchar](20) NOT NULL,
	[tenMayTinh] [nvarchar](50) NULL,
	[maLoai] [nvarchar](20) NULL,
	[namSanXuat] [int] NULL,
 CONSTRAINT [PK_MayTinh] PRIMARY KEY CLUSTERED 
(
	[maMayTinh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MuaHang]    Script Date: 6/14/2020 6:58:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MuaHang](
	[maMuaHang] [nvarchar](20) NOT NULL,
	[maGioHang] [nvarchar](20) NULL,
	[maMayTinh] [nvarchar](20) NULL,
	[maNV] [nvarchar](20) NULL,
 CONSTRAINT [PK_MuaHang] PRIMARY KEY CLUSTERED 
(
	[maMuaHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 6/14/2020 6:58:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[maNV] [nvarchar](20) NOT NULL,
	[tenNV] [nvarchar](100) NULL,
	[diaChi] [nvarchar](100) NULL,
	[SDT] [int] NULL,
 CONSTRAINT [PK_NhanVien] PRIMARY KEY CLUSTERED 
(
	[maNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[GioHang] ([maGioHang], [soLuong], [ngayTao], [donGia]) VALUES (N'GH001', 3, CAST(N'2019-12-23' AS Date), 500000)
INSERT [dbo].[GioHang] ([maGioHang], [soLuong], [ngayTao], [donGia]) VALUES (N'GH002', 2, CAST(N'2020-02-13' AS Date), 300000)
INSERT [dbo].[GioHang] ([maGioHang], [soLuong], [ngayTao], [donGia]) VALUES (N'GH003', 5, CAST(N'2019-12-02' AS Date), 12000000)
INSERT [dbo].[GioHang] ([maGioHang], [soLuong], [ngayTao], [donGia]) VALUES (N'GH004', 2, CAST(N'2018-12-24' AS Date), 2000000)
INSERT [dbo].[GioHang] ([maGioHang], [soLuong], [ngayTao], [donGia]) VALUES (N'GH005', 5, CAST(N'2019-05-04' AS Date), 2001000)
INSERT [dbo].[GioHang] ([maGioHang], [soLuong], [ngayTao], [donGia]) VALUES (N'GH006', 2, CAST(N'2020-01-02' AS Date), 2012425)
INSERT [dbo].[GioHang] ([maGioHang], [soLuong], [ngayTao], [donGia]) VALUES (N'GH007', 5, CAST(N'2020-04-02' AS Date), 5123444)
INSERT [dbo].[GioHang] ([maGioHang], [soLuong], [ngayTao], [donGia]) VALUES (N'GH008', 6, CAST(N'2020-05-24' AS Date), 2245235)
INSERT [dbo].[KhachHang] ([maKH], [tenKH], [tenDangNhap], [matKhau], [gmail], [SDT]) VALUES (N'KH001', N'Nguyen Hoang Anh', N'username1                                         ', N'username1                                         ', NULL, 23133213)
INSERT [dbo].[KhachHang] ([maKH], [tenKH], [tenDangNhap], [matKhau], [gmail], [SDT]) VALUES (N'KH002', N'NGuyen Tien Anh', N'username2                                         ', N'username2                                         ', N'                                                  ', 241244123)
INSERT [dbo].[KhachHang] ([maKH], [tenKH], [tenDangNhap], [matKhau], [gmail], [SDT]) VALUES (N'KH003', N'Bui Tien Toan', N'username3                                         ', N'username3                                         ', NULL, 12333213)
INSERT [dbo].[KhachHang] ([maKH], [tenKH], [tenDangNhap], [matKhau], [gmail], [SDT]) VALUES (N'KH004', N'Hoang Thai Bao', N'username4                                         ', N'username4                                         ', NULL, 543413451)
INSERT [dbo].[KhachHang] ([maKH], [tenKH], [tenDangNhap], [matKhau], [gmail], [SDT]) VALUES (N'KH005', N'Vo Nguyen Tu', N'username5                                         ', N'username5                                         ', NULL, 456345435)
INSERT [dbo].[KhachHang] ([maKH], [tenKH], [tenDangNhap], [matKhau], [gmail], [SDT]) VALUES (N'KH006', N'Tran Hoang Vu ', N'username6                                         ', N'username6                                         ', NULL, 345355522)
INSERT [dbo].[KhachHang] ([maKH], [tenKH], [tenDangNhap], [matKhau], [gmail], [SDT]) VALUES (N'KH007', N'Tien Anh Thanh', N'username7                                         ', N'username7                                         ', NULL, 346342425)
INSERT [dbo].[KhachHang] ([maKH], [tenKH], [tenDangNhap], [matKhau], [gmail], [SDT]) VALUES (N'KH008', N'Nguyen Chien Anh', N'username8                                         ', N'username8                                         ', NULL, 392134421)
INSERT [dbo].[KhachHang] ([maKH], [tenKH], [tenDangNhap], [matKhau], [gmail], [SDT]) VALUES (N'KH009', N'Le Huong Trang', N'username9                                         ', N'username9                                         ', NULL, 434222139)
INSERT [dbo].[KhachHang] ([maKH], [tenKH], [tenDangNhap], [matKhau], [gmail], [SDT]) VALUES (N'KH010', N'Hoang Van Tu Anh', N'username10                                        ', N'username10                                        ', NULL, 654456001)
INSERT [dbo].[MayTinh] ([maMayTinh], [tenMayTinh], [maLoai], [namSanXuat]) VALUES (N'MT001', N'Chuot May Tinh ABC', NULL, 2019)
INSERT [dbo].[MayTinh] ([maMayTinh], [tenMayTinh], [maLoai], [namSanXuat]) VALUES (N'MT002', N'Ban Phim May Tinh', NULL, 2018)
INSERT [dbo].[MayTinh] ([maMayTinh], [tenMayTinh], [maLoai], [namSanXuat]) VALUES (N'MT003', N'Chip intel I5 103000', NULL, 2020)
INSERT [dbo].[MayTinh] ([maMayTinh], [tenMayTinh], [maLoai], [namSanXuat]) VALUES (N'MT004', N'Chip Ryzen 7 3900X', NULL, 2019)
INSERT [dbo].[MayTinh] ([maMayTinh], [tenMayTinh], [maLoai], [namSanXuat]) VALUES (N'MT005', N'Card do Hoa RX 570', NULL, 2017)
INSERT [dbo].[MayTinh] ([maMayTinh], [tenMayTinh], [maLoai], [namSanXuat]) VALUES (N'MT006', N'Card do hoa GTX 1060', NULL, 2016)
INSERT [dbo].[MayTinh] ([maMayTinh], [tenMayTinh], [maLoai], [namSanXuat]) VALUES (N'MT007', N'Card do hoa GTX 1050TI', NULL, 2016)
INSERT [dbo].[MayTinh] ([maMayTinh], [tenMayTinh], [maLoai], [namSanXuat]) VALUES (N'MT008', N'Card do hoa RX 580', NULL, 2016)
INSERT [dbo].[MayTinh] ([maMayTinh], [tenMayTinh], [maLoai], [namSanXuat]) VALUES (N'MT009', N'main Z490', NULL, 2019)
INSERT [dbo].[MayTinh] ([maMayTinh], [tenMayTinh], [maLoai], [namSanXuat]) VALUES (N'MT010', N'Tai Nghe bluetool', NULL, 2014)
INSERT [dbo].[MayTinh] ([maMayTinh], [tenMayTinh], [maLoai], [namSanXuat]) VALUES (N'MT011', N'Quat Tan Nhiet ', NULL, 2013)
INSERT [dbo].[MayTinh] ([maMayTinh], [tenMayTinh], [maLoai], [namSanXuat]) VALUES (N'MT012', N'Ram DDR3 4GB', NULL, 2016)
INSERT [dbo].[MayTinh] ([maMayTinh], [tenMayTinh], [maLoai], [namSanXuat]) VALUES (N'MT013', N'Ram DDR4 8GB', NULL, 2018)
INSERT [dbo].[MayTinh] ([maMayTinh], [tenMayTinh], [maLoai], [namSanXuat]) VALUES (N'MT014', N'O Cung 500GB', NULL, 2015)
INSERT [dbo].[MayTinh] ([maMayTinh], [tenMayTinh], [maLoai], [namSanXuat]) VALUES (N'MT015', N'O Cung HHD 1TB', NULL, 2015)
INSERT [dbo].[MayTinh] ([maMayTinh], [tenMayTinh], [maLoai], [namSanXuat]) VALUES (N'MT016', N'O Cung SSD 500GB', NULL, 2017)
INSERT [dbo].[MayTinh] ([maMayTinh], [tenMayTinh], [maLoai], [namSanXuat]) VALUES (N'MT017', N'Tai Nghe Không Dây ', NULL, 2018)
INSERT [dbo].[MayTinh] ([maMayTinh], [tenMayTinh], [maLoai], [namSanXuat]) VALUES (N'MT018', N'main H470', NULL, 2020)
INSERT [dbo].[MayTinh] ([maMayTinh], [tenMayTinh], [maLoai], [namSanXuat]) VALUES (N'MT019', N'Chip Ryzen 5 3400', NULL, 2017)
INSERT [dbo].[MayTinh] ([maMayTinh], [tenMayTinh], [maLoai], [namSanXuat]) VALUES (N'MT020', N'Vỏ Cây FDAC', NULL, 2015)
INSERT [dbo].[MayTinh] ([maMayTinh], [tenMayTinh], [maLoai], [namSanXuat]) VALUES (N'MT021', N'Tản Nhiệt Nước KOJA', NULL, 2012)
INSERT [dbo].[NhanVien] ([maNV], [tenNV], [diaChi], [SDT]) VALUES (N'NV001', N'NGuyen Hoang Tien Minh', NULL, 234213124)
INSERT [dbo].[NhanVien] ([maNV], [tenNV], [diaChi], [SDT]) VALUES (N'NV002', N'Bui Van Anh Tai', NULL, 532621136)
INSERT [dbo].[NhanVien] ([maNV], [tenNV], [diaChi], [SDT]) VALUES (N'NV003', N'Tran The Minh', NULL, 887345002)
INSERT [dbo].[NhanVien] ([maNV], [tenNV], [diaChi], [SDT]) VALUES (N'NV004', N'Vo Sy Hoang', NULL, 242423441)
ALTER TABLE [dbo].[DonHang]  WITH CHECK ADD  CONSTRAINT [FK_DonHang_ChiTietDonHang] FOREIGN KEY([maDonHang])
REFERENCES [dbo].[ChiTietDonHang] ([maChiTietDonHang])
GO
ALTER TABLE [dbo].[DonHang] CHECK CONSTRAINT [FK_DonHang_ChiTietDonHang]
GO
ALTER TABLE [dbo].[DonHang]  WITH CHECK ADD  CONSTRAINT [FK_DonHang_GioHang] FOREIGN KEY([maGioHang])
REFERENCES [dbo].[GioHang] ([maGioHang])
GO
ALTER TABLE [dbo].[DonHang] CHECK CONSTRAINT [FK_DonHang_GioHang]
GO
ALTER TABLE [dbo].[DonHang]  WITH CHECK ADD  CONSTRAINT [FK_DonHang_KhachHang] FOREIGN KEY([maKH])
REFERENCES [dbo].[KhachHang] ([maKH])
GO
ALTER TABLE [dbo].[DonHang] CHECK CONSTRAINT [FK_DonHang_KhachHang]
GO
ALTER TABLE [dbo].[MayTinh]  WITH CHECK ADD  CONSTRAINT [FK_MayTinh_LoaiMayTinh] FOREIGN KEY([maLoai])
REFERENCES [dbo].[LoaiMayTinh] ([maLoai])
GO
ALTER TABLE [dbo].[MayTinh] CHECK CONSTRAINT [FK_MayTinh_LoaiMayTinh]
GO
ALTER TABLE [dbo].[MuaHang]  WITH CHECK ADD  CONSTRAINT [FK_MuaHang_GioHang] FOREIGN KEY([maGioHang])
REFERENCES [dbo].[GioHang] ([maGioHang])
GO
ALTER TABLE [dbo].[MuaHang] CHECK CONSTRAINT [FK_MuaHang_GioHang]
GO
ALTER TABLE [dbo].[MuaHang]  WITH CHECK ADD  CONSTRAINT [FK_MuaHang_MayTinh] FOREIGN KEY([maMayTinh])
REFERENCES [dbo].[MayTinh] ([maMayTinh])
GO
ALTER TABLE [dbo].[MuaHang] CHECK CONSTRAINT [FK_MuaHang_MayTinh]
GO
ALTER TABLE [dbo].[MuaHang]  WITH CHECK ADD  CONSTRAINT [FK_MuaHang_NhanVien] FOREIGN KEY([maNV])
REFERENCES [dbo].[NhanVien] ([maNV])
GO
ALTER TABLE [dbo].[MuaHang] CHECK CONSTRAINT [FK_MuaHang_NhanVien]
GO

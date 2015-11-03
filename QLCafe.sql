create database QLCafe
go
use QLCafe
go
create table KhachHang(maKH varchar(10) primary key,
tenKH nvarchar(255) not null,
thanthiet bit not null)
go

create table NhanVien(maNV varchar(10) primary key,
tenNV nvarchar(255) not null,
phai nvarchar(10) not null,
diachi nvarchar(255),
cmnd varchar(10) not null,
matkhauNV varchar(20))
go

create table Coupon(maCP varchar(10) primary key,
noidung nvarchar(200),
giam int not null,
ngayBatDau date not null,
ngayKetThuc date not null)
go

create table HoaDon(maHD varchar(10) primary key,
maNV varchar(10) references NhanVien(maNV),
ngaylapHD date not null,
loaiHD bit not null,
tongtien money)
go

create table LoaiSP(maLoai varchar(10) primary key,
tenLoai nvarchar(255) not null,
)
go

create table SanPham(maSP varchar(10) primary key,
loaiSP varchar(10) references LoaiSP(maLoai),
tenSP nvarchar(255) not null,
dongia money not null,
mota nvarchar(255))
go

create table CT_HoaDonThu(maHDT varchar(10) references HoaDon(maHD),
maSP varchar(10) references SanPham(maSP),
soluong int not null,
maKH varchar(10) references KhachHang(maKH),
maCP varchar(10) references Coupon(maCP),
dongia money)
go

create table NguyenLieu(maNL varchar(10) primary key,
tenNL nvarchar(255) not null,
dongiaNL money)
go

create table CT_HoaDonChi(maHDC varchar(10) references HoaDon(maHD),
maNL varchar(10) references NguyenLieu(maNL),
soluong int not null,
ghichu nvarchar(255)) 
go

insert into NhanVien values('Admin',N'Administrator','Other','','','admin')
go
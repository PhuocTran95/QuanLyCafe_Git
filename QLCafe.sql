create database QLCafe
go
use QLCafe
go
create table KhachHang(maKH varchar(10) primary key,
tenKH nvarchar(255) not null,
cmnd varchar(10) not null,
thanthiet bit not null)
go	

create table NhanVien(maNV varchar(10) primary key,
tenNV nvarchar(255) not null,
phai nvarchar(10) not null,
diachi nvarchar(255),
cmnd varchar(10) not null,
matkhauNV varchar(20) not null)
go

create table HoaDon(maHD varchar(100) primary key,
maNV varchar(10) references NhanVien(maNV) on delete cascade on update cascade,
ngaylapHD date not null,
loaiHD bit not null,
maKH varchar(10) references KhachHang(maKH) on delete cascade on update cascade,
giamgia money,
phuthu money,
tongtien money)
go

create table LoaiSP(maLoai varchar(10) primary key,
tenLoai nvarchar(255) not null,
)
go

create table SanPham(maSP varchar(10) primary key,
loaiSP varchar(10) references LoaiSP(maLoai) on delete cascade on update cascade,
tenSP nvarchar(255) not null,
dongia money not null,
mota nvarchar(255))
go

create table CT_HoaDonThu(maHDT varchar(100) references HoaDon(maHD) on delete cascade on update cascade,
maSP varchar(10) references SanPham(maSP) on delete cascade on update cascade,
soluong int not null,
dongia money,
primary key(maHDT,maSP))
go

create table NguyenLieu(maNL varchar(10) primary key,
tenNL nvarchar(255) not null,
dvtinh nvarchar(10) not null)
go

create table CT_HoaDonChi(maHDC varchar(100) references HoaDon(maHD) on delete cascade on update cascade,
maNL varchar(10) references NguyenLieu(maNL) on delete cascade on update cascade,
soluong int not null,
ghichu nvarchar(255),
primary key(maHDC,maNL)) 
go

insert into NhanVien values('Admin',N'Administrator','Other','','','admin')
go

insert into KhachHang values('KH00001',N'Unknown','000000000','1')
go

insert into LoaiSP values('LSP1',N'Nước ngọt'),
						('LSP2',N'Cafe'),
						('LSP3',N'Kem')
go

insert into SanPham values('SP1','LSP1','Coca-Cola',10000,''),
						('SP2','LSP1','Pepsi',10500,''),
						('SP3','LSP2',N'Cafe Đá',12000,''),
						('SP4','LSP2',N'Cafe Sữa đá',15000,''),
						('SP5','LSP3',N'Kem dâu',24000,N'2 viên kem'),
						('SP6','LSP3',N'Kem Socola',30000,N'3 viên kem')
go

insert into NguyenLieu values('NL1',N'Sữa','Lít'),
							('NL2',N'Cafe hạt','Kg'),
							('NL3',N'Hương liệu','Chai')
go

insert into NhanVien values('NV1',N'Nguyễn Văn A',N'Nam',N'123 Đường ABC','123456789','nv1password'),
							('NV2',N'Trần Thị B',N'Nữ',N'29 Đường DEF','534234765','nv2password')
go

insert into KhachHang values('KH00002',N'Trần Thị Mén','123654312','0'),
							('KH00003',N'Văn Tèo','765080345','1')
go
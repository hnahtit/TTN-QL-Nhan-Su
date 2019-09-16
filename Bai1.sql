CREATE DATABASE Bai1_baitapnhom

CREATE TABLE QL_PhongBan
(
	Id_PhongBan INT PRIMARY KEY,
	Ten_PhongBan NVARCHAR(200),
	MaTP_PhongBan NCHAR(50)
)

INSERT INTO dbo.QL_PhongBan
        ( Id_PhongBan ,
          Ten_PhongBan ,
          MaTP_PhongBan
        )
VALUES  
	(1,N'Giám đốc','nv00001'),
	(2,N'Phòng 1','nv00002'),
	(3,N'Phòng 2','nv00003'),
	(4,N'Phòng 3','nv00004')


CREATE TABLE QL_ChucVu
(
	Id_ChucVu INT PRIMARY KEY,
	Ten_ChucVu NVARCHAR(200),
	Luong MONEY
)

INSERT INTO dbo.QL_ChucVu
        ( Id_ChucVu, Ten_ChucVu, Luong )
VALUES 
	(1,N'Giám đốc',100000000),
	(2,N'Trưởng phòng',50000000),
	(3,N'Nhân viên',10000000)



CREATE TABLE QL_NhanVien
(
	Id_NV NCHAR(50) PRIMARY KEY,
	Ho_NV NVARCHAR(50),
	Ten_NV NVARCHAR(50),
	DiaChi_NV NVARCHAR(200),
	SDT_NV NVARCHAR(30),
	GioiTinh_NV NVARCHAR(30) CHECK (GioiTinh_NV IN (N'Nam',N'Nữ')),
	PhongBan_NV INT REFERENCES dbo.QL_PhongBan(Id_PhongBan)
)

INSERT INTO dbo.QL_NhanVien
        ( Id_NV ,
          Ho_NV ,
          Ten_NV ,
          DiaChi_NV ,
          SDT_NV ,
          GioiTinh_NV ,
          PhongBan_NV
        )
VALUES 
	('nv00001',N'Bùi',N'Duy',N'Hưng Yên','0337088288',N'Nam',1),
	('nv00002',N'Nguyễn',N'Thành',N'Hưng Yên','0337088288',N'Nam',2),
	('nv00003',N'Nguyễn',N'Trường',N'Hưng Yên','0337088288',N'Nam',3),
	('nv00004',N'Đặng',N'Trường',N'Hưng Yên','0337088288',N'Nam',4),
	('nv00005',N'Lữ',N'Học',N'Hưng Yên','0337088288',N'Nam',2),
	('nv00006',N'Trịnh',N'Trà',N'Hưng Yên','0337088288',N'Nam',2),
	('nv00007',N'Nguyễn',N'Long',N'Hưng Yên','0337088288',N'Nam',3),
	('nv00008',N'Hoàng',N'Phát',N'Hưng Yên','0337088288',N'Nam',3),
	('nv00009',N'Cáp',N'Thắng',N'Hưng Yên','0337088288',N'Nam',4),
	('nv00010',N'Trần',N'Thông',N'Hưng Yên','0337088288',N'Nam',4)

CREATE TABLE QL_NhanVien_ChucVu
(
	Id_NhanVien NCHAR(50) REFERENCES dbo.QL_NhanVien(Id_NV),
	Id_ChucVu INT REFERENCES dbo.QL_ChucVu(Id_ChucVu),
	PRIMARY KEY(Id_NhanVien,Id_ChucVu)
)

CREATE TABLE DN_NguoiDung
(
	id_user INT PRIMARY KEY, 
	name_account NVARCHAR(50) NOT NULL,--tên tài khoản
	pass NVARCHAR(50),
	id_NhanVien NCHAR(50) REFERENCES dbo.QL_NhanVien(Id_NV)

)

CREATE TABLE DN_QuyenHan --quyền hạn
(
	id_per INT PRIMARY KEY,
	name_per NVARCHAR(50),
	description_per NVARCHAR(200)
)

CREATE TABLE DN_NguoiDung_QuyenHan
(
	id_relation INT PRIMARY KEY,
	id_user_rel INT REFERENCES dbo.DN_NguoiDung(id_user),
	id_permision_rel INT REFERENCES dbo.DN_QuyenHan(id_per),
	suspended BIT --account bị đình chỉ hay ko 
)

CREATE TABLE DN_QuyenHanChiTiet
(
	id_pd INT PRIMARY KEY,
	name_action NVARCHAR(100),
	code_action NVARCHAR(50),
	id_per INT REFERENCES dbo.DN_QuyenHan(id_per)
)



INSERT INTO DN_NguoiDung
        ( id_user ,
          name_account ,
          pass ,
          id_NhanVien
        )
VALUES  ( 1 ,N'Duy' ,N'123' ,N'nv00001'),
		( 2 ,N'Thành' ,N'123' ,N'nv00002'),
		( 3 ,N'Học' ,N'123' ,N'nv00003'),
		( 4 ,N'Trường' ,N'123' ,N'nv00004')


INSERT INTO DN_QuyenHan
        ( id_per, name_per, description_per )
VALUES  
	(1, N'Quản trị' ,N'nhóm quyền quản trị cao nhất'),
	(2, N'Quản trị phòng' ,N'nhóm quyền quản trị phòng'),
	(3, N'Nhân viên' ,N'nhóm quyền chỉ có thể xem')


INSERT INTO DN_NguoiDung_QuyenHan
        ( id_relation ,
          id_user_rel ,
          id_permision_rel ,
          suspended
        )
VALUES  
	(1,1,1,0),
	(2,2,2,0),
	(3,3,3,0),
	(4,4,3,0)


INSERT INTO DN_QuyenHanChiTiet
        ( id_pd ,
          name_action ,
          code_action ,
          id_per
        )
VALUES  
	(1,N'Thêm',N'ADD',2),
	(2,N'Sửa',N'FIX',2),
	(3,N'Xóa',N'DELETE',2),
	(4,N'Thêm',N'ADD',1),
	(5,N'Sửa',N'FIX',1),
	(6,N'Xóa',N'DELETE',1),
	(7,N'Quản lý người dùng',N'MUSER',1)


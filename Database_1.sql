CREATE DATABASE Bai1_baitapnhom

CREATE TABLE QL_USER
(
	id_user INT PRIMARY KEY, 
	name_account NVARCHAR(50) NOT NULL,--tên tài khoản
	pass NVARCHAR(50),
	_user_name NVARCHAR(100) --tên người dùng

)

CREATE TABLE QL_PERMISION --quyền hạn
(
	id_per INT PRIMARY KEY,
	name_per NVARCHAR(50),
	description_per NVARCHAR(200)
)

CREATE TABLE QL_USER_PERMISION
(
	id_relation INT PRIMARY KEY,
	id_user_rel INT REFERENCES dbo.QL_USER(id_user),
	id_permision_rel INT REFERENCES dbo.QL_PERMISION(id_per),
	suspended BIT --account bị đình chỉ hay ko 
)

CREATE TABLE QL_PERMISION_DETAIL
(
	id_pd INT PRIMARY KEY,
	name_action NVARCHAR(100),
	code_action NVARCHAR(50),
	id_per INT REFERENCES dbo.QL_PERMISION(id_per)
)

INSERT INTO dbo.QL_USER
        ( id_user ,
          name_account ,
          pass ,
          [_user_name]
        )
VALUES  ( 1 ,N'Duy' ,N'123' ,N'Bùi Quang Duy'),
		( 2 ,N'Thành' ,N'123' ,N'Nguyễn Trung Thành'),
		( 3 ,N'Học' ,N'123' ,N'Lữ Thái Học'),
		( 4 ,N'Trường' ,N'123' ,N'Nguyễn Đức Trường')
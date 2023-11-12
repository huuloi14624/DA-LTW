use master
GO
create database QLSinhVien
go
use QLSinhVien
go
CREATE TABLE SinhVien
(
	MaSV varchar (11) primary key,
	TenSV nvarchar (30),
	Lop varchar (9),
	Diem float,
)
INSERT INTO SinhVien (MaSV, TenSV, Lop, Diem) values (2122110264, N'Nguyễn Thanh Bình', 'CCQ2211G', 9);
go
INSERT INTO SinhVien (MaSV, TenSV, Lop, Diem) values (2122110271, N'Nguyễn Thanh Cường', 'CCQ2211A', 10);
go
INSERT INTO SinhVien (MaSV, TenSV, Lop, Diem) values (2122110295, N'Nguyễn Quốc Duy', 'CCQ2211H', 8.5);
go
select *from SinhVien;
create database DuLieuSach3
use DuLieuSach3

CREATE TABLE TaiKhoan
(
    TenTK NVARCHAR(50) PRIMARY KEY NOT NULL,
    MatKhau CHAR(50)
);

CREATE TABLE KhachHang
(
    MaKH NVARCHAR(50) PRIMARY KEY NOT NULL,
    Tenkh NVARCHAR(100) NOT NULL,
    Diachi NVARCHAR(100) NOT NULL,
    Sdt INT
);

CREATE TABLE LoaiSach
(
    Maloai NVARCHAR(20) PRIMARY KEY NOT NULL,
    Tenloai NVARCHAR(30)
);

CREATE TABLE Sach
(
    MaSach NVARCHAR(20) PRIMARY KEY NOT NULL,
    Tensach NVARCHAR(255) NOT NULL,
    Tentacgia NVARCHAR(30),
    NXB NVARCHAR(30),
    Ngaynhap DATETIME,
    Soluongnhap INT,
    Maloai NVARCHAR(20),
    GiaBan FLOAT,
    FOREIGN KEY (Maloai) REFERENCES LoaiSach(Maloai) ON DELETE CASCADE ON UPDATE CASCADE
);

-- Thêm dữ liệu mẫu vào bảng LoaiSach
INSERT INTO LoaiSach (Maloai, Tenloai) VALUES
('LS01', N'Tâm Lý'),
('LS02', N'Kỹ Năng Sống'),
('LS03', N'Văn Học'),
('LS04', N'Kinh Tế'),
('LS05', N'Giáo Dục');

-- Sửa đổi cột Tensach thành kiểu NVARCHAR(255)
ALTER TABLE Sach
ALTER COLUMN Tensach NVARCHAR(255) NOT NULL;

-- Thêm dữ liệu vào bảng Sach
INSERT INTO Sach (MaSach, Tensach, Tentacgia, NXB, Ngaynhap, Soluongnhap, GiaBan, Maloai) VALUES
('S01', N'Hạt giống tâm hồn', N'Nguyễn Văn Phước', N'NXB Trẻ', '2024-06-14', 100, 10000, 'LS01'),
('S02', N'Những bài học cuộc sống', N'Hal Urban', N'NXB Tổng Hợp', '2024-06-14', 50, 50000, 'LS02'),
('S03', N'Sống chậm', 'Melanie Barnes', N'NXB Lao Động', '2024-06-14', 60, 60000, 'LS02'),
('S04', N'Tôi tài giỏi bạn cũng thế', N'Adam Khoo', 'NXB Trẻ', '2024-06-14', 45, 45000, 'LS02'),
('S06', N'Bốn mùa cuộc sống', 'Jim Rohn', 'NXB Lao Động', '2024-06-14', 35, 35000, 'LS02'),
('S07', N'Tôi là ai', 'Richard David Precht', 'NXB Tri Thức', '2024-06-14', 60, 60000, 'LS01'),
('S08', N'Không gia đình', 'Hector Malot', 'NXB Kim Đồng', '2024-06-14', 30, 30000, 'LS03'),
('S09', N'Người thầy', 'Nguyễn Chí Vịnh', 'NXB Trẻ', '2024-06-14', 60, 60000, 'LS03'),
('S10', N'Phù thủy xứ OZ', 'L. Frank Baum', 'NXB Văn Học', '2024-06-14', 70, 70000, 'LS03'),
('S11', N'Mans Search For Meaning', 'Viktor Frankl', 'NXB Tri Thức', '2024-06-14', 45, 45000, 'LS01'),
('S12', N'Tư duy nhanh và chậm', 'Daniel Kahneman', 'NXB Tri Thức', '2024-06-14', 45, 45000, 'LS01'),
('S13', N'The Power of Now', 'Eckhart Tolle', 'NXB Tri Thức', '2024-06-14', 85, 85000, 'LS01'),
('S14', N'Cách người Do Thái quản lý tiền và tài sản', 'Eran Katz', 'NXB Lao Động', '2024-06-14', 75, 75000, 'LS04'),
('S15', N'Phương Pháp Giáo Dục Con Của Người Do Thái', 'Tây Mông', 'NXB Giáo Dục', '2024-06-14', 55, 55000, 'LS05');

CREATE TABLE LichSuNhapSach
(
    ID INT PRIMARY KEY IDENTITY,
    MaSach NVARCHAR(20),
    SoLuongNhap INT,
    NgayNhap DATETIME,
    FOREIGN KEY (MaSach) REFERENCES Sach(MaSach)
);

-- Thêm dữ liệu vào bảng LichSuNhapSach
INSERT INTO LichSuNhapSach (MaSach, SoLuongNhap, NgayNhap) VALUES
('S01', 100, '2024-06-14'),
('S02', 50, '2024-06-14'),
('S03', 60, '2024-06-14');
-- Thêm các bản ghi nhập hàng khác ở đây
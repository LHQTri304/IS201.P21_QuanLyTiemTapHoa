-- Tạo database
-- DROP DATABASE QuanLyTiemTapHoa;
CREATE DATABASE QuanLyTiemTapHoa;
USE QuanLyTiemTapHoa;

-- Bảng SANPHAM
CREATE TABLE SANPHAM (
    MaSP VARCHAR(10) PRIMARY KEY,
    TenSP VARCHAR(100),
    GiaSP DECIMAL(10, 2)
);

-- Bảng NHANVIEN
CREATE TABLE NHANVIEN (
    MaNV VARCHAR(10) PRIMARY KEY,
    TenNV VARCHAR(100),
    ChucVu VARCHAR(50),
    CCCD VARCHAR(20),
    SDT VARCHAR(15),
    Email VARCHAR(100),
    Password VARCHAR(100)
);

-- Bảng KHACHHANG
CREATE TABLE KHACHHANG (
    MaKH VARCHAR(10) PRIMARY KEY,
    SDT VARCHAR(15),
    TenKH VARCHAR(100),
    LoaiKH VARCHAR(50)
);

-- Bảng HOADON
CREATE TABLE HOADON (
    SoHD VARCHAR(10) PRIMARY KEY,
    NgayLap DATE,
    MaNV VARCHAR(10),
    TenKH VARCHAR(100),
    SDT VARCHAR(15),
    TongTien DECIMAL(12, 2),
    FOREIGN KEY (MaNV) REFERENCES NHANVIEN(MaNV)
);

-- Bảng CTHD
CREATE TABLE CTHD (
    SoHD VARCHAR(10),
    NgayLap DATE,
    MaNV VARCHAR(10),
    TenKH VARCHAR(100),
    SDT VARCHAR(15),
    MaSP VARCHAR(10),
    TenSP VARCHAR(100),
    GiaSP DECIMAL(10, 2),
    SoLuong INT,
    TongGia DECIMAL(12, 2),
    TinhTrang VARCHAR(50),
    FOREIGN KEY (SoHD) REFERENCES HOADON(SoHD),
    FOREIGN KEY (MaSP) REFERENCES SANPHAM(MaSP),
    FOREIGN KEY (MaNV) REFERENCES NHANVIEN(MaNV)
);

-- Bảng KHUYENMAI
CREATE TABLE KHUYENMAI (
    MaKM VARCHAR(10) PRIMARY KEY,
    TenKM VARCHAR(100),
    MucKM DECIMAL(5, 2),
    MaNV VARCHAR(10),
    FOREIGN KEY (MaNV) REFERENCES NHANVIEN(MaNV)
);

-- Bảng CTKM
CREATE TABLE CTKM (
    MaKM VARCHAR(10),
    TenKM VARCHAR(100),
    MucKM DECIMAL(5, 2),
    MaSP VARCHAR(10),
    TenSP VARCHAR(100),
    NgayApDung DATE,
    NgayKetThuc DATE,
    FOREIGN KEY (MaKM) REFERENCES KHUYENMAI(MaKM),
    FOREIGN KEY (MaSP) REFERENCES SANPHAM(MaSP)
);

-- Thủ tục lấy thông tin nhân viên theo danh sách tên đăng nhập
DELIMITER //
CREATE PROCEDURE LayNhanVienTheoDanhSachTenDangNhap(
    IN danh_sach_ten TEXT
)
BEGIN
    SET @cau_lenh = CONCAT(
        'SELECT MaNV, TenNV, ChucVu, CCCD, SDT, Email FROM NHANVIEN WHERE Email IN (', danh_sach_ten, ')'
    );
    PREPARE stmt FROM @cau_lenh;
    EXECUTE stmt;
    DEALLOCATE PREPARE stmt;
END //
DELIMITER ;

-- Thủ tục kiểm tra đăng nhập
DELIMITER //
CREATE PROCEDURE DangNhapNhanVien(
    IN p_Email VARCHAR(100),
    IN p_Password VARCHAR(100)
)
BEGIN
    SELECT MaNV, TenNV, ChucVu, CCCD, SDT, Email
    FROM NHANVIEN
    WHERE Email = p_Email AND Password = p_Password;
END //
DELIMITER ;

-- Thủ tục thêm hóa đơn trống mới
DELIMITER //
CREATE PROCEDURE ThemHoaDonMoi()
BEGIN
    DECLARE newSoHD VARCHAR(10);
    DECLARE lastSoHD VARCHAR(10);
    DECLARE lastNumber INT;
    DECLARE firstMaNV VARCHAR(10);
    DECLARE firstSDT VARCHAR(20);
    DECLARE firstTenKH VARCHAR(100);

    -- Lấy SoHD cuối cùng (giá trị lớn nhất)
    SELECT SoHD INTO lastSoHD
    FROM HOADON
    ORDER BY SoHD DESC
    LIMIT 1;

    -- Nếu chưa có hóa đơn nào thì mặc định bắt đầu từ HD00
    IF lastSoHD IS NULL THEN
        SET lastNumber = 0;
    ELSE
        -- Lấy số từ SoHD (bỏ "HD" đầu)
        SET lastNumber = CAST(SUBSTRING(lastSoHD, 3) AS UNSIGNED);
    END IF;

    -- Tạo SoHD mới, định dạng HDxx với padding 2 chữ số
    SET newSoHD = CONCAT('HD', LPAD(lastNumber + 1, 2, '0'));

    -- Lấy nhân viên đầu tiên
    SELECT MaNV, SDT INTO firstMaNV, firstSDT
    FROM NHANVIEN
    ORDER BY MaNV ASC
    LIMIT 1;

    -- Lấy khách hàng đầu tiên
    SELECT TenKH INTO firstTenKH
    FROM KHACHHANG
    ORDER BY MaKH ASC
    LIMIT 1;

    -- Thêm dòng mới vào HOADON
    INSERT INTO HOADON (SoHD, NgayLap, MaNV, SDT, TenKH, TongTien)
    VALUES (newSoHD, NOW(), firstMaNV, firstSDT, firstTenKH, 0);
END //
DELIMITER ;

-- Thủ tục xóa hóa đơn và chi tiết hóa đơn liên quan
DELIMITER //
CREATE PROCEDURE XoaHoaDon(
    IN p_SoHD VARCHAR(10)
)
BEGIN
    DELETE FROM CTHD WHERE SoHD = p_SoHD;
    DELETE FROM HOADON WHERE SoHD = p_SoHD;
END //
DELIMITER ;

-- Thủ tục thêm/xóa sản phẩm vào chi tiết hóa đơn
DELIMITER //
CREATE PROCEDURE ThemSanPhamVaoCTHD(
    IN p_SoHD VARCHAR(10),
    IN p_MaSP VARCHAR(10),
    IN p_SoLuong INT
)
BEGIN
    DECLARE v_MaNV VARCHAR(10);
    DECLARE v_SDT VARCHAR(15);
    DECLARE v_TenKH VARCHAR(100);
    DECLARE v_TenSP VARCHAR(100);
    DECLARE v_GiaSP DECIMAL(18, 2);
    DECLARE v_TongGia DECIMAL(18, 2);
    DECLARE v_SoLuongHienTai INT DEFAULT 0;
    DECLARE v_TonTai INT DEFAULT 0;

    -- Kiểm tra có tồn tại dòng sản phẩm trong hóa đơn không
    SELECT COUNT(*) INTO v_TonTai
    FROM CTHD
    WHERE SoHD = p_SoHD AND MaSP = p_MaSP;

    -- Nếu đã tồn tại
    IF v_TonTai > 0 THEN
        SELECT SoLuong INTO v_SoLuongHienTai
        FROM CTHD
        WHERE SoHD = p_SoHD AND MaSP = p_MaSP;

        SELECT GiaSP INTO v_GiaSP
        FROM SANPHAM
        WHERE MaSP = p_MaSP;

        -- Nếu số lượng thêm là âm
        IF p_SoLuong < 0 THEN
            IF v_SoLuongHienTai + p_SoLuong <= 0 THEN
                -- Xóa dòng nếu số lượng mới ≤ 0
                DELETE FROM CTHD
                WHERE SoHD = p_SoHD AND MaSP = p_MaSP;
            ELSE
                -- Trừ bớt số lượng và cập nhật tổng giá
                SET v_SoLuongHienTai = v_SoLuongHienTai + p_SoLuong;
                SET v_TongGia = v_GiaSP * v_SoLuongHienTai;

                UPDATE CTHD
                SET SoLuong = v_SoLuongHienTai,
                    TongGia = v_TongGia
                WHERE SoHD = p_SoHD AND MaSP = p_MaSP;
            END IF;
        ELSE
            -- Nếu số lượng dương thì cộng thêm
            SET v_SoLuongHienTai = v_SoLuongHienTai + p_SoLuong;
            SET v_TongGia = v_GiaSP * v_SoLuongHienTai;

            UPDATE CTHD
            SET SoLuong = v_SoLuongHienTai,
                TongGia = v_TongGia
            WHERE SoHD = p_SoHD AND MaSP = p_MaSP;
        END IF;
    ELSE
        -- Nếu chưa có sản phẩm trong hóa đơn
        IF p_SoLuong > 0 THEN
            SELECT MaNV, SDT INTO v_MaNV, v_SDT
            FROM NHANVIEN
            ORDER BY MaNV
            LIMIT 1;

            SELECT TenKH INTO v_TenKH
            FROM KHACHHANG
            ORDER BY MaKH
            LIMIT 1;

            SELECT TenSP, GiaSP INTO v_TenSP, v_GiaSP
            FROM SANPHAM
            WHERE MaSP = p_MaSP;

            SET v_TongGia = v_GiaSP * p_SoLuong;

            INSERT INTO CTHD (
                SoHD, MaSP, SoLuong, NgayLap,
                MaNV, SDT, TenKH, TenSP,
                GiaSP, TongGia, TinhTrang
            )
            VALUES (
                p_SoHD, p_MaSP, p_SoLuong, NOW(),
                v_MaNV, v_SDT, v_TenKH, v_TenSP,
                v_GiaSP, v_TongGia, 'Da ban'
            );
        END IF;
        -- Nếu p_SoLuong < 0 và chưa có dòng thì không làm gì cả
    END IF;
END //
DELIMITER ;

-- Thêm dữ liệu mẫu
-- 1. Thêm sản phẩm
INSERT INTO SANPHAM VALUES
('SP01', 'Sua tuoi', 15000),
('SP02', 'Mi tom', 3500),
('SP03', 'Nuoc ngot', 10000),
('SP04', 'Banh mi', 3000),
('SP05', 'Banh quy', 12000),
('SP06', 'Tra xanh', 8000),
('SP07', 'Ca phe', 12000),
('SP08', 'Nuoc suoi', 5000),
('SP09', 'Kem danh rang', 22000),
('SP10', 'Xa bong', 18000),
('SP11', 'Dau an', 40000),
('SP12', 'Duong', 15000),
('SP13', 'Muoi', 8000),
('SP14', 'Trung ga', 25000),
('SP15', 'Bot ngot', 18000),
('SP16', 'Bia', 14000),
('SP17', 'Nuoc mam', 30000),
('SP18', 'Banh trang', 9000),
('SP19', 'Bot giat', 50000),
('SP20', 'Giay ve sinh', 10000);

-- 2. Thêm nhân viên
INSERT INTO NHANVIEN VALUES
('NV01', 'Nguyen Van A', 'Quan ly', '123456789', '0909123456', 'admin', '1'),
('NV02', 'Tran Thi B', 'Ban hang', '223456789', '0909123457', 'b@gmail.com', 'pass2'),
('NV03', 'Le Van C', 'Thu ngan', '323456789', '0909123458', 'c@gmail.com', 'pass3'),
('NV04', 'Pham Thi D', 'Ban hang', '423456789', '0909123459', 'd@gmail.com', 'pass4'),
('NV05', 'Do Van E', 'Kho', '523456789', '0909123460', 'e@gmail.com', 'pass5');

-- 3. Thêm khách hàng
INSERT INTO KHACHHANG VALUES
('KH01', '0909120001', 'Nguyen Thi X', 'Vip'),
('KH02', '0909120002', 'Tran Van Y', 'Thuong'),
('KH03', '0909120003', 'Le Thi Z', 'Moi'),
('KH04', '0909120004', 'Pham Van M', 'Vip'),
('KH05', '0909120005', 'Hoang Thi N', 'Thuong');

-- 4. Thêm hóa đơn và CTHD
-- INSERT INTO HOADON VALUES
-- ('HD01', '2024-06-01', 'NV01', 'Nguyen Thi X', '0909120001', 15000),
-- ('HD02', '2024-06-02', 'NV02', 'Tran Van Y', '0909120002', 23000),
-- ('HD03', '2024-06-03', 'NV03', 'Le Thi Z', '0909120003', 45000),
-- ('HD04', '2024-06-04', 'NV04', 'Pham Van M', '0909120004', 75000),
-- ('HD05', '2024-06-05', 'NV05', 'Hoang Thi N', '0909120005', 100000);
CALL ThemHoaDonMoi();
CALL ThemHoaDonMoi();
CALL ThemHoaDonMoi();
CALL ThemHoaDonMoi();
CALL ThemHoaDonMoi();

-- CTHD cho mỗi hóa đơn, từ 1 đến 5 sản phẩm
INSERT INTO CTHD VALUES
('HD01', '2024-06-01', 'NV01', 'Nguyen Thi X', '0909120001', 'SP01', 'Sua tuoi', 15000, 1, 15000, 'Da ban'),

('HD02', '2024-06-02', 'NV02', 'Tran Van Y', '0909120002', 'SP02', 'Mi tom', 3500, 2, 7000, 'Da ban'),
('HD02', '2024-06-02', 'NV02', 'Tran Van Y', '0909120002', 'SP03', 'Nuoc ngot', 10000, 1, 10000, 'Da ban'),

('HD03', '2024-06-03', 'NV03', 'Le Thi Z', '0909120003', 'SP04', 'Banh mi', 3000, 2, 6000, 'Da ban'),
('HD03', '2024-06-03', 'NV03', 'Le Thi Z', '0909120003', 'SP05', 'Banh quy', 12000, 2, 24000, 'Da ban'),
('HD03', '2024-06-03', 'NV03', 'Le Thi Z', '0909120003', 'SP06', 'Tra xanh', 8000, 2, 16000, 'Da ban'),

('HD04', '2024-06-04', 'NV04', 'Pham Van M', '0909120004', 'SP07', 'Ca phe', 12000, 1, 12000, 'Da ban'),
('HD04', '2024-06-04', 'NV04', 'Pham Van M', '0909120004', 'SP08', 'Nuoc suoi', 5000, 2, 10000, 'Da ban'),
('HD04', '2024-06-04', 'NV04', 'Pham Van M', '0909120004', 'SP09', 'Kem danh rang', 22000, 1, 22000, 'Da ban'),
('HD04', '2024-06-04', 'NV04', 'Pham Van M', '0909120004', 'SP10', 'Xa bong', 18000, 1, 18000, 'Da ban'),

('HD05', '2024-06-05', 'NV05', 'Hoang Thi N', '0909120005', 'SP11', 'Dau an', 40000, 1, 40000, 'Da ban'),
('HD05', '2024-06-05', 'NV05', 'Hoang Thi N', '0909120005', 'SP12', 'Duong', 15000, 1, 15000, 'Da ban'),
('HD05', '2024-06-05', 'NV05', 'Hoang Thi N', '0909120005', 'SP13', 'Muoi', 8000, 2, 16000, 'Da ban'),
('HD05', '2024-06-05', 'NV05', 'Hoang Thi N', '0909120005', 'SP14', 'Trung ga', 25000, 1, 25000, 'Da ban'),
('HD05', '2024-06-05', 'NV05', 'Hoang Thi N', '0909120005', 'SP15', 'Bot ngot', 18000, 1, 18000, 'Da ban');

-- 5. Thêm khuyến mãi và CTKM
INSERT INTO KHUYENMAI VALUES
('KM01', 'Giam gia 10%', 10.00, 'NV01'),
('KM02', 'Giam gia 15%', 15.00, 'NV02'),
('KM03', 'Giam gia 20%', 20.00, 'NV03'),
('KM04', 'Giam gia 25%', 25.00, 'NV04'),
('KM05', 'Giam gia 30%', 30.00, 'NV05');

INSERT INTO CTKM VALUES
('KM01', 'Giam gia 10%', 10.00, 'SP01', 'Sua tuoi', '2024-06-01', '2024-06-30'),

('KM02', 'Giam gia 15%', 15.00, 'SP02', 'Mi tom', '2024-06-01', '2024-06-30'),
('KM02', 'Giam gia 15%', 15.00, 'SP03', 'Nuoc ngot', '2024-06-01', '2024-06-30'),

('KM03', 'Giam gia 20%', 20.00, 'SP04', 'Banh mi', '2024-06-01', '2024-06-30'),
('KM03', 'Giam gia 20%', 20.00, 'SP05', 'Banh quy', '2024-06-01', '2024-06-30'),
('KM03', 'Giam gia 20%', 20.00, 'SP06', 'Tra xanh', '2024-06-01', '2024-06-30'),

('KM04', 'Giam gia 25%', 25.00, 'SP07', 'Ca phe', '2024-06-01', '2024-06-30'),
('KM04', 'Giam gia 25%', 25.00, 'SP08', 'Nuoc suoi', '2024-06-01', '2024-06-30'),
('KM04', 'Giam gia 25%', 25.00, 'SP09', 'Kem danh rang', '2024-06-01', '2024-06-30'),
('KM04', 'Giam gia 25%', 25.00, 'SP10', 'Xa bong', '2024-06-01', '2024-06-30'),

('KM05', 'Giam gia 30%', 30.00, 'SP11', 'Dau an', '2024-06-01', '2024-06-30'),
('KM05', 'Giam gia 30%', 30.00, 'SP12', 'Duong', '2024-06-01', '2024-06-30'),
('KM05', 'Giam gia 30%', 30.00, 'SP13', 'Muoi', '2024-06-01', '2024-06-30'),
('KM05', 'Giam gia 30%', 30.00, 'SP14', 'Trung ga', '2024-06-01', '2024-06-30'),
('KM05', 'Giam gia 30%', 30.00, 'SP15', 'Bot ngot', '2024-06-01', '2024-06-30');

-- Tạo database
-- DROP DATABASE QuanLyTiemTapHoa;
CREATE DATABASE QuanLyTiemTapHoa;
USE QuanLyTiemTapHoa;

-- Bảng Users (Nhân viên và quản trị viên)
CREATE TABLE Users (
    UserID INT AUTO_INCREMENT PRIMARY KEY,
    FullName VARCHAR(100) NOT NULL,
    Username VARCHAR(50) UNIQUE NOT NULL,
    PasswordHash VARCHAR(255) NOT NULL,
    Role ENUM('admin', 'staff') NOT NULL,
    Phone VARCHAR(15),
    Email VARCHAR(100)
);

INSERT INTO Users (FullName, Username, PasswordHash, Role, Phone, Email) VALUES
('Admin User', 'admin', '1', 'admin', '0123456789', 'admin@example.com'),
('John Doe', 'johndoe', '2', 'staff', '0987654321', 'john@example.com'),
('Jane Smith', 'janesmith', '3', 'staff', '0912345678', 'jane@example.com'),
('Mike Johnson', 'mikej', '4', 'staff', '0909090909', 'mike@example.com');

-- Bảng Customers (Khách hàng)
CREATE TABLE Customers (
    CustomerID INT AUTO_INCREMENT PRIMARY KEY,
    FullName VARCHAR(100) NOT NULL,
    Phone VARCHAR(15) UNIQUE,
    Email VARCHAR(100) UNIQUE,
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

INSERT INTO Customers (FullName, Phone, Email) VALUES
('Unknown', '0000000000', 'unknown@example.com'),
('Bob White', '0822222222', 'bob@example.com'),
('Charlie Green', '0833333333', 'charlie@example.com'),
('David Black', '0844444444', 'david@example.com'),
('Emma Wilson', '0855555555', 'emma@example.com');

-- Bảng Categories (Danh mục sản phẩm)
CREATE TABLE Categories (
    CategoryID INT AUTO_INCREMENT PRIMARY KEY,
    CategoryName VARCHAR(100) NOT NULL
);

INSERT INTO Categories (CategoryName) VALUES
('Rỗng'),
('Thực phẩm tươi sống'),
('Đồ uống'),
('Sản phẩm từ sữa'),
('Đồ hộp và thực phẩm khô'),
('Bánh kẹo và đồ ăn vặt'),
('Đồ gia dụng'),
('Sản phẩm chăm sóc cá nhân'),
('Đồ dùng vệ sinh'),
('Đồ dùng nhà bếp'),
('Đồ dùng văn phòng phẩm');

-- Bảng Products (Sản phẩm)
CREATE TABLE Products (
    ProductID INT AUTO_INCREMENT PRIMARY KEY,
    ProductName VARCHAR(200) NOT NULL,
    CategoryID INT,
    Price INT NOT NULL,
    StockQuantity INT DEFAULT 0,
    FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID) ON DELETE CASCADE
);

INSERT INTO Products (ProductName, CategoryID, Price, StockQuantity) VALUES
('Thịt heo vai', 2, 136000, 234),
('Cá hồi đông lạnh', 2, 250000, 312),
('Bịch gạo ST25 5kg', 2, 150000, 198),
('Bình nước Aquavina 5l', 2, 30000, 421),
('Rau cải xanh', 2, 25000, 367),
('Nước ngọt Coca-Cola', 3, 12000, 145),
('Trà xanh C2', 3, 10000, 389),
('Sữa tươi Vinamilk', 3, 25000, 276),
('Nước ép trái cây Tropicana', 3, 35000, 497),
('Nước khoáng Lavie', 3, 8000, 321),
('Sữa chua Vinamilk', 4, 6000, 142),
('Phô mai Con Bò Cười', 4, 50000, 367),
('Sữa đặc Ông Thọ', 4, 20000, 221),
('Sữa tươi TH True Milk', 4, 25000, 198),
('Bơ Anchor', 4, 80000, 312),
('Cá hộp Vissan', 5, 25000, 145),
('Đậu phộng rang muối', 5, 30000, 276),
('Mì gói Hảo Hảo', 5, 5000, 389),
('Bánh quy Oreo', 5, 20000, 234),
('Nấm hương khô', 5, 150000, 421),
('Kẹo dẻo Haribo', 6, 35000, 198),
('Bánh Choco-Pie', 6, 50000, 367),
('Snack khoai tây Lay', 6, 20000, 312),
('Kẹo sô cô la KitKat', 6, 25000, 145),
('Bánh quy Ritz', 6, 30000, 276),
('Nồi cơm điện Sharp', 7, 800000, 234),
('Máy xay sinh tố Philips', 7, 1200000, 389),
('Bàn ủi Panasonic', 7, 500000, 312),
('Quạt điện Senko', 7, 300000, 145),
('Máy hút bụi Electrolux', 7, 2000000, 276),
('Dầu gội Clear', 8, 100000, 198),
('Sữa tắm Dove', 8, 120000, 367),
('Kem đánh răng Colgate', 8, 50000, 312),
('Nước hoa hồng Nivea', 8, 150000, 145),
('Kem dưỡng da Vaseline', 8, 80000, 276),
('Bồn cầu Inax', 9, 3500000, 234),
('Lavabo Toto', 9, 2000000, 389),
('Vòi sen Caesar', 9, 1200000, 312),
('Gương soi phòng tắm', 9, 500000, 145),
('Kệ để đồ nhà tắm', 9, 300000, 276),
('Chảo chống dính Sunhouse', 10, 250000, 198),
('Bộ dao kéo Lock&Lock', 10, 500000, 367),
('Nồi inox Kangaroo', 10, 300000, 312),
('Máy ép trái cây Philips', 10, 1500000, 145),
('Lò vi sóng Electrolux', 10, 2000000, 276),
('Giấy in Double A A4', 11, 75000, 234),
('Bút bi Thiên Long', 11, 5000, 389),
('Sổ tay Campus', 11, 20000, 312),
('Kẹp giấy Deli', 11, 10000, 145),
('Băng keo Scotch', 11, 15000, 276);



-- Bảng Orders (Đơn hàng)
CREATE TABLE Orders (
    OrderID INT AUTO_INCREMENT PRIMARY KEY,
    CustomerID INT NOT NULL DEFAULT 1,
    UserID INT,
    OrderDate TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    Status ENUM('pending', 'completed', 'cancelled') DEFAULT 'pending',
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID) ON DELETE CASCADE,
    FOREIGN KEY (UserID) REFERENCES Users(UserID) ON DELETE CASCADE
);

INSERT INTO Orders (CustomerID, UserID, Status) VALUES
(1, 2, 'completed'),
(2, 3, 'pending'),
(3, 2, 'completed'),
(4, 4, 'completed'),
(5, 3, 'cancelled'),
(1, 4, 'pending');

-- Bảng OrderDetails (Chi tiết đơn hàng)
CREATE TABLE OrderDetails (
    OrderDetailID INT AUTO_INCREMENT PRIMARY KEY,
    OrderID INT,
    ProductID INT,
    Quantity INT NOT NULL,
    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID) ON DELETE CASCADE,
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID) ON DELETE CASCADE
);

INSERT INTO OrderDetails (OrderID, ProductID, Quantity) VALUES
(1, 1, 2),
(1, 2, 1),
(1, 3, 3),
(2, 2, 4),
(2, 4, 2),
(3, 3, 5),
(3, 5, 2),
(4, 1, 3),
(4, 4, 4),
(5, 5, 1),
(6, 2, 3),
(6, 3, 2);


-- Thủ tục lấy thông tin người dùng theo Username, nhiều username
DELIMITER //
CREATE PROCEDURE USP_GetUsersByUsernames (
    IN user_list TEXT
)
BEGIN
    SET @sql_query = CONCAT(
        'SELECT UserID, FullName, Username, Role, Phone, Email FROM Users WHERE Username IN (', user_list, ')'
    );
    PREPARE stmt FROM @sql_query;
    EXECUTE stmt;
    DEALLOCATE PREPARE stmt;
END //
DELIMITER ;


-- Thủ tục lấy thông tin login theo Username & Password
DELIMITER //
CREATE PROCEDURE GetUserLogin_ByUsernameAndPassword(
    IN p_Username VARCHAR(50),
    IN p_PasswordHash VARCHAR(255)
)
BEGIN
    SELECT UserID, FullName, Username, Role, Phone, Email
    FROM Users
    WHERE Username = p_Username AND PasswordHash = p_PasswordHash;
END //
DELIMITER ;;


-- Thủ tục xóa một đơn hàng cùng với tất cả chi tiết đơn hàng liên quan
DELIMITER //
CREATE PROCEDURE DeleteOrder (
    IN p_OrderID INT
)
BEGIN
    -- Xóa tất cả chi tiết đơn hàng trước
    DELETE FROM OrderDetails WHERE OrderID = p_OrderID;

    -- Xóa đơn hàng
    DELETE FROM Orders WHERE OrderID = p_OrderID;
END //
DELIMITER ;


-- Thủ tục thêm sản phẩm vào chi tiết đơn hàng
-- Nếu sản phẩm chưa có trong đơn hàng → Thêm mới.
-- Nếu sản phẩm đã tồn tại trong đơn hàng → Cập nhật số lượng.
DELIMITER //
CREATE PROCEDURE AddProductInOrder (
    IN p_OrderID INT,
    IN p_ProductID INT,
    IN p_Quantity INT
)
BEGIN
    DECLARE v_ExistingQuantity INT;

    -- Kiểm tra xem sản phẩm đã tồn tại trong chi tiết đơn hàng chưa
    SELECT Quantity INTO v_ExistingQuantity
    FROM OrderDetails
    WHERE OrderID = p_OrderID AND ProductID = p_ProductID;

    -- Nếu sản phẩm chưa tồn tại, thêm mới
    IF v_ExistingQuantity IS NULL THEN
        INSERT INTO OrderDetails (OrderID, ProductID, Quantity)
        VALUES (p_OrderID, p_ProductID, p_Quantity);
    ELSE
        -- Nếu sản phẩm đã tồn tại, cập nhật số lượng
        UPDATE OrderDetails 
        SET Quantity = Quantity + p_Quantity
        WHERE OrderID = p_OrderID AND ProductID = p_ProductID;
    END IF;
END //
DELIMITER ;


-- Thủ tục xóa sản phẩm khỏi chi tiết đơn hàng
-- Nếu sản phẩm không tồn tại trong đơn hàng → Báo lỗi.
-- Nếu số lượng cần xóa lớn hơn hoặc bằng số lượng hiện có → Xóa sản phẩm khỏi đơn hàng.
-- Nếu số lượng cần xóa nhỏ hơn số lượng hiện có → Cập nhật lại số lượng.
DELIMITER //
CREATE PROCEDURE RemoveProductFromOrder (
    IN p_OrderID INT,
    IN p_ProductID INT,
    IN p_Quantity INT
)
BEGIN
    DECLARE v_CurrentQuantity INT;

    -- Lấy số lượng sản phẩm hiện có trong đơn hàng
    SELECT Quantity INTO v_CurrentQuantity
    FROM OrderDetails
    WHERE OrderID = p_OrderID AND ProductID = p_ProductID;

    -- Kiểm tra nếu không tìm thấy sản phẩm trong đơn hàng
    IF v_CurrentQuantity IS NULL THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'Sản phẩm không tồn tại trong đơn hàng!';
    END IF;

    -- Nếu số lượng cần xóa >= số lượng hiện có, xóa luôn sản phẩm khỏi đơn hàng
    IF p_Quantity >= v_CurrentQuantity THEN
        DELETE FROM OrderDetails 
        WHERE OrderID = p_OrderID AND ProductID = p_ProductID;
    ELSE
        -- Nếu số lượng cần xóa < số lượng hiện có, chỉ cập nhật lại số lượng
        UPDATE OrderDetails 
        SET Quantity = Quantity - p_Quantity
        WHERE OrderID = p_OrderID AND ProductID = p_ProductID;
    END IF;
END //
DELIMITER ;

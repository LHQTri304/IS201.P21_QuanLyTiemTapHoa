-- Tạo database
DROP DATABASE QuanLyTiemTapHoa;
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
    Email VARCHAR(100),
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP
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
('Dairy'),
('Bakery'),
('Grain'),
('Grocery');

-- Bảng Products (Sản phẩm)
CREATE TABLE Products (
    ProductID INT AUTO_INCREMENT PRIMARY KEY,
    ProductName VARCHAR(200) NOT NULL,
    CategoryID INT,
    Price DECIMAL(10,2) NOT NULL,
    StockQuantity INT DEFAULT 0,	
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID)
);

INSERT INTO Products (ProductName, CategoryID, Price, StockQuantity) VALUES
('Milk', 1, 1.50, 100),
('Bread', 2, 2.00, 80),
('Rice', 3, 3.00, 120),
('Eggs', 1, 2.50, 90),
('Sugar', 4, 1.75, 110);

-- Bảng Orders (Đơn hàng)
CREATE TABLE Orders (
    OrderID INT AUTO_INCREMENT PRIMARY KEY,
    CustomerID INT NOT NULL DEFAULT 1,
    UserID INT,
    OrderDate TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    Status ENUM('pending', 'completed', 'cancelled') DEFAULT 'pending',
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
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
    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
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
        'SELECT UserID, FullName, Username, Role, Phone, Email, CreatedAt FROM Users WHERE Username IN (', user_list, ')'
    );
    PREPARE stmt FROM @sql_query;
    EXECUTE stmt;
    DEALLOCATE PREPARE stmt;
END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE GetUserLogin_ByUsernameAndPassword(
    IN p_Username VARCHAR(50),
    IN p_PasswordHash VARCHAR(255)
)
BEGIN
    SELECT UserID, FullName, Username, Role, Phone, Email, CreatedAt
    FROM Users
    WHERE Username = p_Username AND PasswordHash = p_PasswordHash;
END //
DELIMITER ;
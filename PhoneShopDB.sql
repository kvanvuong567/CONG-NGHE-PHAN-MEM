CREATE DATABASE PhoneShopDB
go
USE PhoneShopDB
go
-- Tạo bảng Product
CREATE TABLE Product (
    ProductID INT PRIMARY KEY IDENTITY(1,1), 
    ProductName NVARCHAR(100) NOT NULL,      
    Price FLOAT NOT NULL,                     
    Stock INT NOT NULL,                       
    Brand NVARCHAR(100) NOT NULL,            
    Description NVARCHAR(255)                
)
go
-- Tạo bảng Order
CREATE TABLE [Order] (
    OrderID INT PRIMARY KEY IDENTITY(1,1), 
    CustomerName NVARCHAR(100) NOT NULL,   
    ProductID INT NOT NULL,                 
    Quantity INT NOT NULL,                   
    OrderDate DATETIME NOT NULL DEFAULT GETDATE(), 
    TotalPrice FLOAT NOT NULL,               
    FOREIGN KEY (ProductID) REFERENCES Product(ProductID) 
);

-- Thêm dữ liệu mẫu vào bảng Product với giá VND
INSERT INTO Product (ProductName, Price, Stock, Brand, Description)
VALUES 
    (N'iPhone 13 Pro Max', 25849747, 25, N'Apple', N'Model cao cấp với màn hình 6.7 inch và camera siêu nét'),
    (N'Samsung Galaxy S21 Ultra', 28129973, 20, N'Samsung', N'Điện thoại hàng đầu với camera 108MP và màn hình 6.8 inch'),
    (N'Xiaomi Mi 11 Ultra', 21118983, 15, N'Xiaomi', N'Mẫu flagship với camera 50MP và sạc nhanh 67W'),
    (N'Oppo Find X5 Pro', 23449973, 18, N'Oppo', N'Chất lượng camera vượt trội với thiết kế sang trọng'),
    (N'Google Pixel 6 Pro', 21118983, 10, N'Google', N'Camera AI mạnh mẽ và hiệu suất tuyệt vời');

-- Thêm dữ liệu mẫu vào bảng Order với giá VND
INSERT INTO [Order] (CustomerName, ProductID, Quantity, TotalPrice)
VALUES 
    (N'Nguyễn Văn Thành', 1, 1, 25849747),   -- iPhone 13 Pro Max
    (N'Trần Thị Bình', 2, 2, 56259946),    -- Samsung Galaxy S21 Ultra
    (N'Lê Văn Chánh', 3, 1, 21118983),      -- Xiaomi Mi 11 Ultra
    (N'Hoàng Thị Kim Trúc', 4, 1, 23449973),   -- Oppo Find X5 Pro
    (N'Phạm Văn Hữu', 5, 3, 63356949);    -- Google Pixel 6 Pro

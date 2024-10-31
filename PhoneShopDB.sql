CREATE DATABASE PhoneShopDB;
GO
USE PhoneShopDB;
GO

-- Tạo bảng Product với ImageURL
CREATE TABLE Product (
    ProductID INT PRIMARY KEY IDENTITY(1,1),
    ProductName NVARCHAR(100) NOT NULL,
    Price FLOAT NOT NULL,
    Stock INT NOT NULL,
    Brand NVARCHAR(100) NOT NULL,
    Description NVARCHAR(255),
    ImageURL NVARCHAR(255) -- Thêm cột URL ảnh
);
GO

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

-- Thêm dữ liệu mẫu vào bảng Product với ImageURL
INSERT INTO Product (ProductName, Price, Stock, Brand, Description, ImageURL)
VALUES 
    (N'iPhone 13 Pro Max', 25849747, 25, N'Apple', N'Model cao cấp với màn hình 6.7 inch và camera siêu nét', N'https://th.bing.com/th/id/OIP.IA7EhAFiKUpm76lbvzh-ygHaJ4?rs=1&pid=ImgDetMain'),
    (N'Samsung Galaxy S21 Ultra', 28129973, 20, N'Samsung', N'Điện thoại hàng đầu với camera 108MP và màn hình 6.8 inch', N'https://th.bing.com/th/id/OIP.Sj38FFNXMvk6S-2KWcKyigHaJM?rs=1&pid=ImgDetMain'),
    (N'Xiaomi Mi 11 Ultra', 21118983, 15, N'Xiaomi', N'Mẫu flagship với camera 50MP và sạc nhanh 67W', N'https://th.bing.com/th/id/R.eabe1cd6b5468db9b7084a94969c8a46?rik=t1F%2b6XlUa6k%2bIw&pid=ImgRaw&r=0'),
    (N'Oppo Find X5 Pro', 23449973, 18, N'Oppo', N'Chất lượng camera vượt trội với thiết kế sang trọng', N'https://th.bing.com/th/id/R.311e892fbd1097f0872348813a8d6bc1?rik=VxYfQLlohOvy1g&pid=ImgRaw&r=0'),
    (N'Google Pixel 6 Pro', 21118983, 10, N'Google', N'Camera AI mạnh mẽ và hiệu suất tuyệt vời', N'https://th.bing.com/th/id/R.a4a89c32cbcf3e86063f9e7b4f3404b5?rik=7fqXyCMwSDW3cQ&pid=ImgRaw&r=0');
	
	




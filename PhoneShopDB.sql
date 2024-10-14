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

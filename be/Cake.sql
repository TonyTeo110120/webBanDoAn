CREATE DATABASE Cake
GO

USE Cake
GO

CREATE TABLE Categories
(
	CategoryId int PRIMARY KEY,
	CategoryName nvarchar(255)
)
GO

CREATE TABLE Products
(
	ProductId int IDENTITY(1,1) PRIMARY KEY,
	ProductName nvarchar(255),
	CategoryId int,
	Price float,
	Avatar nvarchar(255),
	InStocks int,
	CONSTRAINT FK_CategoryId FOREIGN KEY(CategoryId)
		REFERENCES Categories(CategoryId)
)
GO

Insert Into Categories(CategoryId,CategoryName)
values (1, N'Đồ Ăn')
Insert Into Categories(CategoryId,CategoryName)
values (2, N'Đồ uống')
Insert Into Categories(CategoryId,CategoryName)
values (3, N'Bánh Kem')
Insert Into Categories(CategoryId,CategoryName)
values (4, N'Tráng Miệng')
select * from Categories
	
	

Insert Into Products (ProductName,CategoryId,Price,Avatar,InStocks)
values (N'Cơm Gà',1, 20000,N'https://images.foody.vn/res/g28/277130/prof/s750x400/foody-upload-api-foody-mobile-5-201006112619.jpg',100)
Insert Into Products (ProductName,CategoryId,Price,Avatar,InStocks)
values (N'Cháo Dinh Dưỡng',1, 10000,N'https://images.foody.vn/res/g99/987204/prof/s750x400/foody-upload-api-foody-mobile-hoc-nau-chao-dinh-du-191205150756.jpg',10)
Insert Into Products (ProductName,CategoryId,Price,Avatar,InStocks)
values (N'Bún Đậu Mắm Tôm',1, 450,N'https://images.foody.vn/res/g100001/1000000209/prof/s750x400/file_restaurant_photo_zajt_16369-d0c47432-211115195618.jpg',40)
Insert Into Products (ProductName,CategoryId,Price,Avatar,InStocks)
values (N'Cơm Gà Sôi Mỡ',1, 450,N'https://images.foody.vn/res/g100001/1000000248/prof/s750x400/foody-upload-api-foody-mobile-5-200518104607.jpg',40)

Insert Into Products (ProductName,CategoryId,Price,Avatar,InStocks)
values (N'Tiger',2, 1400,N'https://images.foody.vn/res/g90/894577/prof/s750x400/foody-upload-api-foody-mobile-img_7714-191203134854.jpg',20)
Insert Into Products (ProductName,CategoryId,Price,Avatar,InStocks)
values (N'Trà Sữa 52',2, 1400,N'https://images.foody.vn/res/g79/789052/prof/s750x400/foody-upload-api-foody-mobile-3-200605091741.jpg',20)
Insert Into Products (ProductName,CategoryId,Price,Avatar,InStocks)
values (N'Coffee',2, 1400,N'https://images.foody.vn/res/g19/184588/prof/s750x400/foody-upload-api-foody-mobile-1111-200528174110.jpg',20)
Insert Into Products (ProductName,CategoryId,Price,Avatar,InStocks)
values (N'Coffee Phúc Long',2, 1400,N'https://images.foody.vn/res/g19/184588/prof/s750x400/foody-upload-api-foody-mobile-1111-200528174110.jpg',20)



Insert Into Products (ProductName,CategoryId,Price,Avatar,InStocks)
values (N'Đông Tiến Bakery',3, 900,N'https://images.foody.vn/res/g9/86745/prof/s750x400/foody-mobile-bong-lan-trai-cay-1-.jpg',50)
Insert Into Products (ProductName,CategoryId,Price,Avatar,InStocks)
values (N'Bánh Cherry',3, 1100,N'https://images.foody.vn/res/g104/1034711/prof/s750x400/foody-upload-api-foody-mobile-banhbonglanjj-200707104813.jpg',10)
Insert Into Products (ProductName,CategoryId,Price,Avatar,InStocks)
values (N'Happy Cake',3, 1100,N'https://images.foody.vn/res/g95/946508/prof/s750x400/foody-upload-api-foody-mobile-banh-191127085613.jpg',10)
Insert Into Products (ProductName,CategoryId,Price,Avatar,InStocks)
values (N'Bánh Anh Quân Bakery',3, 1100,N'https://images.foody.vn/res/g106/1057551/prof/s750x400/foody-upload-api-foody-mobile-118286450_7392118232-201127131941.jpg',10)

Insert Into Products (ProductName,CategoryId,Price,Avatar,InStocks)
values (N'ChiKi Hoàng Phương',4,600,N'https://images.foody.vn/res/g98/971627/prof/s750x400/file_restaurant_photo_j3kl_16123-b502ec1f-210203153055.jpg',5)
Insert Into Products (ProductName,CategoryId,Price,Avatar,InStocks)
values (N'Chân Gà',4,600,N'https://images.foody.vn/res/g100001/1000000069/prof/s750x400/file_restaurant_photo_5r7a_16035-b62f02c1-201025093611.jpg',10)
Insert Into Products (ProductName,CategoryId,Price,Avatar,InStocks)
values (N'Xôi',4,600,N'https://images.foody.vn/res/g99/981358/prof/s750x400/foody-upload-api-foody-mobile-c__media_temp-_-food-191204145412.jpg',10)
Insert Into Products (ProductName,CategoryId,Price,Avatar,InStocks)
values (N'Trà Sửa',4,600,N'https://images.foody.vn/res/g79/789052/prof/s750x400/foody-upload-api-foody-mobile-3-200605091741.jpg',10)

select * from Products

CREATE TABLE Contact 
(
	ContactId int IDENTITY(1,1) PRIMARY KEY,
	Hoten nvarchar(255),
	SoDienThoai int,
	DiaChiEmail nvarchar(255),
	NoiDung nvarchar(255)
)

INSERT INTO Contact VALUES ('Pham Cao Trinh','12345678','Hue','Abc')

CREATE TABLE DonHang
(
	DonHangId int IDENTITY(1,1) PRIMARY KEY,
	ProductName nvarchar(255),
	SoLuong int,
	Price int,
	HoTen nvarchar(255),
	DiaChi nvarchar(255),
	SoDienThoai int,
)

INSERT INTO DonHang VALUES (N'Bánh Macaron Pháp 1','2','900',N'Phạm Cao Trinh','Quảng Ngãi','123')
select * from DonHang

CREATE TABLE`	
(
	AccountId int IDENTITY(1,1) PRIMARY KEY,
	Username varchar(255),
	Password varchar(255),
	Hoten nvarchar(255),
	Email nvarchar(255)
)

INSERT INTO Account VALUES ('toan','123456',N'Phạm Cao Trinh','Trinh@gmail.com')


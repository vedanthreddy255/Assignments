CREATE DATABASE ShoppingCartDb;

CREATE TABLE Users(
	UserId INT PRIMARY KEY,
	UserName VARCHAR(30),
	Password VARCHAR(20),
	ContactNumber BIGINT,
	City VARCHAR(20)
);


CREATE TABLE Products(
	ProductId INT,
	ProductName VARCHAR(30) NOT NULL,
	QuantityInStock INT NOT NULL,
	UnitPrice INT NOT NULL,
	Category VARCHAR(20) NOT NULL,
	CONSTRAINT PK_Pro_Pid PRIMARY KEY(ProductId),
	CONSTRAINT Pro_Stock CHECK(QuantityInStock >0),
	CONSTRAINT Pro_Price CHECK(UnitPrice>0),
);

CREATE TABLE Cart(
	Id INT,
	CartId INT NOT NULL,
	ProductId INT,
	Qunatity INT NOT NULL,
	CONSTRAINT PK_Cart_Id PRIMARY KEY(Id),
	CONSTRAINT FK_Cart_PId FOREIGN KEY (ProductId)
		REFERENCES Products(ProductId),
	CONSTRAINT Cart_Q CHECK(Qunatity>0)
);

CREATE TABLE Orders(
	OrderId INT,
	CartId INT NOT NULL,
	OrderDate Date,
	TotalAmount INT,
	UserId INT,
	CONSTRAINT PK_Order_OId PRIMARY KEY(OrderId),
	CONSTRAINT FK_Order_UId FOREIGN KEY(UserId)
		REFERENCES Users(UserId)
);


INSERT INTO Users VALUES (1,'Vedanth','Icon',9177512175,'Hyd');
INSERT INTO Users VALUES (2,'Poojith','poo',7421956568,'Hyd');
INSERT INTO Users VALUES (3,'Nikhil','nil',3762517989,'Hyd');
INSERT INTO Users VALUES (4,'Akshay','aks',4878395897,'Hyd');
INSERT INTO Users VALUES (5,'Roshan','ros',2738456827,'Hyd');


INSERT INTO Products VALUES(1,'LG',290,2500,'TV')
INSERT INTO Products VALUES(2,'IPhone',4,62500,'Phone');
INSERT INTO PRODUCTS(ProductId,ProductName,QuantityInStock,UnitPrice,Category) VALUES (3,'samsung',9,105000,'Phone')
INSERT INTO Products VALUES(4,'Bullet350',9,325000,'Bike')
INSERT INTO Products VALUES(5,'KTM',9,200000,'Bike')

SELECT * FROM PRODUCTS


INSERT INTO CART VALUES(1,1,5,70)
INSERT INTO CART VALUES(2,2,2,32)
INSERT INTO CART VALUES(3,6,4,37)
INSERT INTO CART VALUES(4,3,1,29)
INSERT INTO CART VALUES(5,9,3,28)

SELECT * FROM Cart;

INSERT INTO Orders VALUES(1,2,'2008-11-11',25000,3)
INSERT INTO Orders VALUES(2,3,'2023-08-12',37820,5)
INSERT INTO Orders VALUES(3,5,'2001-06-19',28900,4)
INSERT INTO Orders VALUES(4,4,'2005-06-01',09272,2)
INSERT INTO Orders VALUES(5,1,'2015-03-09',49800,1)


SELECT * FROM Products
SELECT * FROM Products WHERE Category='Bike'
SELECT * FROM Products WHERE QuantityInStock=0
SELECT * FROM Products WHERE UnitPrice>=1000 AND UnitPrice<=10000
SELECT * FROM Products WHERE ProductId=3

 

SELECT * FROM Cart WHERE CartId=3
SELECT * FROM Cart WHERE ProductId=3

 

SELECT * FROM Users
SELECT * FROM Users WHERE UserName='Vedanth'
SELECT * FROM Users WHERE UserId=5

 

SELECT * FROM Orders WHERE OrderId=4;
SELECT * FROM Orders WHERE UserId=2;
SELECT * FROM Orders WHERE OrderDate='2008-11-11'

 


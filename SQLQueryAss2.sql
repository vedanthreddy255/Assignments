Select c.CartId,p.ProductName,c.Quantity,p.UnitPrice from Products p,CART c where p.ProductId=c.ProductId

Select c.CartId,p.ProductName,c.Quantity,p.UnitPrice from Products p INNER JOIN CART c ON p.ProductId=c.ProductId
Select c.CartId,p.ProductName,c.Quantity,p.UnitPrice from Products p RIGHT JOIN CART c ON p.ProductId=c.ProductId
Select c.CartId,p.ProductName,c.Quantity,p.UnitPrice from Products p LEFT JOIN CART c ON p.ProductId=c.ProductId
Select c.CartId,p.ProductName,c.Quantity,p.UnitPrice from Products p FULL OUTER JOIN CART c ON p.ProductId=c.ProductId

CREATE TABLE Student(
	StudentId INT PRIMARY KEY,
	StudentName VARCHAR(20),
	CourseName VARCHAR(20),
	CityName VARCHAR(20),
	ContactNumber BIGINT
);

INSERT INTO Student VALUES(1,'Vedanth','Angular','Adilabad',9215374836);
INSERT INTO Student VALUES(2,'Poojith','.Net','Hyderabad',73256874315);
INSERT INTO Student VALUES(3,'Dileep','SQL','Adilabad',48739592834);
INSERT INTO Student VALUES(4,'Nikhil','Angular','Hyderabad',9837594352);
INSERT INTO Student VALUES(5,'Sai Teja','JS','Nizambad',3284756452);
INSERT INTO Student VALUES(6,'Akshay','Angular','Hyderabad',823715984);
INSERT INTO Student VALUES(7,'Shashank','SQL','Nizambad',9842562893);
INSERT INTO Student VALUES(8,'Ashish','Java','Hyderabad',951678);
INSERT INTO Student VALUES(9,'Harish','Python','Arli',847150987);
INSERT INTO Student VALUES(10,'Gangadhar','Angular','Adilabad',92153344836);

SELECT * FROM Student

SELECT COUNT(*) as Angular_Students_Count from Student group by CourseName having CourseName='Angular'

SELECT COUNT(*) as Hyd_Students_Count from Student group by CityName having CityName='Hyderabad'

SELECT COUNT(*) as Students_Count,CityName from Student group by CityName 

SELECT COUNT(*) as Students_Count,CourseName from Student group by CourseName

SELECT COUNT(*) as Students_Count,CourseName from Student group by CourseName

SELECT COUNT(*) as Students_Count,CourseName,CityName from Student group by CourseName,CityName

-----------------------------------------


Select count(*) as Orders_Placed from Orders where UserId IN (sELECT UserId FROM Users Where City='Hyd')

UPDATE USERS set City='Mum' where UserId=3

Select count(*) as Orders_Placed from Orders where UserId NOT IN (sELECT UserId FROM Users Where City='Hyd')

Select * from Products where ProductId IN (Select ProductId from Cart)


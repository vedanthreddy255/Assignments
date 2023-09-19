Create table Student(StudentId int PRIMARY KEY, StudentName VARCHAR(20),CourseName VARCHAR(20),CityName VARCHAR(20),ContactNumber bigint);

--Index Name [PK__Student__32C52B99F5FE7E28]

CREATE INDEX Contact_Index on Student(ContactNumber ASC);

CREATE  INDEX Index_Stud_SN_CN
ON Student(StudentName,CourseName);

DROP INDEX Contact_Index ON Student;

EXEC sp_rename 'Student.Index_Stud_SN_CN','Index_SN_CN'	;

ALTER INDEX Index_SN_CN on Student DISABLE	

sp_helpindex 'Student'



--Views 

CREATE VIEW Products_Less_Than_Average_Price AS SELECT * FROM Products WHERE UnitPrice <( SELECT AVG(UnitPrice) FROM Products);

SELECT * FROM Products_Less_Than_Average_Price;

EXEC sp_rename 'Products_Less_Than_Average_Price','LOW_COST_PRODUCTS';

DROP VIEW LOW_COST_PRODUCTS;
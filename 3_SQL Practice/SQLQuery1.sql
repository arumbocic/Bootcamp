CREATE DATABASE TractorShopDB;

CREATE TABLE Customer (
"Id" UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
"FirstName" nvarchar(50) NOT NULL,
"LastName" nvarchar(50) NOT NULL,
"Address" nvarchar(255)
);

CREATE TABLE TractorBrand (
"Id" int IDENTITY(1,1) PRIMARY KEY,
"Brand" nvarchar(50) NOT NULL
);

CREATE TABLE TractorModel (
"Id" int IDENTITY(1,1) PRIMARY KEY,
"Model" nvarchar(50) NOT NULL,
"Code" UNIQUEIDENTIFIER DEFAULT NEWID(),
"BrandId" int NOT NULL,
FOREIGN KEY (BrandId) REFERENCES TractorBrand(Id)
);

CREATE TABLE CustomerTractorModel (
"Id" int IDENTITY(1,1) PRIMARY KEY,
"ModelId" int NOT NULL,
"CustomerId" UNIQUEIDENTIFIER NOT NULL,
"OrderDate" date,
FOREIGN KEY (ModelId) REFERENCES TractorModel(Id),
FOREIGN KEY (CustomerId) REFERENCES Customer(Id)
);

ALTER TABLE TractorModel
ADD HorsePower nvarchar(50);

ALTER TABLE TractorModel
DROP COLUMN HorsePower;

UPDATE Customer
SET FirstName = 'Ivan'
WHERE Address = 'Zupanja';

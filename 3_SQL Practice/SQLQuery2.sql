/* Populating dbo.TractorBrand*/
INSERT INTO TractorBrand (Brand)
VALUES 
('CaseIH'),
('Deutz Fahr'),
('John Deere'),
('New Holland');

/* Populating dbo.TractorModel*/
INSERT INTO TractorModel (Model, BrandId)
VALUES 
('Maxxum 115', (SELECT Id FROM TractorBrand WHERE Brand = 'CaseIH')),
('Maxxum 125', (SELECT Id FROM TractorBrand WHERE Brand = 'CaseIH')),
('Maxxum 135', (SELECT Id FROM TractorBrand WHERE Brand = 'CaseIH')),
('Maxxum 145', (SELECT Id FROM TractorBrand WHERE Brand = 'CaseIH')),
('Maxxum 150', (SELECT Id FROM TractorBrand WHERE Brand = 'CaseIH')),
('6110', (SELECT Id FROM TractorBrand WHERE Brand = 'Deutz Fahr')),
('6120', (SELECT Id FROM TractorBrand WHERE Brand = 'Deutz Fahr')),
('6130', (SELECT Id FROM TractorBrand WHERE Brand = 'Deutz Fahr')),
('6140', (SELECT Id FROM TractorBrand WHERE Brand = 'Deutz Fahr')),
('6150', (SELECT Id FROM TractorBrand WHERE Brand = 'Deutz Fahr')),
('6R 110', (SELECT Id FROM TractorBrand WHERE Brand = 'John Deere')),
('6R 120', (SELECT Id FROM TractorBrand WHERE Brand = 'John Deere')),
('6R 130', (SELECT Id FROM TractorBrand WHERE Brand = 'John Deere')),
('6R 140', (SELECT Id FROM TractorBrand WHERE Brand = 'John Deere')),
('6R 150', (SELECT Id FROM TractorBrand WHERE Brand = 'John Deere')),
('T5.110', (SELECT Id FROM TractorBrand WHERE Brand = 'New Holland')),
('T5.120', (SELECT Id FROM TractorBrand WHERE Brand = 'New Holland')),
('T5.130', (SELECT Id FROM TractorBrand WHERE Brand = 'New Holland')),
('T5.140', (SELECT Id FROM TractorBrand WHERE Brand = 'New Holland')),
('T5.150', (SELECT Id FROM TractorBrand WHERE Brand = 'New Holland'));

/* Populating dbo.Customer*/
INSERT INTO Customer (FirstName, LastName, Address)
VALUES
('Dragan', 'Komadina', 'Krizevci'),
('Marko', 'Markovic', 'Popovaca'),
('Martin', 'Martin', 'Orahovica'),
('Ivo', ' Ivic', 'Zupanja'),
('Zoran', 'Lucin', 'Bjelovar'),
('Goran', 'Popovic', 'Virovitica'),
('Zdravko', 'Dren', 'Donji Miholjac'),
('Luka', 'Lovric', 'Osijek');

/* Populating dbo.CustomerTractorModel refering to other tables*/
INSERT INTO CustomerTractorModel (ModelId, CustomerId, OrderDate)
VALUES
((SELECT Id FROM TractorModel WHERE Model = '6R 140'),(SELECT Id FROM Customer WHERE Address = 'Popovaca'),'2018-12-25'),
((SELECT Id FROM TractorModel WHERE Model = 'Maxxum 135'),(SELECT Id FROM Customer WHERE Address = 'Orahovica'),'2019-05-15'),
((SELECT Id FROM TractorModel WHERE Model = '6R 140'),(SELECT Id FROM Customer WHERE Address = 'Osijek'),'2017-02-27'),
((SELECT Id FROM TractorModel WHERE Model = '6140'),(SELECT Id FROM Customer WHERE Address = 'Donji Miholjac'),'2020-08-03'),
((SELECT Id FROM TractorModel WHERE Model = 'T5.150'),(SELECT Id FROM Customer WHERE Address = 'Bjelovar'),'2016-11-04'),
((SELECT Id FROM TractorModel WHERE Model = 'T5.120'),(SELECT Id FROM Customer WHERE Address = 'Orahovica'),'2021-01-08'),
((SELECT Id FROM TractorModel WHERE Model = '6R 140'),(SELECT Id FROM Customer WHERE Address = 'Donji Miholjac'),'2022-03-12'),
((SELECT Id FROM TractorModel WHERE Model = '6110'),(SELECT Id FROM Customer WHERE Address = 'Zupanja'),'2016-09-01'),
((SELECT Id FROM TractorModel WHERE Model = '6R 140'),(SELECT Id FROM Customer WHERE Address = 'Osijek'),'2020-05-25'),
((SELECT Id FROM TractorModel WHERE Model = 'Maxxum 115'),(SELECT Id FROM Customer WHERE Address = 'Popovaca'),'2020-11-01'),
((SELECT Id FROM TractorModel WHERE Model = 'Maxxum 135'),(SELECT Id FROM Customer WHERE Address = 'Bjelovar'),'2017-11-10');
 
/*Selecting tractor models serial numbers*/
SELECT Code, Model FROM TractorModel;

/* Selecting columns from dbo.TractorModel, dbo.TractorBrand*/
SELECT m.Id, m.Model, b.Brand 
FROM TractorModel m
JOIN TractorBrand b
ON m.BrandId = b.Id;

/* Selecting columns from dbo.TractorModel, dbo.Customr and dbo.CustomerTractorModel*/
SELECT c.Id, ct.OrderDate, t.Model
FROM Customer c
CROSS JOIN TractorModel t
INNER JOIN CustomerTractorModel ct
ON ct.CustomerId = c.Id 
AND ct.ModelId = t.Id;

/* Selecting columns from dbo.TractorModel, dbo.Customr and dbo.CustomerTractorModel*/
SELECT YEAR(ct.OrderDate), c.LastName, t.Model 
FROM CustomerTractorModel ct
CROSS JOIN TractorModel t
INNER JOIN Customer c
ON ct.CustomerId = c.Id 
AND ct.ModelId = t.Id
WHERE c.Address = 'Popovaca';

/*Selecting a subset of data from tables*/
SELECT c.Id, ct.OrderDate, t.Model
FROM Customer c
CROSS JOIN TractorModel t
INNER JOIN CustomerTractorModel ct
ON ct.CustomerId = c.Id 
AND ct.ModelId = t.Id
WHERE YEAR(ct.OrderDate) BETWEEN 2017 AND 2020
ORDER BY OrderDate ASC;

/*Counting tractor model for every brand*/
SELECT b.Brand as 'Brand Name', COUNT(m.Model) as 'No of Models'
FROM TractorBrand b, TractorModel m
WHERE m.BrandId = b.Id
GROUP BY b.Brand;

/*Counting number od tractor for every customer*/
SELECT c.Id, COUNT(m.Model)
FROM Customer c, TractorModel m, CustomerTractorModel ct
WHERE ct.CustomerId = c.Id AND ct.ModelId = m.Id
GROUP BY c.Id;

/*Counting number od tractor for every customer - LEFT JOIN*/
SELECT c.FirstName, c.LastName, COUNT(ct.ModelId)
FROM Customer c
LEFT JOIN CustomerTractorModel ct
ON ct.CustomerId = c.Id 
GROUP BY c.FirstName, c.LastName;

/*Pagination implementation using dbo.TractorModel and dbo.TractorBrand*/
DECLARE @PageNumber AS INT
DECLARE @RowsOfPage AS INT
SET @PageNumber=2
SET @RowsOfPage=3
SELECT m.Id, m.Model, b.Brand FROM TractorModel as m, TractorBrand as b
ORDER BY  m.Id
OFFSET (@PageNumber-1)*@RowsOfPage ROWS
FETCH NEXT @RowsOfPage ROWS ONLY;
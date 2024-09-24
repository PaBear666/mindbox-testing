CREATE TABLE Products (
  Id INT NOT NULL PRIMARY KEY,
  Name NVARCHAR(50),
);

CREATE TABLE ProductCategories (
  ProductId INT NOT NULL,
  CategoryId INT NOT NULL,
  CONSTRAINT PK_ProductCategories_ProductId_CategoryId PRIMARY KEY (ProductId, CategoryId)
);

CREATE TABLE Categories (
  Id int NOT NULL PRIMARY KEY,
  Name NVARCHAR(50),
);


SELECT Products.Name as "Продукт", Categories.Name as "Тип продукта"
FROM Products
LEFT JOIN ProductCategories ON Products.Id = ProductCategories.ProductId
LEFT JOIN Categories ON ProductCategories.CategoryId = Categories.Id
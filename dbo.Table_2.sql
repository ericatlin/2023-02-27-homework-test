CREATE TABLE [dbo].[Product_Table]
(
	[product-id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [product-name] NVARCHAR(50) NOT NULL, 
    [product-quantity] INT NOT NULL, 
    [product-price] INT NOT NULL, 
    [product-type] NVARCHAR(50) NOT NULL
)
CREATE PROCEDURE [dbo].[AddProductToStorage]
	@productId INT,
	@storageId INT,
	@productCount INT = 0
AS
	INSERT INTO Product_On_Storage (ProductId, StorageId, ProductCount)
    VALUES (@productId, @storageId, @productCount);
RETURN 0

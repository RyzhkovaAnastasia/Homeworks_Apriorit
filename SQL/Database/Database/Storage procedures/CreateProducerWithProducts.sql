CREATE TYPE productTableType AS TABLE 
(
[id] INT, 
[ProductName] NVARCHAR(50)
);
GO

CREATE PROCEDURE [dbo].[CreateProducerWithProducts]
	@producerName NVARCHAR(50),
	@productTable productTableType READONLY
AS
	INSERT INTO Producer (ProducerName)
	VALUES (@producerName);

	DECLARE @producerId INT;
	SET @producerId = SCOPE_IDENTITY();

	INSERT INTO Product (ProductName, ProducerId)
	SELECT ProductName, @producerId 
	FROM @productTable;
RETURN 0

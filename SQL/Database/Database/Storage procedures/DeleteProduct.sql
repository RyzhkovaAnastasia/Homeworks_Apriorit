CREATE PROCEDURE [dbo].[DeleteProduct]
	@id INT
AS
	DELETE FROM Product  
	WHERE Product.Id = @id
RETURN 0

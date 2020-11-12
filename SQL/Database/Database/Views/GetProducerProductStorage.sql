CREATE VIEW [dbo].[GetProducerProductStorage]
	AS 
		SELECT Product.ProductName, Producer.ProducerName, Storage.StorageName
		FROM Product 
		LEFT JOIN Producer ON Producer.Id = Product.ProducerId
		LEFT JOIN Product_On_Storage ON Product_On_Storage.ProductId = Product.Id
		LEFT JOIN Storage ON Product_On_Storage.StorageId = Storage.Id
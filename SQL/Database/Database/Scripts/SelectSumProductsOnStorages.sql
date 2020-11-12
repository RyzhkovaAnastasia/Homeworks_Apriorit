--Написать запрос, который выводит суммарное количество товаров на
--складах, сгруппированных по производителю

SELECT Product.ProductName, Producer.ProducerName, SUM(Product_On_Storage.ProductCount) AS 'Product count' 
	FROM Product_On_Storage
		JOIN Product ON Product_On_Storage.ProductId = Product.Id
		JOIN Storage ON Product_On_Storage.StorageId = Storage.Id
		JOIN Producer ON Producer.Id = Product.ProducerId
	GROUP BY Producer.ProducerName, Product.ProductName
--Реализовать заполнение всех таблиц базовыми значениями(2 товара, 2
--производителя, 2 склада) при выполнении паблиша SSDT проекта на
--базу данных. Данные не должны дублироваться при повторном
--паблише

IF NOT EXISTS (SELECT TOP (1) Product.Id FROM Product)
BEGIN 
  DECLARE @products ProductTableType;
  INSERT INTO @products (ProductName) VALUES 
  ('Dior Sauvage'),
  ('Dior Miss Dior Blooming Bouquet');
  exec CreateProducerWithProducts 
  @producerName = 'Dior', @productTable = @products;
  DELETE FROM @products;

  INSERT INTO @products (ProductName) VALUES 
  ('Chanel Chance Eau Tendre'),
  ('Chanel Coco Mademoiselle');
  exec CreateProducerWithProducts
  @producerName = 'Chanel', @productTable = @products;
  DELETE FROM @products;
END
  

IF NOT EXISTS (SELECT TOP (1) Storage.Id FROM Storage)
BEGIN
  INSERT INTO Storage (StorageName) VALUES 
  ('MakeUpUA'), 
  ('Parfums');
END

IF NOT EXISTS (SELECT TOP (1) Id FROM Product_On_Storage)
	BEGIN
	  exec AddProductToStorage @productId = 1, @storageId = 1, @productCount = 109; 
	  exec AddProductToStorage @productId = 2, @storageId = 1, @productCount = 98; 
	  exec AddProductToStorage @productId = 3, @storageId = 1, @productCount = 105; 
	  exec AddProductToStorage @productId = 4, @storageId = 1, @productCount = 45; 
	  exec AddProductToStorage @productId = 1, @storageId = 2, @productCount = 152; 
	  exec AddProductToStorage @productId = 2, @storageId = 2, @productCount = 34; 
	  exec AddProductToStorage @productId = 3, @storageId = 2, @productCount = 149;
	END
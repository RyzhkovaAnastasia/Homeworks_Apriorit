CREATE TABLE [dbo].[Product_On_Storage]
(
	[Id] INT NOT NULL IDENTITY PRIMARY KEY, 
    [ProductCount] INT NOT NULL,
	[StorageId] INT NOT NULL,
	CONSTRAINT FK_ProductOnStorage_to_Storage FOREIGN KEY ([StorageId]) REFERENCES [Storage]([Id]) ON DELETE CASCADE,
	[ProductId] INT NOT NULL,
	CONSTRAINT FK_ProductOnStorage_to_Product FOREIGN KEY ([ProductId]) REFERENCES [Product]([Id]) ON DELETE CASCADE
)

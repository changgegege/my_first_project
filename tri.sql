USE cgg_ks
GO
CREATE TRIGGER tri_updateid_dht11
ON dht11
FOR DELETE 
AS
DECLARE @count int,@id int
SELECT @count = COUNT(*),@id = MAX(id)
FROM dht11

IF @count = 0
	DBCC checkident('dht11',reseed,0)
ELSE
	DBCC checkident('dht11',reseed,@id) 
GO

USE cgg_ks
GO
CREATE TRIGGER tri_updateid_dht11his
ON dht11_history
FOR DELETE
AS
DECLARE @count int,@id int
SELECT @count = COUNT(*),@id = MAX(id)
FROM dht11_history

IF @count = 0
	DBCC checkident('dht11_history',reseed,0)
ELSE
	DBCC checkident('dht11_history',reseed,@id) 
GO

USE cgg_ks
GO
CREATE TRIGGER tri_updateid_water
ON water
FOR DELETE
AS
DECLARE @count int,@id int
SELECT @count = COUNT(*),@id = MAX(id)
FROM water

IF @count = 0
	DBCC checkident('water',reseed,0)
ELSE
	DBCC checkident('water',reseed,@id) 
GO

USE cgg_ks
GO
CREATE TRIGGER tri_updateid_waterhis
ON water_history
FOR DELETE
AS
DECLARE @count int,@id int
SELECT @count = COUNT(*),@id = MAX(id)
FROM water_history

IF @count = 0
	DBCC checkident('water_history',reseed,0)
ELSE
	DBCC checkident('water_history',reseed,@id) 
GO
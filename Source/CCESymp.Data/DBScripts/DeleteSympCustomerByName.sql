  DECLARE @CustomerName VARCHAR (1000) = @searchedCustomerName
  IF (SELECT COUNT(*) FROM [Symphony].[Customer] WHERE Name = @CustomerName) = 0 
	SELECT 0
  ELSE
	DECLARE @CustomerId VARCHAR(100) = (SELECT ID FROM [Symphony].[Customer] WHERE Name = @CustomerName)
  	DELETE FROM Symphony.GlobalConnection WHERE CustomerId = @CustomerId
	DELETE FROM Symphony.Facility WHERE CustomerId = @CustomerId
	DELETE FROM Symphony.Solution WHERE CustomerId = @CustomerId
  	DELETE FROM Symphony.Customer WHERE Id = @CustomerId
 SELECT 1
 -- DECLARE @CustomerName VARCHAR (1000) = @searchedCustomerName
 -- IF (SELECT COUNT(*) FROM [Symphony].[Customer] WHERE Name = @CustomerName) = 0 
	--SELECT 0
 -- ELSE
	--DECLARE @CustomerId VARCHAR(100) = (SELECT ID FROM [Symphony].[Customer] WHERE Name = @CustomerName)
 -- 	DELETE FROM Symphony.GlobalConnection WHERE CustomerId = @CustomerId
	--DELETE FROM Symphony.Facility WHERE CustomerId = @CustomerId
 -- 	DELETE FROM Symphony.Customer WHERE Id = @CustomerId
 --SELECT 1
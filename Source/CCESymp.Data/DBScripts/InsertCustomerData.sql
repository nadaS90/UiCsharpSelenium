DECLARE @CustomerCount INT = (SELECT COUNT(*) FROM Symphony.Customer)
DECLARE @FacilityCount INT = (SELECT COUNT(*) FROM Symphony.Facility)

	IF @CustomerCount < 200 and @FacilityCount < 200
	DECLARE @intFlag INT = 1
		WHILE (@intFlag <= 500)
		BEGIN
			DECLARE @CustomerName VARCHAR(100) = (SELECT SUBSTRING(CONVERT(varchar(40), NEWID()),0,9))
			DECLARE @RssId VARCHAR(36) = NEWID()
			DECLARE @IntegrationId VARCHAR(20) = (select CAST(RAND() * 100000 AS INT))
			DECLARE @Address1 VARCHAR (255) = (SELECT SUBSTRING(CONVERT(varchar(40), NEWID()),0,9))
			DECLARE @Address2 VARCHAR (255) = (SELECT SUBSTRING(CONVERT(varchar(40), NEWID()),0,9))
			DECLARE @City  VARCHAR (255) = (SELECT SUBSTRING(CONVERT(varchar(40), NEWID()),0,9))
			DECLARE @State VARCHAR (255) = (SELECT SUBSTRING(CONVERT(varchar(40), NEWID()),0,9))
			DECLARE @ZipCode VARCHAR (255) = (select CAST(RAND() * 100000 AS INT))
			DECLARE @Notes VARCHAR (MAX) = (SELECT SUBSTRING(CONVERT(varchar(40), NEWID()),0,9))

		INSERT INTO Symphony.Customer VALUES (@CustomerName, @RssId, @IntegrationId, @Address1, @Address2, @City, @State, @ZipCode, @Notes)
			DECLARE @CustomerId VARCHAR (255) = (SELECT TOP 1 ID FROM Symphony.Customer as Customer ORDER BY Customer.ID DESC)
		INSERT INTO Symphony.Facility VALUES (@CustomerId, NEWID(), @IntegrationId, @CustomerName, @Address1, @Address2,@City,@State,@ZipCode)
    PRINT @intFlag
    SET @intFlag = @intFlag + 1
END
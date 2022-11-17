--DECLARE @CustomerId int = (SELECT Id FROM Symphony.Customer WHERE Name = @CustomerName)
DECLARE @SolutionsCount int = (SELECT COUNT(*) FROM Symphony.Solution WHERE CustomerId = @CustomerId AND TemplateTypeId = @TemplateTypeId)
DECLARE @SolName VARCHAR(100) = ('SOLUTION ' + (SELECT SUBSTRING(CONVERT(varchar(40), NEWID()),0,9)))
DECLARE @GlobalId uniqueidentifier = NEWID()

IF(@SolutionsCount < 1)
	INSERT INTO Symphony.Solution(GlobalId, CustomerId, Name, Notes, Description, Category, TemplateTypeId, FacilityCode , FacilityUsername , FacilityPassword, IsPublished)
	VALUES (@GlobalId, @CustomerId, @SolName,'', (SELECT SUBSTRING(CONVERT(varchar(40), NEWID()),0,9)), 'TEST', @TemplateTypeId, '', '' ,'' ,'')
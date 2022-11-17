DECLARE @IntegrationID VARCHAR (1000) = @custId
UPDATE [Symphony].[Customer] SET Notes = '' WHERE IntegrationId = @IntegrationID
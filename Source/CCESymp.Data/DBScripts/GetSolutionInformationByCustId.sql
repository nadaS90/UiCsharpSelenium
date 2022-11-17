SELECT C.Id AS CustomerID, C.Name AS CustomerName, S.Id, TT.Template, tt.Id as TemplateTypeId , s.FacilityCode, S.FacilityPassword, s.FacilityUsername,
S.Name AS SolutionName, S.Description, S.Notes as SolutionNotes, S.Category, TT.Name AS TemplateTypeName, 
BU.Name AS BusinessUnitName , tt.Version , C.GlobalId AS CustomerGlobalId
FROM Symphony.Customer AS C JOIN Symphony.Solution as S ON C.ID = S.CustomerId
JOIN Symphony.ConfigurationTemplate AS TT ON S.TemplateTypeId = TT.Id
JOIN Symphony.BusinessUnit AS BU ON TT.BusinessUnitId = BU.Id 
where S.CustomerId = @customerId
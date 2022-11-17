Select s.Category, CT.Id TemplateTypeId , CT.ModifiedBy, CT.ModifiedDateTime, CT.Template , C.Configuration configurationValue , C.Id ConfigurationId
, CU.GlobalId CustomerGlobalId , S.Description, S.FacilityCode, S.FacilityPassword , S.FacilityUsername, S.GlobalId, 
S.Id as SolutionId, C.IsPublished, S.Name SolutionName, S.Notes, CT.Name TemplateType, CU.Id CustomerId , CU.Name as Customer
from Symphony.Solution S 
inner join [Symphony].[Configuration] C on S.Id = C.SolutionId
inner join [Symphony].[ConfigurationTemplate] CT on S.TemplateTypeId = CT.Id
inner join [Symphony].[Customer]  CU on CU.Id = S.CustomerId
where s.name = @SolutionName

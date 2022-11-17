/****** Script for SelectTopNRows command from SSMS  ******/

Select count (*) as 'Auidt Logs Count'FROM [Audit].[AuditLogging]
where Description = 'POST : /api/solution' 
 
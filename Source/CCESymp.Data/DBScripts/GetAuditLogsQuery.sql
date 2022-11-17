  SELECT * FROM [Audit].[AuditLogging] 
  WHERE UserId = @UserId
  ORDER BY [StartDateTime] DESC
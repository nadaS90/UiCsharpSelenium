  IF (SELECT [InactivityTimeoutMinutes] FROM [Core].[SystemSetting]) IS NULL
  OR
  (SELECT [InactivityTimeoutMinutes] FROM [Core].[SystemSetting]) != 60
  SELECT 60 AS InactivityTimeoutMinutes
  ELSE SELECT [InactivityTimeoutMinutes] FROM [Core].[SystemSetting]
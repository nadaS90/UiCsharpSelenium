  DECLARE @CommonFacilityName VARCHAR (255) = 'FACILITY - '
  INSERT INTO Symphony.Facility VALUES (
  (SELECT TOP 1 ID FROM Symphony.Customer as Customer ORDER BY Customer.ID DESC), 
  NEWID(), 
  (SELECT FLOOR(RAND()*(99999-10000+1))+10000), 
  @CommonFacilityName + (SELECT TOP 1 Name FROM Symphony.Customer as Customer ORDER BY Customer.Id DESC), 
  (SELECT TOP 1 Address1 FROM Symphony.Customer as Customer ORDER BY Customer.Id DESC),
  (SELECT TOP 1 Address2 FROM Symphony.Customer as Customer ORDER BY Customer.Id DESC), 
  (SELECT TOP 1 City FROM Symphony.Customer as Customer ORDER BY Customer.Id DESC), 
  (SELECT TOP 1 State FROM Symphony.Customer as Customer ORDER BY Customer.Id DESC), 
  (SELECT FLOOR(RAND()*(99999-10000+1))+10000)
  )
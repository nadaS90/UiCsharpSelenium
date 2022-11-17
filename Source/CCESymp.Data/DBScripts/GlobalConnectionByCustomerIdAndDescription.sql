﻿SELECT GCT.Type as type, GCT.Version as version,
GC.CustomerID as customerID, GC.GlobalConnectionTypeID as globalConnectionTypeId,
GC.Name as name, GC.Value as value, 
GC.Description as description,
GC.ValidFrom as validFrom, 
GC.ValidTo as validTo, GC.ID as id
FROM [Symphony].[GlobalConnection] AS GC 
JOIN [Symphony].[GlobalConnectionType] AS GCT 
ON GC.GlobalConnectionTypeID = GCT.ID
inner Join [Symphony].[Customer] as C
on GC.CustomerID = C.ID
WHERE C.integrationId  = @customerId
and GC.Description = @description
﻿INSERT INTO Symphony.GlobalConnection (CustomerId, GlobalConnectionTypeId, Name, Description, Value) 
VALUES (@custId, 1, 'Global Connection Test', 'Global Connection insert from DB', '{"cust_global.name":"Hospital_A_ADT_IN","cust_global.hl7_in.host":"0.0.0.0","cust_global.hl7_in.port":"15001"}');
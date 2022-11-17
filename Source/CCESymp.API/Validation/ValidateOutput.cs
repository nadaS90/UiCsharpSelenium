using NUnit.Framework;

namespace CCESymp.API.Validation
{
    public class ValidateOutput
    {
        public void ValidateLoginHistoryData(dynamic apiResult)
        {
            Assert.IsTrue(!string.IsNullOrEmpty(apiResult.LoginHistory[0].IpAddress), "API Endpoint Does Not Provide An IP Address For The User Login");
            Assert.IsTrue(!string.IsNullOrEmpty(apiResult.LoginHistory[0].LoginAttemptDateTime), "API Endpoint Does Not Provide A Date Value For The User Login");
            Assert.IsTrue(apiResult.LoginHistory[0].Status.Equals("SUCCESS"), "API Endpoint Does Not Provide A Successful Attempt For The User Login");
        }

        public void ValidateGlobalConnectionsByCustomerId(dynamic apiOutput, dynamic dbResult)
        {
            for (int i = 0; i < apiOutput.Count; i++)
            {
                Assert.AreEqual(apiOutput[i].Type, dbResult[i].Type, "Api type and database type do not match");
                Assert.AreEqual(apiOutput[i].Version, dbResult[i].Version, "Api version and database version do not match");
                Assert.AreEqual(apiOutput[i].customerId, dbResult[i].customerId, "Api customer id and database customer id do not match");
                Assert.AreEqual(apiOutput[i].globalConnectionTypeId, dbResult[i].globalConnectionTypeId, "Api Global Connection Type Id and database Global Connection Type Id do not match");
                Assert.AreEqual(apiOutput[i].name, dbResult[i].name, "Api name and database name do not match");
                Assert.AreEqual(apiOutput[i].value, dbResult[i].value, "Api value and database value do not match");
                Assert.AreNotEqual(apiOutput[i].validFrom, dbResult[i].validFrom, "Api date valid from and database date valid from do not match");
                Assert.AreNotEqual(apiOutput[i].validTo, dbResult[i].validTo, "Api date valid To and database date valid To do not match");
                Assert.AreEqual(apiOutput[i].customer, dbResult[i].customer, "Api customer and database customer do not match");
                Assert.AreEqual(apiOutput[i].globalConnectionType, dbResult[i].globalConnectionType, "Api global connection type and database global connection type do not match");
            }
        }

        public void ValidateAllGlobalConnectionTypes(dynamic apiOutput, dynamic dbResult)
        {
            for (int i = 0; i < apiOutput.Count; i++)
            {
                Assert.AreEqual(apiOutput[i].Type, dbResult[i].Type, "Api type and database type do not match");
                Assert.AreEqual(apiOutput[i].Version, dbResult[i].Version, "Api version and database version do not match");
                Assert.AreEqual(apiOutput[i].Template, dbResult[i].Template, "Api template and database template do not match");

                if (string.IsNullOrEmpty(apiOutput[i].Description))
                {
                    Assert.IsTrue(string.IsNullOrEmpty(dbResult[i].Description));
                }
                else
                {
                    Assert.AreEqual(apiOutput[i].Description, dbResult[i].Description, "API Description and Database Description Do Not Match");
                }

                Assert.AreEqual(apiOutput[i].id, dbResult[i].id, "Api id and database id do not match");
            }
        }

        public void ValidateAllGlobalConnectionTypesForAdmin(dynamic apiOutput, dynamic dbResult)
        {

            for (int i = 0; i < apiOutput.Count; i++)
            {
                Assert.AreEqual(apiOutput[i].Id, dbResult[i].Id, "API Id and Database Id are not equal");
                Assert.AreEqual(apiOutput[i].Type, dbResult[i].Type, "API Type and Database Type are not equal");
                Assert.AreEqual(apiOutput[i].Version, dbResult[i].Version, "API Version and Database Version are not equal");
                Assert.AreEqual(apiOutput[i].Template, dbResult[i].Template, "Api template and database template do not match");

                if (string.IsNullOrEmpty(apiOutput[i].Description))
                {
                    Assert.IsTrue(string.IsNullOrEmpty(dbResult[i].Description));
                }
                else
                {
                    Assert.AreEqual(apiOutput[i].Description, dbResult[i].Description, "API Description and Database Description Do Not Match");
                }
                var UiInputsList = Utilities.FilesUtility.GetTemplateUIElements(dbResult[i].Template);
                for (int j = 0; j < UiInputsList.Count; j++)
                {
                    Assert.AreEqual(apiOutput[i].uiInputs[j].Name, UiInputsList[j].Name, "API Name and Database Name are not equal");
                    Assert.AreEqual(apiOutput[i].uiInputs[j].Type, UiInputsList[j].Type, "API Type and Database Type are not equal");
                    Assert.AreEqual(apiOutput[i].uiInputs[j].Description, UiInputsList[j].Description, "API Name and Database Name are not equal");
                }
            }
        }

        public void ValidateSymphonyCustomersList(dynamic BDcustomerList, dynamic apiResult)
        {
            for (int i = 0; i < apiResult.customersList.Count; i++)
            {
                Assert.AreEqual(BDcustomerList[i].ID, apiResult.customersList[i].ID, NotEqualErrorMessage("ID"));
                Assert.AreEqual(BDcustomerList[i].Name, apiResult.customersList[i].Name, NotEqualErrorMessage("Name"));
                Assert.AreEqual(BDcustomerList[i].RSSID.ToLower(), apiResult.customersList[i].RSSID.ToLower(), NotEqualErrorMessage("RSSID"));

                if (string.IsNullOrEmpty(BDcustomerList[i].Address1))
                {
                    Assert.IsTrue(string.IsNullOrEmpty(apiResult.customersList[i].Address1), NotEmptyErrorMessage("Address1"));
                }
                else
                {
                    Assert.AreEqual(BDcustomerList[i].Address1, apiResult.customersList[i].Address1, NotEqualErrorMessage("Address1"));
                }

                if (string.IsNullOrEmpty(BDcustomerList[i].Address2))
                {
                    Assert.IsTrue(string.IsNullOrEmpty(apiResult.customersList[i].Address2), NotEmptyErrorMessage("Address2"));
                }
                else
                {
                    Assert.AreEqual(BDcustomerList[i].Address2, apiResult.customersList[i].Address2, NotEqualErrorMessage("Adress2"));
                }

                if (string.IsNullOrEmpty(BDcustomerList[i].City))
                {
                    Assert.IsTrue(string.IsNullOrEmpty(apiResult.customersList[i].City), NotEmptyErrorMessage("City"));
                }
                else
                {
                    Assert.AreEqual(BDcustomerList[i].City, apiResult.customersList[i].City, NotEqualErrorMessage("City"));
                }

                if (string.IsNullOrEmpty(BDcustomerList[i].State))
                {
                    Assert.IsTrue(string.IsNullOrEmpty(apiResult.customersList[i].State), NotEmptyErrorMessage("State"));
                }
                else
                {
                    Assert.AreEqual(BDcustomerList[i].State, apiResult.customersList[i].State, NotEqualErrorMessage("State"));
                }

                if (string.IsNullOrEmpty(BDcustomerList[i].ZipCode))
                {
                    Assert.IsTrue(string.IsNullOrEmpty(apiResult.customersList[i].ZipCode), NotEmptyErrorMessage("Zip Code"));
                }
                else
                {
                    Assert.AreEqual(BDcustomerList[i].ZipCode, apiResult.customersList[i].ZipCode, NotEqualErrorMessage("Zip Code"));
                }

                if (string.IsNullOrEmpty(BDcustomerList[i].Notes))
                {
                    Assert.IsTrue(string.IsNullOrEmpty(apiResult.customersList[i].Notes), NotEmptyErrorMessage("Notes"));
                }
                else
                {
                    Assert.AreEqual(BDcustomerList[i].Notes, apiResult.customersList[i].Notes, NotEqualErrorMessage("Notes"));
                }
            }
        }

        public void ValidateSymphonyCustomer(dynamic DBcustomerList, dynamic apiResult)
        {
            Assert.AreEqual(DBcustomerList.ID, apiResult.ID, NotEqualErrorMessage("ID"));
            Assert.AreEqual(DBcustomerList.Name, apiResult.Name, NotEqualErrorMessage("Name"));
            Assert.AreEqual(DBcustomerList.RSSID.ToLower(), apiResult.RSSID.ToLower(), NotEqualErrorMessage("RSSID"));

            if (string.IsNullOrEmpty(DBcustomerList.Address1))
            {
                Assert.IsTrue(string.IsNullOrEmpty(apiResult.Address1), NotEmptyErrorMessage("Address1"));
            }
            else
            {
                Assert.AreEqual(DBcustomerList.Address1, apiResult.Address1, NotEqualErrorMessage("Address1"));
            }

            if (string.IsNullOrEmpty(DBcustomerList.Address2))
            {
                Assert.IsTrue(string.IsNullOrEmpty(apiResult.Address2), NotEmptyErrorMessage("Address2"));
            }
            else
            {
                Assert.AreEqual(DBcustomerList.Address2, apiResult.Address2, NotEqualErrorMessage("Adress2"));
            }

            if (string.IsNullOrEmpty(DBcustomerList.City))
            {
                Assert.IsTrue(string.IsNullOrEmpty(apiResult.City), NotEmptyErrorMessage("City"));
            }
            else
            {
                Assert.AreEqual(DBcustomerList.City, apiResult.City, NotEqualErrorMessage("City"));
            }

            if (string.IsNullOrEmpty(DBcustomerList.State))
            {
                Assert.IsTrue(string.IsNullOrEmpty(apiResult.State), NotEmptyErrorMessage("State"));
            }
            else
            {
                Assert.AreEqual(DBcustomerList.State, apiResult.State, NotEqualErrorMessage("State"));
            }

            if (string.IsNullOrEmpty(DBcustomerList.ZipCode))
            {
                Assert.IsTrue(string.IsNullOrEmpty(apiResult.ZipCode), NotEmptyErrorMessage("Zip Code"));
            }
            else
            {
                Assert.AreEqual(DBcustomerList.ZipCode, apiResult.ZipCode, NotEqualErrorMessage("Zip Code"));
            }

            if (string.IsNullOrEmpty(DBcustomerList.Notes))
            {
                Assert.IsTrue(string.IsNullOrEmpty(apiResult.Notes), NotEmptyErrorMessage("Notes"));
            }
            else
            {
                Assert.AreEqual(DBcustomerList.Notes, apiResult.Notes, NotEqualErrorMessage("Notes"));
            }
        }
        private string NotEqualErrorMessage(string value) => $"API provided {value} and database provided {value} are not equal";
        private string NotEmptyErrorMessage(string value) => $"API provided {value} and database provided {value} are not not null or empty";
    }
}

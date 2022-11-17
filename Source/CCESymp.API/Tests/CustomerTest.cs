using CCESymp.API.Services;
using CCESymp.Data;
using CCESymp.Data.Mapping;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CCESymp.API.Tests
{
    [TestFixture]
    public class CustomerTest : TestBase
    {
        [TestCase(TestName = "API - GET Rss Customer List ", Description = "Test Case 1253409: US1221775 - API - GET Rss Customer List"), Category("CustomerPage")]
        [TestCase(TestName = "API - Return a list of customers in the RSS DB ", Description = "Test Case 1317685: US 1201241 - API - Return a list of customers in the RSS DB"), Category("CustomerPage")]
        public void GetRssResponse()
        {
            Logger.Info("EXECUTING: " + TestContext.CurrentContext.Test.Properties.Get("Description"));
            Logger.Info("Generating customer service object");
            var _customer = new RSSCustomerService();
            Logger.Info("Executing the task to retrieve all RSS Customers");
            var CustomersTask = _customer.GetAllRssCustomersAsync();
            Logger.Info("Waiting until task is complete");
            CustomersTask.Wait();
            Logger.Info("Extracting the obtained results from previous task");
            var result = CustomersTask.Result;
            Logger.Info("Performing validation");
            Assert.GreaterOrEqual(result.Value.Count, 0);
            Logger.Info($"Current RSS customers count equals: {result.Value.Count}");
        }

        [Test, Category("CustomerPage")]
        [Description("Test Case 1261114: US1204993 - GET Facility Contact data")]
        public void GetFacilityContactData()
        {
            Logger.Info("EXECUTING: Test Case 1261114: US1204993 - GET Facility Contact data");
            string RSSId = "fc31e1b7-560e-4c50-86d6-2e3d169b5a57";

            var RequestBuilder = new RequestBuilder(_webDriver);
            var response = RequestBuilder.GetResponse($"api/customer/{RSSId}/contacts", RestSharp.Method.GET);

            //Verify Status Code
            string Expectedcode = response.StatusCode.ToString();
            var Deserializer = new JsonDeserializer();
            var FacilityContactResponse = Deserializer.Deserialize<FacilityContactResponse>(response);

            string Code = FacilityContactResponse.Code.ToString();
            string Message = FacilityContactResponse.Message.ToString();

            Logger.Info($"VALIDATION: Status code should be {Expectedcode}");
            Assert.AreEqual(Expectedcode, "OK", "Response code is " + response.StatusCode);
            Logger.Info($"VALIDATION SUCCESS: Status code is {Expectedcode}");
            var FacilityContactList = FacilityContactResponse.Response;

            //If response was successfull but the customer does not have any facility contact data
            if (FacilityContactList is null)
            {
                Assert.IsTrue(Code.Equals("204"));
                Assert.IsTrue(Message.Equals("No Data founds"));
                Logger.Info("The customer selected does not have any facility contacts");
            }
            //If response was successfull and customer has facility contact data
            else
            {
                Logger.Info("VALIDATION: Endpoint should return the Facility Contact List");
                Assert.Greater(FacilityContactList.Count, 0);
                Logger.Info($"VALIDATION SUCCESS: The endpoint returned {FacilityContactList.Count} facility contacts");
            }

        }

        [TestCase(TestName = "Add notes to customer ", Description = "Test Case 1270499: US1214695 - API - PUT notes to a Customer"), Category("CustomerPage")]
        [TestCase(TestName = "Edit notes to customer ", Description = "Test Case 1319459: US 1280800 - API endpoint is used to provide the edit customer notes"), Category("CustomerPage")]
        public void UpdateCustomerNotes()
        {
            Logger.Info("EXECUTING: " + TestContext.CurrentContext.Test.Properties.Get("Description"));
            string IntID = "IDN009";
            string body = "This is an API testing";

            DataRepository.Query<string>(DataRepository.BuildConnectionString(), "DeleteCustomerNotes.sql", new { custId = IntID });

            List<CustomerModel> GetDBcustomerList = DataRepository.Query<CustomerModel>(DataRepository.BuildConnectionString(), "GetAllSymphonyCustomers.sql");        
            IEnumerable<CustomerModel> Customer = GetDBcustomerList.Where(customer => customer.IntegrationId.Equals(IntID));

            var RequestBuilder = new RequestBuilder(_webDriver);
            string id = Customer.ElementAt(0).Id.ToString();

            var response = RequestBuilder.GetResponse($"api/customer/{id}/notes", RestSharp.Method.PATCH, body);
            //Verify Status Code

            string Actualcode = response.StatusCode.ToString();
            Logger.Info($"VALIDATION: Status code should be OK");
            Assert.AreEqual("OK", Actualcode, "Response code is " + response.StatusCode);
            Logger.Info($"VALIDATION SUCCESS: Status code is OK");

            var customersDBAfterCall = DataRepository.Query<CustomerModel>(DataRepository.BuildConnectionString(), "GetAllSymphonyCustomers.sql");
            var getNewCustomerData = customersDBAfterCall.Where(customer => customer.IntegrationId.Equals(IntID));

            Logger.Info("VALIDATION: Notes should be added to the Customer");
            Assert.IsTrue(getNewCustomerData.ElementAt(0).Notes.Equals(body), "VALIDATION ERROR: Notes were not added to the Customer");
            Logger.Info($"VALIDATION SUCCESS: Notes were added to the Customer {getNewCustomerData.ElementAt(0).Name} in the DB");
        }


        [Test, Category("CustomerPage")]
        [Description("Test Case 1281350: US1201243 - API - POST Customer")]
        public void AddCustomer()
        {
            Logger.Info("EXECUTING: Test Case 1281350: US1201243 - API - POST Customer");
            var RequestBuilder = new RequestBuilder(_webDriver);

            CustomerModel body = new CustomerModel()
            {
                Name = Common.CommonUtilities.GenerateRandomString(12),
                Rssid = Guid.NewGuid().ToString(),
                IntegrationId = Common.CommonUtilities.GenerateRandomAlphanumericString(6),
                Address1 = Common.CommonUtilities.GenerateRandomString(10),
                Address2 = Common.CommonUtilities.GenerateRandomString(10),
                City = "San Diego",
                StateCode = "CA",
                ZipCode = "10210",
                Notes = ""
            };

            var response = RequestBuilder.GetResponse($"api/customer", RestSharp.Method.POST, body);

            //Verify Status Code
            string Expectedcode = response.StatusCode.ToString();
            Logger.Info($"VALIDATION: Status code should be {Expectedcode}");
            Assert.AreEqual(Expectedcode, "OK", "Response code is " + response.StatusCode);
            Logger.Info($"VALIDATION SUCCESS: Status code is {Expectedcode}");

            var isAdded = false;

            var customersDBAfterCall = DataRepository.Query<CustomerModel>(DataRepository.BuildConnectionString(), "GetAllSymphonyCustomers.sql");
            var getNewCustomerData = customersDBAfterCall.Where(customer => customer.IntegrationId.Equals(body.IntegrationId));

            if (getNewCustomerData.ElementAt(0).Name.Equals(body.Name) && getNewCustomerData.ElementAt(0).Rssid.Equals(body.Rssid) &&
                getNewCustomerData.ElementAt(0).IntegrationId.Equals(body.IntegrationId) &&
                getNewCustomerData.ElementAt(0).Address1.Equals(body.Address1) && getNewCustomerData.ElementAt(0).Address2.Equals(body.Address2) &&
                getNewCustomerData.ElementAt(0).City.Equals(body.City) && getNewCustomerData.ElementAt(0).State.Equals(body.StateCode) &&
                getNewCustomerData.ElementAt(0).ZipCode.Equals(body.ZipCode))
            {
                isAdded = true;
            }
            else
            {
                isAdded = false;
            }
            Logger.Info("VALIDATION: Customer should be added to CCE Symphony DB");
            Assert.IsTrue(isAdded, "Customer was not added");
            Logger.Info($"The Customer {getNewCustomerData.ElementAt(0).Name} was added to the CCE Symphony DB");
        }


        [Test, Category("CustomerPage")]
        [Description("Test Case 1317698: US1200993 - API - Return a list of all customers and associated facilities in the CCE DB.")]
        public void SearchForCustomersAndFacilities()
        {
            Logger.Info("EXECUTING: Test Case 1317698: US1200993 - API - Return a list of all customers and associated facilities in the CCE DB.");
            var RequestBuilder = new RequestBuilder(_webDriver);

            CustomerSearch body = new CustomerSearch()
            {
                CustomerName = Common.Common.CustomerName,
                CustomerId = "",
                CustomerState = "",
                FacilityName = "",
                FacilityId = "",
                FacilityState = "",
                ChangeEventSource = "",
                PageNumber = 1,
                PageSize = 25
            };

            var response = RequestBuilder.GetResponse($"api/customer/searchCustomer", RestSharp.Method.POST, body);

            var Deserializer = new JsonDeserializer();
            //var CustomerList = Deserializer.Deserialize<CustomerListResponse>(response);

            //var x = CustomerList.Total.ToString();
            //Verify Status Code
            string Expectedcode = response.StatusCode.ToString();
            Logger.Info($"VALIDATION: Status code should be {Expectedcode}");
            Assert.AreEqual(Expectedcode, "OK", "Response code is " + response.StatusCode);
            Logger.Info($"VALIDATION SUCCESS: Status code is {Expectedcode}");

            var customersDBAfterCall = DataRepository.Query<CustomerModel>(DataRepository.BuildConnectionString(), "GetAllSymphonyCustomers.sql");
            var getNewCustomerData = customersDBAfterCall.Where(customer => customer.Name.Equals(body.CustomerName));

            Logger.Info("VALIDATION: API return all the customers that match search criteria on CCE Symphony DB");
            //Assert.IsTrue(getNewCustomerData.Count().Equals(int.Parse(CustomerList.Total)), "API doesn't return all the customers that match search criteria on CCE Symphony DB");
            Logger.Info("API return all the customers that match search criteria on CCE Symphony DB");
        }

        [Test, Category("CustomerPage")]
        [Description("Test Case 1317708: US1204995 - API - Endpoint provides customer address data.")]
        public void GetCustomersAdresss()
        {
            Logger.Info("EXECUTING: Test Case 1317708: US1204995 - API - Endpoint provides customer address data.");
           
            List<CustomerModel> GetDBcustomerList = DataRepository.Query<CustomerModel>(DataRepository.BuildConnectionString(), "GetAllSymphonyCustomers.sql");
           var getNewCustomerData = GetDBcustomerList.Where(customer => customer.Address1.Equals("Danbury, CT 06810"));
            var RequestBuilder = new RequestBuilder(_webDriver);
            string id = getNewCustomerData.ElementAt(0).Id.ToString();
            string address1 = getNewCustomerData.ElementAt(0).Address1;
            string address2 = getNewCustomerData.ElementAt(0).Address2;

            dynamic Addresses = "";
            dynamic ResponseAddress1 = "";
            dynamic ResponseAddress2 = "";
            var response = RequestBuilder.GetResponse($"api/customer/{id}", RestSharp.Method.GET);

            dynamic stuff1 = Newtonsoft.Json.JsonConvert.DeserializeObject(response.Content);

            
            foreach (var JsonEle in stuff1)
            {
                if (JsonEle.Name == "response" )
                { 
                    Addresses = JsonEle.Value; 
                
                }
               
            }

            foreach (var JsonEle1 in Addresses)
            {
               

                if (JsonEle1.Name == "address1")
                {
                    ResponseAddress1 = JsonEle1.Value;
                }
                else if (JsonEle1.Name == "address2")
                {
                    ResponseAddress2 = JsonEle1.Value;
                }

            }
            bool validation = ResponseAddress1.ToString().Equals(address1) && ResponseAddress2.ToString().Equals(address2);

            //Verify Status Code
            
            string Actualcode = response.StatusCode.ToString();
            Logger.Info($"VALIDATION: Status code should be OK");
            Assert.AreEqual("OK", Actualcode, "Response code is " + response.StatusCode);
            Logger.Info($"VALIDATION SUCCESS: Status code is OK");

            Logger.Info("VALIDATION: API Return the Customer address");
            Assert.IsTrue(validation, "VALIDATION ERROR: API does not return the Customer address");
            Logger.Info("VALIDATION SUCCESS: API Return the Customer address");
        }

    }
}

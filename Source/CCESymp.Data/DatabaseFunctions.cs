using CCESymp.Data.Mapping;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading;

namespace CCESymp.Data
{
    public static partial class DataRepository
    {

        /// <summary>
        /// Returns the user Id stored in database when user mail is provided
        /// </summary>
        /// <param name="userEmail">email associated to the user id looked for</param>
        public static string GetUserID(string userEmail) => Query<string>(BuildConnectionString(), "GetUserIdByEmail.sql", new { UserEmail = userEmail })[0];

        /// <summary>
        /// Deletes existing user sessions for auto-admin and auto-user test users
        /// </summary>
        /// <param name="delete">deletes user sessions when set to true</param>
        public static void DeleteUserSessions(bool delete = true)
        {
            if (delete)
            {
                DataLogger.Info("Deleting generated user sessions");
                try
                {
                    Common.Common.waitBeforeDeleteSessions = Common.Common.GetEnvVar(@"waitBeforeDelete", @"Don't Wait");
                    _ = Query<string>(BuildConnectionString(), "DeleteSessionByUserId.sql", new { UserId = GetUserID(Common.Common.CurrentUsername) });

                    Common.Common.waitBeforeDeleteSessions = Common.Common.GetEnvVar(@"waitBeforeDelete", @"Wait");
                }
                catch
                {
                    DataLogger.Info($"ERROR while trying to delete existing user sessions for {Common.Common.CurrentUsername}");
                }
            }
        }

        /// <summary>
        /// Deletes an active session from the database when the desired IP is provided
        /// </summary>
        public static void DeleteGeneratedIpSession(string IpAddress) => Query<int>(BuildConnectionString(), "DeleteSessionByIp.sql", new { IPAddress = IpAddress });

        /// <summary>
        /// Returns the count of active user session when a particular User email is provided
        /// </summary>
        /// <param name="userEmail">email associated to the user sessions to be found</param>
        public static int GetCountOfActiveUserSessions(string email) => (Query<UserSessionModel>(BuildConnectionString(), "GetUserSessions.sql", new { UserId = GetUserID(email) })).Count();

        /// <summary>
        /// Returns all the cce symphony customers in database
        /// </summary>
        public static List<CCESymphonyCustomer> GetCCESymphonyCustomers() => Query<CCESymphonyCustomer>(BuildConnectionString(), "GetAllSymphonyCustomers.sql");

        /// <summary>
        /// Inserts test data into the Customer and Facility Tables
        /// </summary>
        public static void InsertCustomerData()
        {
            Common.Common.waitBeforeDeleteSessions = Common.Common.GetEnvVar(@"waitBeforeDelete", @"Don't Wait");
            var CustomersCount = GetCCESymphonyCustomers().Count;
            if (CustomersCount < 100)
            {
                var CustomerDataQueryLines = ReadFileLines("InsertCustomerDataQuery.sql");
                foreach (var line in CustomerDataQueryLines)
                {
                    if (!string.IsNullOrEmpty(line))
                    {
                        try
                        {
                            _ = ExecuteQuery<int>(line);
                            _ = Query<int>(BuildConnectionString(), "GenerateCustomerFacilities.sql");
                        }
                        catch
                        {
                            DataLogger.Info("Customer data could not be inserted");
                        }
                    }
                }
            }
            Common.Common.waitBeforeDeleteSessions = Common.Common.GetEnvVar(@"waitBeforeDelete", @"Wait");
        }

        private static void RemoveCustomer(string CustomerName)
        {
            Common.Common.waitBeforeDeleteSessions = Common.Common.GetEnvVar(@"waitBeforeDelete", @"Don't Wait");

            string CustomerIdQuery = $"SELECT Id FROM Symphony.Customer WHERE Name = '{CustomerName}'";
            var CustomerID = ExecuteQuery<int>(CustomerIdQuery).FirstOrDefault();
            string SolutionIdQuery = $"SELECT Id FROM Symphony.Solution WHERE CustomerId = {CustomerID}";
            var SolutionIds = ExecuteQuery<int>(SolutionIdQuery);

            DeleteCustomerNotesFromDB(CustomerID.ToString());

            foreach (var SolID in SolutionIds)
            {
                string DeleteConfigsQuery = $"DELETE FROM Symphony.Configuration WHERE SolutionId = {SolID}";
                _ = ExecuteQuery<int>(DeleteConfigsQuery).FirstOrDefault();
            }

            _ = Query<bool>(BuildConnectionString(), "DeleteSympCustomerByName.sql", new { searchedCustomerName = CustomerName });

            Common.Common.waitBeforeDeleteSessions = Common.Common.GetEnvVar(@"waitBeforeDelete", @"Wait");
        }


        /// <summary>
        /// Deletes all the data from Customers and Facility Tables when there are less than 200 customers in database
        /// </summary>
        public static void DeleteCustomerData()
        {
            var customerList = GetCCESymphonyCustomers();
            if (customerList.Count() < 100)
            {
                _ = Query<int>(BuildConnectionString(), "DeleteCustomerData.sql");
            }
        }

        /// <summary>
        /// Updates the IP address of an existing user session in database and returns the new assigned IP Address
        /// </summary>
        public static void UpdateSessionIPAddress(string oldIP, out string newIp)
        {
            newIp = "0.0.0.0";
            _ = Query<int>(BuildConnectionString(), "UpdateSessionIp.sql", new { NewIpAddress = newIp, CurrentIpAddress = oldIP });
        }

        /// <summary>
        /// Reads a file line by line and returns all lines in a list of strings when the name of the file is provided
        /// </summary>
        public static List<string> ReadFileLines(string FileName)
        {
            string directoryRoot = Path.GetDirectoryName((new Uri(Assembly.GetExecutingAssembly().CodeBase)).LocalPath);
            string fileLocation = string.Format("{0}\\DBScripts\\", directoryRoot);
            string result = File.ReadAllText(string.Format("{0}\\{1}", fileLocation, FileName));
            string[] FileLinesArray = Regex.Split(result, Environment.NewLine);
            List<string> FileLinesList = new(FileLinesArray);
            return FileLinesList;
        }

        /// <summary>
        /// Returns the value saved in database for the inactivity timeout
        /// </summary>
        public static int GetInactivityTimeout => Query<int>(BuildConnectionString(), "GetInactivityTimeout.sql")[0];

        /// <summary>
        /// Updates the current inactivity timeout value in database
        /// </summary>
        /// /// <param name="timeoutValue">New inactivity timeout value</param>
        public static void UpdateInactivityTimeout(int timeoutValue) => Query<int>(BuildConnectionString(), "UpdateInactivityTimeout.sql", new { TimeoutValue = timeoutValue });

        /// <summary>
        /// Inserts a random solution into the database when the customer name is provided 
        /// </summary>
        /// <param name="customerName"></param>
        /// <param name="templateTypeId"></param>
        public static void InsertRandomSolutionInDB(string customerName, int customerId, int templateTypeId = 6) => Query<int>(BuildConnectionString(), "InsertRandomSolution.sql", new { CustomerName = customerName, TemplateTypeId = templateTypeId, CustomerId = customerId });

        /// <summary>
        /// Get all the Solutions available in DB
        /// </summary>
        public static List<SolutionModel> GetAllSolutions => Query<SolutionModel>(BuildConnectionString(), "GetAllSolutions.sql");

        /// <summary>
        /// Wait for the Data to be loaded into the DB
        /// </summary>
        /// <param name="timeout"></param>
        public static void WaitForDataLoad(int timeout = 2000)
        {
            Thread.Sleep(timeout);
        }

        /// <summary>
        /// Return List of all customer in Symphony DB
        /// </summary>
        public static List<CustomerModel> GetDBcustomerList => Query<CustomerModel>(BuildConnectionString(), "GetAllSymphonyCustomers.sql");

        /// <summary>
        /// Get the customer in DB using the Customer Name
        /// </summary>
        /// <param name="custName"></param>
        /// <returns></returns>
        public static IEnumerable<CustomerModel> GetCustomerByName(string custName) => GetDBcustomerList.Where(customer => customer.Name.Equals(custName));

        /// <summary>
        /// Get the customer data in DB using the Customer integration ID
        /// <br>NOTE: Customer integration ID is the same id displayed in the Customer Home Page</br>
        /// </summary>
        /// <param name="custId"></param>
        /// <returns></returns>
        public static IEnumerable<CustomerModel> GetCustomerByID(string custId) => GetDBcustomerList.Where(customer => customer.IntegrationId.Equals(custId));

        /// <summary>
        /// Delete the customer found using Customer Name
        /// </summary>
        /// <param name="customerName"></param>
        public static void DeleteCustomerByName(string customerName) => RemoveCustomer(customerName);

        /// <summary>
        /// Get Solutions from a customer by using Customer ID
        /// </summary>
        /// <param name="custID"></param>
        /// <returns></returns>
        public static List<SolutionModel> GetSolutionWithCustomerID(string custID) => Query<SolutionModel>(BuildConnectionString(), "GetSolutionInformationByCustId.sql", new { customerId = custID }).ToList();

        /// <summary>
        /// Deletes the notes in database via customer id
        /// </summary>
        /// <param name="custId"></param>
        public static void DeleteCustomerNotesFromDB(string custId) => Query<string>(BuildConnectionString(), "DeleteCustomerNotes.sql", new { custId });

        /// <summary>
        /// Get Solution Information from DB
        /// </summary>
        /// <param name="solutionName"></param>
        /// <returns></returns>
        public static List<SolutionModel> GetSolutionInformationFromDB(string SolutionName) => Query<SolutionModel>(BuildConnectionString(), "GetSolutionInformationBySolName.sql", new { solutionName = SolutionName });



        /// <summary>
        /// Get Solution Configuration By solution name from DB
        /// </summary>
        /// <param name="SolutionName"></param>
        /// <returns></returns>
        public static string GetSolutionConfigurationBySolutionName(string SolutionName) => Query<string>(BuildConnectionString(), "GetSolutionConfiguration.sql", new { solutionname = SolutionName })[0];


        /// <summary>
        /// Get Solution Configuration template by Template type in DB
        /// </summary>
        /// <param name="TemplateType"></param>
        /// <returns></returns>
        public static string GetSolutionConfigurationTemplateByTemplateType(string TemplateType) => Query<SolutionConfigurationTemplate>(BuildConnectionString(), "GetSolutionConfigurationTemplate.sql").Where(Conf => Conf.Name.Contains(TemplateType)).ElementAt(1).Template;

        /// <summary>
        /// Delete uploaded data by solution ID from DB
        /// </summary>
        /// <param name="Id"></param>
        public static void DeleteUploadDataBySolutionId(string Id) => Query<int>(BuildConnectionString(), "DeleteUploadDataBySolutionId.sql", new { SolutionId = Id });

        /// <summary>
        /// GetMessageTracing using SolutionID from DB
        /// </summary>
        /// <param name="SolutionID"></param>
        /// <returns></returns>
        public static List<MessageTracingModel> GetMessageTracingWithSolutionID(string SolutionID) => Query<MessageTracingModel>(BuildConnectionString(), "GetAllMessageTracing.sql").Where(messageTracing => messageTracing.SolutionId.Equals(SolutionID)).ToList();
        public static List<PublishModel> GetSolutionConfigurations(string solutionName) => Query<PublishModel>(BuildConnectionString(), "PublishConfiguration.sql", new { SolutionName = solutionName });

        public static List<Configuration> GetSolutionConfigurations() => Query<Configuration>(BuildConnectionString(), "GetSolutionConfigurationTemplate.sql");

        /// <summary>
        /// Get Customers from DB with Address 1 and Address 2
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<CustomerModel> GetCustomersWithAdressess() => GetDBcustomerList.Where(customer => customer.Address1 != "" && customer.Address2 != "");


        public static void DeleteSolutionByCustId(string customerId) => Query<int>(BuildConnectionString(), "DeleteSolutionByCustId.sql", new { customerID = customerId });

        public static void DeleteSessionIdByUserID(string user) => Query<string>(BuildConnectionString(), "DeleteSessionByUserId.sql", new { UserId = GetUserID(user) });

    }
}


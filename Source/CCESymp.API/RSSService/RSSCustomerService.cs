using CCESymp.Data.Mapping;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using CCESymp.Data;
using RestSharp;
using System.IO;

namespace CCESymp.API.Services
{
    public class RSSCustomerService : TestBase
    {
        /// <summary>
        /// Returns all customers in found in RSS API
        /// </summary>
        public async Task<Response<RssCustomers>> GetAllRssCustomersAsync()
        {
            Response<RssCustomers> result = new();
            HttpClient _httpClientFactory = new();
            _httpClientFactory.BaseAddress = new Uri(string.Concat(Common.Common.RSSUrl, Common.Constants.RSSConstants.GetCustomersEndpoint));
            _httpClientFactory.DefaultRequestHeaders.Add(Common.Common.RSSKeyName, Common.Common.RSSKeyValue);

            try
            {
                HttpResponseMessage response = await _httpClientFactory.GetAsync(_httpClientFactory.BaseAddress);

                Logger.Info($"Awaiting data for GET request: {_httpClientFactory.BaseAddress}");
                Logger.Info($"Response received for GET request, Status Code: {response.StatusCode}");

                string content = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                    result = JsonConvert.DeserializeObject<Response<RssCustomers>>(content);

            }
            catch (TimeoutException ex)
            {
                Logger.Info($"Method - FindAllRssCustomers :: Error - {ex.Message}");
                Logger.Info($"Method - FindAllRssCustomers :: StackTrace - {ex.StackTrace}");
                throw;
            }
            catch (Exception ex)
            {
                Logger.Info($"Method - FindAllRssCustomers :: Error - {ex.Message}");
                Logger.Info($"Method - FindAllRssCustomers :: StackTrace - {ex.StackTrace}");
                throw;
            }

            return result;
        }

        /// <summary>
        /// Returns the list of facilities associated to the provided <paramref name="rssCustomerId"/>
        /// </summary>
        public async Task<Response<RssFacility>> FindAllRssFacilitiesByCustomerId(string rssCustomerId)
        {
            HttpClient _httpClientFactory = new();
            Response<RssFacility> result = new();

            try
            {

                _httpClientFactory.BaseAddress = new Uri($"{Common.Common.RSSUrl}api/odata/Customers(guid'{rssCustomerId}')/Facilities");
                _httpClientFactory.DefaultRequestHeaders.Add(Common.Common.RSSKeyName, Common.Common.RSSKeyValue);
                HttpResponseMessage response = await _httpClientFactory.GetAsync(_httpClientFactory.BaseAddress);

                Logger.Info($"Awaiting data for GET request: {_httpClientFactory.BaseAddress}");
                Logger.Info($"Response received for GET request, Status Code: {response.StatusCode}");

                string content = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                    result = JsonConvert.DeserializeObject<Response<RssFacility>>(content);
            }
            catch (TimeoutException ex)
            {
                Logger.Info($"Method - FindAllFacilitiesByCustomerId :: Error - {ex.Message}");
                Logger.Info($"Method - FindAllFacilitiesByCustomerId :: StackTrace - {ex.StackTrace}");
                throw;
            }
            catch (Exception ex)
            {
                Logger.Info($"Method - FindAllFacilitiesByCustomerId :: Error - {ex.Message}");
                Logger.Info($"Method - FindAllFacilitiesByCustomerId :: StackTrace - {ex.StackTrace}");
                throw;
            }

            return result;
        }

        public RssFacility GetRSSFacility(string RSSFacilityId)
        {
            var RSSFacilityTask = FindAllRssFacilitiesByCustomerId(RSSFacilityId);
            RSSFacilityTask.Wait();
            var FacilityList = RSSFacilityTask.Result.Value;
            int index = Common.CommonUtilities.GenerateRandomNumber(0, FacilityList.Count);
            return FacilityList[index];
        }

        /// <summary>
        /// Checks whether a customer exists on HSCE DB using the provided <paramref name="RSSId"/>
        /// </summary>
        public async Task<bool> CheckCustomerExistsAsync (string accessToken, string RSSId)
        {
            HttpClient _httpClientFactory = new();
            string BaseAddress = (string.Concat(Common.Common.CCESymp_DashboardAPI_Url, $"api/customer/checkCustomerExist/{RSSId}"));
            _httpClientFactory.BaseAddress = new Uri(BaseAddress);
            _httpClientFactory.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");

            HttpResponseMessage Response = await _httpClientFactory.GetAsync(_httpClientFactory.BaseAddress);

            Logger.Info($"Awaiting data for GET request: {_httpClientFactory.BaseAddress}");
            Logger.Info($"Response received for GET request, Status Code: {Response.StatusCode}");

            var ResponseContent = await Response.Content.ReadAsStringAsync();

            return ResponseContent.Contains("Customer already exists and will not be added to CCE Database");
        }

        /// <summary>
        /// On-boards an RSS Customer to HSCE database if it doesn't exist
        /// </summary>
        public async Task<CustomerModel> AddACustomerAsync(string accessToken)
        {
            var RSSCustomersTask = await GetAllRssCustomersAsync();
            var RSSCustomerResults = RSSCustomersTask.Value;
            //Check if customer exists on the database...
            var RSSCustomer = RSSCustomerResults[0];

            CustomerModel body = new()
            {
                Name = RSSCustomer.Name,
                Rssid = RSSCustomer.CustomerId,
                IntegrationId = RSSCustomer.IntegrationId,
                Address1 = RSSCustomer.Address1,
                Address2 = RSSCustomer.Address2,
                City = RSSCustomer.CityName,
                StateCode = RSSCustomer.CityCode,
                ZipCode = RSSCustomer.ZipCode,
                Notes = "",
            };

            var CheckCustomerExists = await CheckCustomerExistsAsync(accessToken, RSSCustomer.CustomerId);
            if (!CheckCustomerExists)
            {
                var RequestBuilder = new RequestBuilder(_webDriver);
                var response = RequestBuilder.GetResponse($"api/customer", RestSharp.Method.POST, body);
                string ExpectedCode = response.StatusCode.ToString();
                NUnit.Framework.Assert.IsTrue(ExpectedCode.Equals("OK"), "THE RSS CUSTOMER COULD NOT BE SUCCESSFULLY ONBOARDED");
            }
            else {
                Logger.Info("The customer already exists on HSCE DATABASE, no onboarding is needed");
            }
            return body;
        }

        /// <summary>
        /// Returns the data of a random RSS Customer
        /// </summary>
        private async Task<RssCustomers> GetRandomRSSCustomer() {
            var RSSCustomersTask = await GetAllRssCustomersAsync();
            var RSSCustomerResults = RSSCustomersTask.Value;
            var index = Common.CommonUtilities.GenerateRandomNumber(0, RSSCustomerResults.Count);
            var RSSCustomer = RSSCustomerResults[index];
            return RSSCustomer;
        }

        public RssCustomers RandomRSSCustomer()
        {
            var CustomerTask = GetRandomRSSCustomer();
            CustomerTask.Wait();
            return CustomerTask.Result;
        }

        /// <summary>
        /// Returns a word which matches multiple RSS Customer Names
        /// The main intent is to use this for pagination
        /// <paramref name="MatchCount"/> is the maximum amount of customers which should contain the match word
        /// </summary>
        public string GetConcurrentCustomerWord(int MatchCount = 150) {
            string ConcurrentWord = string.Empty;

            var CustomersTask = GetAllRssCustomersAsync();
            CustomersTask.Wait();
            var CustomerResults = CustomersTask.Result.Value;

            var CustomersNamesList = from CustomerItem in CustomerResults select CustomerItem.Name;

            string Text = String.Join(Convert.ToChar(32).ToString(), CustomersNamesList);

            var WordsIterator = Regex.Split(Text.ToLower(), @"\W+").Where(s => s.Length > 3).GroupBy(s => s).OrderByDescending(g => g.Count()).Select(element => element.Key).ToList();

            if (CustomersNamesList.Count() > 160)
            {
                foreach (var Word in WordsIterator)
                {
                    var MatchList = CustomersNamesList.Where(item => item.ToLower().Contains(Word.ToLower())).ToList();
                    if (MatchList.Count() < MatchCount && MatchList.Count() > 25)
                    {
                        ConcurrentWord = Word;
                        break;
                    }
                }
            }
            else {
                ConcurrentWord = WordsIterator.FirstOrDefault();
            }

            return ConcurrentWord;
        }

        public string GetRandCustomerStateCode() {
            string CustomerState = string.Empty;

            var CustomersTask = GetAllRssCustomersAsync();
            CustomersTask.Wait();
            var CustomerResults = CustomersTask.Result.Value;

            var CustomerStateElements = (from CustomerItem in CustomerResults select CustomerItem.StateCode).
                                        Where(Code => !string.IsNullOrEmpty(Code));

            CustomerState = CustomerStateElements.
                            ElementAt(Common.CommonUtilities.GenerateRandomNumber(0, CustomerStateElements.Count() - 1));

            return CustomerState;
        }

        public Dictionary<string, string> SetSolutionConfiguration(String SolutionName)
        {
            var MappingTemplate = "";
            string FacilityCode = "Facility" + Common.CommonUtilities.RandomString(4, false);



            SolutionModel AddSolutionBody = new()
            {
                Name = SolutionName,
                Category = "PROD",
                TemplateTypeId = "1",
                Description = "Added by Automation",
                CustomerID = Common.Common.Solution_Customer_DBId

            };

            var RequestBuilder = new RequestBuilder(_webDriver);
            RequestBuilder.GetResponse($"api/solution", Method.POST, AddSolutionBody);

            
                DataRepository.WaitForDataLoad(300);

                var SolutionInfo = DataRepository.GetSolutionInformationFromDB(SolutionName)[0];
                string CurrentDirectoryPath = AppDomain.CurrentDomain.BaseDirectory; //Save current directroy path.
                string CombinedPath = string.Concat(CurrentDirectoryPath, Common.Common.MappingTemplate); //Combine current path with xml file path.
                string FilePath = Path.GetFullPath(CombinedPath); // Save full path of the upload file
                using (StreamReader streamReader = new StreamReader(FilePath, Encoding.UTF8))
                {

                    MappingTemplate = streamReader.ReadToEnd();

                }

                PublishModel SolutionConfigurationBody = new()
                {
                    BusinessUnit = "MedBank",
                    Category = "PROD",
                    Id = SolutionInfo.Id,
                    Name = SolutionName,
                    TemplateTypeId = "1",
                    Description = SolutionInfo.Description,
                    CustomerID = SolutionInfo.CustomerID,
                    ConfigurationValue = MappingTemplate,
                    //Configurations = "",
                    Customer = SolutionInfo.CustomerName,
                    CustomerGlobalId = SolutionInfo.CustomerGlobalId,
                    FacilityCode = FacilityCode,
                    FacilityPassword = "H@{ tYU_E_{ .6@% -} &amp; })oRogz & amp;?2; ;)#b([jZ0.Lq({|2B*_3z;EiS=W^Ca&gt;#iie_&amp;xr#*?#y%hrU-r)?taNj4Az*^NMS?Y[-d[;Rn*w{?1+^zTXP)+9-&gt;ez_=$0.kT|_",
                    FacilityUsername = "$$}0w=aTL%.GDUTwrpVWT67OG7dk)ZHym*gAwQ70T-OVJ!;6!Vu[HBrkHiZ&amp;w{fST{r@zq^J!J2|Iz_enfm9Iqj+?K+r26YHI7+rfz5sL|Wybd[rpm+e!*+}t5lO=#A_",
                    GlobalId = SolutionInfo.globalId,
                    IsBusinessUnitPermitted = true,
                    IsPublished = false,
                    Notes = SolutionInfo.Notes,
                    TemplateType = SolutionInfo.TemplateTypeName,
                    TemplateVersion = SolutionInfo.Version,

                    configuration = new Configuration()
                    {
                        Id = 1,
                        Name = SolutionInfo.TemplateTypeName,
                        template = SolutionInfo.Template,
                        modifiedBy = "0",
                        modifiedByNavigation = "null",
                        modifiedDateTime = "",
                    }
                };
                _ = new RequestBuilder(_webDriver);

                Dictionary<string, string> sid = new()
                {
                {"session-id", sessionId }
                };
                _ = RequestBuilder.GetResponse($"api/solution/configuration", Method.PUT, sid, SolutionConfigurationBody);
                DataRepository.WaitForDataLoad(3000);
                return sid;
            }
        
    }
}

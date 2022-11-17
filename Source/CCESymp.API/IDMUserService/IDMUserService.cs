using CCESymp.API;
using CCESymp.Data.IDMMapping;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CCESymp.IDMServices.Services
{
    public class IDMUserService : TestBase
    {
        private string AccessToken => IDMToken.GetUserServiceToken();
        private readonly string UserExpirationYear = DateTime.Now.AddYears(2).Year.ToString();
        /// <summary>
        /// Checks whether a user account exists on IDM using the provided <paramref name="email"/>
        /// eg (adamjohnes1@example.com)
        /// </summary>
        private async Task<bool> CheckUserExistsAsync(string email)
        {
            UserExistence userDetails = new();
            var MailObject = (dynamic)new JsonObject();
            MailObject.email = email;
            StringContent queryString = new(JsonConvert.SerializeObject(MailObject), Encoding.UTF8, "application/json");

            HttpClient _httpClientFactory = new();

            string BaseAddress = Path.Combine(Common.Common.IDMUserServiceBaseURL, "api/users/email-in-use");
            _httpClientFactory.BaseAddress = new Uri(BaseAddress);
            SetUserCreationToken();
            _httpClientFactory.DefaultRequestHeaders.Add("Authorization", $"Bearer {Common.Common.UserCreationToken}");

            HttpResponseMessage Response = await _httpClientFactory.PostAsync(_httpClientFactory.BaseAddress, queryString);

            Logger.Info($"Awaiting data for POST request: {_httpClientFactory.BaseAddress}");
            Logger.Info($"Response received for POST request, Status Code: {Response.StatusCode}");

            var ResponseContent = await Response.Content.ReadAsStringAsync();

            if (Response.IsSuccessStatusCode)
                userDetails = JsonConvert.DeserializeObject<UserExistence>(ResponseContent);

            return userDetails.data;
        }

        private void SetUserCreationToken()
        {
            if (string.IsNullOrEmpty(Common.Common.UserCreationToken))
                Common.Common.UserCreationToken = AccessToken;
        }

        /// <summary>
        /// Checks whether a user account exists on IDM using the provided <paramref name="email"/>
        /// eg (adamjohnes1@example.com)
        /// </summary>
        public bool CheckIDMEmailExists(string email)
        {
            var CheckEmailTask = CheckUserExistsAsync(email);
            CheckEmailTask.Wait();
            return CheckEmailTask.Result;
        }

        /// <summary>
        /// Returns all user details associated to the provided <paramref name="username"/>
        /// eg (adamjohnes1@example.com)
        /// </summary>
        private async Task<UserDetails> RetrieveUserDetails(string username)
        {
            HttpClient _httpClientFactory = new();

            var MailObject = (dynamic)new JsonObject();
            MailObject.username = username;
            StringContent queryString = new(JsonConvert.SerializeObject(MailObject), Encoding.UTF8, "application/json");
            UserDetails result;
            try
            {
                string BaseAddress = Path.Combine(Common.Common.IDMUserServiceBaseURL, "api/users/details");
                _httpClientFactory.BaseAddress = new Uri(BaseAddress);
                SetUserCreationToken();
                _httpClientFactory.DefaultRequestHeaders.Add("Authorization", $"Bearer {Common.Common.UserCreationToken}");
                HttpResponseMessage response = await _httpClientFactory.PostAsync(_httpClientFactory.BaseAddress, queryString);

                Logger.Info($"Awaiting data for GET request: {_httpClientFactory.BaseAddress}");
                Logger.Info($"Response received for GET request, Status Code: {response.StatusCode}");

                string content = await response.Content.ReadAsStringAsync();

                //if (response.IsSuccessStatusCode)
                result = JsonConvert.DeserializeObject<UserDetails>(content);
            }
            catch (TimeoutException ex)
            {
                Logger.Info($"Method - Find User Details By Username :: Error - {ex.Message}");
                Logger.Info($"Method - Find User Details By Username :: StackTrace - {ex.StackTrace}");
                throw;
            }
            catch (Exception ex)
            {
                Logger.Info($"Method - Find User Details By Username :: Error - {ex.Message}");
                Logger.Info($"Method - Find User Details By Username :: StackTrace - {ex.StackTrace}");
                throw;
            }

            return result;
        }

        /// <summary>
        /// Returns all user details associated to the provided <paramref name="username"/>
        /// eg (adamjohnes1@example.com)
        /// </summary>
        public UserDetails GetUserDetailsByUsername(string username)
        {
            var UserDetailsTask = RetrieveUserDetails(username);
            UserDetailsTask.Wait();
            return UserDetailsTask.Result;
        }

        /// <summary>
        /// Resets the user password associated to the specified <paramref name="username"/>
        /// Returns true when password is successfully changed
        /// </summary>
        private async Task<bool> UpdateUserPassword(string username, string password)
        {
            bool IsPasswordUpdated = false;
            var UserDetails = GetUserDetailsByUsername(username);

            if (!UserDetails.status.Equals("NotFound"))
            {
                string BaseAddress = Path.Combine(Common.Common.IDMUserServiceBaseURL, $"api/users/{UserDetails.data.parentKey}/set-password");

                HttpClient _httpClientFactory = new();

                var PasswordObject = (dynamic)new JsonObject();
                PasswordObject.password = password;
                StringContent queryString = new(JsonConvert.SerializeObject(PasswordObject), Encoding.UTF8, "application/json");

                _httpClientFactory.BaseAddress = new Uri(BaseAddress);
                SetUserCreationToken();
                _httpClientFactory.DefaultRequestHeaders.Add("Authorization", $"Bearer {Common.Common.UserCreationToken}");

                HttpResponseMessage response = await _httpClientFactory.PutAsync(_httpClientFactory.BaseAddress, queryString);

                Logger.Info($"Awaiting data for PUT request: {_httpClientFactory.BaseAddress}");
                Logger.Info($"Response received for PUT request, Status Code: {response.StatusCode}");

                string content = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                    IsPasswordUpdated = content.Contains("Password set successfully");
            }
            else
            {
                Logger.Info($"The specified user does not exist on IDM database: {username}");
            }

            return IsPasswordUpdated;
        }

        /// <summary>
        /// Resets the user password associated to the specified <paramref name="username"/>
        /// Returns true when password is successfully changed
        /// </summary>
        public bool ResetUserPassword(string username, string password)
        {
            var PasswordTask = UpdateUserPassword(username, password);
            PasswordTask.Wait();
            return PasswordTask.Result;
        }

        /// <summary>
        /// Updates the user details using the provided information on <paramref name="Information"/> model
        /// </summary>
        private async Task<bool> UpdateUserDetailsAsync(string username, UserInfo Information)
        {
            bool IsUserUpdated = false;
            var UserDetails = GetUserDetailsByUsername(username);

            if (!UserDetails.status.Equals("NotFound"))
            {
                Logger.Info("Updating current user data");
                string BaseAddress = Path.Combine(Common.Common.IDMUserServiceBaseURL, $"api/users/{UserDetails.data.parentKey}");

                HttpClient _httpClientFactory = new();

                StringContent queryString = new(JsonConvert.SerializeObject(Information), Encoding.UTF8, "application/json");

                _httpClientFactory.BaseAddress = new Uri(BaseAddress);
                SetUserCreationToken();
                _httpClientFactory.DefaultRequestHeaders.Add("Authorization", $"Bearer {Common.Common.UserCreationToken}");

                HttpResponseMessage response = await _httpClientFactory.PutAsync(_httpClientFactory.BaseAddress, queryString);

                Logger.Info($"Awaiting data for PUT request: {_httpClientFactory.BaseAddress}");
                Logger.Info($"Response received for PUT request, Status Code: {response.StatusCode}");

                string content = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                    IsUserUpdated = content.Contains("User Updated");
            }
            else
            {
                Logger.Info($"The specified user does not exist on IDM database: {username}");
            }
            return IsUserUpdated;
        }

        /// <summary>
        /// Updates the user details using the provided information on <paramref name="Information"/> model
        /// </summary>
        public bool UpdateIDMUserDetails(string username, UserInfo Information)
        {
            var UpdateTask = UpdateUserDetailsAsync(username, Information);
            UpdateTask.Wait();
            return UpdateTask.Result;
        }

        /// <summary>
        /// Creates a new IDM user account based on the provided <paramref name="email"/> model
        /// Activates user account if provided <paramref name="email"/> already exists on IDM database
        /// </summary>
        private async Task<UserDetails> CreateIDMUserAsync(string email)
        {
            dynamic UserObject = GenerateUserCreationObject(email);       
            
            if (!CheckIDMEmailExists(email))
            {
                Logger.Info($"Determined provided email {email} does not exist on HSCE database\nProceeding to create user");
                StringContent queryString = new(JsonConvert.SerializeObject(UserObject), Encoding.UTF8, "application/json");

                string BaseAddress = Path.Combine(Common.Common.IDMUserServiceBaseURL, "api/users");
                HttpClient _httpClientFactory = new();
                _httpClientFactory.BaseAddress = new Uri(BaseAddress);
                SetUserCreationToken();
                _httpClientFactory.DefaultRequestHeaders.Add("Authorization", $"Bearer {Common.Common.UserCreationToken}");

                HttpResponseMessage response = await _httpClientFactory.PostAsync(_httpClientFactory.BaseAddress, queryString);

                Logger.Info($"Awaiting data for PUT request: {_httpClientFactory.BaseAddress}");
                Logger.Info($"Response received for PUT request, Status Code: {response.StatusCode}");

                string content = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)                
                    await CreateIDMUserAsync(email);                
            }
            else
            {
                Logger.Info($"Determined provided email {email} already exists on HSCE Database\nEnabling account");
                UserDetails _details = GetUserDetailsByUsername(UserObject.username);
                UserInfo Information = GenerateUserInformationModel(_details);

                _ = UpdateIDMUserDetails(email, Information);
            }

            _ = ResetUserPassword(email, Common.Common.HSCEAutomationPassword);
            var Details = GetUserDetailsByUsername(email);
            Logger.Info("Returning user details");
            return Details;
        }

        /// <summary>
        /// Creates a new IDM user account based on the provided <paramref name="email"/>.
        /// Activates user account if provided <paramref name="email"/> already exists on IDM database.
        /// Returns user account data associated to the provided <paramref name="email"/>.
        /// </summary>
        public UserDetails CreateIDMUserAccount(string email)
        {
            Logger.Info($"Starting user creation flow for email {email}");
            var CreationTask = CreateIDMUserAsync(email);
            CreationTask.Wait();
            return CreationTask.Result;
        }

        //Object which is only meant to be used when generating a new user account
        private UserInfo GenerateUserInformationModel(UserDetails _details)
        {
            return new UserInfo()
            {
                firstname = "Automation",
                lastname = "User",
                suffix = _details.data.suffix,
                initials = _details.data.initials,
                middleInitial = _details.data.middleInitial,
                isLoginAllowedFlag = true,
                expirationDate = $"{UserExpirationYear}-12-25T08:54:05.909Z",
                email = _details.data.email,
                username = _details.data.email,
                isAccountClosed = false,
                exemptBioId = false,
                userBadgeId = _details.data.userBadgeId,
                userScanCode = _details.data.userScanCode,
                rowaId = Common.CommonUtilities.GenerateRandomNumber(100000000, 999999999).ToString(),
                jobTitle = _details.data.jobTitle,
            };
        }

        //Object which is only meant to be used when generating a new user account
        private dynamic GenerateUserCreationObject(string email)
        {
            var Details = email.Split('@')[0];
            var UsernameDetails = Details.Split('-');

            var UserObject = (dynamic)new JsonObject();
            UserObject.tenantCode = Common.Common.IDMTenantCode;
            UserObject.firstname = UsernameDetails[0];
            UserObject.lastname = UsernameDetails[1];
            UserObject.suffix = "AUTO";
            UserObject.middleInitial = "A";
            UserObject.isLoginAllowedFlag = true;
            UserObject.expirationDate = $"{UserExpirationYear}-12-25T08:54:05.909Z";
            UserObject.email = email;
            UserObject.username = email;
            UserObject.isAccountClosed = false;
            UserObject.exemptBioId = false;
            UserObject.userBadgeId = Common.CommonUtilities.GenerateRandomNumber(1000, 99999).ToString();
            UserObject.userScanCode = Common.CommonUtilities.GenerateRandomNumber(10000, 999999).ToString();
            UserObject.rowaId = Common.CommonUtilities.GenerateRandomNumber(100000000, 999999999).ToString();
            UserObject.jobTitle = "AutoRole";
            UserObject.preferredLanguage = "en-us";
            return UserObject;
        }
    }
}

using CCESymp.API;
using CCESymp.Data.IDMMapping;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CCESymp.IDMServices.Services
{
    public partial class IDMAuthorizationService : TestBase
    {
        //public void WaitInterval() => System.Threading.Thread.Sleep(1000);
        private string AccessToken => IDMToken.GetAuthorizationServiceToken();

        /// <summary>
        /// Returns all the permissions available on IDM
        /// </summary>
        private async Task<PermissionDetails> GetAllPermissionsAsync()
        {
            HttpClient _httpClientFactory = new();
            PermissionDetails _permissionDetails = new();

            string BaseAddress = Path.Combine(Common.Common.IDMAuthServiceBaseURL, $"api/permissions/{Common.Common.IDMClientId}");
            _httpClientFactory.BaseAddress = new Uri(BaseAddress);
            _httpClientFactory.DefaultRequestHeaders.Add("Authorization", $"Bearer {AccessToken}");

            HttpResponseMessage Response = await _httpClientFactory.GetAsync(_httpClientFactory.BaseAddress);

            Logger.Info($"Awaiting data for POST request: {_httpClientFactory.BaseAddress}");
            Logger.Info($"Response received for POST request, Status Code: {Response.StatusCode}");

            var ResponseContent = await Response.Content.ReadAsStringAsync();

            if (Response.IsSuccessStatusCode)
                _permissionDetails  = JsonConvert.DeserializeObject<PermissionDetails>(ResponseContent);

            return _permissionDetails;
        }

        /// <summary>
        /// Returns all existing roles associated to tenant code and client id found in common file
        /// <summary>
        private async Task<RoleDetails> GetAllRolesAsync()
        {
            IDMToken.Scopes = string.Format("{0}.access {0}.manageroles {0}.config", Common.Common.IDMRoleScopesPreffix);
            HttpClient _httpClientFactory = new();
            RoleDetails _details = new();

            string BaseAddress = Path.Combine(Common.Common.IDMAuthServiceBaseURL, "api/roles");
            _httpClientFactory.BaseAddress = new Uri(BaseAddress);
            _httpClientFactory.DefaultRequestHeaders.Add("Authorization", $"Bearer {AccessToken}");
            _httpClientFactory.DefaultRequestHeaders.Add("tenantCode", Common.Common.IDMTenantCode);
            _httpClientFactory.DefaultRequestHeaders.Add("client_id", Common.Common.IDMClientId);

            HttpResponseMessage Response = await _httpClientFactory.GetAsync(_httpClientFactory.BaseAddress);

            Logger.Info($"Awaiting data for POST request: {_httpClientFactory.BaseAddress}");
            Logger.Info($"Response received for POST request, Status Code: {Response.StatusCode}");

            var ResponseContent = await Response.Content.ReadAsStringAsync();

            if (Response.IsSuccessStatusCode)
                _details = JsonConvert.DeserializeObject<RoleDetails>(ResponseContent);

            IDMToken.Scopes = string.Empty;
            return _details;
        }

        /// <summary>
        /// Returns a role id associated to the provided <paramref name="RoleName"/>
        /// <summary>
        private async Task<string> GetRoleIdByRoleName(string RoleName) {
            string RoleId = string.Empty;
            var Roles = await GetAllRolesAsync();
            foreach (var Role in Roles.data) {
                if (Role.name.Equals(RoleName)) { 
                    RoleId = Role.id;
                    break;
                }
            }
            return RoleId;
        }

        /// <summary>
        /// Returns all the role permissions associated to provided <paramref name="RoleName"/>
        /// <summary>
        private async Task<PermissionDetails> GetPermissionsAssociatedToRole(string RoleName)
        {
            string RoleId = await GetRoleIdByRoleName(RoleName);
            IDMToken.Scopes = string.Format("{0}.access {0}.manageroles {0}.config", Common.Common.IDMRoleScopesPreffix);
            HttpClient _httpClientFactory = new();
            PermissionDetails _details = new();
            
            string BaseAddress = Path.Combine(Common.Common.IDMAuthServiceBaseURL, $"api/roles/{RoleId}/permissions");
            _httpClientFactory.BaseAddress = new Uri(BaseAddress);
            _httpClientFactory.DefaultRequestHeaders.Add("Authorization", $"Bearer {AccessToken}");
            _httpClientFactory.DefaultRequestHeaders.Add("tenantCode", Common.Common.IDMTenantCode);
            _httpClientFactory.DefaultRequestHeaders.Add("client_id", Common.Common.IDMClientId);

            HttpResponseMessage Response = await _httpClientFactory.GetAsync(_httpClientFactory.BaseAddress);

            Logger.Info($"Awaiting data for POST request: {_httpClientFactory.BaseAddress}");
            Logger.Info($"Response received for POST request, Status Code: {Response.StatusCode}");

            var ResponseContent = await Response.Content.ReadAsStringAsync();

            if (Response.IsSuccessStatusCode)
                _details = JsonConvert.DeserializeObject<PermissionDetails>(ResponseContent);

            IDMToken.Scopes = string.Empty;
            return _details;
        }

        /// <summary>
        /// Returns all the role details associated to provided <paramref name="RoleName"/>
        /// <summary>
        private RoleDetails.DetailsData GetRoleDetailsByName(string RoleName) {
            var Details = new RoleDetails.DetailsData();
            var RolesTask = GetAllRolesAsync();
            RolesTask.Wait();
            var Roles = RolesTask.Result;
            var RolesList = Roles.data;
            Details = (from role in RolesList where role.name.Equals(RoleName) select role).First();
            return Details;
        }

        /// <summary>
        /// Returns the permission details associated to provided <paramref name="RoleName"/>
        /// <summary>
        private PermissionDetails.Datum GetPermissionDetailsByName(string RoleName)
        {
            var Details = new PermissionDetails.Datum();
            var PermissionsTask = GetAllPermissionsAsync();
            PermissionsTask.Wait();
            var Permissions = PermissionsTask.Result;
            var PermissionsList = Permissions.data;
            Details = (from Permission in PermissionsList where Permission.name.Equals(RoleName) select Permission).First();
            return Details;
        }

        /// <summary>
        /// Creates a new role based on the provided <paramref name="RoleName"/>
        /// No new role is created when provided <paramref name="RoleName"/> already exists
        /// <summary>
        private async Task<RoleDetails.DetailsData> CreateRoleAsync(string RoleName)
        {
            IDMToken.Scopes = string.Format("{0}.access {0}.manageroles {0}.config", Common.Common.IDMRoleScopesPreffix);
            HttpClient _httpClientFactory = new();

            CreateRoleMapper RoleBody = MapRoleDetails(RoleName);

            StringContent queryString = new(JsonConvert.SerializeObject(RoleBody), Encoding.UTF8, "application/json");

            string BaseAddress = Path.Combine(Common.Common.IDMAuthServiceBaseURL, "api/roles");
            _httpClientFactory.BaseAddress = new Uri(BaseAddress);
            _httpClientFactory.SetBearerToken(AccessToken);
            _httpClientFactory.DefaultRequestHeaders.Add("tenantCode", Common.Common.IDMTenantCode);
            _httpClientFactory.DefaultRequestHeaders.Add("client_id", Common.Common.IDMClientId);

            HttpResponseMessage Response = await _httpClientFactory.PostAsync(_httpClientFactory.BaseAddress, queryString);

            var ResponseContent = await Response.Content.ReadAsStringAsync();
            var RoleDetails = GetRoleDetailsByName(RoleName);

            IDMToken.Scopes = string.Empty;
            return RoleDetails;
        }

        /// <summary>
        /// Assigns a <paramref name="PermissionName"/> to an existing role
        /// No new permission is assigned to the provided <paramref name="RoleName"/> if the role posses the permission
        /// <summary>
        private async Task<UserExistence> AddPermissionsToRoleAsync(string RoleName, string PermissionName)
        {
            //WaitInterval();
            var MessageDetails = new UserExistence();
            string RoleId = GetRoleDetailsByName(RoleName).id;
            string PermissionId = GetPermissionDetailsByName(PermissionName).id;

            IDMToken.Scopes = string.Format("{0}.access {0}.manageroles {0}.config", Common.Common.IDMRoleScopesPreffix);
            HttpClient _httpClientFactory = new();

            string BaseAddress = Path.Combine(Common.Common.IDMAuthServiceBaseURL, $"api/roles/{RoleId}/permissions/{PermissionId}");
            _httpClientFactory.BaseAddress = new Uri(BaseAddress);
            SetAddPermissionsToRoleToken();
            _httpClientFactory.SetBearerToken(Common.Common.AddPermissionsToRoleToken);
            _httpClientFactory.DefaultRequestHeaders.Add("tenantCode", Common.Common.IDMTenantCode);
            _httpClientFactory.DefaultRequestHeaders.Add("client_id", Common.Common.IDMClientId);

            HttpResponseMessage Response = await _httpClientFactory.PostAsync(_httpClientFactory.BaseAddress, null);

            var ResponseContent = await Response.Content.ReadAsStringAsync();
            //Using user existence model as it contains the parameters needed to deserialize this response
            MessageDetails = JsonConvert.DeserializeObject<UserExistence>(ResponseContent);

            IDMToken.Scopes = string.Empty;
            return MessageDetails;
        }

        private void SetAddPermissionsToRoleToken()
        {
            if (string.IsNullOrEmpty(Common.Common.AddPermissionsToRoleToken))
                Common.Common.AddPermissionsToRoleToken = AccessToken;
        }

        /// <summary>
        /// Removes a <paramref name="PermissionName"/> to an existing <paramref name="RoleName"/>
        /// <summary>
        private async Task<UserExistence> RemovePermissionsFromRoleAsync(string RoleName, string PermissionName)
        {
            //WaitInterval();
            var MessageDetails = new UserExistence();
            string RoleId = GetRoleDetailsByName(RoleName).id;
            string PermissionId = GetPermissionDetailsByName(PermissionName).id;

            IDMToken.Scopes = string.Format("{0}.access {0}.manageroles {0}.config", Common.Common.IDMRoleScopesPreffix);
            HttpClient _httpClientFactory = new();

            string BaseAddress = Path.Combine(Common.Common.IDMAuthServiceBaseURL, $"api/roles/{RoleId}/permissions/{PermissionId}");
            _httpClientFactory.BaseAddress = new Uri(BaseAddress);
            SetRemoveRolePermissionsToken();
            _httpClientFactory.SetBearerToken(Common.Common.RemoveRolePermissionsTokens);
            _httpClientFactory.DefaultRequestHeaders.Add("tenantCode", Common.Common.IDMTenantCode);
            _httpClientFactory.DefaultRequestHeaders.Add("client_id", Common.Common.IDMClientId);

            HttpResponseMessage Response = await _httpClientFactory.DeleteAsync(_httpClientFactory.BaseAddress);

            var ResponseContent = await Response.Content.ReadAsStringAsync();
            //Using user existence model as it contains the parameters needed to deserialize this response
            MessageDetails = JsonConvert.DeserializeObject<UserExistence>(ResponseContent);

            IDMToken.Scopes = string.Empty;
            return MessageDetails;
        }

        private void SetRemoveRolePermissionsToken()
        {
            if (string.IsNullOrEmpty(Common.Common.RemoveRolePermissionsTokens))
                Common.Common.RemoveRolePermissionsTokens = AccessToken;
        }

        /// <summary>
        /// Assings a <paramref name="roleName"/> to an existing user <paramref name="email"/>
        /// <summary>
        private async Task<UserExistence> AddRoleToUserAsync(string email, string roleName)
        {
            //WaitInterval();
            var MessageDetails = new UserExistence();
            string RoleId = GetRoleDetailsByName(roleName).id;

            AssignRoleMapper RoleBody = MapRoleToUser(email, RoleId);
            StringContent queryString = new(JsonConvert.SerializeObject(RoleBody), Encoding.UTF8, "application/json");
            IDMToken.Scopes = string.Format("{0}.manageuserpermissions {0}.config {0}.access", Common.Common.IDMRoleScopesPreffix);
            HttpClient _httpClientFactory = new();

            string BaseAddress = Path.Combine(Common.Common.IDMAuthServiceBaseURL, "api/user-permissions");
            _httpClientFactory.BaseAddress = new Uri(BaseAddress);
            _httpClientFactory.SetBearerToken(AccessToken);
            _httpClientFactory.DefaultRequestHeaders.Add("tenantCode", Common.Common.IDMTenantCode);
            _httpClientFactory.DefaultRequestHeaders.Add("client_id", Common.Common.IDMClientId);

            HttpResponseMessage Response = await _httpClientFactory.PostAsync(_httpClientFactory.BaseAddress, queryString);

            var ResponseContent = await Response.Content.ReadAsStringAsync();
            //Using user existence model as it contains the parameters needed to deserialize this response
            MessageDetails = JsonConvert.DeserializeObject<UserExistence>(ResponseContent);

            IDMToken.Scopes = string.Empty;
            return MessageDetails;
        }

        private async Task RemoveAllPermissionsFromRole(string RoleName)
        {
            var CurrentRolePermissions = GetPermissionsAssociatedToRole(RoleName);

            foreach (var permission in CurrentRolePermissions.Result.data)
            {
                _ = await RemovePermissionsFromRoleAsync(RoleName, permission.name);
            }
        }

        private static CreateRoleMapper MapRoleDetails(string RoleName)
        {
            return new CreateRoleMapper()
            {
                name = RoleName,
                description = "AutoTestRole",
                active = true,
                permissions = new System.Collections.Generic.List<object>(),
            };
        }

        private static AssignRoleMapper MapRoleToUser(string email, string RoleId)
        {
            var _userService = new IDMUserService();
            var userDetails = _userService.GetUserDetailsByUsername(email);
            return new AssignRoleMapper()
            {
                userAccount = userDetails.data.parentKey,
                roleId = RoleId,
                facilities = new System.Collections.Generic.List<object>(),
            };
        }
    }
}

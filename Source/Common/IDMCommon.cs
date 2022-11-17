using Microsoft.Win32;
using System;
using System.Net;
using System.Net.Sockets;

namespace Common
{
    public partial class Common
    {
        //General static variable to determine if prerequired settings are already done
        public static bool AreHSCEUsersEnabled { get; set; }
        public static string IDMRunScript => GetEnvVar(@"IDMRunScript", @"No");
        //IDM API DETAILS
        public static string IDMTenantCode => GetEnvVar(@"IDMTenantCode", @"BD");
        public static string IDMClientId => GetEnvVar(@"IDMClientId", @"hsce-stg-ui");
        public static string IDMUserServiceBaseURL => GetEnvVar(@"IDMUserServiceBaseURL", @"https://coreuserapi-stg.bdx-cloud.com/");
        public static string IDMAuthServiceBaseURL => GetEnvVar(@"IDMAuthServiceBaseURL", @"https://coreapi-stg.bdx-cloud.com/");
        public static string IDMAccessTokenURL => GetEnvVar(@"IDMAccessTokenURL", @"https://core-stg.bdx-cloud.com/ids/connect/token");
        public static string IDMUserServiceClientId => GetEnvVar(@"IDMUserServiceClientId", @"idmuserapi");
        public static string IDMUserScopesPreffix => GetEnvVar(@"IDMUserScopesPreffix", @"idmuserapi");
        public static string IDMAuthServiceClientId => GetEnvVar(@"IDMAuthServiceClientId", @"idmauthzapi");
        public static string IDMRoleScopesPreffix => GetEnvVar(@"IDMRoleScopesPreffix", @"idmauthz");
        public static string IDMReferranceName => GetEnvVar(@"IDMReferranceName", "UserValidation");
        public static string IDMAuthServiceClientSecret => GetEnvVar(@"IDMAuthServiceClientSecret", "secret");
        public static string IDMUserServiceScopes => GetEnvVar(@"IDMUserServiceScopes", string.Format("{0}.access {0}.managepassword {0}.manageusers {0}.rowa", IDMUserScopesPreffix));
        public static string IDMAuthServiceScopes => GetEnvVar(@"IDMAuthServiceScopes", string.Format("{0}.access {0}.managepermissions {0}.config", IDMRoleScopesPreffix));

        //IDM User Details
        public static string HSCEAutoAdminUser => GetEnvVar(@"AutoAdminUser", "dashboardauto-adminuser@hsce.com");
        public static string HSCEAutoViewerUser => GetEnvVar(@"HSCEAutoViewerUser", "dashboardauto-vieweruser@hsce.com");
        public static string HSCENoBUUser => GetEnvVar(@"HSCENoBUUser", "dashboardauto-nobuuser@hsce.com");
        public static string HSCEUser => GetEnvVar(@"HSCEUser", "dashboardauto-hsceuser@hsce.com");
        public static string HSCEAddViewOnlyUser => GetEnvVar(@"HSCEAddViewOnlyUser", "dashboardauto-addviewonlyuser@hsce.com");
        public static string HSCENoPermissionsUser => GetEnvVar(@"HSCENoPermissionsUser", "dashboardauto-nonpermissionsuser@hsce.com");
        public static string HSCEAutomationPassword => GetEnvVar(@"HSCEAutomationPassword", "Carefusion@123!");
        
        //IDM Token variables
        public static string RemoveRolePermissionsTokens { get; set; }
        public static string AddPermissionsToRoleToken { get; set; }
        public static string UserCreationToken { get; set; }
    }
}

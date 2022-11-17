using Microsoft.Win32;
using System;
using System.Net;
using System.Net.Sockets;

namespace Common
{
    public partial class Common
    {
        //MedBank IMS - Sending messages
        public static string TakeMBMValues = GetEnvVar(@"TakeMBMValues", "false");
        public static string APIUser = GetEnvVar(@"APIUser", "rjt0SI7aV7qsQC5L@z#u@b1Qf-tA=kNsb?&gt;8QZlv[l-qLaYE8Qo[#ohQ$aO68SEU9Y_=7^V-v][Zb(0WzRfB(/UoiU+@IeR0725E^(Xaew;wQ7-2y^fDL#0Z|hkDEOlS");
        public static string CustomerId = GetEnvVar(@"CustomerId", @"14cd6af3-3196-4864-b9de-93c4e2ea5055");
        public static string SolutionId = GetEnvVar(@"SolutionId", @"f9bce0b1-6f35-4b18-995f-f22f4df2ac2e");
        public static string EncodedAPIPassword = GetEnvVar(@"EncodedAPIPassword", "+0v5@^=p_9%d|E@-^Ld2(+E;Cps=*/!Q[]/VP3CK-uU|4B@Rz&gt;E)h&amp;q%}dsjN$IQS%G%|[2C_j&gt;Xti^_Y_&amp;{Q@$t){&amp;Gj%-_(Y$w?(AQA-F[w&amp;o1(($@^a-9N%)J%New");
        public static string RelayReceiverEndpointURL = GetEnvVar(@"RelayReceiverEndpointURL", "https://hsce-relayreceiver-stg.bdx-cloud.com/");
        public static string FacilityCode => GetEnvVar(@"FacilityCode", "CCESQETest_LC");
        public static string MedBankIMS_SolutionName = GetEnvVar(@"MedBankIMS_SolutionName", @"CCESQETest_LC");
        public static string ListConfiguration_SolutionName = GetEnvVar(@"ListConfiguration_SolutionName", @"1_demo_typre"); 


        //MBIMS-EC
        //CCE Symphony Pages
        public static string ApplicationName = GetEnvVar(@"ApplicationName", @"HealthSight Connectivity Engine");
        public static string CCESympPage_Home = GetEnvVar(@"CCESympPage_Home", @"Home");
        public static string CCESympPage_Customer = GetEnvVar(@"CCESympPage_Customer", @"Customer");
        public static string CCESympPage_Admin = GetEnvVar(@"CCESympPage_Admin", @"Administration");
        //RSS API DETAILS
        public static string RSSUrl => GetEnvVar(@"RssUrl", @"https://rss-staging.carefusion.com/");
        public static string RSSKeyName => GetEnvVar(@"RSSKeyName", @"X-Atlas-SecurityKey");
        public static string RSSKeyValue => GetEnvVar(@"RSSKeyValue", @"75162FD1-A4E8-40AB-A62A-823932CEAD1F");
        //public static string RSSUrl => GetEnvVar(@"RssUrl", @"https://rss.carefusion.com/");
        //public static string RSSKeyName => GetEnvVar(@"RSSKeyName", @"X-Atlas-SecurityKey");
        //public static string RSSKeyValue => GetEnvVar(@"RSSKeyValue", @"6C6AD4BF-13A8-46BE-B226-FC61D73FE9CB");


        public static string CCESymp_DashboardUI_Url = GetEnvVar(@"CCESymp_DashboardUI_Url", @"https://hsce-dashboard-tst.bdx-cloud.com/");        
        public static string CCESymp_DashboardAPI_Url = GetEnvVar(@"CCESymp_DashboardAPI_Url", @"https://hsce-dashboard-api-tst.bdx-cloud.com/");
        /*Temp Environments*/

        //Test Usernames
        public static string CCESymp_CustomerAdmin_Name = GetEnvVar(@"CCESymp_CustomerAdmin_Name", @"Automation User");
        public static string CCESymp_CCEUser_Name = GetEnvVar(@"CCESymp_CCEUser_Name", @"Automation User");


        public static string CCESympNonPermissionsUser => HSCENoPermissionsUser/*GetEnvVar(@"CCESympNonPermissionsUser", @"Smajali@integrant.com")*/;
        public static string CCESympNonPermissionsUser_PW => HSCEAutomationPassword/*GetEnvVar(@"CCESympNonPermissionsUser_PW", @"Carefusion@1")*/;


        public static string CCESympCCEUser1 => HSCEUser/*GetEnvVar(@"CCESympCCEUser1", @"cceuser1@mailinator.com")*/;
        public static string HSCE_Login_PW_User => HSCEAutomationPassword/*GetEnvVar(@"HSCE_Login_PW_User", @"Carefusion@1")*/;


        public static string CCESympCustomerAdmin1 => HSCEAutoAdminUser/* GetEnvVar(@"CCESympCustomerAdmin1", @"erick.chi@nearshoretechnology.com");*/;
        public static string CCESympNoDeletePermissionUser => HSCEAddViewOnlyUser/*GetEnvVar(@"CCESympNoDeletePermissionUser", @"Ahanafy@integrant.com")*/;
        //with BU permissions, but no permissions to edit/delete solutions
        public static string CCESympViewerUser => HSCEAddViewOnlyUser/*GetEnvVar(@"CCESympViewerUser", @"Ahanafy@integrant.com")*/;
        public static string CCESympNoEditPermissionUser => HSCEAddViewOnlyUser/*GetEnvVar(@"CCESympNoEditPermissionUser", @"Ahanafy@integrant.com")*/;
        public static string CCESympNoPublishPermissionUser => HSCEAddViewOnlyUser/*GetEnvVar(@"CCESympNoPublishPermissionUser", @"Ahanafy@integrant.com")*/;
        public static string CCESymp_Login_PW => HSCEAutomationPassword;/*GetEnvVar(@"CCESymp_Login_PW", @"Carefusion@1");*/

        public static string HSCE_NoAddingPermissionUser => HSCEAutoViewerUser/* GetEnvVar(@"HSCE_NoAddingPermissionUser", @"amrhanfi@gmail.com")*/;
        public static string HSCE_NoAddingPermissionUser_PW => HSCEAutomationPassword/*GetEnvVar(@"HSCE_NoAddingPermissionUser_PW", @"Carefusion@1")*/;


        public static string HSCE_UserWithNoBUPermission => HSCENoBUUser/*GetEnvVar(@"HSCE_UserWithNoBUPermission", @"amrhanfi@outlook.com")*/;
        public static string HSCE_UserWithNoBUPermission_PW => HSCEAutomationPassword/*GetEnvVar(@"HHSCE_UserWithNoBUPermission_PW", @"Carefusion@1")*/;


        public static string LocalIP4 = GetLocalIP(IP4Family);
        public static string LocalIP6 = GetLocalIP(IP6Family);

        //public static string CCESymp_SQLServer_Dashboard = GetEnvVar(@"CCESymp_SQLServer_Dashboard", @"cce-tst-usw-sql.database.windows.net");
        //public static string CCESymp_SQLDB_Dashboard = GetEnvVar(@"CCESymp_SQLDB_Dashboard", @"cce-tst-usw-dashboard-db");
        //public static string CCESymp_SQL_UName = GetEnvVar(@"CCESymp_SQL_UName", @"ccesqladmin");
        //public static string CCESymp_SQL_PW = GetEnvVar(@"CCESymp_SQL_PW", @"Temp1234!");

        /*Temp DB Connection*/
        public static string CCESymp_SQLServer_Dashboard = GetEnvVar(@"CCESymp_SQLServer_Dashboard", @"hsce-tst-usw-sql.database.windows.net");
        public static string CCESymp_SQLDB_Dashboard = GetEnvVar(@"CCESymp_SQLDB_Dashboard", @"hsce-dashboard-db");
        public static string CCESymp_SQL_UName = GetEnvVar(@"CCESymp_SQL_UName", @"hsce_sqe_user");
        public static string CCESymp_SQL_PW = GetEnvVar(@"CCESymp_SQL_PW", @"jtcutl@28c*c32");

        public static string browsersToRunWith = GetEnvVar(@"browsersToRunWith", @"Chrome");
        public static string waitBeforeDeleteSessions = GetEnvVar(@"waitBeforeDeleteSessions", @"Wait");
        public static string AdminAPIAccessToken = GetEnvVar(@"AdminAPIAccessToken", @"asdfg");
        public static string UserAPIAccessToken = GetEnvVar(@"UserAPIAccessToken", @"asdfg");
        public static string UserTypeToken = GetEnvVar(@"UserTypeToken", @"Admin");

        public static string SendToHostAction = "Send to Host";
    }
}

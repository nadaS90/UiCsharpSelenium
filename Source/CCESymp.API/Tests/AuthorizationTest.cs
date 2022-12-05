using CCESymp.Data.Mapping;
using CCESymp.IDMServices.Services;
using NUnit.Framework;
using RestSharp.Serialization.Json;

namespace CCESymp.API.Tests
{
    [TestFixture]
    public class AuthorizationTest : TestBase
    {
      
        [Test, Category("HomePage")]
        [Description("Test Case 1214353: US1198508 - API - GetLoggedInUserDetails")]
        public void GetLoggedInUserDetails()
        {
            Logger.Info("EXECUTING: Test Case 1214353: US1198508 - API - GetLoggedInUserDetails");
            Common.Common.UserTypeToken = Common.Common.GetEnvVar(@"UserTypeToken", @"Admin");
            var RequestBuilder = new RequestBuilder(_webDriver);
            var response = RequestBuilder.GetResponse("api/Auth/User", RestSharp.Method.GET);
            //Verify Status Code
            string Expectedcode = response.StatusCode.ToString();
            Logger.Info($"VALIDATION: Return status code {Expectedcode}");
            Assert.AreEqual(Expectedcode, "OK", "Response code is " + response.StatusCode, $"VALIDATION ERROR: Status code is not {Expectedcode}");
            Logger.Info($"VALIDATION SUCCESS: Return status code is {Expectedcode}");

            //API Result
            var deserialize = new JsonDeserializer();
            var apiResult = deserialize.Deserialize<GetLoggedInUserModel>(response);

            Logger.Info("VALIDATION: Endpoint returns the logged in User details");
            Assert.AreEqual(apiResult.email, Common.Common.HSCEAutoAdminUser, "Response does not include user details");
            Logger.Info("VALIDATION SUCCESS: Endpoint return the logged in User details");
        }

        [Test, Category("HomePage")]
        [Description("Test Case 1238152: US1204525 - API - Get Dashboard Version")]
        public void GetDashboardVersion()
        {
            Logger.Info("EXECUTING: Test Case 1238152: US1204525 - API - Get Dashboard Version");
            Common.Common.UserTypeToken = Common.Common.GetEnvVar(@"UserTypeToken", @"Admin");
            var RequestBuilder = new RequestBuilder(_webDriver);
            var response = RequestBuilder.GetResponse("api/Auth/applicationversion", RestSharp.Method.GET);
            //Verify Status Code
            string Expectedcode = response.StatusCode.ToString();
            Logger.Info($"VALIDATION: Return status code {Expectedcode}");
            Assert.AreEqual("OK", Expectedcode, "Response code is " + response.StatusCode);
            Logger.Info($"VALIDATION SUCCESS: Return status code is {Expectedcode}");

            //API Result
            var deserialize = new JsonDeserializer();
            var apiResult = deserialize.Deserialize<string>(response);

            Logger.Info("VALIDATION: Endpoint should return CCE Symphony Dashboard version");
            Assert.IsTrue(!string.IsNullOrEmpty(apiResult), "API endpoint does not provide the CCE Symphony Dashboard version");
            Logger.Info("VALIDATION SUCCESS: Endpoint return CCE Symphony Dashboard version");
        }



        [Test, Category("HomePage")]
        [Description("Test Case 1250597: US1198508 - API - Check User Has Permissions")]
        public void CheckUserHasPermissions()
        {
            Logger.Info("EXECUTING: Test Case 1250597: US1198508 - API - Check User Has Permissions");
            Common.Common.UserTypeToken = Common.Common.GetEnvVar(@"UserTypeToken", @"Admin");
            var RequestBuilder = new RequestBuilder(_webDriver);
            var response = RequestBuilder.GetResponse("api/auth/hasPermission?permission=0", RestSharp.Method.GET);
            //Verify Status Code
            string Expectedcode = response.StatusCode.ToString();
            Logger.Info($"VALIDATION: Return status code {Expectedcode}");
            Assert.AreEqual("OK", Expectedcode, "Response code is " + response.StatusCode, $"VALIDATION ERROR: Status code is not {Expectedcode}");
            Logger.Info($"VALIDATION SUCCESS: Return status code is {Expectedcode}");

            //API Result
            var deserialize = new JsonDeserializer();
            var apiResult = deserialize.Deserialize<bool>(response);

            Logger.Info("VALIDATION: Endpoint should return the response true");
            Assert.IsTrue(apiResult, "Response is not true");
            Logger.Info("VALIDATION SUCCESS: Endpoint return the response true");
        }

        //[Test, Category("HomePage")]
        //[Description("Test Case 1238160: US1197114 - API - Get User Login History")]
        //public void GetUserLoginHistory()
        //{
        //    Logger.Info("EXECUTING: Test Case 1238160: US1197114 - API - Get User Login History");
        //    Common.Common.UserTypeToken = Common.Common.GetEnvVar(@"UserTypeToken", @"Admin");
        //    var RequestBuilder = new RequestBuilder(_webDriver);
        //    var response = RequestBuilder.GetResponse("api/Auth/userLoginHistory", RestSharp.Method.GET);
        //    //Verify Status Code
        //    string Expectedcode = response.StatusCode.ToString();
        //    Logger.Info($"VALIDATION: Status code should be {Expectedcode}");
        //    Assert.AreEqual(Expectedcode, "OK", "Response code is " + response.StatusCode);
        //    Logger.Info($"VALIDATION SUCCESS: Status code is {Expectedcode}");

        //    //API Result
        //    var deserialize = new JsonDeserializer();
        //    var apiResult = deserialize.Deserialize<LoginAttemptHistoryResponse>(response);

        //    Logger.Info("VALIDATION: Endpoint should provide the login history information");
        //    validateOutput.ValidateLoginHistoryData(apiResult);
        //}
    }
}

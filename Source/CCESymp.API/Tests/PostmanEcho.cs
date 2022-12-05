using NUnit.Framework;
using RestSharp.Serialization.Json;
using CCESymp.Data.Mapping;
using CCESymp.IDMServices.Services;
using NUnit.Framework;
using RestSharp.Serialization.Json;
using CCESymp.Data.Mapping.IMSMapping;

namespace CCESymp.API.Tests
{
    [TestFixture]
    public class PostmanEcho : TestBase
    {
        [Test, Category("Postman-Echo")]
        [Description("Test Case 1214353: US1198508 - API - GetDataFromPostmanEcho")]
        public void GetDataFromPostmanEcho()
        {
            Logger.Info("EXECUTING: Test Case 1214353: US1198508 - API - GetDataFromPostmanEcho");
            var RequestBuilder = new RequestBuilder(_webDriver);
            var response = RequestBuilder.GetResponse("get", RestSharp.Method.GET);
            //Verify Status Code
            string Expectedcode = response.StatusCode.ToString();
            Logger.Info($"VALIDATION: Return status code {Expectedcode}");
            Assert.AreEqual(Expectedcode, "OK", "Response code is " + response.StatusCode, $"VALIDATION ERROR: Status code is not {Expectedcode}");
            Logger.Info($"VALIDATION SUCCESS: Return status code is {Expectedcode}");

            //API Result
            var deserialize = new JsonDeserializer();
            var apiResult = deserialize.Deserialize<GetPostmanEchoResponse>(response);

            Logger.Info("VALIDATION: Endpoint returns postman echo details");
            Assert.AreEqual(apiResult.url, $"{Common.Common.CCESymp_Postman_Echo_Url}/get", "Response does not include url");
            Logger.Info("VALIDATION SUCCESS: Endpoint return postman echo details");
        }

    }
}

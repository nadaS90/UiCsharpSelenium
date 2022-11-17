using BD.Automation.Core.Drivers.Interface;
using CCESymp.Data.Mapping;
using CCESymp.API;
using RestSharp.Serialization.Json;
using System.Collections.Generic;

namespace CCESymp.UI.Utilities
{
    public class EndpointCallsUtility : BaseDriver
    {       

        public List<FacilityModel> GetFacilityContactsOfACustomer(string CustomerRSSID)
        {
            TestBase APITest = new TestBase();
            Logger.Info("START OR TOKEN GENERATION FOR API CALL...");
            APITest.GenerateTokens();
            Logger.Info("FINISHED TOKEN GENERATION");

            List<FacilityModel> FacilityContactList;
            var RequestBuilder = new RequestBuilder(driver);
            var response = RequestBuilder.GetResponse($"api/customer/{CustomerRSSID}/contacts", RestSharp.Method.GET);

            var Deserializer = new JsonDeserializer();
            var FacilityContactResponse = Deserializer.Deserialize<FacilityContactResponse>(response);

            string Code = FacilityContactResponse.Code.ToString();
            string Message = FacilityContactResponse.Message.ToString();

            if (Code.Equals("204") && Message.Equals("No Data founds"))
            {
                Logger.Info("No Facility Contacts found");
                FacilityContactList = null;
            }
            else
            {
                FacilityContactList = FacilityContactResponse.Response;
            }

            return FacilityContactList;
        }
    }
}

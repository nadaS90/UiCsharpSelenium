using BD.Automation.Core.Drivers.Interface;
using CCESymp.API.Requests;
using CCESymp.Data.Mapping;
using FluentAssertions;
using RestSharp;
using System.Net;

namespace CCESymp.API.Utilities
{
    public class PetsRequestBuilder 
    {

        private static RestClient client;
        private static RestClient Client
        {
            get
            {
                if (client == null)
                {
                    client = new RestClient(ConfigProvider.CurrentEnviroment.Url);
                }
                return client;
            }
        }

        public static RestResponse GetPetById(long petId, HttpStatusCode httpStatusCode = HttpStatusCode.OK)
        {
            var request = PetsEndPoints.GetByPetId.AddUrlSegment("petId", petId);

            var response = Client.ExecuteWithLogs(request);
            response.StatusCode.Equals(httpStatusCode);
            return (RestResponse)response;
        }

        public static RestResponse CreatePet(PetDto petDetails, HttpStatusCode httpStatusCode = HttpStatusCode.OK)
        {
            var request = PetsEndPoints.CreatePet.AddJsonBody(petDetails);

            var response = Client.Execute(request);
            response.StatusCode.Equals(httpStatusCode);
            return (RestResponse)response;
        }

        public static RestResponse CreatePet(PetObject petObject, HttpStatusCode httpStatusCode = HttpStatusCode.OK)
        {
            var request = PetsEndPoints.CreatePet;
            request.AddJsonBody(petObject);
            var response = Client.ExecuteWithLogs(request);
            response.StatusCode.Equals(httpStatusCode);
            return (RestResponse)response;
        }

        public static RestResponse UpdatePet(PetDto petDto, HttpStatusCode httpStatusCode = HttpStatusCode.OK)
        {
            var request = PetsEndPoints.CreatePet.AddJsonBody(petDto);

            var response = Client.ExecuteWithLogs(request);
            response.StatusCode.Should().Be(httpStatusCode);
            return (RestResponse)response;
        }

        public static RestResponse UpdatePet(PetObject petObject, HttpStatusCode httpStatusCode = HttpStatusCode.OK)
        {
            var request = PetsEndPoints.UpdatePet.AddJsonBody(petObject);

            var response = Client.ExecuteWithLogs(request);
            response.StatusCode.Equals(httpStatusCode);
            return (RestResponse)response;
        }

        public static RestResponse DeletePet(long petId, HttpStatusCode httpStatusCode = HttpStatusCode.OK)
        {
            var request = PetsEndPoints.DeletePet.AddUrlSegment("petId", petId);

            var response = Client.ExecuteWithLogs(request);
            response.StatusCode.Equals(httpStatusCode);
            return (RestResponse)response;
        }
    }

}


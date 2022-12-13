using CCESymp.Data.Mapping;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCESymp.API.Requests
{
    public class PetsEndPoints
    {
        public static RestRequest GetByPetId => new RestRequest(ConfigProvider.CurrentEnviroment.Url + "/pet/{petId}", Method.GET);
        public static RestRequest CreatePet => new RestRequest(ConfigProvider.CurrentEnviroment.Url + "/pet", Method.POST);
        public static RestRequest UpdatePet => new RestRequest(ConfigProvider.CurrentEnviroment.Url + "/pet", Method.PUT);
        public static RestRequest DeletePet => new RestRequest(ConfigProvider.CurrentEnviroment.Url + "/pet/{petId}", Method.DELETE);

    }
}

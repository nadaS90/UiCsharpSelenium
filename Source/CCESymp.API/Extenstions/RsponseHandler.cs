using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCESymp.API.Utilities
{
    public static class RsponseHandler
    {
        public static T Deserialize<T>(this RestResponse response)
        {
            return JsonConvert.DeserializeObject<T>(response.Content);
        }
    }
}

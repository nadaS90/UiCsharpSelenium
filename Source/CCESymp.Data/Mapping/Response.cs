using Newtonsoft.Json;
using System.Collections.Generic;

namespace CCESymp.Data.Mapping
{
    public class Response<T> where T : class
    {
        public Response() => Value = new ();

        [JsonProperty("odata.metadata")]
        public string OdataMetadata { get; set; }
        [JsonProperty("value")]
        public List<T> Value { get; set; }
    }
}
using System.Collections.Generic;

namespace CCESymp.Data.Mapping
{
    public class FacilityContactResponse
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public List<FacilityModel> Response { get; set; }
    }
}

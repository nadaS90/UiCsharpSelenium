
using System.Collections.Generic;

namespace CCESymp.Data.Mapping
{
    public class CustomerListResponse
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public string Total { get; set; }
        public List<CustomerSearch> Response { get; set; }
    }
}

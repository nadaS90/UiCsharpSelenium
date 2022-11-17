namespace CCESymp.Data.Mapping
{
    public class CustomerSearch : Entity
    {
        public string CustomerName { get; set; }
        public string CustomerId { get; set; }
        public string CustomerState { get; set; }
        public string FacilityName { get; set; }
        public string FacilityId { get; set; }
        public string FacilityState { get; set; }
        public string ChangeEventSource { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
       
    }
   
}

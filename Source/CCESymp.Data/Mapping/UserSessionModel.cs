namespace CCESymp.Data.Mapping
{
    public class UserSessionModel
    {
        public object ID { get; set; }
        public string UserId { get; set; }
        public string IP_Address { get; set; }
        public string Start_DateTime { get; set; }
        public string End_DateTime { get; set; }
    }
}

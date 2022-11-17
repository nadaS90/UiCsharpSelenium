namespace CCESymp.Data.Mapping
{
    public class GlobalConnectionModel : Entity
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string Value { get; set; }
        public string Ip { get; set; }
        public string Port { get; set; }

    }
}
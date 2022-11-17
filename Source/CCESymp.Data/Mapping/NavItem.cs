using System.Collections.Generic;
namespace CCESymp.Data.Mapping
{
    public class NavItem
    {
        public string Name { get; set; }
        public string RouterLink { get; set; }
        public List<NavItem> SubNavItems { get; set; }
    }
}

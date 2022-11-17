using System.Collections.Generic;

namespace CCESymp.Data.Mapping
{
    public class NavMenu
    {
        public string ApplicationName { get; set; }
        public string UserName { get; set; }
        public List<NavItem> NavItems { get; set; }
    }
}

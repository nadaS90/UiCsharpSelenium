using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCESymp.Data.Mapping
{
    public class Configuration : Entity
    {
        public string modifiedBy { get; set; }
        public string modifiedByNavigation { get; set; }
        public string modifiedDateTime { get; set; }
        public string Name { get; set; }
        public string template { get; set; }
        public string version { get; set; }

    }
}

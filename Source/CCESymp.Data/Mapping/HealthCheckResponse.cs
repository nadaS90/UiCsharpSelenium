using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCESymp.Data.Mapping
{
   public  class HealthCheckResponse
    {
        public string OverallStatus { get; set; }
        public string TotalCheckDuration { get; set; }
        public DependencyHealthChecks DependencyHealthChecks { get; set; }
    }
}

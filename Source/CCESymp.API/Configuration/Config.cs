using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCESymp.Data.Mapping
{
    public class Config
    {
        public string DefaultEnviroment { get; set; }
        public Dictionary<string, PetStoreEnviroment> Enviroments { get; set; }
    }

    public class PetStoreEnviroment
    {
        public string Url { get; set; }
        public Dictionary<string, string> Endpoints { get; set; }

    }


}


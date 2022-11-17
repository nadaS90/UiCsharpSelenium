using System;
using System.Collections.Generic;

namespace CCESymp.Data.IDMMapping
{
    public class CreateRoleMapper
    {
        public string name { get; set; }
        public string description { get; set; }
        public bool active { get; set; }
        public List<object> permissions { get; set; }
    }   
}

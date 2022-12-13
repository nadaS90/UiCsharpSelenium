using CCESymp.Data.Mapping;
using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace CCESymp.API.Utilities
{
    public class PetDto
    {
        // Set Id of pet
        public Int64? Id { get; set; }
        // Create Object for pet category informations
        public PetCategoryDto Category { get; set; }
        // Set Pet name
        public string Name { get; set; }
        // List of tag objects
        public IList<PetTag> Tags { get; set; }
        // Status of pet
        public string Status { get; set; }
    }

  

}

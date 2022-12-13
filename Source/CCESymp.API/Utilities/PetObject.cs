using CCESymp.Data.Mapping;
using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.IO;
using MongoDB.Bson;
using RestSharp.Serialization.Json;

namespace CCESymp.API.Utilities
{
    public class PetObject
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

        public PetObject()
        {
            var defaultPet = TestDataReader.Read<PetDto>("DefaultPet");
            Id = defaultPet.Id;
            Category = defaultPet.Category;
            Name = defaultPet.Name;
            Tags = defaultPet.Tags;
            Status = defaultPet.Status;

        }
        public PetObject GetDeafult()
        {
            var defaultPet = TestDataReader.Read<PetDto>("DefaultPet");
            Id = defaultPet.Id;
            Category = defaultPet.Category;
            Name = defaultPet.Name;
            Tags = defaultPet.Tags;
            Status = defaultPet.Status;
            return this;
        }
        public PetObject SetPetData(string name, string status = "active")
        {
            Name = name;
            Status = status;
            return this;
        }

        public PetObject SetCategory(string name, int? id = null)
        {
            Category.Name = name;
            Category.Id = id;
            return this;
        }

        public PetObject AddTag(string name, int? id = null)
        {
            Tags.Add(new PetTag
            {
                Name = name,
                Id = id
            });
            return this;
        }


        public PetObject Create(int? id = null, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            Id = id;
            var response = PetsRequestBuilder.CreatePet(this, statusCode).Deserialize<PetDto>();
            Id = response.Id;
            return this;
        }

        public PetObject Get(HttpStatusCode statusCode = HttpStatusCode.OK, string errorMessage = null)
        {
           var response = PetsRequestBuilder.GetPetById(Id.GetValueOrDefault(), statusCode).Deserialize<PetResponseDto>();

            if (statusCode != HttpStatusCode.OK)
            {
                response.Message.Equals(errorMessage);
            }
            return this;
        }

        public PetObject Update(HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            var response = PetsRequestBuilder.UpdatePet(this, statusCode).Deserialize<PetDto>();
            Id = response.Id;
            return this;
        }

        public PetObject Delete(HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            PetsRequestBuilder.DeletePet(Id.GetValueOrDefault(), statusCode);
            return this;
        }
    }
}

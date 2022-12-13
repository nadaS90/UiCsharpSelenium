using CCESymp.API.Utilities;
using NUnit.Framework;
using CCESymp.API.TestData;
using RestSharp.Serialization.Json;
using System;
using System.IO;
using FluentAssertions;
using System.Net;

namespace CCESymp.API.Tests
{
    [TestFixture]

    public class PetsTest : TestBase
    {
        PetObject pet = new PetObject();

        [Test, Category("Pet Store")]
        [Description("Test Case 1214353: US1198508 - API - Createapet")]
        public void Createapet()
        {
            Logger.Info("EXECUTING: Test Case 1214353: US1198508 - API - Createapet");
            pet.SetPetData(Constants.petName);
            pet.SetCategory(Constants.petCategory, 1);
            pet.Create();

            Logger.Info($"VALIDATION: Validate if that pet created");
            var createdPet = PetsRequestBuilder.GetPetById(pet.Id.GetValueOrDefault()).Deserialize<PetObject>();
            createdPet.Name.Equals(pet.Name);
            createdPet.Id.Equals(pet.Id.GetValueOrDefault());
            Logger.Info($"VALIDATION SUCCESS: pet created successfully ");
        }


        [Test, Category("Pet Store")]
        [Description("Test Case 1214353: US1198508 - API - Createapet")]
        public void Updatepet()
        {

            Logger.Info("EXECUTING: Test Case 1214353: US1198508 - API - Updatepet");
            pet.SetPetData(Constants.petUpdatedName, Constants.petUpdateState);
            pet.AddTag(Constants.petUpdatedTag, 1);
            pet.Update();

            Logger.Info($"VALIDATION: Validate that pet updated");
            var updatedPet = PetsRequestBuilder.GetPetById(pet.Id.GetValueOrDefault()).Deserialize<PetObject>();
            updatedPet.Name.Equals(pet.Name);
            updatedPet.Tags.Equals(pet.Tags);
            Logger.Info($"VALIDATION SUCCESS: pet updated successfully ");
        }


        [Test, Category("Pet Store")]
        [Description("Test Case 1214353: US1198508 - API - GetPetWithOutProvidingId")]
        public void GetPetWithOutProvidingId()
        {

            Logger.Info("EXECUTING: Test Case 1214353: US1198508 - API - GetPetWithOutProvidingId");
            pet.Id = null;

            Logger.Info($"VALIDATION: Validate that user can't Get Pet WithOut Providing Id");
            pet.Get(HttpStatusCode.NotFound, "Pet not found");
            Logger.Info($"VALIDATION SUCCESS: user can't Get Pet WithOut Providing Id");
        }


        [Test, Category("Pet Store")]
        [Description("Test Case 1214353: US1198508 - API - DeletePet")]
        public void DeletePet()
        {

            Logger.Info("EXECUTING: Test Case 1214353: US1198508 - API - DeletePet");
            pet.Delete();
           
            Logger.Info($"VALIDATION: Validate that user can delete pet");
            pet.Get(HttpStatusCode.NotFound, "Pet not found");
            Logger.Info($"VALIDATION SUCCESS: pet deleted successfully");
        }
    }
}

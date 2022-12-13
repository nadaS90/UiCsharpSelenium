using Newtonsoft.Json;
using System;
using FluentAssertions;
using System.Collections.Generic;
using System.IO;

using static System.Net.WebRequestMethods;
using File = System.IO.File;

namespace CCESymp.API
{
    public static class TestDataReader
    {
        public static Dictionary<string, string> DynamicVariables = new Dictionary<string, string>();

        // Method for getting files from TestData directory
        public static string GetFile(string fileName, string extentsion = "json")
        {
            var testDataPath = Path.Combine(Directory.GetCurrentDirectory(), "TestDataReader");
            System.Console.WriteLine(Directory.GetCurrentDirectory());
            var searchFile = Directory.GetFiles(testDataPath, $"{fileName}.{extentsion}", SearchOption.AllDirectories);

            searchFile.Should().HaveCount(1);

            return searchFile[0];
        }

        // Method for reading json files
        public static T Read<T>(string fileName)
        {
           var replacedFileContent = ReplaceVariables(File.ReadAllText(GetFile(fileName)));

           // string replacedFileContent = ReplaceVariables(File.ReadAllText(@"D:\UiCsharpSeleniumInitiative\Source\CCESymp.API\TestData\DefaultPet.json"));
            return JsonConvert.DeserializeObject<T>(replacedFileContent);
        }


        private static string ReplaceVariables(string fileContent)
        {
            var variablesToReplace = new Dictionary<string, string>
            {
                {"{{username}}", Faker.Internet.UserName() + Faker.Name.First() },
                {"{{lastname}}", Faker.Name.Last() },
                {"{{email}}", Faker.Internet.Email() },
                {"{{phone}}", Faker.Phone.Number() }
            };

            foreach (var variable in variablesToReplace)
            {
                fileContent = fileContent.Replace(variable.Key, variable.Value);
            }

            foreach (var dynamicVariable in DynamicVariables)
            {
                fileContent = fileContent.Replace(dynamicVariable.Key, dynamicVariable.Value);
            }

            return fileContent;
        }

        //// Method for replacing variables placed in json default files
        //public static string ReplaceVariables()
        //{
           
        //}

    }
}

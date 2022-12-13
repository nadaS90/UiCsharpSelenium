using System;
using Newtonsoft.Json;
using System;
using FluentAssertions;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace CCESymp.Data.Mapping
{
    public class ConfigProvider
    {
        public static Config Config { get; set; }
        public static string CurrentEnviromentName { get; set; }
        public static PetStoreEnviroment CurrentEnviroment { get; set; }


        public static void LoadConfiguration()
        {
           // var configFile = File.ReadAllText(@"D:\UiCsharpSeleniumInitiative\Source\Config.json");

            var config = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile("Config.json").Build();
            Config = config.Get<Config>();

            SetCurrentEnviroment();
        }

        public static void SetCurrentEnviroment()
        {
            var enviroment = Environment.GetEnvironmentVariable("ENV_NAME");
            if (enviroment == null)
            {
                enviroment = Config.DefaultEnviroment;
            }
            CurrentEnviromentName = enviroment;
            CurrentEnviroment = Config.Enviroments[CurrentEnviromentName];
        }
    }
}

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRunAnalizer.Interfaces;
using TestRunAnalizer.Models;

namespace TestRunAnalizer.Services
{
    public class TestRunJsonExtractor : IJsonExtractor
    {
        public ITestRun extractJson(IFileHandler fileHandler)
        {
            string filePath =fileHandler.GetJsonFilePath();
    
            ////checking filePath variable is not null and the file exists
            //if (filePath == null) throw new ArgumentNullException($"filePath is null, please review: {filePath}");

            //if (!File.Exists(filePath)) throw new FileNotFoundException("File does not exist or could not be found, please review");

            string jsonData = File.ReadAllText(filePath);

            if (string.IsNullOrEmpty(jsonData)) 
            {
                throw new ArgumentException("The json file provided does not seem to contain any data or is null");
            }
            //Deserializing JSON into TestRun object
            try
            {
                // Configuring settings to ignore case
                var settings = new JsonSerializerSettings
                {
                    ContractResolver = new DefaultContractResolver
                    {
                        NamingStrategy = new CamelCaseNamingStrategy()
                    },
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };
                ITestRun testRun = JsonConvert.DeserializeObject<TestRun>(jsonData, settings);
                return testRun;


            }
            catch (Exception ex)
            {

                throw new  JsonException($"JSON file couldn't be deserialized. {ex}");
            }

        }
    }
}

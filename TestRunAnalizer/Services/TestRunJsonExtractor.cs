using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using TestRunAnalizer.Interfaces;
using TestRunAnalizer.Models;

namespace TestRunAnalizer.Services
{
    public class TestRunJsonExtractor : IJsonExtractor
    {
        public ITestRun extractJson(IFileHandler fileHandler)
        {
            string filePath =fileHandler.GetJsonFilePath();
    
            string jsonData = File.ReadAllText(filePath);

            if (string.IsNullOrEmpty(jsonData)) 
            {
                throw new ArgumentException("The json file provided does not seem to contain any data or is null");
            }

            
            //Deserializing JSON into TestRun object
            try
            {
                // Configuring settings to make the deserealitation case insensitive
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

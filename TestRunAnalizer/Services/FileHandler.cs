using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRunAnalizer.Interfaces;

namespace TestRunAnalizer.Services
{
    public class FileHandler : IFileHandler
    {
        string _defaultFilePath;
        string? _inputFilePath;

        public string GetJsonFilePath()
        {
            const string DEFAULT_JSON_FILE_NAME = "TestRun.json";

            //default file path
            _defaultFilePath = Path.Combine(Directory.GetCurrentDirectory(), DEFAULT_JSON_FILE_NAME);

            //Prompting the user to enter a file path
            Console.WriteLine("Please enter the JSON file path (or press Enter to use the default path):");
            var inputPath= Console.ReadLine();
            if (!string.IsNullOrEmpty(inputPath))
            {
                _inputFilePath = Path.Combine( inputPath, DEFAULT_JSON_FILE_NAME);
            }
            var jsonFilePath = GetFilePath(_inputFilePath, _defaultFilePath);
            Console.WriteLine($" JSON file to be read: {jsonFilePath}");
            return jsonFilePath;
        }

        public string GetCSVFilePath()
        {
            const string DEFAULT_CSV_FILE_NAME = "test_run_stats.csv";
            //default file path
            _defaultFilePath = Path.Combine(Directory.GetCurrentDirectory(), DEFAULT_CSV_FILE_NAME);

            //Prompting the user to enter a file path
            Console.WriteLine("Please enter the CSV file path (or press Enter to use the default path):");
            var inputPath = Console.ReadLine();
            if (!string.IsNullOrEmpty(inputPath))
            {
                _inputFilePath = Path.Combine(inputPath, DEFAULT_CSV_FILE_NAME);
            }
            var jsonFilePath = GetFilePath(_inputFilePath, _defaultFilePath);
            var csvFilePath = GetFilePath(_inputFilePath, _defaultFilePath);
            Console.WriteLine($" CSV file to write to: {jsonFilePath}");

            return csvFilePath;
        }

        private string GetFilePath(string? inputFilePath, string defaultFilePath)
        {

            var usingDefaultFilePath = string.IsNullOrWhiteSpace(inputFilePath);
            //Using the default file path if a file path is not provide by the user
            string? filePath = usingDefaultFilePath ? defaultFilePath : inputFilePath;

            if (!usingDefaultFilePath)
            {
                var directory = Path.GetDirectoryName(filePath);
                Directory.Exists(directory);
                // Checking if the folder exists
                if (!Directory.Exists(directory))
                {
                    Console.WriteLine($"path  not found at: {filePath}");
                  throw new FileNotFoundException($"Path not found at: {filePath} check the directory exists");
                }
            }   
            return filePath;
        }
    }
}

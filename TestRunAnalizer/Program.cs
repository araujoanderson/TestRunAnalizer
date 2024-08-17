using System.Text.Json;
using TestRunAnalizer.Interfaces;
using TestRunAnalizer.Models;
using TestRunAnalizer.Services;

public class Program
{
    
    public static void Main(string[] args)
    {
        IJsonExtractor jsonExtractor = new TestRunJsonExtractor();
        ITestRun testRun = new TestRun();
        IDurationParser durationParser = new DurationParser();
        ICsvExporter csvExporter = new CsvExporter();


        const string JSON_FILE_PATH = "example.json";
        const string CSV_FILE_NAME = "test_run_stats.csv";
      
        testRun = jsonExtractor.extractJson(JSON_FILE_PATH);
        ITestRunStatisticsExtractor testRunStatisticsExtractor = new TestRunStatisticsExtractor(testRun, durationParser);

        ITestRunStatistics testRunStatistics = testRunStatisticsExtractor.ExtractStatistics();
        csvExporter.ExportTestRunStatistics(testRunStatistics, CSV_FILE_NAME);
        

    }
}
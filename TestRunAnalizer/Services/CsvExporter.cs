using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRunAnalizer.Interfaces;
using TestRunAnalizer.Models;

namespace TestRunAnalizer.Services
{
    public class CsvExporter : ICsvExporter
    {
        public void ExportTestRunStatistics(ITestRunStatistics testRunStatistics, IFileHandler fileHandler)
        {
            if (testRunStatistics == null) 
            {
                throw new ArgumentNullException($"{nameof(testRunStatistics)} variable is null");
            }

            var filePath = fileHandler.GetCSVFilePath();

            var csvBody = new StringBuilder();

            //Adding the header for statistics
            csvBody.AppendLine("Total Tests,Passed Tests,Failed Tests,Total Duration,Average Duration,Max Duration,Min Duration,Execution Date");

            //Adding statistics row
            csvBody.AppendLine($"{testRunStatistics.TotalTests}," +
                                  $"{testRunStatistics.PassedTests}," +
                                  $"{testRunStatistics.FailedTests}," +
                                  $"{testRunStatistics.TotalDuration}," +
                                  $"{testRunStatistics.AverageDuration}," +
                                  $"{testRunStatistics.MaxDuration}," +
                                  $"{testRunStatistics.MinDuration}," +
                                  $"{testRunStatistics.ExecutionDate}");

            //Adding an empty line for separation
            csvBody.AppendLine();

            //Adding the header for individual test details
            csvBody.AppendLine("Title,ID,Result,Duration,Execution Start Date");

            //Adding each test as a row
            foreach (var test in testRunStatistics.Tests)
            {
                csvBody.AppendLine($"{test.Title}," +
                                      $"{test.Id}," +
                                      $"{test.Result}," +
                                      $"{test.Duration}," +
                                      $"{test.ExecutionStartDate}");
            }

            //Writing the CSV content to the file
            File.WriteAllText(filePath, csvBody.ToString());
        }
    }
}

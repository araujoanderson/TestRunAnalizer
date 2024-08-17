using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRunAnalizer.Interfaces;
using TestRunAnalizer.Models;
using static System.Net.Mime.MediaTypeNames;

namespace TestRunAnalizer.Services
{
    public class TestRunStatisticsExtractor : ITestRunStatisticsExtractor
    {
        ITestRun _testRun;
        IDurationParser _parser;
        public TestRunStatisticsExtractor(ITestRun testRun, IDurationParser durationParser) 
        {
            _testRun = testRun;
            _parser = durationParser;
        
        }

        public ITestRunStatistics ExtractStatistics()
        {
            IList<ITest> tests = new List<ITest>();
            foreach (ITest test in _testRun.Tests)
            {
                tests.Add(test);
            }
            ITestRunStatistics stats = new TestRunStatistics
            {
                TotalTests = _testRun.TotalTestCount,
                PassedTests = _testRun.Tests.Count(t => t.Result.ToLower() == "passed"),
                FailedTests = _testRun.Tests.Count(t => t.Result.ToLower() == "failed"),
                ExecutionDate = _testRun.ExecutionDate,
                TotalDuration = _parser.ParseDuration(_testRun.TotalRunDuration),
                AverageDuration = TimeSpan.FromTicks((long)_testRun.Tests.Average(t => _parser.ParseDuration(t.Duration).Ticks)),
                MaxDuration = TimeSpan.FromTicks(_testRun.Tests.Max(t => _parser.ParseDuration(t.Duration).Ticks)),
                MinDuration = TimeSpan.FromTicks(_testRun.Tests.Min(t => _parser.ParseDuration(t.Duration).Ticks)),
                Tests = tests
            };

            return stats;
        }
    }
}

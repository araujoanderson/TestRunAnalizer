using TestRunAnalizer.Interfaces;

namespace TestRunAnalizer.Models
{
    public class TestRunStatistics : ITestRunStatistics
    {
        public int TotalTests { get;  set; }
        public int PassedTests { get; set; }
        public int FailedTests { get; set; }
        public TimeSpan TotalDuration { get;set; }
        public TimeSpan AverageDuration { get;set; }
        public TimeSpan MaxDuration { get; set; }
        public TimeSpan MinDuration { get; set; }
        public string ExecutionDate     { get; set; }
        public IList<ITest> Tests { get; set;}
    }
}

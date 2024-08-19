namespace TestRunAnalizer.Interfaces
{
    public interface ICsvExporter
    {
        public void ExportTestRunStatistics(ITestRunStatistics testRunStatistics, IFileHandler fileHandler);
    }
}

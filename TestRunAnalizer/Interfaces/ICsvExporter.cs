using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRunAnalizer.Interfaces
{
    public interface ICsvExporter
    {
        public void ExportTestRunStatistics(ITestRunStatistics testRunStatistics, IFileHandler fileHandler);
    }
}

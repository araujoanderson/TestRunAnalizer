using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRunAnalizer.Interfaces
{
    public interface ITestRunStatisticsExtractor
    {
        public ITestRunStatistics ExtractStatistics();
    }
}

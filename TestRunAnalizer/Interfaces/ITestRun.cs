﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRunAnalizer.Models;

namespace TestRunAnalizer.Interfaces
{
    public interface ITestRun
    {
        public int Id { get; set; }

        public int TotalTestCount { get; set; }
        public string TotalRunDuration { get; set; }

        public string ExecutionDate { get; set; }

        public IList<Test> Tests { get; set; }
    }
}

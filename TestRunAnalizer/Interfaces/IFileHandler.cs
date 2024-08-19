using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRunAnalizer.Interfaces
{
    public interface IFileHandler
    {
        public string GetJsonFilePath();
        public string GetCSVFilePath();
    }
}

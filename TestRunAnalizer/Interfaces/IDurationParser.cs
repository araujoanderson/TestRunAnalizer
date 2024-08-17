using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRunAnalizer.Interfaces
{
    public interface IDurationParser
    {
        public TimeSpan ParseDuration(string duration);
    }
}

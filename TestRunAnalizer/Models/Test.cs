using TestRunAnalizer.Interfaces;

namespace TestRunAnalizer.Models
{
    public class Test :ITest
    {
        public int Id { get; set; }
        public string Title{ get; set; }

        public string Result{ get; set; }
        public string Duration{ get; set; }

        public string ExecutionStartDate{ get; set; }
    }
}

using CodeStorm.Domain.Enums;

namespace CodeStorm.Domain.TransferModels
{
    public class TestResult
    {
        public ResultType ResultType { get; set; }

        public int AcceptedTestNumber { get; set; } = 0;

        public Dictionary<int, long> ProcessingTimes { get; set; }
            = new Dictionary<int, long>();

        public Dictionary<int, long> MemoryUsages { get; set; }
            = new Dictionary<int, long>();

        public string ErrorMessage { get; set; } = String.Empty;
    }
}

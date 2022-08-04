using CodeStorm.Core.Interfaces.Base;
using CodeStorm.Domain.Constants;
using CodeStorm.Domain.Enums;
using CodeStorm.Domain.TransferModels;

namespace CodeStorm.Core.Base
{
    public class Tester : ITester
    {
        private readonly string runnerName;
        private readonly string runnerArgs;
        private readonly uint memoryLimit;
        private readonly ushort timeLimit;

        public Tester(string runnerName, string runnerArgs, uint memoryLimit, ushort timeLimit)
        {
            this.runnerName = runnerName;
            this.runnerArgs = runnerArgs;
            this.memoryLimit = memoryLimit;
            this.timeLimit = timeLimit;
        }
        public async Task<TestResult> TestAsync(DirectoryInfo problemSetDirectory)
        {
            var result = new TestResult();
            IRunner runner = new Runner(runnerName, runnerArgs, memoryLimit, timeLimit);

            var testDirs = problemSetDirectory.GetDirectories();
            int totaltestsQuantity = testDirs.Length;
            for(ushort i=0; i<totaltestsQuantity; i++)
            {
                string inputPath = Path.Combine(testDirs[i].FullName, NameConstants.INPUT_FILE_NAME);
                string input = await File.ReadAllTextAsync(inputPath);
                string outputPath = Path.Combine(testDirs[i].FullName, NameConstants.OUTPUT_FILE_NAME);
                if (!File.Exists(outputPath)) throw new DirectoryNotFoundException();
                string output = await File.ReadAllTextAsync(outputPath);
                var runnerResult = await runner.RunAsync(input);

                if (!runnerResult.IsSuccessful && String.IsNullOrEmpty(runnerResult.ErrorMessage))
                {
                    result.ResultType = ResultType.RuntimeError;
                    result.ErrorMessage = runnerResult.ErrorMessage;
                    return result;
                }
                else if (runnerResult.ExecutionTime >= timeLimit)
                {
                    result.ResultType = ResultType.TimeLimitExceeded;
                    return result;
                }
                else if (runnerResult.MemoryUsage >= memoryLimit)
                {
                    result.ResultType = ResultType.MemoryLimitExceeded;
                    return result;
                }
                else if (String.IsNullOrEmpty(runnerResult.Result))
                {
                    result.ResultType = ResultType.PresentationError;
                    return result;
                }
                else if (runnerResult.Result != output)
                {
                    result.ResultType = ResultType.WrongAnswer;
                    return result;
                }
                else
                {
                    result.AcceptedTestNumber++;
                    result.ProcessingTimes.Add(result.AcceptedTestNumber, runnerResult.ExecutionTime);
                    result.MemoryUsages.Add(result.AcceptedTestNumber, runnerResult.MemoryUsage);
                }
            }
            if(result.AcceptedTestNumber == totaltestsQuantity)
            {
                result.ResultType = ResultType.Accepted;
                return result;
            }
            else
            {
                result.ResultType = ResultType.UnknownError;
                return result;
            }
        }
    }
}

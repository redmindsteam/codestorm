using CodeStorm.Core.Analyzers;
using CodeStorm.Core.Helpers;
using CodeStorm.Core.Interfaces.Base;
using CodeStorm.Domain.Common;
using CodeStorm.Domain.TransferModels;
using System.Diagnostics;
using System.Text;

namespace CodeStorm.Core.Base
{
    internal class Runner : BaseEngine, IRunner
    {
        private readonly ushort timeLimit;
        private readonly uint memoryLimit;
        private StringBuilder resultStringBuilder = new StringBuilder();
        private StringBuilder errorStringBuilder = new StringBuilder();

        private Process process = new Process();
        private Stopwatch stopwatch = new Stopwatch();

        public Runner(string runnerName, string runnerArgs,
            uint memoryLimit, ushort timeLimit)
        {
            process.StartInfo = _processInfo;
            process.OutputDataReceived += (obj, e) =>
            {
                if (!string.IsNullOrEmpty(e.Data))
                    resultStringBuilder.Append(e.Data + "\n");
            };
            process.ErrorDataReceived += (obj, e) =>
            {
                if (!string.IsNullOrEmpty(e.Data))
                    errorStringBuilder.Append(e.Data + "\n");
            };
            process.StartInfo.FileName = runnerName;
            process.StartInfo.Arguments = runnerArgs;
            this.timeLimit = timeLimit;
            this.memoryLimit = memoryLimit;
        }

        public async Task<RunnerResult> RunAsync(string input)
        {
            var result = new RunnerResult();
            MemoryAnalyzer memoryAnalyzer = new MemoryAnalyzer(memoryLimit);
            process.Start();
            await process.StandardInput.WriteLineAsync(input);
            memoryAnalyzer.Start(process.Id);
            stopwatch.Restart();
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            process.WaitForExitAsync().Wait(timeLimit);
            stopwatch.Stop();
            memoryAnalyzer.Stop();
            string output = resultStringBuilder.ToString().Trim();
            string error = errorStringBuilder.ToString().Trim();
            result.Result = output;
            result.ExecutionTime = (ushort)stopwatch.ElapsedMilliseconds;
            result.MemoryUsage = memoryAnalyzer.TotalMemoryUsage;
            if (string.IsNullOrEmpty(error)) result.IsSuccessful = true;
            else
            {
                result.ErrorMessage = error;
                result.IsSuccessful = false;
            }
            StopRunner();
            return result;
        }

        public void StopRunner()
        {
            ProcessHelper.KillAllProcessHierarchy(process.Id);
            process.CancelErrorRead();
            process.CancelOutputRead();
            resultStringBuilder.Clear();
            errorStringBuilder.Clear();
        }
    }
}

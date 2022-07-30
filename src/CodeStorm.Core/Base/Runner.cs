using CodeStorm.Core.Helpers;
using CodeStorm.Core.Interfaces.Base;
using CodeStorm.Domain.Common;
using CodeStorm.Domain.Constants;
using CodeStorm.Domain.TransferModels;
using System.Diagnostics;
using System.Text;

namespace CodeStorm.Core.Base
{
    public class Runner : BaseEngine, IRunner
    {
        // for collect from cmd input value
        private StringBuilder resultStringBuilder = new StringBuilder();

        // for collect from cmd errors during process
        private StringBuilder errorStringBuilder = new StringBuilder();

        private Process process = new Process();

        private Stopwatch stopwatch = new Stopwatch();

        public Runner(string runnerName, string runnerArgs, 
            ushort memoryLimit, ushort timeLimit)
        {
            process.StartInfo = _processInfo;
            process.OutputDataReceived += (obj, e) =>
            {
                if (!string.IsNullOrEmpty(e.Data)) 
                    resultStringBuilder.Append(e.Data+"\n");
            };
            process.ErrorDataReceived += (obj, e) =>
            {
                if (!string.IsNullOrEmpty(e.Data)) 
                    errorStringBuilder.Append(e.Data+"\n");
            };
            process.StartInfo.FileName = runnerName;
            process.StartInfo.Arguments = runnerArgs;
        }

        public async Task<RunnerResult> RunAsync(string input)
        {
            var result = new RunnerResult();
            stopwatch.Restart();

            process.Start();
            await process.StandardInput.WriteLineAsync(input);
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            process.WaitForExitAsync().Wait(EngineConstants.ENGINE_MAX_WAIT_TIME);
            stopwatch.Stop();

            string output = resultStringBuilder.ToString().Trim();
            string error = errorStringBuilder.ToString().Trim();
            result.Result = output;
            result.ExecutionTime = (int)stopwatch.ElapsedMilliseconds;
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

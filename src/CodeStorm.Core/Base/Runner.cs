using CodeStorm.Core.Helpers;
using CodeStorm.Core.Interfaces.Base;
using CodeStorm.Domain.Common;
using CodeStorm.Domain.Constants;
using CodeStorm.Domain.TransferModels;
using System.Diagnostics;

namespace CodeStorm.Core.Base
{
    public class Runner : BaseEngine, IRunner
    {
        // for collect from cmd input value
        private IList<string> _results = new List<string>();

        // for collect from cmd errors during process
        private IList<string> _errors = new List<string>();

        public async Task<RunnerResult> RunAsync(string runnerName, 
            string runnerArgs, string input)
        {
            var result = new RunnerResult();
            Stopwatch stopwatch = new Stopwatch();

            Process process = new Process() { StartInfo = _processInfo };
            process.OutputDataReceived += (obj, e) =>
            {
                if (!string.IsNullOrEmpty(e.Data)) _results.Add(e.Data);
            };
            process.ErrorDataReceived += (obj, e) =>
            {
                if (!string.IsNullOrEmpty(e.Data)) _errors.Add(e.Data);
            };
            process.StartInfo.FileName = runnerName;
            process.StartInfo.Arguments = runnerArgs;

            stopwatch.Start();
            process.Start();
            process.StandardInput.WriteLine(input);
            //await process.StandardInput.WriteLineAsync(input);
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            process.WaitForExitAsync().Wait(EngineConstants.ENGINE_MAX_WAIT_TIME);
            stopwatch.Stop();
            string output = CollectionToString(_results.ToList());
            string error = CollectionToString(_errors.ToList());
            result.Result = output;
            result.ExecutionTime = (int)stopwatch.ElapsedMilliseconds;
            // result.MemoryUsage = (int)(process.PrivateMemorySize64 / 1024);
            if (string.IsNullOrEmpty(error)) result.IsSuccessful = true;
            else
            {
                result.ErrorMessage = error;
                result.IsSuccessful = false;
            }
            ProcessHelper.KillAllProcessHierarchy(process.Id);
            _results.Clear();
            _errors.Clear();

            return result;
        }

        /// <summary>
        /// collect output strings from hidden console to one string
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        private string CollectionToString(IEnumerable<string> collection)
        {
            string result = "";
            foreach (string item in collection)
                result += item + "\n";

            return result.Trim();
        }
    }
}

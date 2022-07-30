using CodeStorm.Core.Interfaces.Base;
using CodeStorm.Domain.Common;
using CodeStorm.Domain.TransferModels;
using System.Diagnostics;
using System.Text;

namespace CodeStorm.Core.Base;

internal class Compiler : BaseEngine, ICompiler
{
    public async Task<CompilationResult> CompileAsync(string compilerName,
        string compileArgs, string compiledFilePath)
    {
        var result = new CompilationResult();
        Stopwatch stopwatch = new Stopwatch();

        using (Process process = new Process())
        {
            StringBuilder errorOut = new StringBuilder();
            process.StartInfo = _processInfo;
            process.ErrorDataReceived += new DataReceivedEventHandler((sender, e) =>
            { errorOut.Append(e.Data); });
            process.StartInfo.FileName = compilerName;
            process.StartInfo.Arguments = compileArgs;
            stopwatch.Start();
            process.Start();
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            await process.WaitForExitAsync();
            stopwatch.Stop();
            process.Kill();
            result.ErrorMessage = errorOut.ToString();
            result.CompilationTime = (ushort) stopwatch.ElapsedMilliseconds;
        }
        if (File.Exists(compiledFilePath)) result.IsCompiled = true;
        else result.IsCompiled = false;
        return result;
    }
}


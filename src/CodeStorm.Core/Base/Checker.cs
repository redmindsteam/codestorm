using CodeStorm.Core.Checkers;
using CodeStorm.Core.Helpers;
using CodeStorm.Core.Interfaces.Base;
using CodeStorm.Domain.Enums;
using CodeStorm.Domain.Models;

namespace CodeStorm.Core.Base;
public class Checker : IChecker
{
    private readonly Compiler compiler;
    private readonly CheckerFactory checkerFactory;

    public Checker()
    {
        this.compiler = new Compiler();
        this.checkerFactory = new CheckerFactory();
    }
    public async Task<CheckerResult> CheckAsync(CheckerInput checkerInput)
    {
        if (!ValidationHelper.IsValid(checkerInput)) throw new Exception();
        CheckerResult checkerResult = new CheckerResult();
        string runnerName, runnerArgs;
        if (checkerFactory.IsCompiledLanguage(checkerInput.Language))
        {
            var checker = checkerFactory.GetCompiledChecker(checkerInput.Language);
            string compiledFileName = checker.GetCompiledFileName(Path.GetFileName(checkerInput.SourceCodePath));
            string compiledFilePath = Path.Combine(checkerInput.MissionPath, compiledFileName);
            string compilerName = checker.GetCompilerName();
            string compilerArgs = checker.GetCompilerArgs(checkerInput.SourceCodePath, compiledFilePath);
            var compilationResult = await compiler.CompileAsync(compilerName, compilerArgs, compiledFilePath);
            if (compilationResult.IsCompiled)
            {
                runnerName = checker.GetRunnerName(compiledFilePath);
                runnerArgs = checker.GetRunnerArgs(compiledFilePath);
            }
            else
            {
                checkerResult.Result = ResultType.CompileError.ToString();
                checkerResult.ErrorMessage = compilationResult.ErrorMessage;
                return checkerResult;
            }
        }
        else
        {
            var checker = checkerFactory.GetInterpretedChecker(checkerInput.Language);
            runnerName = checker.GetRunnerName();
            runnerArgs = checker.GetRunnerArgs(checkerInput.SourceCodePath);
        }
        ITester tester = new Tester(runnerName, runnerArgs, checkerInput.MemoryLimit, checkerInput.TimeLimit);
        DirectoryInfo problemSetDirectory = new DirectoryInfo(checkerInput.ProblemSetPath);
        var testResult = await tester.TestAsync(problemSetDirectory);
        if (testResult.ResultType == ResultType.Accepted)
            checkerResult.Result = testResult.ResultType.ToString();
        else
            checkerResult.Result = testResult.ResultType.ToString() + $"({testResult.AcceptedTestNumber + 1})";
        checkerResult.ProcessingTimes = testResult.ProcessingTimes;
        checkerResult.MemoryUsages = testResult.MemoryUsages;
        return checkerResult;
    }
}

using CodeStorm.Core.Base;
using CodeStorm.Core.Interfaces.Base;
using CodeStorm.Domain.Models;
using CodeStorm.UnitTest.Helpers;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace CodeStorm.UnitTest.ResultTests.Accepted;

public class CppTest
{
    [Fact]
    public async Task AcceptedResult()
    {
        string problemSet = "0000001";
        IChecker checker = new Checker();
        string problemSetPath = ResourceHelper.GetProblemSetDirectory();
        problemSetPath = Path.Combine(problemSetPath, problemSet);
        string sourceCodePath = ResourceHelper.GetSourceCodesDirectory();
        sourceCodePath = Path.Combine(sourceCodePath, problemSet, "accepted", "1.cpp");
        CheckerInput checkerInput = new CheckerInput()
        {
            Language = "cpp",
            MemoryLimit = 16000,
            TimeLimit = 1000,
            MissionPath = ResourceHelper.GetTemporaryDirectory(),
            ProblemSetPath = problemSetPath,
            SourceCodePath = sourceCodePath
        };
        var checkerResult = await checker.CheckAsync(checkerInput);
        Assert.True(checkerResult.Result == "Accepted");
    }
}

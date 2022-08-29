using CodeStorm.Core.Base;
using CodeStorm.Core.Interfaces.Base;
using CodeStorm.Domain.Models;
using CodeStorm.UnitTest.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CodeStorm.UnitTest.ResultTests.Accepted;

public class JavaTest
{
    [Fact]
    public async Task AcceptedResult()
    {
        string problemSet = "0000001";
        IChecker checker = new Checker();
        string problemSetPath = ResourceHelper.GetProblemSetDirectory();
        problemSetPath = Path.Combine(problemSetPath, problemSet);
        string sourceCodePath = ResourceHelper.GetSourceCodesDirectory();
        sourceCodePath = Path.Combine(sourceCodePath, problemSet, "accepted", "main.java");
        CheckerInput checkerInput = new CheckerInput()
        {
            Language = "java",
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

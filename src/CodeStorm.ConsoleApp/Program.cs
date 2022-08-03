using CodeStorm.Core.Base;
using CodeStorm.Core.Interfaces.Base;
using CodeStorm.Domain.Models;

namespace App;

class Program
{
    public static async Task Main(string[] args)
    {
        CheckerInput checkerInput = new CheckerInput()
        {
            Language = "cpp",
            MemoryLimit = 16000,
            TimeLimit = 2000,
            MissionPath = "d://CodeStormTest//MissionDirectory",
            SourceCodePath = "d://CodeStormTest//SourceCodes//1//Accepted//1.cpp",
            ProblemSetPath = "d://CodeStormTest//ProblemSets//a+b"
        };
        IChecker checker = new Checker();
        var result = await checker.CheckAsync(checkerInput);

        Console.WriteLine(result.Result);

        Console.WriteLine("Times-->");
        foreach (var i in result.ProcessingTimes) Console.WriteLine(i.Key+'-'+i.Value+" ms");

        Console.WriteLine("Memories-->");
        foreach (var i in result.MemoryUsages) Console.WriteLine(i.Key + '-' + i.Value + " KB");
    }
}

using CodeStorm.Core.Base;
using CodeStorm.Core.Interfaces.Base;

namespace App;

class Program
{
    public static async Task Main(string[] args)
    {
        string runnerName = "d:/cptest/amodb.exe";
        string runnerArgs = "";
        uint memoryLimit = 16000;
        ushort timeLimit = 1000;
        DirectoryInfo problemSetDirectory = new DirectoryInfo("d://problemSets//amodb(runtime-error)");
        ITester tester = new Tester(runnerName, runnerArgs, memoryLimit, timeLimit);
        var result = await tester.TestAsync(problemSetDirectory);

        Console.WriteLine(result.AcceptedTestNumber);
        Console.WriteLine(result.ResultType.ToString());

        Console.WriteLine("Times-->");
        foreach (var i in result.ProcessingTimes) Console.WriteLine(i.Key+'-'+i.Value+" ms");

        Console.WriteLine("Memories-->");
        foreach (var i in result.MemoryUsages) Console.WriteLine(i.Key + '-' + i.Value + " KB");
    }
}

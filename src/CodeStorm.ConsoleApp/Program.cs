using CodeStorm.Core.Base;
using CodeStorm.Core.Interfaces.Base;
using CodeStorm.Domain.Exceptions;
using CodeStorm.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace App;

class Program
{
    public static void Main(string[] args)
    {
        try
        {
            CheckWindowsAsync().Wait();
        }
        catch(SpecificSystemException exception)
        {
            Console.WriteLine("SystemException");
            Console.WriteLine(exception.Message);
            Console.WriteLine((exception.InnerException is not null)?exception.InnerException.Message:"");
        }
        catch(ValidationException exception)
        {
            Console.WriteLine("ValidationException");
            Console.WriteLine(exception.Message);
            Console.WriteLine((exception.InnerException is not null) ? exception.InnerException.Message : "");
        }
        catch(Exception exception)
        {
            Console.WriteLine("Exception");
            Console.WriteLine(exception.Message);
            Console.WriteLine((exception.InnerException is not null) ? exception.InnerException.Message : "");
        }
    }

    public static async Task CheckWindowsAsync()
    {
        CheckerInput checkerInput = new CheckerInput()
        {
            Language = "cpp",
            MemoryLimit = 16000,
            TimeLimit = 2000,
            MissionPath = @"C:\Users\O'tkirbek\Desktop\",
            SourceCodePath = @"C:\Users\O'tkirbek\Desktop\5.cpp",
            ProblemSetPath = @"C:\Users\O'tkirbek\Desktop\2000005"
        };
        IChecker checker = new Checker();
        var result = await checker.CheckAsync(checkerInput);

        Console.WriteLine(result.Result);

        Console.WriteLine("Times-->");
        foreach (var i in result.ProcessingTimes) Console.WriteLine(i.Key + '-' + i.Value + " ms");

        Console.WriteLine("Memories-->");
        foreach (var i in result.MemoryUsages) Console.WriteLine(i.Key + '-' + i.Value + " KB");
    }
}

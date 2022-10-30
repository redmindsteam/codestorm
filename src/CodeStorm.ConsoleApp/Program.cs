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
            Language = "py3",
            MemoryLimit = 16000,
            TimeLimit = 2000,
            TemporaryPath = @"C:\Users\O'tkirbek\Desktop\",
            SourceCodePath = @"C:\Users\O'tkirbek\Desktop\init.py",
            ProblemSetPath = @"D:\DEVELOPMENT\ASP.NET\API\codestorm-webapi\dependencies\IdentityFiles\92e6743d-6a60-43ee-a295-2b4f53b8fa0a\4000003"
        };
        IChecker checker = new Checker();
        var result = await checker.CheckAsync(checkerInput);

        Console.WriteLine(result.Result);

        Console.WriteLine("Times-->");
        foreach (var i in result.ProcessingTimes) Console.WriteLine(i.Key + '-' + i.Value + " ms");

        Console.WriteLine("Memories-->");
        foreach (var i in result.MemoryUsages) Console.WriteLine(i.Key + '-' + i.Value + " KB");

        Console.WriteLine(result.ErrorMessage);
    }
}

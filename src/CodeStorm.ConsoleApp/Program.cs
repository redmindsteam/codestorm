using CodeStorm.Core.Base;
using CodeStorm.Core.Interfaces.Base;

namespace App;

class Program
{
    public static async Task Main(string[] args)
    {
        IRunner runner = new Runner("d://test.exe", "", 16000, 2000);
        var result = await runner.RunAsync("5 5 5");
        Console.WriteLine("Status : " + result.IsSuccessful);
        Console.WriteLine("Output : " + result.Result);
        Console.WriteLine("Error : " + result.ErrorMessage);
        Console.WriteLine("Vaqt : " + result.ExecutionTime);
        Console.WriteLine("Xotira : " + result.MemoryUsage);
        Console.WriteLine();
        var result1 = await runner.RunAsync("6 6 6");
        Console.WriteLine("Status : " + result1.IsSuccessful);
        Console.WriteLine("Output : " + result1.Result);
        Console.WriteLine("Error : " + result1.ErrorMessage);
        Console.WriteLine("Vaqt : " + result1.ExecutionTime);
        Console.WriteLine("Xotira : " + result1.MemoryUsage);
        Console.WriteLine();
        var result2 = await runner.RunAsync("7 7 7");
        Console.WriteLine("Status : " + result2.IsSuccessful);
        Console.WriteLine("Output : " + result2.Result);
        Console.WriteLine("Error : " + result2.ErrorMessage);
        Console.WriteLine("Vaqt : " + result2.ExecutionTime);
        Console.WriteLine("Xotira : " + result2.MemoryUsage);
        Console.WriteLine();
    }
}

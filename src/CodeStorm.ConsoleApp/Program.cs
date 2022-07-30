using CodeStorm.Core.Base;
using CodeStorm.Core.Interfaces.Base;

namespace App;

class Program
{
    public static async Task Main(string[] args)
    {
        IRunner runner = new Runner();
        var result = await runner.RunAsync("d://test.exe", "", "5 5 5");
        Console.WriteLine("Status : " + result.IsSuccessful);
        Console.WriteLine("Output : " + result.Result);
        Console.WriteLine("Error : " + result.ErrorMessage);
        Console.WriteLine("Vaqt : " + result.ExecutionTime);
        Console.WriteLine("Xotira : " + result.MemoryUsage);
    }
}

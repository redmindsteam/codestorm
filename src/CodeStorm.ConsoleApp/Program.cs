using CodeStorm.Core.Base;
using CodeStorm.Core.Interfaces.Base;

namespace App;

class Program
{
    public static async Task Main(string[] args)
    {
        for(int i=5; i<15; i++)
        {
            IRunner runner = new Runner("d://cptest/1.exe", "", 16000, 2000);
            var result = await runner.RunAsync(i+" "+i);
            Console.WriteLine("Status : " + result.IsSuccessful);
            Console.WriteLine("Output : " + result.Result);
            Console.WriteLine("Error : " + result.ErrorMessage);
            Console.WriteLine("Vaqt : " + result.ExecutionTime);
            Console.WriteLine("Xotira : " + result.MemoryUsage);
            Console.WriteLine();
        }
    }
}

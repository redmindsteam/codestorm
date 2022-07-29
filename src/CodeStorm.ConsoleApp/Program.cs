using CodeStorm.Core.Base;
using CodeStorm.Core.Interfaces.Base;

namespace App;

class Program
{
    public static async Task Main(string[] args)
    {
        string sourceCode = "d://cpp.cpp";
        string compiledFilePath = "d://cpp.exe";
        ICompiler compiler = new Compiler();
        var result = await compiler.CompileAsync("g++", $"-o \"{compiledFilePath}\" \"{sourceCode}\"", compiledFilePath);
        Console.WriteLine("Natija : " + result.IsCompiled);
        Console.WriteLine("Errorlar :" + result.ErrorMessage);
        Console.WriteLine("Vaqt : "+result.CompilationTime);
    }
}

using CodeStorm.Domain.TransferModels;

namespace CodeStorm.Core.Interfaces.Base
{
    internal interface ICompiler
    {
        /// <summary>
        /// Build .exe or dll or ... 
        /// From .cpp or cs or ...
        /// </summary>
        /// <returns></returns>
        Task<CompilationResult> CompileAsync(string compilerName,
            string compileArgs, string compiledFilePath);
    }
}

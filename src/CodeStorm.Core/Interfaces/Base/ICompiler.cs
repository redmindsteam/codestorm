using CodeStorm.Domain.TransferModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

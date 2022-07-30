using CodeStorm.Core.Interfaces.Root;

namespace CodeStorm.Core.Checkers.Tools
{
    internal class CppChecker : ICompiled
    {
        public string GetCompilerName() => "g++";

        public string GetCompilerArgs(string sourceCodeFilePath, string compiledFilePath)
            => $"-o \"{compiledFilePath}\" \"{sourceCodeFilePath}\" ";

        public string GetRunnerName(string compiledFilePath) => compiledFilePath;

        public string GetRunnerArgs(string compiledFilePath) => "";

        public string GetCompiledFileName(string filename)
        {
            if (OperatingSystem.IsWindows()) return Path.GetFileNameWithoutExtension(filename) + ".exe";
            else return filename;
        }
    }
}

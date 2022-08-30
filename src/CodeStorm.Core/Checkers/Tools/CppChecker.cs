using CodeStorm.Core.Interfaces.Root;

namespace CodeStorm.Core.Checkers.Tools
{
    internal class CppChecker : ICompiled
    {
        public string GetCompilerName() => "g++";

        public string GetCompilerArgs(string sourceCodeFilePath, string compiledFilePath)
        {
            if (OperatingSystem.IsWindows())
                return $"-o \"{compiledFilePath}\" \"{sourceCodeFilePath}\" ";
            else if (OperatingSystem.IsLinux())
                return $"\"{sourceCodeFilePath}\" -o \"{compiledFilePath}\" ";
            else
                return $"-o \"{sourceCodeFilePath}\" \"{compiledFilePath}\" ";
        }


        public string GetRunnerName(string compiledFilePath) => compiledFilePath;

        public string GetRunnerArgs(string compiledFilePath) => "";

        public string GetCompiledFileName(string filename)
        {
            if (OperatingSystem.IsWindows()) return Path.GetFileNameWithoutExtension(filename) + ".exe";
            else if (OperatingSystem.IsLinux()) return Path.GetFileNameWithoutExtension(filename) + ".out";
            else return filename;
        }
    }
}

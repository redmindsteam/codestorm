using CodeStorm.Core.Interfaces.Root;

namespace CodeStorm.Core.Checkers.Tools
{
    public class CChecker : ICompiled
    {
        public string GetCompilerName() => "gcc";

        public string GetCompilerArgs(string sourceCodeFilePath, string compiledFilePath)
            => $"-o \"{compiledFilePath}\" \"{sourceCodeFilePath}\" ";

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

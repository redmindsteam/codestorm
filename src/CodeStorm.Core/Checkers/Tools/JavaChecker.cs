using CodeStorm.Core.Interfaces.Root;

namespace CodeStorm.Core.Checkers.Tools
{
    public class JavaChecker : ICompiled
    {
        public string GetCompiledFileName(string filename)
        {
            string asmFileName = Path.GetFileNameWithoutExtension(filename) + ".class";
            return asmFileName;
        }

        public string GetCompilerArgs(string sourceCodeFilePath, string compiledFilePath)
            => sourceCodeFilePath;

        public string GetCompilerName() => "javac";

        public string GetRunnerArgs(string compiledFilePath)
        {
            string folderPath = Path.GetDirectoryName(compiledFilePath);
            string className = Path.GetFileName(compiledFilePath)[0..^6];
            string args = String.Empty;
            if (OperatingSystem.IsWindows())
                args = $"-cp \"{folderPath}\"; {className}";
            else if (OperatingSystem.IsLinux())
                args = $"-classpath {folderPath} {className}";
            return args;
        }

        public string GetRunnerName(string compiledFilePath) => "java";
    }
}

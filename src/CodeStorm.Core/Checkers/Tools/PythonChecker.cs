using CodeStorm.Core.Interfaces.Root;

namespace CodeStorm.Core.Checkers.Tools
{
    public class PythonChecker : IInterpreted
    {
        public string GetRunnerArgs(string sourceCodeFilePath)
            => sourceCodeFilePath;

        public string GetRunnerName() => "python";
    }
}

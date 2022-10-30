using CodeStorm.Core.Checkers.Tools;
using CodeStorm.Core.Interfaces.Base;
using CodeStorm.Core.Interfaces.Root;

namespace CodeStorm.Core.Checkers
{
    internal class CheckerFactory : ICheckerFactory
    {
        private Dictionary<string, ICompiled> _compiledCheckers;
        private Dictionary<string, IInterpreted> _interpretedCheckers;

        public CheckerFactory()
        {
            _compiledCheckers = new Dictionary<string, ICompiled>()
            {
                { "cpp", new CppChecker() },
                { "c", new CChecker() },
                { "java", new JavaChecker() }
            };

            _interpretedCheckers = new Dictionary<string, IInterpreted>()
            {
                { "py3", new PythonChecker() }
            };
        }

        public ICompiled GetCompiledChecker(string language)
        {
            return _compiledCheckers[language];
        }

        public IInterpreted GetInterpretedChecker(string language)
        {
            return _interpretedCheckers[language];
        }

        public bool IsCompiledLanguage(string language)
        {
            if (_compiledCheckers.ContainsKey(language)) return true;
            else return false;
        }

        public bool IsSupportableLanguage(string language)
        {
            if (_compiledCheckers.Keys.Contains(language)) return true;
            else if (_interpretedCheckers.Keys.Contains(language)) return true;
            else return false;
        }
    }
}

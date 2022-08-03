﻿using CodeStorm.Core.Checkers.Tools;
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
                { "cpp", new CppChecker() }
            };

            _interpretedCheckers = new Dictionary<string, IInterpreted>()
            {
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
    }
}

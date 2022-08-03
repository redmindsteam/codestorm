using CodeStorm.Core.Interfaces.Root;

namespace CodeStorm.Core.Interfaces.Base
{
    internal interface ICheckerFactory
    {
        bool IsCompiledLanguage(string language);

        IInterpreted GetInterpretedChecker(string language);

        ICompiled GetCompiledChecker(string language);
    }
}

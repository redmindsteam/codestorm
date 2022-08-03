using CodeStorm.Domain.TransferModels;

namespace CodeStorm.Core.Interfaces.Base
{
    internal interface ITester
    {
        Task<TestResult> TestAsync(DirectoryInfo problemSetDirectory);
    }
}

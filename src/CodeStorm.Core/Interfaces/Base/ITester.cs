using CodeStorm.Domain.TransferModels;

namespace CodeStorm.Core.Interfaces.Base
{
    public interface ITester
    {
        Task<TestResult> TestAsync(DirectoryInfo problemSetDirectory);
    }
}

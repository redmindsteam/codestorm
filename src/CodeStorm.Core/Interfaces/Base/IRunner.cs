using CodeStorm.Domain.TransferModels;

namespace CodeStorm.Core.Interfaces.Base
{
    public interface IRunner
    {
        Task<RunnerResult> RunAsync(string input);
    }
}

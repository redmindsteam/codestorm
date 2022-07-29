using CodeStorm.Domain.TransferModels;

namespace CodeStorm.Core.Interfaces.Base
{
    internal interface IRunner
    {
        Task<RunnerResult> RunAsync(string runnerName, string runnerArgs, string input);
    }
}

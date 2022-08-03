using CodeStorm.Domain.Models;

namespace CodeStorm.Core.Interfaces.Base
{
    public interface IChecker
    {
        Task<CheckerResult> CheckAsync(CheckerInput checkerInput);
    }
}

namespace CodeStorm.Domain.Enums
{
    /// <summary>
    /// Result Type yuborilgan kod natijasi 
    /// qanday bo'lganligi haqida xabar beradi
    /// </summary>
    public enum ResultType
    {
        Waiting = -2,
        Compiling,
        Running,
        Accepted ,
        WrongAnswer ,
        CompileError,
        TimeLimitExceeded,
        MemoryLimitExceeded,
        PresentationError,
        RuntimeError ,
        UnknownError
    }
}

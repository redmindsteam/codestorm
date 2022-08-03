namespace CodeStorm.Core.Interfaces.Root
{
    internal interface IInterpreted
    {
        /// <summary>
        /// Executor run qilishi uchun foydalanadigan dastur nomi
        /// Masalan: python uchun python.exe,
        /// </summary>
        /// <returns></returns>
        string GetRunnerName();

        /// <summary>
        /// Har bir test uchun source code ishga tushiruvchi argumentlar
        /// </summary>
        /// <param name="sourceCodeFilePath"></param>
        /// <returns></returns>
        string GetRunnerArgs(string sourceCodeFilePath);
    }
}

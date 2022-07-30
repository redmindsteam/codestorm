namespace CodeStorm.Core.Interfaces.Root
{
    /// <summary>
    /// ICompiled kompilatsiya qilinadigan tillar uchun boshlang'ich 
    /// asos sifatida foydalaniladi 
    /// </summary>
    internal interface ICompiled
    {
        /// <summary>
        /// Har bir ochilgan process uchun beriladigan dastur nomi
        /// Masalan : cpp uchun g++.exe, java uchun javac.exe
        /// </summary>
        /// <returns></returns>
        string GetCompilerName();

        /// <summary>
        /// Compiler Sdk kompilatsiya qilish uchun foydalanadigan argumentlar
        /// </summary>
        /// <param name="sourceCodeFilePath"></param>
        /// <param name="compiledFilePath"></param>
        /// <returns></returns>
        string GetCompilerArgs(string sourceCodeFilePath, string compiledFilePath);

        /// <summary>
        /// Executor run qilishi uchun foydalanadigan dastur nomi
        /// Masalan: java uchun java.exe, cpp uchun 'name'.exe
        /// </summary>
        string GetRunnerName(string compiledFilePath);

        /// <summary>
        /// Har bir test uchun kompilatsiya bo'lgan dasturni ishga tushiruvchi argumentlar
        /// </summary>
        /// <param name="compiledFilePath"></param>
        /// <returns></returns>
        string GetRunnerArgs(string compiledFilePath);

        /// <summary>
        /// Ba'zi dasturlash tillari uchun kompilatsiya fayli boshqacha bo'ladi
        /// shuning uchun kompilatsiya bo'ladigan fayl nomi kiritilishi kerak
        /// Masalan : dastur.exe yoki ...
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        string GetCompiledFileName(string filename);
    }
}

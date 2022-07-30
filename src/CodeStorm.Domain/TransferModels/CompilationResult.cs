namespace CodeStorm.Domain.TransferModels
{
    public class CompilationResult
    {
        /// <summary>
        /// Kelgan kod kompilatsiya bo'ldimi yoki yo'qmi aniqlash
        /// </summary>
        public bool IsCompiled { get; set; }

        /// <summary>
        /// Kompilatsiya vaqtida sodir bo'lgan errorlar
        /// </summary>
        public string ErrorMessage { get; set; } = String.Empty;

        /// <summary>
        /// Kompilatsiya qilish uchun ketgan vaqt
        /// o'lchov birligi millisecond larda
        /// </summary>
        public ushort CompilationTime { get; set; }
    }
}

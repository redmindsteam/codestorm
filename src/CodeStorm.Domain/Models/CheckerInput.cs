namespace CodeStorm.Domain.Models
{
    /// <summary>
    /// Foydalanuvchi tomonidan kiritilishi kerak bo'lgan ma'lumotlar
    /// </summary>
    public class CheckerInput
    {
        /// <summary>
        /// Tekshirilishi kerak bo'lgan kod yozilgan til
        /// </summary>
        public string Language { get; set; } = String.Empty;

        /// <summary>
        /// Tekshirilishi kerak bo'lgan kod manzili
        /// </summary>
        public string SourceCodePath { get; set; } = String.Empty;

        /// <summary>
        /// Tekshirilishi kerak bo'lgan kodni testlari manzili
        /// ushbu kodni tekshirish uchun yozib qo'yilgan 
        /// input va output lar yig'ilgan joy
        /// </summary>
        public string ProblemSetPath { get; set; } = String.Empty;

        /// <summary>
        /// Kodni qayerda kompilatsiya qilish kerakligi, 
        /// va qayerda uni boshqarish kerakligi manzili
        /// </summary>
        public string MissionPath { get; set; } = String.Empty;

        /// <summary>
        /// Har bir test uchun xotiradan ishlatilishi mumkin bo'lgan maksimum qiymat
        /// o'lchov birligi MB larda
        /// </summary>
        public ushort MemoryLimit { get; set; }

        /// <summary>
        /// Har bir test uchun ishlatilishi mumkin bo'lgan maksimum vaqt
        /// o'lchov birligi millisecond larda
        /// </summary>
        public ushort TimeLimit { get; set; }
    }
}

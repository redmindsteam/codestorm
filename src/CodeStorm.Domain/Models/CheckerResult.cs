namespace CodeStorm.Domain.Models
{
    /// <summary>
    /// Dastur qaytaradigan asosiy natija uchun
    /// </summary>
    public class CheckerResult
    {
        /// <summary>
        /// Source code ni testlardan o'tkazilgandagi natijani qaytaradi
        /// </summary>
        public string Result { get; set; } = String.Empty;

        /// <summary>
        /// Dasturni kompilatsiya qilishda va testlashda chiqqan xatolar uchun
        /// </summary>
        public string ErrorMessage { get; set; } = String.Empty;

        /// <summary>
        /// Yuborilgan kodni har bir test qilinganda 
        /// input qiymat kirishi va output qaytarishi orasidagi vaqtlar o'lchanadi
        /// o'lchov birligi - millisecond larda
        /// </summary>
        public Dictionary<ushort, ushort> ProcessingTimes { get; set; }
            = new Dictionary<ushort, ushort>();

        /// <summary>
        /// Yuborilgan kodni har bir test qilinganda
        /// foydalanuvchi kodi har bir test uchun ishlatadigan xotira hajmi o'lchanadi
        /// o'lchov birligi - KB larda
        /// </summary>
        public Dictionary<ushort, uint> MemoryUsages { get; set; }
            = new Dictionary<ushort, uint>();
    }
}

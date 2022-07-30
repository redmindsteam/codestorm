using CodeStorm.Domain.Enums;

namespace CodeStorm.Domain.TransferModels
{
    public class TestResult
    {
        public ResultType ResultType { get; set; }

        public ushort AcceptedTestNumber { get; set; } = 0;

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

        public string ErrorMessage { get; set; } = String.Empty;
    }
}

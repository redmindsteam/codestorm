using CodeStorm.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public ResultType Result { get; set; }

        /// <summary>
        /// Yuborilgan kod nechta testdan o'tganligini bildiradi
        /// </summary>
        public int TestNumber { get; set; }

        /// <summary>
        /// Dasturni kompilatsiya qilishda va testlashda chiqqan xatolar uchun
        /// </summary>
        public string ErrorMessage { get; set; } = String.Empty;

        /// <summary>
        /// Yuborilgan kodni har bir test qilinganda 
        /// input qiymat kirishi va output qaytarishi orasidagi vaqtlar o'lchanadi
        /// o'lchov birligi - millisecond larda
        /// </summary>
        public Dictionary<int, long> ProcessingTimes { get; set; }
            = new Dictionary<int, long>();

        /// <summary>
        /// Yuborilgan kodni har bir test qilinganda
        /// foydalanuvchi kodi har bir test uchun ishlatadigan xotira hajmi o'lchanadi
        /// o'lchov birligi - Kb larda
        /// </summary>
        public Dictionary<int, long> MemoryUsages { get; set; }
            = new Dictionary<int, long>();
    }
}

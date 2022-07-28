namespace CodeStorm.Domain.Constants
{
    /// <summary>
    /// Engine Constants ning vazifasi
    /// Foydalanuvchi tomonidan kiritiladigan ma'lumotlarga 
    /// cheklovlar qo'yish uchun ishlatiladi
    /// </summary>
    public class EngineConstants
    {
        /// <summary>
        /// Engine qancha vaqt code ni ishlatib turadi
        /// Masalan foydalanuvchi codda checksiz sikl yozgan bo'lsa 
        /// dastur buni kutib turavermasligi kerak
        /// va foydalanuvchi time limit kiritayotganda vaqt checklanadi
        /// o'lchov birligi millisecond larda
        /// </summary>
        public const ushort ENGINE_MAX_WAIT_TIME = 2000;

        /// <summary>
        /// Foydalanuvchi har bir test uchun xotira ajratadi 
        /// va undan xoxlagancha ajrata olmaydi 
        /// eng katta oladigan qiymat dastur tomonidan belgilangan
        /// undan katta qiymat ololmaydi
        /// o'lchov birligi MB larda
        /// </summary>
        public const ushort ENGINE_MAX_USAGE_MEMORY = 512;

        /// <summary>
        /// Foydalanuvchi xoxlagancha kod kiritmasligi kerak
        /// Kodlarni belgilar soni cheklanadi
        /// o'lchov birligi belgi larda
        /// </summary>
        public const ushort MAXIMUM_CODE_SIZE = 65525;
    }
}

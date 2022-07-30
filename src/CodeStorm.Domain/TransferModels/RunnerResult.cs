namespace CodeStorm.Domain.TransferModels
{
    public class RunnerResult
    {
        /// <summary>
        /// Kiritilgan input uchun kod muvaffaqqiyatli 
        /// ishlagani bildirish uchun
        /// </summary>
        public bool IsSuccessful { get; set; }

        /// <summary>
        /// User dasturi har biri input va output uchun 
        /// Ushbu o'zgaruvchi command execute qilinganda terminalda
        /// olingan qiymatni natijasi uchun
        /// </summary>
        public string Result { get; set; } = String.Empty;

        /// <summary>
        /// Har bir amal run qilganda sdk yoki terminal olgan errorlar
        /// </summary>
        public string ErrorMessage { get; set; } = String.Empty;

        /// <summary>
        /// User source code run qilinganda har bir kiritilgan input uchun 
        /// o'lchov birligi millisecondlarda o'lchanadi
        /// </summary>
        public ushort ExecutionTime { get; set; }

        /// <summary>
        /// Har bir test uchun xotira sarfi
        /// </summary>
        public uint MemoryUsage { get; set; }
    }
}

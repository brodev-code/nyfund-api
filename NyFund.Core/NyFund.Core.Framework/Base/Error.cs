using NyFund.Core.Framework.Enums;

namespace NyFund.Core.Framework.Base
{
    public class Error
    {
        /// <summary>
        /// Hata kodu
        /// </summary>
        public ErrorCode Code { get; set; }

        /// <summary>
        /// Hata mesajı, Özelleştirilebilir, Ör => ex.Message
        /// </summary>
        public string Message { get; set; }


        public Error()
        {
            Code = ErrorCode.Success;
        }
    }
}

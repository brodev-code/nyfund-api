using NyFund.Core.Framework.Enums;

namespace NyFund.Common.Dto.Base
{
    public class BaseResponse
    {
        public bool IsSuccess { get; set; }
        public long Id { get; set; }
        public string Message { get; set; }
        public ErrorCode ErrorCode { get; set; }
        public int OtpCounter { get; set; }
    }
}

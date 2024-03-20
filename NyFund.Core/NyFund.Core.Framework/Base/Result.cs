using NyFund.Core.Framework.Enums;

namespace NyFund.Core.Framework.Base
{
    public class Result
    {
        public bool IsSuccess { get; set; }
        public object Data { get; set; }
        public Error Error { get; set; }
        public Error Message { get; set; }
    }

    public class Result<T>
    {
        public bool IsSuccess { get; set; }
        public T Data { get; set; }
        public Error Error { get; set; }
        public Error Message { get; set; }


        public Result() { }

        public static Result<T> CreateSuccessResult(T data)
        {
            return new Result<T>
            {
                IsSuccess = true,
                Data = data
            };
        }

        public static Result<T> CreateErrorResult(ErrorCode errorCode,
            string errorMessage = null)
        {
            return new Result<T>
            {
                IsSuccess = false,
                Error = new Error {
                    Code = errorCode,
                    Message = errorMessage,
                }
            };
        }

		public static Result<T> CreateErrorResult(T data, ErrorCode errorCode,
		   string errorMessage = null)
		{
			return new Result<T>
			{
				IsSuccess = false,
                Data = data,
				Error = new Error
				{
					Code = errorCode,
					Message = errorMessage,
				}
			};
		}

		public static Result<T> Cast<TE>(Result<TE> result)
        {
            return new Result<T>
            {
                Error = result.Error,
                IsSuccess = result.IsSuccess
            };
        }
    }
}

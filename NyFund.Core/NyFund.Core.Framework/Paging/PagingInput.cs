
namespace NyFund.Core.Framework.Paging
{
    public class PagingInput
    {
        public int Page { get; set; }
        public int Size { get; set; }
    }

    public class PagingRequest
    {
        public int Page { get; set; }
        public int Size { get; set; }
    }

    public class PagingInput<T>
    {
        public T Data { get; set; }
        public PagingInput PagingOptions { get; set; }
    }
}


namespace NyFund.Core.Framework.Paging
{
    public class PagingResult<T>
    {
        public int Page { get; set; }
        public int Size { get; set; }
        public int TotalPage { get; set; }
        public int TotalSize { get; set; }
        public List<T> Result { get; set; }
    }
}

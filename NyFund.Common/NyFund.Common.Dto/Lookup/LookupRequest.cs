using NyFund.Core.Framework.Paging;

namespace NyFund.Common.Dto.Lookup
{
    public class LookupRequest : PagingRequest
    {
        public long MasterId { get; set; }
        public string SearchText { get; set; }
    }
}

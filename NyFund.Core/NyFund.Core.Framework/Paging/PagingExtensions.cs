using Microsoft.EntityFrameworkCore;

namespace NyFund.Core.Framework.Paging
{
    public static class PagingExtensions
    {
        public static async Task<PagingResult<T>> ToPagedListAsync<T>(this IQueryable<T> query, PagingRequest paging)
        {
            var response = new PagingResult<T>();

            if (paging.Page <= 0)
            {
                response.Result = await query.ToListAsync();
                response.Size = await query.CountAsync();
                response.Page = 1;
                response.TotalSize = response.Size;
                response.TotalPage = 1;
                return response;
            }

            if (paging.Size < 1)
                paging.Size = 100;

            var rowsToSkip = (paging.Page - 1) * paging.Size;
            var data =  await query.Skip(rowsToSkip).Take(paging.Size).AsQueryable().ToListAsync();
            var size = data.Count();
            var page = paging.Page;
            var totalSize = await query.CountAsync();
            var totalPage = (int)Math.Ceiling((double)size / paging.Size);

            response.Result = data;
            response.Page = page;
            response.Size = size;
            response.TotalSize = totalSize;
            response.TotalPage = totalPage;

            return response;
        }
    }
}

using Book.uz.PaginationModels;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Book.uz.Extensions;

public static class QueryableExtensions
{
    public static async Task<IEnumerable<TEntity>> ToPagedListAsync<TEntity>(this IQueryable<TEntity> source,
        HttpContextHelper httpContextHelper, PaginationParams filterParams)
    {
        var content = JsonConvert.SerializeObject(
            new PaginationMetaData(source.Count(), filterParams.AmountData, filterParams.PageNumber));

        httpContextHelper.AddResponseToHeader("X-Pagination", content);

        return await source.Skip(filterParams.AmountData * (filterParams.PageNumber - 1)).
            Take(filterParams.AmountData).ToListAsync();
    }
    
}
using Application.Features;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Paging;

public static class PagingExtensions
{
    public static async Task<PagedList<T>> ToPagedListAsync<T>(
            this IQueryable<T> source,
            int currentPage,
            int pageSize,
            CancellationToken cancellationToken = default)
    {
        currentPage = currentPage <= 0 ? 1 : currentPage;
        pageSize = pageSize <= 0 ? 10 : pageSize;

        var count = await source.CountAsync(cancellationToken);
        var items = await source
            .Skip((currentPage - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

        return new PagedList<T>(items, count, currentPage, pageSize);
    }
}

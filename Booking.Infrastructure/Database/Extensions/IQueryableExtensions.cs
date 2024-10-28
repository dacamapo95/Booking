using Booking.Application.Models;
using Microsoft.EntityFrameworkCore;

namespace Booking.Infrastructure.Database.Extensions;

public static class IQueryableExtensions
{
    public static async Task<PaginationResponse<T>> ToPagedListAsync<T>(this IQueryable<T> source, int pageNumber, int pageSize)
    {
        var totalRecords = await source.CountAsync();
        var data = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        return new PaginationResponse<T>(data, totalRecords, pageNumber, pageSize);
    }


}

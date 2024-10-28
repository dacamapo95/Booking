using Booking.Domain.Entities;
using Booking.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Booking.Infrastructure.Database.Repositories;
public class FloorRepository(ApplicationDbContext context) : IFloorRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task<Floor[]> GetAllAsync(CancellationToken cancellation = default)
    {
        return await _context.Floors.AsNoTracking().ToArrayAsync(cancellation);
    }
}
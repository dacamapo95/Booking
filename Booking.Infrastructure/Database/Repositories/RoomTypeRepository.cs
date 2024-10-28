using Booking.Domain.Entities;
using Booking.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Booking.Infrastructure.Database.Repositories;
public class RoomTypeRepository(ApplicationDbContext context) : IRoomTypeRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task<RoomType[]> GetAllAsync(CancellationToken cancellationToken = default) =>
        await _context.RoomTypes.AsNoTracking().ToArrayAsync(cancellationToken);
}

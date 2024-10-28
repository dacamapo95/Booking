using Booking.Domain.Entities;
using Booking.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Booking.Infrastructure.Database.Repositories;

public class ReservationStatusesRepository(ApplicationDbContext dbContext) : IReservationStatusesRepository
{
    private readonly ApplicationDbContext _dbContext = dbContext;

    public async Task<List<ReservationStatus>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.ReservationStatuses.AsNoTracking().ToListAsync(cancellationToken);   
    }
}
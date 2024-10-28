using Booking.Domain.Entities;

namespace Booking.Domain.Repositories;

public interface IReservationStatusesRepository
{
    public Task<List<ReservationStatus>> GetAllAsync(CancellationToken cancellationToken = default);
}
using Booking.Domain.Entities;

namespace Booking.Domain.Repositories;

public interface IRoomTypeRepository
{
    Task<RoomType[]> GetAllAsync(CancellationToken cancellationToken = default);
}
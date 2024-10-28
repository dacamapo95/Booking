using Booking.Domain.Entities;
namespace Booking.Domain.Repositories;

public interface IHotelRepository

{
    void Add(Hotel hotel);

    Task<Hotel?> FindByIdAsync(Guid id);

    Task<Hotel?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<bool> IsAnyHotelWithName(string name, CancellationToken cancellationToken = default);

    Task<bool> IsAnyRoomWithRoomNumber(Guid hotelId, int roomNumber, CancellationToken cancellationToken = default);
    
    Task<int> GetRoomsCount(Guid hotelId, CancellationToken cancellationToken = default);
    
    Task<Room?> GetRoomByIdAsync(Guid hotelId, Guid roomId, CancellationToken cancellationToken = default);

    Task<Room[]> GetRoomsAsync(Guid hotelId, CancellationToken cancellationToken = default);
}
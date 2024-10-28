using Booking.Domain.Primitives;

namespace Booking.Domain.Entities;

public class RoomType : MasterEntity<Guid>
{
    public int MaxCapacity { get; set; }
    public ICollection<Room> Rooms { get; } = [];
}
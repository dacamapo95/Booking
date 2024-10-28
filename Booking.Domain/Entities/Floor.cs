using Booking.Domain.Primitives;

namespace Booking.Domain.Entities;

public class Floor : AuditableEntity<Guid>
{
    public int FloorNumber { get; set; }
    public string Description { get; set; }
    public ICollection<Location> Locations { get; } = [];
}
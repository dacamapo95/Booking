using Booking.Domain.Primitives;

namespace Booking.Domain.Entities;

public class Location : AuditableEntity<Guid>
{
    public string AdditionalInfo { get; set; }
    public Guid FloorId { get; set; }
    public Floor Floor { get; set; }

    public Guid RoomId { get; set; }

    public Room Room { get; set; }

    public static Location Create(string additionalInfo, Guid floorId)
    {
        return new Location
        {
            AdditionalInfo = additionalInfo,
            FloorId = floorId
        };
    }
}
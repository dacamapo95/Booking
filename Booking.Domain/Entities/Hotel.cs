using Booking.Domain.Primitives;

namespace Booking.Domain.Entities;

public class Hotel : AuditableEntity<Guid>
{
    public string Name { get; set; }
    public string Address { get; set; }
    public bool IsEnabled { get; set; }
    public int MaxRooms { get; set; }
    public Guid CityId { get; set; }
    public City City { get; set; }
    public ICollection<Room> Rooms { get; } = [];

    public static Hotel Create(string name, string address, bool isEnabled, int maxRooms, Guid cityId)
    {
        return new Hotel
        {
            Name = name,
            Address = address,
            IsEnabled = isEnabled,
            MaxRooms = maxRooms,
            CityId = cityId,
        };
    }
}

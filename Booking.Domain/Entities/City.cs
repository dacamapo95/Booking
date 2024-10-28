using Booking.Domain.Primitives;

namespace Booking.Domain.Entities;

public class City : MasterEntity<Guid>
{
    public Guid CountryId { get; set; }
    public Country Country { get; set; }
    public ICollection<Hotel> Hotels { get; } = [];
}
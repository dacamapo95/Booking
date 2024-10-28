using Booking.Domain.Primitives;

namespace Booking.Domain.Entities;

public class Country : MasterEntity<Guid>
{
    public ICollection<City> Cities { get; } = [];
}

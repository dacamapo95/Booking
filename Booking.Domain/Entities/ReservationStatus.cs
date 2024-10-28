using Booking.Domain.Primitives;

namespace Booking.Domain.Entities;

public class ReservationStatus : MasterEntity<int>
{
    public virtual ICollection<Reservation> Reservations { get; } = [];
}

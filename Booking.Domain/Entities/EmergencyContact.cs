using Booking.Domain.Primitives;

namespace Booking.Domain.Entities;

public class EmergencyContact : AuditableEntity<Guid>
{
    public string FullName { get; set; }
    public string PhoneNumber { get; set; }
    public Guid ReservationId { get; set; }
    public Reservation Reservation { get; set; }

    public static EmergencyContact Create(string fullName, string phoneNumber)
    {
        return new EmergencyContact
        {
            FullName = fullName,
            PhoneNumber = phoneNumber
        };
    }
}
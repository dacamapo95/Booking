using Booking.Domain.Primitives;

namespace Booking.Domain.Entities;

public class Guest : AuditableEntity<Guid>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public Guid ReservationId { get; set; }
    public Reservation Reservation { get; set; }

    public static Guest Create(string firstName, string lastName, string email, string phoneNumber)
    {
        return new Guest
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            PhoneNumber = phoneNumber
        };
    }
}

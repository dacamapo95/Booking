namespace Booking.Application.Features.Reservations.Create;

public class ReservationRequest 
{
    public DateTime ReservationDate { get; set; }
    public DateTime? CheckInDate { get; set; }
    public DateTime? CheckOutDate { get; set; }
    public int NumberOfNights { get; set; }
    public int NumberOfGuests { get; set; }
    public string? SpecialRequests { get; set; }
    public EmergencyContactRequest EmergencyContact { get; set; }
    public List<GuestRequest> Guests { get; set; }
}

public class GuestRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
}

public class EmergencyContactRequest
{
    public string FullName { get; set; }
    public string PhoneNumber { get; set; }
}

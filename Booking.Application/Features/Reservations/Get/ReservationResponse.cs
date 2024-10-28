namespace Booking.Application.Features.Reservations.Get;

public class ReservationResponse
{
    public Guid Id { get; set; }
    public DateTime ReservationDate { get; set; }
    public DateTime? CheckInDate { get; set; }
    public DateTime? CheckOutDate { get; set; }
    public decimal TotalCost { get; set; }
    public int NumberOfGuests { get; set; }
}
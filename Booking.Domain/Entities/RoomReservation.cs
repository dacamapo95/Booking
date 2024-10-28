namespace Booking.Domain.Entities;

public class RoomReservation 
{
    public Guid RoomId { get; set; }
    public Room Room { get; set; }

    public Guid ReservationId { get; set; }
    public Reservation Reservation { get; set; }
}
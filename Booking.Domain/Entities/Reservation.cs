using Booking.Domain.Primitives;

namespace Booking.Domain.Entities;

public class Reservation : AuditableEntity<Guid>
{
    public DateTime ReservationDate { get; set; }
    public DateTime? CheckInDate { get; set; }
    public DateTime? CheckOutDate { get; set; }
    public decimal TotalCost { get; set; }
    public int NumberOfGuests { get; set; }
    public string? SpecialRequests { get; set; }
    public int ReservationStatusId { get; set; }
    public ReservationStatus ReservationStatus { get; set; }
    public EmergencyContact EmergencyContact { get; set; }
    public ICollection<Guest> Guests { get; } = new List<Guest>();
    public ICollection<RoomReservation> RoomReservations { get; } = new List<RoomReservation>();

    public static Reservation Create(
        DateTime reservationDate,
        DateTime? checkInDate,
        DateTime? checkOutDate,
        decimal totalCost,
        int numberOfGuests,
        string? specialRequests,
        int reservationStatusId,
        EmergencyContact emergencyContact)
    {
        return new Reservation
        {
            ReservationDate = reservationDate,
            CheckInDate = checkInDate,
            CheckOutDate = checkOutDate,
            TotalCost = totalCost,
            NumberOfGuests = numberOfGuests,
            SpecialRequests = specialRequests,
            ReservationStatusId = reservationStatusId,
            EmergencyContact = emergencyContact
        };
    }
}
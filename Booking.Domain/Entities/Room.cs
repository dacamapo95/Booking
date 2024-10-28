using Booking.Domain.Primitives;

namespace Booking.Domain.Entities;

public class Room : AuditableEntity<Guid>
{
    public int RoomNumber { get; set; }
    public int Capacity { get; set; }
    public decimal BaseCost { get; set; }
    public decimal Taxes { get; set; }
    public decimal PricePerNight { get; set; }
    public bool IsEnabled { get; set; }
    public Guid HotelId { get; set; }
    public Hotel Hotel { get; set; }
    public Guid RoomTypeId { get; set; }
    public RoomType RoomType { get; set; }
    public Location Location { get; set; }

    public ICollection<RoomReservation> RoomReservations { get; } = [];

    public static Room Create(
        int roomNumber,
        int capacity, 
        decimal baseCost,
        decimal taxes, 
        decimal pricePerNight,
        bool isEnabled,
        Guid roomTypeId,
        Location Location)
    {
        return new Room
        {
            RoomNumber = roomNumber,
            Capacity = capacity,
            BaseCost = baseCost,
            Taxes = taxes,
            PricePerNight = pricePerNight,
            IsEnabled = isEnabled,
            RoomTypeId = roomTypeId,
            Location = Location
        };
    }
}
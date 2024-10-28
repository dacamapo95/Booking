namespace Booking.Application.Features.Hotels.Create;

public abstract class BaseHotelModel
{
    public string Name { get; set; }
    public string Address { get; set; }
    public bool IsEnabled { get; set; }
    public int MaxRooms { get; set; }
    public Guid CityId { get; set; }
}

public abstract class BaseRoomModel
{
    public int RoomNumber { get; set; }
    public int Capacity { get; set; }
    public decimal BaseCost { get; set; }
    public decimal Taxes { get; set; }
    public decimal PricePerNight { get; set; }
    public bool IsEnabled { get; set; }
    public Guid RoomTypeId { get; set; }
}

public abstract class BaseLocationModel
{
    public string AdditionalInfo { get; set; }
    public Guid FloorId { get; set; }

}
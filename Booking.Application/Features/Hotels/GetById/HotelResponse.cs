using Booking.Application.Features.Hotels.Create;

namespace Booking.Application.Features.Hotels.GetById;

public class HotelResponse : BaseHotelModel
{
    public Guid Id { get; set; }
    
    public List<RoomResponse> Rooms { get; set; }
}

public class RoomResponse : BaseRoomModel
{
    public Guid Id { get; set; }
    public LocationResponse Location { get; set; }
}

public class LocationResponse : BaseLocationModel
{
    public Guid Id { get; set; }
}
namespace Booking.Application.Features.Hotels.Create;

public class CreateHotelRequest : BaseHotelModel
{
    public List<RoomRequest> Rooms { get; set; }
}

public class RoomRequest : BaseRoomModel
{
    public LocationRequest Location { get; set; }
}

public class LocationRequest : BaseLocationModel
{

}

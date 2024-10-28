using Booking.Application.Core.Abstractions;
using Booking.Application.Features.Hotels.Create;

namespace Booking.Application.Features.Hotels.CreateRoom;

public class CreateRoomCommand(Guid hotelId, RoomRequest roomRequest) : ICommand
{
    public Guid HotelId { get; set; } = hotelId;
    public RoomRequest RoomRequest { get; set; } = roomRequest;
}
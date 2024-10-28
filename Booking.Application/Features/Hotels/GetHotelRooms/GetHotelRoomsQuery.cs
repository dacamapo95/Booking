using Booking.Application.Core.Abstractions;
using Booking.Application.Features.Hotels.GetById;

namespace Booking.Application.Features.Hotels.GetHotelRooms;

public record GetHotelRoomsQuery(Guid HotelId) : IQuery<RoomResponse[]>;
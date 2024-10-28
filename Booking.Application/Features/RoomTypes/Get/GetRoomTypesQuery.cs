using Booking.Application.Core.Abstractions;
namespace Booking.Application.Features.RoomTypes.Get;

public sealed record class GetRoomTypesQuery : IQuery<RoomTypeResponse[]>;

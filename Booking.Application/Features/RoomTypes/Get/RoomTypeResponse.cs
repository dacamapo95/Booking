namespace Booking.Application.Features.RoomTypes.Get;

public sealed record RoomTypeResponse(
    Guid Id,
    string Name,
    string MaxCapacity);
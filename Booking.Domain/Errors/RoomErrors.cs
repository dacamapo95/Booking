using Booking.Domain.Result;

namespace Booking.Domain.Errors;
public static class RoomErrors 
{

    public static Error RoomTypesNotFound => Error.NotFound("Room types not found.");

    public static Error FloorsNotFound => Error.NotFound("Floors not found.");

    public static Error RoomIsDisabled(Guid roomId) =>
        Error.BadRequest($"Room with id {roomId} is disabled.");
}


using Booking.Domain.Result;

namespace Booking.Domain.Errors;

public static class HotelErrors
{
    public static Error HotelNotFound(Guid id) =>  Error.NotFound($"Hotel with id {id} was not found.");

    public static Error HotelNameAlreadyExists(string name) => Error.BadRequest($"Hotel with name {name} already exists.");

    public static Result.Result RoomNumberAlreadyExists(int roomNumber) =>
        Error.BadRequest($"Room with number {roomNumber} already exists.");
    
    public static Error MaxRoomsLessThanRoomsCount(int roomsCount)
        => Error.BadRequest($"Max rooms cannot be less than rooms count. Rooms count: {roomsCount}");

    public static Error RoomNotFound(Guid requestHotelId, Guid requestRoomId) =>
        Error.NotFound($"Room with id {requestRoomId} in hotel with id {requestHotelId} was not found.");

    public static Error HotelIsDisabled(Guid hotelId) =>
        Error.BadRequest($"Hotel with id {hotelId} is disabled.");

    public static Error ReservationInRoomInProgress(Guid roomId) =>
        Error.BadRequest($"There is a reservation in progress in room with id {roomId}.");
}

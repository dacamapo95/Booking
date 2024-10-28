
using Booking.Application.Core.Abstractions;

namespace Booking.Application.Features.Reservations.Create;
public sealed record CreateReservationCommand(
    Guid HotelId,
    Guid RoomId,
    ReservationRequest ReservationRequest
    ) : ICommand<Guid>;
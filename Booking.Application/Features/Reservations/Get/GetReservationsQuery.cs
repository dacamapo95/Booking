using Booking.Application.Core.Abstractions;
using Booking.Application.Models;

namespace Booking.Application.Features.Reservations.Get;

public record GetReservationsQuery(
    int PageNumber,
    int PageSize,
    DateTime? ReservationDate,
    DateTime? CheckInDate,
    DateTime? CheckOutDate,
    int? ReservationStatusId,
    int? NumberOfGuests) : IQuery<PaginationResponse<ReservationResponse>>;
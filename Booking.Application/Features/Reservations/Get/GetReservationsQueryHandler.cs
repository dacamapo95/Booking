using Booking.Application.Core.Abstractions;
using Booking.Application.Models;
using Booking.Domain.Repositories;
using Booking.Domain.Result;
using Mapster;

namespace Booking.Application.Features.Reservations.Get;

internal class GetReservationsQueryHandler : IQueryHandler<GetReservationsQuery, PaginationResponse<ReservationResponse>>
{
    private readonly IReservationRepository _reservationRepository;

    public GetReservationsQueryHandler(IReservationRepository reservationRepository)
    {
        _reservationRepository = reservationRepository;
    }

    public async Task<Result<PaginationResponse<ReservationResponse>>> Handle(GetReservationsQuery request, CancellationToken cancellationToken)
    {
        var reservations = await _reservationRepository.GetAll(
            request.PageNumber,
            request.PageSize,
            request.ReservationDate,
            request.CheckInDate,
            request.CheckOutDate, 
            request.ReservationStatusId, 
            request.NumberOfGuests,
            cancellationToken);

        var reservationsResponse = reservations.Reservations.Adapt<List<ReservationResponse>>();

        return new PaginationResponse<ReservationResponse>(
            reservationsResponse,
            reservations.TotalRecords, 
            reservations.PageNumber, 
            reservations.PageSize);
    }
}

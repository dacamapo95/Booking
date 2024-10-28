using Booking.Application.Core.Abstractions;
using Booking.Application.Models;
using Booking.Domain.Errors;
using Booking.Domain.Repositories;
using Booking.Domain.Result;
using Mapster;

namespace Booking.Application.Features.ReservationStatuses.Get;

public class GetReservationStatusesQueryHandler(IReservationStatusesRepository reservationStatusesRepository)
    : IQueryHandler<GetReservationStatusesQuery, MasterEntityResponse<int>[]>
{
    private readonly IReservationStatusesRepository _reservationStatusesRepository = reservationStatusesRepository;

    public async Task<Result<MasterEntityResponse<int>[]>> Handle(GetReservationStatusesQuery request, CancellationToken cancellationToken)
    {
        var statuses = await _reservationStatusesRepository.GetAllAsync(cancellationToken);
        
        if (statuses.Count == 0)
            return SharedErrors.MasterEntityNotFound(nameof(ReservationStatuses));
        
        return statuses.Adapt<MasterEntityResponse<int>[]>();
    }
}
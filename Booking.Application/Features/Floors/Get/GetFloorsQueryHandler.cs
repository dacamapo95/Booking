using Booking.Application.Core.Abstractions;
using Booking.Domain.Errors;
using Booking.Domain.Repositories;
using Booking.Domain.Result;
using Mapster;

namespace Booking.Application.Features.Floors.Get;

public class GetFloorsQueryHandler(IFloorRepository floorRepository)
    : IQueryHandler<GetFloorsQuery, FloorResponse[]>
{
    private readonly IFloorRepository _floorRepository = floorRepository;

    public async Task<Result<FloorResponse[]>> Handle(GetFloorsQuery request, CancellationToken cancellationToken)
    {
        var floors = await _floorRepository.GetAllAsync(cancellationToken);

        if (floors.Length == 0)
        {
            return RoomErrors.FloorsNotFound;
        }

        return floors.Adapt<FloorResponse[]>();
    }
}

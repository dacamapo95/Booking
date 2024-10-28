using Booking.Application.Core.Abstractions;
using Booking.Domain.Errors;
using Booking.Domain.Repositories;
using Booking.Domain.Result;
using Mapster;

namespace Booking.Application.Features.RoomTypes.Get;

public class GetRoomTypesQueryHandler(IRoomTypeRepository roomTypeRepository) : IQueryHandler<GetRoomTypesQuery, RoomTypeResponse[]>
{
    private readonly IRoomTypeRepository _roomTypeRepository = roomTypeRepository;

    public async Task<Result<RoomTypeResponse[]>> Handle(GetRoomTypesQuery request, CancellationToken cancellationToken)
    {
        var roomTypes = await _roomTypeRepository.GetAllAsync(cancellationToken);

        if (roomTypes.Length == 0) return RoomErrors.RoomTypesNotFound;

        return roomTypes.Adapt<RoomTypeResponse[]>();
    }
}

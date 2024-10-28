using Booking.Application.Core.Abstractions;
using Booking.Application.Features.Hotels.GetById;
using Booking.Domain.Repositories;
using Booking.Domain.Result;
using Mapster;

namespace Booking.Application.Features.Hotels.GetHotelRooms;

public class GetHotelRoomsQueryHandler(IHotelRepository repositoryRepository) 
    : IQueryHandler<GetHotelRoomsQuery, RoomResponse[]>
{
    public readonly IHotelRepository _repositoryRepository = repositoryRepository;

    public async Task<Result<RoomResponse[]>> Handle(GetHotelRoomsQuery request, CancellationToken cancellationToken)
    {
        var rooms = await _repositoryRepository.GetRoomsAsync(request.HotelId, cancellationToken);
        return rooms.Adapt<RoomResponse[]>();   
    }
}

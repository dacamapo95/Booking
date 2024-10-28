using Booking.Application.Core.Abstractions;
using Booking.Domain.Entities;
using Booking.Domain.Errors;
using Booking.Domain.Repositories;
using Booking.Domain.Result;

namespace Booking.Application.Features.Hotels.CreateRoom;
internal class CreateRoomCommandHandler(IHotelRepository hotelRepository,
    IUnitOfWork unitOfWork) : ICommandHandler<CreateRoomCommand>
{
    private readonly IHotelRepository _hotelRepository = hotelRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Result> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
    {
        var hotel = await _hotelRepository.FindByIdAsync(request.HotelId);

        if (hotel is null)
        {
            return HotelErrors.HotelNotFound(request.HotelId);
        }

        if (await _hotelRepository.IsAnyRoomWithRoomNumber(request.HotelId, request.RoomRequest.RoomNumber))
        {
            return HotelErrors.RoomNumberAlreadyExists(request.RoomRequest.RoomNumber);
        }

        hotel.Rooms.Add(
            Room.Create(
                request.RoomRequest.RoomNumber,
                request.RoomRequest.Capacity,
                request.RoomRequest.BaseCost,
                request.RoomRequest.Taxes,
                request.RoomRequest.PricePerNight,
                request.RoomRequest.IsEnabled,
                request.RoomRequest.RoomTypeId,
                Location.Create(
                    request.RoomRequest.Location.AdditionalInfo,
                    request.RoomRequest.Location.FloorId)
            ));

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}
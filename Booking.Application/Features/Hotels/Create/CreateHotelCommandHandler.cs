using Booking.Application.Core.Abstractions;
using Booking.Domain.Entities;
using Booking.Domain.Errors;
using Booking.Domain.Repositories;
using Booking.Domain.Result;

namespace Booking.Application.Features.Hotels.Create;
public class CreateHotelCommandHandler(
    IHotelRepository hotelRepository, 
    IUnitOfWork unitOfWork) : ICommandHandler<CreateHotelCommand, Guid>
{
    private readonly IHotelRepository _hotelRepository = hotelRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Result<Guid>> Handle(CreateHotelCommand request, CancellationToken cancellationToken)
    {
        if (await _hotelRepository.IsAnyHotelWithName(request.CreateHotelRequest.Name, cancellationToken))
        {
            return HotelErrors.HotelNameAlreadyExists(request.CreateHotelRequest.Name);
        }

        var hotel = Hotel.Create(
            request.CreateHotelRequest.Name,
            request.CreateHotelRequest.Address,
            request.CreateHotelRequest.IsEnabled,
            request.CreateHotelRequest.MaxRooms,
            request.CreateHotelRequest.CityId);

        foreach (var roomRequest in request.CreateHotelRequest.Rooms)
        {
            hotel.Rooms.Add(Room.Create(
                roomRequest.RoomNumber,
                roomRequest.Capacity,
                roomRequest.BaseCost,
                roomRequest.Taxes,
                roomRequest.PricePerNight,
                roomRequest.IsEnabled,
                roomRequest.RoomTypeId,
                Location.Create(
                    roomRequest.Location.AdditionalInfo,
                    roomRequest.Location.FloorId)
            ));
        }

        _hotelRepository.Add(hotel);
        await _unitOfWork.SaveChangesAsync(cancellationToken);   

        return hotel.Id;
    }
}
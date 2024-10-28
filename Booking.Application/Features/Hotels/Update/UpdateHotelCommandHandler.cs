using Booking.Application.Core.Abstractions;
using Booking.Application.Core.Common;
using Booking.Domain.Errors;
using Booking.Domain.Repositories;
using Booking.Domain.Result;
using FluentValidation;
using Mapster;

namespace Booking.Application.Features.Hotels.Update;

public class UpdateHotelCommandHandler(
    IHotelRepository hotelRepository,
    IValidator<UpdateHotelRequest> validator,
    IUnitOfWork unitOfWork) : ICommandHandler<UpdateHotelCommand>
{
    private readonly IHotelRepository _hotelRepository = hotelRepository;
    private readonly IValidator<UpdateHotelRequest> _validator = validator;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Result> Handle(UpdateHotelCommand request, CancellationToken cancellationToken)
    {
        var hotel = await _hotelRepository.FindByIdAsync(request.HotelId);

        if (hotel is null)
            return HotelErrors.HotelNotFound(request.HotelId);

        var hotelRequest = hotel.Adapt<UpdateHotelRequest>();
        request.JsonPatchDocument.ApplyTo(hotelRequest);

        var validationResult = await _validator.ValidateAsync(hotelRequest, cancellationToken);

        if (!validationResult.IsValid)
            return ValidationResult.WithErrors(validationResult.ToResultValidationErrors());
        
        var roomsCount = await _hotelRepository.GetRoomsCount(request.HotelId, cancellationToken);
        
        if (hotelRequest.MaxRooms < roomsCount)
            return HotelErrors.MaxRoomsLessThanRoomsCount(roomsCount);

        hotelRequest.Adapt(hotel);
        
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        
        return Result.Success();
    }
}
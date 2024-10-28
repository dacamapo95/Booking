using Booking.Application.Core.Abstractions;
using Booking.Application.Core.Common;
using Booking.Application.Features.Hotels.Create;
using Booking.Domain.Errors;
using Booking.Domain.Repositories;
using Booking.Domain.Result;
using FluentValidation;
using Mapster;

namespace Booking.Application.Features.Hotels.UpdateRoom;

public class UpdateRoomCommandHandler(
    IHotelRepository hotelRepository,
    IUnitOfWork unitOfWork, 
    IValidator<RoomRequest> validator)
    : ICommandHandler<UpdateRoomCommand>
{
    private readonly IHotelRepository _hotelRepository = hotelRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IValidator<RoomRequest> _validator = validator;

    public async Task<Result> Handle(UpdateRoomCommand request, CancellationToken cancellationToken)
    {
        var room = await _hotelRepository.GetRoomByIdAsync(request.HotelId, request.RoomId, cancellationToken);
        
        if (room is null)
        {
            return HotelErrors.RoomNotFound(request.HotelId, request.RoomId);
        }
        
        var updateRoomRequest = room.Adapt<RoomRequest>();
        request.PatchDocument.ApplyTo(updateRoomRequest);
        
        var validationResult = await _validator.ValidateAsync(updateRoomRequest, cancellationToken);
        
        if (!validationResult.IsValid)
        {
            return ValidationResult.WithErrors(validationResult.ToResultValidationErrors());
        }
        
        if (room.RoomNumber != updateRoomRequest.RoomNumber &&
            await _hotelRepository.IsAnyRoomWithRoomNumber(request.HotelId, updateRoomRequest.RoomNumber, cancellationToken))
        {
            return HotelErrors.RoomNumberAlreadyExists(updateRoomRequest.RoomNumber);
        }
        
        updateRoomRequest.Adapt(room);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}
using Booking.Application.Features.Hotels.Create;
using FluentValidation;

namespace Booking.Application.Features.Hotels.CreateRoom;
public class CreateRoomCommandValidator : AbstractValidator<CreateRoomCommand>
{
    public CreateRoomCommandValidator()
    {
        RuleFor(x => x.HotelId)
            .NotEmpty().WithMessage("HotelId is required.");

        RuleFor(x => x.RoomRequest)
            .NotNull().WithMessage("RoomRequest is required.")
            .SetValidator(new RoomRequestValidator());
    }
}

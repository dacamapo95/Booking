using FluentValidation;

namespace Booking.Application.Features.Hotels.Update;

public class UpdateHotelCommandValidator : AbstractValidator<UpdateHotelRequest>
{
    public UpdateHotelCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Hotel name is required.")
            .MaximumLength(100).WithMessage("Hotel name must not exceed 100 characters.");

        RuleFor(x => x.Address)
            .NotEmpty().WithMessage("Hotel address is required.")
            .MaximumLength(200).WithMessage("Hotel address must not exceed 200 characters.");

        RuleFor(x => x.CityId)
            .NotEmpty().WithMessage("CityId is required.");
    }
}
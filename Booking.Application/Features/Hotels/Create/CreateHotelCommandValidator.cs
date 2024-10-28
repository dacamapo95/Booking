using FluentValidation;

namespace Booking.Application.Features.Hotels.Create;
public class CreateHotelCommandValidator : AbstractValidator<CreateHotelCommand>
{
    public CreateHotelCommandValidator()
    {
        RuleFor(x => x.CreateHotelRequest)
            .NotNull().WithMessage("CreateHotelRequest is required.");

        RuleFor(x => x.CreateHotelRequest.Name)
            .NotEmpty().WithMessage("Hotel name is required.")
            .MaximumLength(100).WithMessage("Hotel name must not exceed 100 characters.");

        RuleFor(x => x.CreateHotelRequest.Address)
            .NotEmpty().WithMessage("Hotel address is required.")
            .MaximumLength(200).WithMessage("Hotel address must not exceed 200 characters.");

        RuleFor(x => x.CreateHotelRequest.CityId)
            .NotEmpty().WithMessage("CityId is required.");

        RuleFor(x => x.CreateHotelRequest.Rooms)
            .NotEmpty().WithMessage("At least one room is required.");

        RuleForEach(x => x.CreateHotelRequest.Rooms)
            .SetValidator(new RoomRequestValidator());
    }
}

public class RoomRequestValidator : AbstractValidator<RoomRequest>
{
    public RoomRequestValidator()
    {
        RuleFor(x => x.RoomNumber)
            .GreaterThan(0).WithMessage("Room number must be greater than 0.");

        RuleFor(x => x.Capacity)
            .GreaterThan(0).WithMessage("Room capacity must be greater than 0.");

        RuleFor(x => x.BaseCost)
            .GreaterThan(0).WithMessage("Base cost must be greater than 0.");

        RuleFor(x => x.PricePerNight)
            .GreaterThan(0).WithMessage("Price per night must be greater than 0.");

        RuleFor(x => x.RoomTypeId)
            .NotEmpty().WithMessage("RoomTypeId is required.");

        RuleFor(x => x.Location)
            .SetValidator(new LocationRequestValidator());
    }
}
public class LocationRequestValidator : AbstractValidator<LocationRequest>
{
    public LocationRequestValidator()
    {
        RuleFor(x => x.AdditionalInfo)
            .NotEmpty().WithMessage("Additional info is required.")
            .MaximumLength(100).WithMessage("Additional info must not exceed 100 characters.");

        RuleFor(x => x.FloorId)
            .NotEmpty().WithMessage("FloorId is required.");
    }
}
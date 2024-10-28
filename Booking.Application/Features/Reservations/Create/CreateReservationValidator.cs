using FluentValidation;

namespace Booking.Application.Features.Reservations.Create;

public class CreateReservationCommandValidator : AbstractValidator<CreateReservationCommand>
{
    public CreateReservationCommandValidator()
    {
        RuleFor(x => x.HotelId)
            .NotEmpty().WithMessage("Hotel ID is required.");

        RuleFor(x => x.RoomId)
            .NotEmpty().WithMessage("Room ID is required.");

        RuleFor(x => x.ReservationRequest)
            .NotNull().WithMessage("Reservation request is required.")
            .SetValidator(new ReservationRequestValidator());
    }
}

public class ReservationRequestValidator : AbstractValidator<ReservationRequest>
{
    public ReservationRequestValidator()
    {
        RuleFor(x => x.ReservationDate)
            .NotEmpty().WithMessage("Reservation date is required.");

        RuleFor(x => x.CheckInDate)
            .NotEmpty().WithMessage("Check-in date is required.")
            .GreaterThanOrEqualTo(x => x.ReservationDate).WithMessage("Check-in date must be on or after the reservation date.");

        RuleFor(x => x.CheckOutDate)
            .NotEmpty().WithMessage("Check-out date is required.")
            .GreaterThan(x => x.CheckInDate).WithMessage("Check-out date must be after the check-in date.");

        RuleFor(x => x.NumberOfNights)
            .GreaterThan(0).WithMessage("Number of nights must be greater than zero.");

        RuleFor(x => x.NumberOfGuests)
            .GreaterThan(0).WithMessage("Number of guests must be greater than zero.");

        RuleFor(x => x.SpecialRequests)
            .MaximumLength(500).WithMessage("Special requests must be less than 500 characters.");

        RuleFor(x => x.EmergencyContact)
            .NotNull().WithMessage("Emergency contact is required.")
            .SetValidator(new EmergencyContactRequestValidator());

        RuleForEach(x => x.Guests)
            .SetValidator(new GuestRequestValidator());
    }
}

public class EmergencyContactRequestValidator : AbstractValidator<EmergencyContactRequest>
{
    public EmergencyContactRequestValidator()
    {
        RuleFor(x => x.FullName)
            .NotEmpty().WithMessage("Full name is required.")
            .MaximumLength(100).WithMessage("Full name must be less than 100 characters.");

        RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage("Phone number is required.")
            .MaximumLength(15).WithMessage("Phone number must be less than 15 characters.");
    }
}

public class GuestRequestValidator : AbstractValidator<GuestRequest>
{
    public GuestRequestValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("First name is required.");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Last name is required.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email format.");

        RuleFor(x => x.PhoneNumber)
        .NotEmpty().WithMessage("Phone number is required.")
        .MaximumLength(15).WithMessage("Phone number must be less than 15 characters.");
    }
}

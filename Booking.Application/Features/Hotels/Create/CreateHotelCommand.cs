using Booking.Application.Core.Abstractions;

namespace Booking.Application.Features.Hotels.Create;

public sealed record class CreateHotelCommand(
    CreateHotelRequest CreateHotelRequest
    ) : ICommand<Guid>;
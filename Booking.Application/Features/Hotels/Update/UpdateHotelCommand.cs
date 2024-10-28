
using Booking.Application.Core.Abstractions;
using Booking.Application.Features.Hotels.Create;
using Microsoft.AspNetCore.JsonPatch;

namespace Booking.Application.Features.Hotels.Update;

public record UpdateHotelCommand(
    Guid HotelId,
    JsonPatchDocument<UpdateHotelRequest> JsonPatchDocument) : ICommand;
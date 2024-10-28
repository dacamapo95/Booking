using Booking.Application.Core.Abstractions;
using Booking.Application.Features.Hotels.Create;
using Microsoft.AspNetCore.JsonPatch;

namespace Booking.Application.Features.Hotels.UpdateRoom;

public record UpdateRoomCommand(
    Guid HotelId,
    Guid RoomId,
    JsonPatchDocument<RoomRequest> PatchDocument
    ) : ICommand;
using Booking.API.Infrastructure;
using Booking.Application.Features.RoomTypes.Get;
using Booking.Domain.Result;
using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Booking.API.Endpoints;

public class RoomTypes : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("api/room-types", async (ISender sender) =>
        {
            var result = await sender.Send(new GetRoomTypesQuery());
            return result.Match(Results.Ok, ResultExtensions.ResultToResponse);
        })
        .WithTags(nameof(RoomTypes))
        .WithOpenApi()
        .Produces<ProblemDetails>(StatusCodes.Status404NotFound)
        .Produces<RoomTypeResponse[]>(StatusCodes.Status200OK);
    }
}
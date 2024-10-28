using Booking.API.Infrastructure;
using Booking.Application.Features.Floors.Get;
using Booking.Domain.Result;
using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Booking.API.Endpoints;

public class Floors : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("api/floors", async(ISender sender) =>
        {
            var result = await  sender.Send(new GetFloorsQuery());
            return result.Match(Results.Ok, ResultExtensions.ResultToResponse);
        }).WithTags(nameof(Floors))
        .WithOpenApi()
        .Produces<ProblemDetails>(StatusCodes.Status404NotFound)
        .Produces<FloorResponse[]>(StatusCodes.Status200OK);
    }
}

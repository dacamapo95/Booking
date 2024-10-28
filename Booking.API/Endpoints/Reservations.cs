using Booking.API.Infrastructure;
using Booking.Application.Features.Reservations.Create;
using Booking.Application.Features.Reservations.Get;
using Booking.Application.Models;
using Booking.Domain.Result;
using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Booking.API.Endpoints;

public class Reservations : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/hotels/{id}/rooms/{roomId}")
             .WithTags(nameof(Reservations))
             .WithOpenApi();

        group.MapPost("/reservations", AddReservation)
            .Produces<ValidationProblemDetails>(StatusCodes.Status400BadRequest)
            .Produces<ProblemDetails>(StatusCodes.Status404NotFound)
            .Produces<Guid>(StatusCodes.Status201Created);

        app.MapGet("/reservations", GetReservations)
            .Produces<PaginationResponse<ReservationResponse>>(StatusCodes.Status200OK); 

    }

    private async Task<IResult> AddReservation(
        ISender sender,
        [FromRoute] Guid id,
        [FromRoute] Guid roomId,
        [FromBody] ReservationRequest request)
    {
        var command = new CreateReservationCommand(id, roomId, request);
        var result = await sender.Send(command);
        return result.Match(Results.Ok, ResultExtensions.ResultToResponse);
    }

    private async Task<IResult> GetReservations(
        ISender sender,
        [FromQuery] int pageNumber,
        [FromQuery] int pageSize, 
        [FromQuery] DateTime? reservationDate,
        [FromQuery] DateTime? checkInDate, 
        [FromQuery] DateTime? checkOutDate, 
        [FromQuery] int? reservationStatusId, 
        [FromQuery] int? numberOfGuests)
    {
        var query = new GetReservationsQuery(
            pageNumber,
            pageSize,
            reservationDate,
            checkInDate,
            checkOutDate,
            reservationStatusId,
            numberOfGuests);

        var result = await sender.Send(query);
        return result.Match(Results.Ok, ResultExtensions.ResultToResponse);
    }
}

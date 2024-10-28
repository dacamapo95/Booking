using Booking.API.Infrastructure;
using Booking.Application.Features.ReservationStatuses.Get;
using Booking.Domain.Result;
using Carter;
using MediatR;

namespace Booking.API.Endpoints;

public class ReservationStatuses : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGroup("/api/reservation-statuses")
            .WithTags(nameof(ReservationStatuses))
            .WithOpenApi()
            .MapGet("/", async (ISender sender) =>
            {
                var result = await sender.Send(new GetReservationStatusesQuery());
                return result.Match(Results.Ok, ResultExtensions.ResultToResponse);
            });
    }
}
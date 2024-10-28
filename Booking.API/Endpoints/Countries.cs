using Booking.API.Infrastructure;
using Booking.Application.Features.Countries.Get;
using Booking.Application.Features.Countries.GetCitiesByCountry;
using Booking.Application.Models;
using Booking.Domain.Result;
using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Booking.API.Endpoints;

public class Countries : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/countries")
            .WithTags(nameof(Countries))
            .WithOpenApi();

        group.MapGet("/", GetCountries)
            .Produces<ProblemDetails>(StatusCodes.Status404NotFound)
            .Produces<MasterEntityResponse<Guid>>(StatusCodes.Status200OK);

        group.MapGet("/{countryId}/cities", GetCityByCountryId)
            .Produces<ProblemDetails>(StatusCodes.Status404NotFound)
            .Produces<MasterEntityResponse<Guid>>(StatusCodes.Status200OK);
    }

    private async Task<IResult> GetCountries(ISender sender)
    {
        var result = await sender.Send(new GetCountriesQuery());
        return result.Match(Results.Ok, ResultExtensions.ResultToResponse);
    }

    private async Task<IResult> GetCityByCountryId(ISender sender, [FromRoute]Guid countryId)
    {
        var result = await sender.Send(new GetCitiesByCountryQuery(countryId));
        return result.Match(Results.Ok, ResultExtensions.ResultToResponse);
    }
}
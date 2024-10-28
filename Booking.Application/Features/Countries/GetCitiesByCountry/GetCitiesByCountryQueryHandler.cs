using Booking.Application.Core.Abstractions;
using Booking.Application.Models;
using Booking.Domain.Entities;
using Booking.Domain.Errors;
using Booking.Domain.Repositories;
using Booking.Domain.Result;
using Mapster;

namespace Booking.Application.Features.Countries.GetCitiesByCountry;

public sealed class GetCitiesByCountryQueryHandler(ICityRepository cityRepository)
    : IQueryHandler<GetCitiesByCountryQuery, MasterEntityResponse<Guid>[]>
{
    private readonly ICityRepository _cityRepository = cityRepository;

    public async Task<Result<MasterEntityResponse<Guid>[]>> Handle(GetCitiesByCountryQuery request, CancellationToken cancellationToken)
    {
        var cities = await _cityRepository.GetCitiesAsync(request.CountryId, cancellationToken);

        if (cities.Count == 0) return SharedErrors.MasterEntityNotFound(nameof(City));

        return cities.Adapt<MasterEntityResponse<Guid>[]>();
    }
}

using Booking.Application.Core.Abstractions;
using Booking.Application.Models;
using Booking.Domain.Entities;
using Booking.Domain.Errors;
using Booking.Domain.Primitives;
using Booking.Domain.Repositories;
using Booking.Domain.Result;
using Mapster;

namespace Booking.Application.Features.Countries.Get;

public sealed class GetCountriesQueryHandler(ICountryRepository countryRepository) : IQueryHandler<GetCountriesQuery, MasterEntityResponse<Guid>[]>
{
    private readonly ICountryRepository _countryRepository = countryRepository;

    public async Task<Result<MasterEntityResponse<Guid>[]>> Handle(GetCountriesQuery request, CancellationToken cancellationToken)
    {
        var countries = await _countryRepository.GetCountriesAsync(cancellationToken);

        if (countries.Count == 0)
            return SharedErrors.MasterEntityNotFound(nameof(Country));

        return countries.Adapt<MasterEntityResponse<Guid>[]>();
    }
}
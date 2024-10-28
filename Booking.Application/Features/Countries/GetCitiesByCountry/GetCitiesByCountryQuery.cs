using Booking.Application.Core.Abstractions;
using Booking.Application.Models;

namespace Booking.Application.Features.Countries.GetCitiesByCountry;

public sealed record GetCitiesByCountryQuery(Guid CountryId) : IQuery<MasterEntityResponse<Guid>[]>;
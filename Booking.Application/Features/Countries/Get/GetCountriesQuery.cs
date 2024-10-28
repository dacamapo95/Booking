using Booking.Application.Core.Abstractions;
using Booking.Application.Models;
using Booking.Domain.Primitives;

namespace Booking.Application.Features.Countries.Get;

public sealed record GetCountriesQuery : IQuery<MasterEntityResponse<Guid>[]>;
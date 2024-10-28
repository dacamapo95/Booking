using Booking.Domain.Entities;

namespace Booking.Domain.Repositories;

public interface ICountryRepository 
{
    Task<List<Country>> GetCountriesAsync(CancellationToken cancellationToken = default);
}

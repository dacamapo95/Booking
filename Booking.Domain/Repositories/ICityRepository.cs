using Booking.Domain.Entities;

namespace Booking.Domain.Repositories;

public interface ICityRepository 
{
    Task<List<City>> GetCitiesAsync(Guid countryId, CancellationToken cancellation = default);
}
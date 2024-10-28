using Booking.Domain.Entities;
using Booking.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Booking.Infrastructure.Database.Repositories;

public class CityRepository(ApplicationDbContext context) : ICityRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task<List<City>> GetCitiesAsync(Guid countryId, CancellationToken cancellationToken) =>
        await _context.Cities.Where(city => city.CountryId == countryId)
        .AsNoTracking()
        .ToListAsync(cancellationToken);
}
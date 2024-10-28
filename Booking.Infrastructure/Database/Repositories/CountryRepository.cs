using Booking.Domain.Entities;
using Booking.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Booking.Infrastructure.Database.Repositories;
public class CountryRepository(ApplicationDbContext context) : ICountryRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task<List<Country>> GetCountriesAsync(CancellationToken cancellationToken = default) =>
        await _context.Countries.AsNoTracking().ToListAsync(cancellationToken);
}

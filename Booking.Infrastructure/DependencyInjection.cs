using Ardalis.GuardClauses;
using Booking.Application.Core.Abstractions;
using Booking.Domain.Identity;
using Booking.Domain.Repositories;
using Booking.Infrastructure.Database;
using Booking.Infrastructure.Database.Repositories;
using Booking.Infrastructure.Database.Seed;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Booking.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection RegisterInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = Guard.Against.NullOrEmpty(
            configuration.GetConnectionString("ConnectionString"),
             message: "Connection string 'ConnectionString' not found.");

        services.AddDbContext<ApplicationDbContext>((sp, options) =>
        {
            options.UseSqlServer(connectionString);
        });

        services.AddScoped<IUnitOfWork>(sp =>
           sp.GetRequiredService<ApplicationDbContext>());

        services
            .AddIdentityCore<User>()
            .AddRoles<Role>()
            .AddEntityFrameworkStores<ApplicationDbContext>();


        services.AddScoped<DatabaseInitializer>();
        services.AddScoped<ICityRepository, CityRepository>();
        services.AddScoped<ICountryRepository, CountryRepository>();
        services.AddScoped<IRoomTypeRepository, RoomTypeRepository>();
        services.AddScoped<IFloorRepository, FloorRepository>();
        services.AddScoped<IHotelRepository, HotelRepository>();
        services.AddScoped<IReservationStatusesRepository, ReservationStatusesRepository>();
        services.AddScoped<IReservationRepository, ReservationRepository>();
        return services;
    }
}

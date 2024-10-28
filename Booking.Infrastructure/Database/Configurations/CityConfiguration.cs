using Booking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Booking.Infrastructure.Database.Configurations;

public class CityConfiguration : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.Property(c => c.Name).IsRequired().HasMaxLength(100);
        builder.HasOne(c => c.Country)
               .WithMany(c => c.Cities)
               .HasForeignKey(c => c.CountryId);
    }
}

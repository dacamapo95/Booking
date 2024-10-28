using Booking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Booking.Infrastructure.Database.Configurations;

public class LocationConfiguration : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder.HasKey(l => l.Id);
        builder.Property(l => l.AdditionalInfo).IsRequired().HasMaxLength(100);
        builder.HasOne(l => l.Floor)
               .WithMany(f => f.Locations)
               .HasForeignKey(l => l.FloorId);
    }
}

using Booking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Booking.Infrastructure.Database.Configurations;

public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
{
    public void Configure(EntityTypeBuilder<Hotel> builder)
    {
        builder.HasKey(h => h.Id);
        builder.Property(h => h.Name).IsRequired().HasMaxLength(100);
        builder.Property(h => h.Address).IsRequired().HasMaxLength(200);
        builder.Property(h => h.IsEnabled).IsRequired();
        builder.Property(h => h.MaxRooms).IsRequired();
        builder.HasOne(h => h.City)
               .WithMany(c => c.Hotels)
               .HasForeignKey(h => h.CityId);
    }
}

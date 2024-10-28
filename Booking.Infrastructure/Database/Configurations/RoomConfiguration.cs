using Booking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Booking.Infrastructure.Configurations;

public class RoomConfiguration : IEntityTypeConfiguration<Room>
{
    public void Configure(EntityTypeBuilder<Room> builder)
    {
        builder.Property(r => r.RoomNumber)
            .IsRequired();
        builder.HasIndex(r => r.RoomNumber)
            .IsUnique(false);
        builder.Property(r => r.Capacity).IsRequired();
        builder.Property(r => r.BaseCost).IsRequired();
        builder.Property(r => r.Taxes).IsRequired();
        builder.Property(r => r.PricePerNight).IsRequired();
        builder.Property(r => r.IsEnabled).IsRequired();
        builder.HasOne(r => r.Hotel)
               .WithMany(h => h.Rooms)
               .HasForeignKey(r => r.HotelId);
        builder.HasOne(r => r.RoomType)
               .WithMany(rt => rt.Rooms)
               .HasForeignKey(r => r.RoomTypeId);
        builder.HasOne(r => r.Location)
               .WithOne(l => l.Room)
               .HasForeignKey<Location>(r => r.RoomId);
    }
}

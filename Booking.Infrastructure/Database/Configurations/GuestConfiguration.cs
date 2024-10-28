using Booking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Booking.Infrastructure.Database.Configurations;

public class GuestConfiguration : IEntityTypeConfiguration<Guest>
{
    public void Configure(EntityTypeBuilder<Guest> builder)
    {
        builder.Property(g => g.FirstName).IsRequired().HasMaxLength(100);
        builder.Property(g => g.LastName).IsRequired().HasMaxLength(100);
        builder.Property(g => g.Email).IsRequired().HasMaxLength(100);
        builder.Property(g => g.PhoneNumber).IsRequired().HasMaxLength(15);
        builder.HasOne(g => g.Reservation)
               .WithMany(x => x.Guests)
               .HasForeignKey(g => g.ReservationId);
    }
}

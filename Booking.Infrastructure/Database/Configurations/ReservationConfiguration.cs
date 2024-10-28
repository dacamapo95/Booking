using Booking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Booking.Infrastructure.Database.Configurations;

public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
{
    public void Configure(EntityTypeBuilder<Reservation> builder)
    {
        builder.Property(r => r.ReservationDate).IsRequired();
        builder.Property(r => r.TotalCost).IsRequired();
        builder.Property(r => r.NumberOfGuests).IsRequired();
        builder.HasOne(r => r.ReservationStatus)
               .WithMany(s => s.Reservations)
               .HasForeignKey(r => r.ReservationStatusId);
    }
}
using Booking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Booking.Infrastructure.Database.Configurations;

public class RoomReservationConfiguration : IEntityTypeConfiguration<RoomReservation>
{
    public void Configure(EntityTypeBuilder<RoomReservation> builder)
    {
        builder.HasKey(rr => new { rr.RoomId, rr.ReservationId });
        builder.HasOne(rr => rr.Room)
               .WithMany(r => r.RoomReservations)
               .HasForeignKey(rr => rr.RoomId);

        builder.HasOne(rr => rr.Reservation)
            .WithMany(r => r.RoomReservations)
                .HasForeignKey(rr => rr.ReservationId);
    }
}

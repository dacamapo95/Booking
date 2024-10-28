using Booking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Booking.Infrastructure.Database.Configurations;

public class ReservationStatusConfiguration : IEntityTypeConfiguration<ReservationStatus>
{
    public void Configure(EntityTypeBuilder<ReservationStatus> builder)
    {
        builder.Property(rs => rs.Name)
            .IsRequired().HasMaxLength(50);
    }
}

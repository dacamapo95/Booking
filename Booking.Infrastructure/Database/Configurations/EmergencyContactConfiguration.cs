using Booking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Booking.Infrastructure.Database.Configurations;

public class EmergencyContactConfiguration : IEntityTypeConfiguration<EmergencyContact>
{
    public void Configure(EntityTypeBuilder<EmergencyContact> builder)
    {
        builder.Property(ec => ec.FullName).IsRequired().HasMaxLength(100);
        builder.Property(ec => ec.PhoneNumber).IsRequired().HasMaxLength(15);
        builder.HasOne(ec => ec.Reservation)
               .WithOne(re => re.EmergencyContact)
               .HasForeignKey<EmergencyContact>(ec => ec.ReservationId);
    }
}

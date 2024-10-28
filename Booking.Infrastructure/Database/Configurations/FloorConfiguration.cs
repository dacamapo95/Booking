using Booking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Booking.Infrastructure.Database.Configurations;

public class FloorConfiguration : IEntityTypeConfiguration<Floor>
{
    public void Configure(EntityTypeBuilder<Floor> builder)
    {
        builder.HasKey(f => f.Id);
        builder.Property(f => f.FloorNumber).IsRequired();
        builder.Property(f => f.Description).IsRequired().HasMaxLength(100);
    }
}

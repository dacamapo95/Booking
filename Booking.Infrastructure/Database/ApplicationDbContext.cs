using Booking.Application.Core.Abstractions;
using Booking.Domain.Entities;
using Booking.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data.Common;

namespace Booking.Infrastructure.Database;

public sealed class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
    IdentityDbContext<User, Role, Guid, IdentityUserClaim<Guid>,
    UserRole,
    IdentityUserLogin<Guid>,
    IdentityRoleClaim<Guid>,
    IdentityUserToken<Guid>>(options), IUnitOfWork
{
    public DbSet<Country> Countries => Set<Country>();
    public DbSet<City> Cities => Set<City>();
    public DbSet<Hotel> Hotels => Set<Hotel>();
    public DbSet<EmergencyContact> EmergencyContacts => Set<EmergencyContact>();
    public DbSet<Room> Rooms => Set<Room>();
    public DbSet<Reservation> Reservations => Set<Reservation>();
    public DbSet<Guest> Guests => Set<Guest>();
    public DbSet<RoomType> RoomTypes => Set<RoomType>();
    public DbSet<Floor> Floors => Set<Floor>();
    public DbSet<Location> Locations => Set<Location>();
    public DbSet<ReservationStatus> ReservationStatuses => Set<ReservationStatus>();
    public DbSet<RoomReservation> RoomReservations => Set<RoomReservation>();

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await base.SaveChangesAsync(cancellationToken);
    }

    public DbTransaction BeginTransaction()
    {
        var transaction = Database.BeginTransaction();
        return transaction.GetDbTransaction();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("BO");
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(AssemblyReference.Assembly);

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("Users", "AUTH");
            entity.HasMany(e => e.UserRoles)
                    .WithOne(e => e.User)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("Roles", "AUTH");
            entity.HasMany(e => e.UserRoles)
                    .WithOne(e => e.Role)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.ToTable("UserRoles", "AUTH");
            entity.HasKey(key => new { key.UserId, key.RoleId });
        });

        modelBuilder.Ignore<IdentityUserClaim<Guid>>();
        modelBuilder.Ignore<IdentityUserLogin<Guid>>();
        modelBuilder.Ignore<IdentityRoleClaim<Guid>>();
        modelBuilder.Ignore<IdentityUserToken<Guid>>();
    }
}

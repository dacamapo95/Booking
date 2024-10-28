namespace Booking.Domain.Primitives;

public abstract class AuditableEntity<TId> : Entity<TId>, IAuditEntity where TId : IEquatable<TId>
{
    public DateTimeOffset CreatedAtUtc { get; set; }
    public string? CreatedBy { get; set; }
    public DateTimeOffset? LastModifiedAtUtc { get; set; }
    public string? LastModifiedBy { get; set; }
}
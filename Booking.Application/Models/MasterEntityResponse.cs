namespace Booking.Application.Models;

public sealed record MasterEntityResponse<TId>(TId Id, string Name) where TId : IEquatable<TId>;

using Microsoft.AspNetCore.Identity;

namespace Booking.Domain.Identity;

public class User : IdentityUser<Guid>
{
    public ICollection<UserRole> UserRoles { get; } = [];
}

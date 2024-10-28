using Microsoft.AspNetCore.Identity;

namespace Booking.Domain.Identity;

public class Role : IdentityRole<Guid>
{
    public ICollection<UserRole> UserRoles { get; set; }
}

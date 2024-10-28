using System.Reflection;

namespace Booking.Infrastructure;
internal static class AssemblyReference
{
    public static Assembly Assembly => typeof(AssemblyReference).Assembly;
}

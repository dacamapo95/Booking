using System.Reflection;

namespace Booking.Application;

internal static class AssemblyReference
{
    public static Assembly Assembly = typeof(AssemblyReference).Assembly;
}
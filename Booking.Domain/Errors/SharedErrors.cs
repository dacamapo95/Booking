using Booking.Domain.Result;

namespace Booking.Domain.Errors;

public static class SharedErrors
{
    public static Error MasterEntityNotFound(string entityName) =>
        Error.NotFound($"Master {entityName} not found.");
}

using System.Data.Common;

namespace Booking.Application.Core.Abstractions;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    public DbTransaction BeginTransaction();
}

using Booking.Domain.Entities;

namespace Booking.Domain.Repositories;

public interface IReservationRepository
{
    Task<Reservation> GetByIdAsync(Guid id, CancellationToken cancellationToken);

    void Add(Reservation reservation);

    void Update(Reservation reservation);

    Task<bool> IsAnyReservationInRoomInProgress(Guid roomId, DateTime checkInDate, DateTime checkOutDate, CancellationToken cancellationToken);

    Task<(List<Reservation> Reservations,
        int TotalRecords,
        int PageNumber,
        int PageSize)> GetAll(
        int pageNumber,
        int pageSize,
        DateTime? reservationDate,
        DateTime? checkInDate,
        DateTime? checkOutDate,
        int? reservationStatusId,
        int? numberOfGuests,
        CancellationToken cancellationToken);
}

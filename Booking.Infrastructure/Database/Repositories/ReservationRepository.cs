using Booking.Domain.Entities;
using Booking.Domain.Enums;
using Booking.Domain.Repositories;
using Booking.Infrastructure.Database.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Booking.Infrastructure.Database.Repositories;
public class ReservationRepository(ApplicationDbContext context) : IReservationRepository
{
    private readonly ApplicationDbContext _context = context;

    public void Add(Reservation reservation)
    {
        _context.Reservations.Add(reservation);
    }

  

    public async Task<Reservation?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _context.Reservations
            .Include(r => r.Guests)
            .Include(r => r.EmergencyContact)
            .FirstOrDefaultAsync(r => r.Id == id, cancellationToken);
    }

    public Task<bool> IsAnyReservationInRoomInProgress(
        Guid roomId,
        DateTime checkInDate,
        DateTime checkOutDate,
        CancellationToken cancellationToken)
    {
        return _context.RoomReservations
            .Include(rr => rr.Reservation)
            .AnyAsync(rr => rr.RoomId == roomId &&
                            rr.Reservation.CheckInDate < checkOutDate &&
                            rr.Reservation.CheckOutDate > checkInDate &&
                            (rr.Reservation.ReservationStatusId == (int)ReservationStatusEnum.Confirmed ||
                             rr.Reservation.ReservationStatusId == (int)ReservationStatusEnum.CheckedIn),
                    cancellationToken);
    }

    public void Update(Reservation reservation)
    {
        _context.Reservations.Update(reservation);
    }

    public async Task<(List<Reservation> Reservations, int TotalRecords, int PageNumber, int PageSize)>
        GetAll(
        int pageNumber,
        int pageSize,
        DateTime? reservationDate,
        DateTime? checkInDate, 
        DateTime? checkOutDate, 
        int? reservationStatusId,
        int? numberOfGuests,
        CancellationToken cancellationToken)
    {
        //TODO: Filtrar por User y Ciudad.

        var query = _context.Set<Reservation>().AsQueryable();

        if (reservationDate.HasValue)
        {
            query = query.Where(r => r.ReservationDate.Date == reservationDate.Value);
        }

        if (checkInDate.HasValue)
        {
            query = query.Where(r => r.CheckInDate!.Value.Date == checkInDate.Value);
        }

        if (checkOutDate.HasValue)
        {
            query = query.Where(r => r.CheckOutDate!.Value.Date == checkOutDate.Value);
        }

        if (reservationStatusId.HasValue)
        {
            query = query.Where(r => r.ReservationStatusId == reservationStatusId.Value);
        }

        if (numberOfGuests.HasValue)
        {
            query = query.Where(r => r.NumberOfGuests == numberOfGuests.Value);
        }

        query.OrderByDescending(r => r.ReservationDate);
        
        var pagedList = await query.ToPagedListAsync(pageNumber, pageSize);

        return (pagedList.Data, pagedList.TotalRecords, pagedList.PageNumber, pagedList.PageSize);
    }
}

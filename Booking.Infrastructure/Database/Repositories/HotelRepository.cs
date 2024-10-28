using Booking.Domain.Entities;
using Booking.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Booking.Infrastructure.Database.Repositories;

public class HotelRepository(ApplicationDbContext applicationDbContext) : IHotelRepository
{
    private readonly ApplicationDbContext _applicationDbContext = applicationDbContext;

    public void Add(Hotel hotel)
    {
        _applicationDbContext.Add(hotel);
    }

    public async Task<Hotel?> FindByIdAsync(Guid id) =>
        await _applicationDbContext.Hotels.FindAsync(id);

    public async Task<Hotel?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _applicationDbContext.Hotels
            .AsNoTracking()
            .Include(h => h.Rooms)
            .ThenInclude(h => h.Location)
            .FirstOrDefaultAsync(h => h.Id == id, cancellationToken);
    }

    public async Task<bool> IsAnyHotelWithName(string name, CancellationToken cancellationToken = default)
    {
        return await _applicationDbContext.Hotels.AnyAsync(h => h.Name == name, cancellationToken);
    }

    public Task<bool> IsAnyRoomWithRoomNumber(Guid hotelId, int roomNumber,
        CancellationToken cancellationToken = default)
    {
        return _applicationDbContext.Rooms
            .AnyAsync(r => r.HotelId == hotelId && r.RoomNumber == roomNumber, cancellationToken);
    }

    public async Task<int> GetRoomsCount(Guid hotelId, CancellationToken cancellationToken = default)
    {
        return await _applicationDbContext.Rooms
            .CountAsync(r => r.HotelId == hotelId, cancellationToken);
    }

    public async Task<Room?> GetRoomByIdAsync(Guid hotelId, Guid roomId, CancellationToken cancellationToken = default)
    {
        return await _applicationDbContext.Rooms
            .Include(r => r.Location)
            .FirstOrDefaultAsync(r => r.HotelId == hotelId && r.Id == roomId, cancellationToken);
    }

    public async Task<Room[]> GetRoomsAsync(Guid hotelId, CancellationToken cancellationToken = default)
    {
        return  await _applicationDbContext.Rooms
            .AsNoTracking()
            .Include(r => r.Location)
            .Where(r => r.HotelId == hotelId)
            .ToArrayAsync(cancellationToken);
    }
}
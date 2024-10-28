using Booking.Application.Core.Abstractions;
using Booking.Domain.Errors;
using Booking.Domain.Repositories;
using Booking.Domain.Result;
using Mapster;

namespace Booking.Application.Features.Hotels.GetById;

public sealed class GetHotelByIdQueryHandler(IHotelRepository hotelRepository) 
    : IQueryHandler<GetHotelByIdQuery, HotelResponse>
{
    private readonly IHotelRepository _hotelRepository = hotelRepository;

    public async Task<Result<HotelResponse>> Handle(GetHotelByIdQuery request, CancellationToken cancellationToken)
    {
        var hotel = await _hotelRepository.GetByIdAsync(request.Id, cancellationToken);
        
        if (hotel is null)
        {
            return HotelErrors.HotelNotFound(request.Id);
        }

        return hotel.Adapt<HotelResponse>();
    }
}

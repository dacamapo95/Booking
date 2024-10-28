using Booking.Application.Core.Abstractions;

namespace Booking.Application.Features.Hotels.GetById;
public sealed record GetHotelByIdQuery(Guid Id) : IQuery<HotelResponse>;
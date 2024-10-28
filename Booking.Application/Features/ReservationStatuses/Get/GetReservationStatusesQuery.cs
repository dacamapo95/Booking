using Booking.Application.Core.Abstractions;
using Booking.Application.Models;
using Booking.Domain.Primitives;

namespace Booking.Application.Features.ReservationStatuses.Get;

public sealed record GetReservationStatusesQuery : IQuery<MasterEntityResponse<int>[]>;
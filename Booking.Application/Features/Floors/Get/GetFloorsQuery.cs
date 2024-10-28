using Booking.Application.Core.Abstractions;
using Booking.Domain.Result;
using MediatR;

namespace Booking.Application.Features.Floors.Get;

public record GetFloorsQuery : IQuery<FloorResponse[]>;
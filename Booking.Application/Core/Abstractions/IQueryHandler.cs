using Booking.Domain.Result;
using MediatR;

namespace Booking.Application.Core.Abstractions;

public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>;
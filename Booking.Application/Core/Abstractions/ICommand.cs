using Booking.Domain.Result;
using MediatR;

namespace Booking.Application.Core.Abstractions;

public interface ICommand : IRequest<Result>;

public interface ICommand<TResponse> : IRequest<Result<TResponse>>;

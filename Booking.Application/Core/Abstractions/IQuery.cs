using Booking.Domain.Result;
using MediatR;
namespace Booking.Application.Core.Abstractions;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>;
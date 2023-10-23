using MediatR;
using ResultWrapper.Abstractions;

namespace CQRS.Abstractions.Queries;

public interface IQueryHandler<in TRequest, TResponse> : IRequestHandler<TRequest, IResult<TResponse>> where TRequest : IQuery<TResponse>
{ }
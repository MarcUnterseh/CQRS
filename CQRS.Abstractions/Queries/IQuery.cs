using MediatR;
using ResultWrapper.Abstractions;

namespace CQRS.Abstractions.Queries;

public interface IQuery<TResponse> : IRequest<IResult<TResponse>>
{ }
using MediatR;
using ResultWrapper.Abstractions;

namespace CQRS.Abstractions.Commands;

public interface ICommand<TResponse> : IRequest<IResult<TResponse>>
{ }

public interface ICommand : IRequest<IResult>
{ }
using MediatR;
using ResultWrapper.Abstractions;

namespace CQRS.Abstractions.Commands;

public interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, IResult<TResponse>> where TCommand : ICommand<TResponse>
{ }

public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand, IResult> where TCommand : ICommand
{ }
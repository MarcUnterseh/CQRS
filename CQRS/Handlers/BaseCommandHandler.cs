using CQRS.Abstractions.Commands;

namespace CQRS.Handlers;

public abstract class BaseCommandHandler<TCommand> : BaseHandler<TCommand>
    where TCommand : ICommand
{
}

public abstract class BaseCommandHandler<TCommand, TResponse> : BaseHandler<TCommand, TResponse>
    where TCommand : ICommand<TResponse>
{
}
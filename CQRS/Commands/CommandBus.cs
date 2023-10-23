using CQRS.Abstractions.Commands;
using MediatR;
using ResultWrapper.Abstractions;

namespace CQRS.Commands;

public class CommandBus : ICommandBus
{
    private readonly IMediator _mediator;

    public CommandBus(IMediator mediator)
    {
        _mediator = mediator ?? throw new Exception($"Missing dependency '{nameof(IMediator)}'");
    }

    public virtual async Task<IResult<TResponse>> Send<TResponse>(ICommand<TResponse> command, CancellationToken cancellationToken = default)
    {
        var result = await _mediator.Send(command, cancellationToken);

        return result;
    }

    public virtual async Task<IResult> Send(ICommand command, CancellationToken cancellationToken = default)
    {
        var result = await _mediator.Send(command, cancellationToken);

        return result;
    }
}
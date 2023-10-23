using ResultWrapper.Abstractions;

namespace CQRS.Abstractions.Commands;

public interface ICommandBus
{
    Task<IResult<TResponse>> Send<TResponse>(ICommand<TResponse> command, CancellationToken cancellationToken = default);

    Task<IResult> Send(ICommand command, CancellationToken cancellationToken = default);
}
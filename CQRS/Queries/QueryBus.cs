using CQRS.Abstractions.Queries;
using MediatR;
using ResultWrapper.Abstractions;

namespace CQRS.Queries;

public class QueryBus : IQueryBus
{
    private readonly IMediator _mediator;

    public QueryBus(IMediator mediator)
    {
        _mediator = mediator ?? throw new Exception($"Missing dependency '{nameof(IMediator)}'");
    }

    public virtual async Task<IResult<TResponse>> Send<TResponse>(IQuery<TResponse> query, CancellationToken cancellationToken = default)
    {
        var result = await _mediator.Send(query, cancellationToken);

        return result;
    }
}
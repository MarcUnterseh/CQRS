using ResultWrapper.Abstractions;

namespace CQRS.Abstractions.Queries;

public interface IQueryBus
{
    Task<IResult<TResponse>> Send<TResponse>(IQuery<TResponse> query, CancellationToken cancellationToken = default);
}
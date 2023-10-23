using CQRS.Abstractions.Queries;

namespace CQRS.Handlers;

public abstract class BaseQueryHandler<TQuery, TResponse> : BaseHandler<TQuery, TResponse>
    where TQuery : IQuery<TResponse>
{
}
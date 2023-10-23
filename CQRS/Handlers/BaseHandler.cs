using MediatR;
using ResultWrapper;
using ResultWrapper.Abstractions;

namespace CQRS.Handlers;

public abstract class BaseHandler<TRequest> : IRequestHandler<TRequest, IResult>
    where TRequest : IRequest<IResult>
{
    public async Task<IResult> Handle(TRequest request, CancellationToken cancellationToken)
    {
        try
        {
            await TryToHandle(request, cancellationToken);
            return Result.Success();
        }
        catch (Exception e)
        {
            return await ManageExceptions(e);
        }
    }

    protected abstract Task TryToHandle(TRequest command, CancellationToken cancellationToken);

    protected virtual Task<IFailureResult> ManageExceptions(Exception exception) => Task.FromResult(Result.Fail(exception));
}

public abstract class BaseHandler<TRequest, TResponse> : IRequestHandler<TRequest, IResult<TResponse>>
    where TRequest : IRequest<IResult<TResponse>>
{
    public async Task<IResult<TResponse>> Handle(TRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await TryToHandle(request, cancellationToken);
            return Result.Success(result);
        }
        catch (Exception e)
        {
            return await ManageExceptions(e);
        }
    }

    protected abstract Task<TResponse> TryToHandle(TRequest request, CancellationToken cancellationToken);

    protected virtual Task<IFailureResult<TResponse>> ManageExceptions(Exception exception) => Task.FromResult(Result.Fail<TResponse>(exception));
}
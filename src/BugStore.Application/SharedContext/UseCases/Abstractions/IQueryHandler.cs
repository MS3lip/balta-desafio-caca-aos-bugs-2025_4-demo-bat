using Balta.Mediator.Abstractions;
using BugStore.Application.SharedContext.UseCases.Results;

namespace BugStore.Application.SharedContext.UseCases.Abstractions;

public interface IQueryHandler<in TQuery, TResponse> : IHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>
    where TResponse : IQueryResponse;
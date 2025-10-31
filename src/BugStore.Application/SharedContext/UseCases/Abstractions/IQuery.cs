using Balta.Mediator.Abstractions;
using BugStore.Application.SharedContext.UseCases.Results;

namespace BugStore.Application.SharedContext.UseCases.Abstractions;

public interface IQuery<TResponse> : IRequest<Result<TResponse>> where TResponse : IQueryResponse;

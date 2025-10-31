using Balta.Mediator.Abstractions;
using BugStore.Application.SharedContext.UseCases.Results;

namespace BugStore.Application.SharedContext.UseCases.Abstractions;

public interface ICommand : IRequest<Result>, IBaseCommand;

public interface ICommand<TResult> : IRequest<Result<TResult>>, IBaseCommand where TResult : ICommandResponse;

public interface IBaseCommand;
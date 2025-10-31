using Balta.Mediator.Abstractions;
using BugStore.Application.SharedContext.UseCases.Results;

namespace BugStore.Application.SharedContext.UseCases.Abstractions;

public interface ICommandHandler<in TCommand> : IHandler<TCommand, Result> where TCommand : ICommand
{
}

public interface ICommandHandler<in TCommand, TResponse> : IHandler<TCommand, Result<TResponse>>
    where TCommand : ICommand<TResponse>
    where TResponse : ICommandResponse
{
}
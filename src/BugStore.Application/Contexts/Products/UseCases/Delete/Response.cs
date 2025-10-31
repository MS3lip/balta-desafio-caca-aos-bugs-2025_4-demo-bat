using BugStore.Application.SharedContext.UseCases.Abstractions;

namespace BugStore.Application.Contexts.Products.UseCases.Delete;

public sealed record Response(Guid Id, string Title) : ICommandResponse;
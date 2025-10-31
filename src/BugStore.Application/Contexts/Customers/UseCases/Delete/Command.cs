using BugStore.Application.SharedContext.UseCases.Abstractions;

namespace BugStore.Application.Contexts.Customers.UseCases.Delete;

public sealed record Command(Guid Id) : ICommand<Response>;

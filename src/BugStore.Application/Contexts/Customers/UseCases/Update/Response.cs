using BugStore.Application.SharedContext.UseCases.Abstractions;

namespace BugStore.Application.Contexts.Customers.UseCases.Update;

public sealed record Response(Guid Id, string Name, string Email, string Phone, DateTime BirthDate) : ICommandResponse;
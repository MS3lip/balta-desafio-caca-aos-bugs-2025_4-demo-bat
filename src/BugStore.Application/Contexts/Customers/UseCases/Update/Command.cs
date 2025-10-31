using BugStore.Application.SharedContext.UseCases.Abstractions;

namespace BugStore.Application.Contexts.Customers.UseCases.Update;

public sealed record Command(Guid Id, string Name, string Email, string Phone, DateTime BirthDate) : ICommand<Response>;

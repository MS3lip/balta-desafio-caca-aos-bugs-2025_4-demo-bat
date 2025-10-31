using BugStore.Application.SharedContext.UseCases.Abstractions;

namespace BugStore.Application.Contexts.Customers.UseCases.Create;

public sealed record Command(string Name, string Email, string Phone, DateTime BirthDate) : ICommand<Response>;

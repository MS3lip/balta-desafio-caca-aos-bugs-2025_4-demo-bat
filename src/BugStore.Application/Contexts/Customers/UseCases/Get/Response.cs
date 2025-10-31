using BugStore.Application.SharedContext.UseCases.Abstractions;
using BugStore.Domain.Contexts.Customers.Entities;

namespace BugStore.Application.Contexts.Customers.UseCases.Get;

public record Response(IEnumerable<Customer>? Customers) : IQueryResponse;
using BugStore.Application.SharedContext.UseCases.Abstractions;
using BugStore.Domain.Contexts.Customers.Entities;
using BugStore.Domain.Contexts.Orders.ValueObjects;

namespace BugStore.Application.Contexts.Orders.UseCases.GetById;

public sealed record Response(Guid Id, Customer Customer, List<OrderLine> Lines, DateTime CreatedAt) : IQueryResponse;
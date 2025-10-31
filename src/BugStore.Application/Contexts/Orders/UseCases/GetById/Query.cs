using BugStore.Application.SharedContext.UseCases.Abstractions;

namespace BugStore.Application.Contexts.Orders.UseCases.GetById;

public record Query(Guid Id) : IQuery<Response>;


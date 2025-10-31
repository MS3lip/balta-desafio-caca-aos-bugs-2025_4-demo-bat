using BugStore.Application.SharedContext.UseCases.Abstractions;

namespace BugStore.Application.Contexts.Products.UseCases.GetById;

public record Query(Guid Id) : IQuery<Response>;


using BugStore.Application.SharedContext.UseCases.Abstractions;

namespace BugStore.Application.Contexts.Products.UseCases.GetById;

public sealed record Response(Guid Id, string Title, string Description, string Slug, decimal Price) : IQueryResponse;
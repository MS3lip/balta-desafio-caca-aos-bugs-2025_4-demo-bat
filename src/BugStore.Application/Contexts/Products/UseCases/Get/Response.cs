using BugStore.Application.SharedContext.UseCases.Abstractions;
using BugStore.Domain.Contexts.Products.Entities;

namespace BugStore.Application.Contexts.Products.UseCases.Get;

public record Response(IEnumerable<Product>? products) : IQueryResponse;
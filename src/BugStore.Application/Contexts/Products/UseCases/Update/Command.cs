using BugStore.Application.SharedContext.UseCases.Abstractions;

namespace BugStore.Application.Contexts.Products.UseCases.Update;

public sealed record Command(Guid Id, string Title, string Description, string Slug, decimal Price) : ICommand<Response>;

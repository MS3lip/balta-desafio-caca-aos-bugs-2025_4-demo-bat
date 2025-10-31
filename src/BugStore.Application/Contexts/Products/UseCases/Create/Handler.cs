using BugStore.Application.SharedContext.UseCases.Abstractions;
using BugStore.Application.SharedContext.UseCases.Results;
using BugStore.Domain.Contexts.Products.Entities;
using BugStore.Domain.Contexts.Products.Repositories;

namespace BugStore.Application.Contexts.Products.UseCases.Create;

public class Handler(IProductRepository repository) : ICommandHandler<Command, Response>
{
    public async Task<Result<Response>> HandleAsync(Command request, CancellationToken cancellationToken = default)
    {
        var product = Product.Create(request.Title, request.Description, request.Slug, request.Price); 
        await repository.SaveAsync(product, cancellationToken);

        return Result.Success(new Response(product.Id, product.Title, product.Description, product.Slug, product.Price));
    }
}
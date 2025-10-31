using BugStore.Application.SharedContext.UseCases.Abstractions;
using BugStore.Application.SharedContext.UseCases.Results;
using BugStore.Domain.Contexts.Products.Entities;
using BugStore.Domain.Contexts.Products.Repositories;

namespace BugStore.Application.Contexts.Products.UseCases.Update;

public class Handler(IProductRepository repository) : ICommandHandler<Command, Response>
{
    public async Task<Result<Response>> HandleAsync(Command request, CancellationToken cancellationToken = default)
    {
        var product = await repository.GetByIdAsync(request.Id, cancellationToken);
        if (product is null)
            return Result.Failure<Response>(new Error("404", "Product not found."));

        var updateProduct = Product.Update(product.Id, request.Title, request.Description, request.Slug, request.Price);        
        await repository.UpdateAsync(updateProduct, cancellationToken);       
        
        return Result.Success(new Response(product.Id, request.Title, request.Description, request.Slug, request.Price));
    }
}
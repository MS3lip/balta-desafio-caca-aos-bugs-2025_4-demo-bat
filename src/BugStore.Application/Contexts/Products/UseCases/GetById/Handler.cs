﻿using BugStore.Application.SharedContext.UseCases.Abstractions;
using BugStore.Application.SharedContext.UseCases.Results;
using BugStore.Domain.Contexts.Products.Repositories;

namespace BugStore.Application.Contexts.Products.UseCases.GetById;

public class Handler(IProductRepository repository) : IQueryHandler<Query, Response>
{
    public async Task<Result<Response>> HandleAsync(Query request, CancellationToken cancellationToken = default)
    {
        var result = await repository.GetByIdAsync(request.Id, cancellationToken);
        if (result is null)
            return Result.Failure<Response>(new Error("404", "Product not found."));

        var response = new Response(result.Id, result.Title, result.Description, result.Slug, result.Price);
        return Result.Success(response);
    }
}

using BugStore.Application.SharedContext.UseCases.Abstractions;
using BugStore.Application.SharedContext.UseCases.Results;
using BugStore.Domain.Contexts.Orders.Repositories;

namespace BugStore.Application.Contexts.Orders.UseCases.GetById;

public class Handler(IOrderRepository repository) : IQueryHandler<Query, Response>
{
    public async Task<Result<Response>> HandleAsync(Query request, CancellationToken cancellationToken = default)
    {
        var result = await repository.GetByIdAsync(request.Id, cancellationToken);
        if (result is null)
            return Result.Failure<Response>(new Error("404", "Customer not found."));

        var order = new Response(result.Id, result.Customer, result.Lines, result.CreatedAt);
        return Result.Success(order);
    }
}

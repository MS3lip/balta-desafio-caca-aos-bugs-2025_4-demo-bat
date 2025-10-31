using BugStore.Application.SharedContext.UseCases.Abstractions;
using BugStore.Application.SharedContext.UseCases.Results;
using BugStore.Domain.Contexts.Orders.Entities;
using BugStore.Domain.Contexts.Orders.Repositories;

namespace BugStore.Application.Contexts.Orders.UseCases.Create;

public class Handler(IOrderRepository repository) : ICommandHandler<Command, Response>
{
    public async Task<Result<Response>> HandleAsync(Command request, CancellationToken cancellationToken = default)
    {
        //Vo's       
        var order = Order.Create(request.Customer, request.Lines);
        await repository.SaveAsync(order, cancellationToken);

        return Result.Success(new Response(order.Id, order.Customer, order.Lines, order.CreatedAt));
    }
}
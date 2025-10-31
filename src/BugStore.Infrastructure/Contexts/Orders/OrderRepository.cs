using BugStore.Domain.Contexts.Orders.Entities;
using BugStore.Domain.Contexts.Orders.Repositories;
using BugStore.Infrastructure.Data;

namespace BugStore.Infrastructure.Contexts.Orders;

public class OrderRepository(AppDbContext context) : IOrderRepository
{
    public Task<Order?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task SaveAsync(Order order, CancellationToken cancellationToken)
    {
        await context.Orders.AddAsync(order, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }
}
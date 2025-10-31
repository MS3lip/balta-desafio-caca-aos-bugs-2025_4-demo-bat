using BugStore.Domain.Contexts.Orders.Entities;

namespace BugStore.Domain.Contexts.Orders.Repositories;

public interface IOrderRepository
{
    Task<Order?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task SaveAsync(Order order, CancellationToken cancellationToken);
}

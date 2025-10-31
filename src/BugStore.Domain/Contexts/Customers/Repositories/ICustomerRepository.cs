using BugStore.Domain.Contexts.Customers.Entities;

namespace BugStore.Domain.Contexts.Customers.Repositories
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>?> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Customer?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        
        Task DeleteAsync(Customer customer, CancellationToken cancellationToken);
        Task SaveAsync(Customer customer, CancellationToken cancellationToken);
        Task UpdateAsync(Customer customer, CancellationToken cancellationToken);
    }
}

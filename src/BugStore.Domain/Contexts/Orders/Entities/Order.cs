using BugStore.Domain.Contexts.Customers.Entities;
using BugStore.Domain.Contexts.Orders.Exceptions;
using BugStore.Domain.Contexts.Orders.ValueObjects;
using BugStore.Domain.SharedContext.Abstractions.Entities;

namespace BugStore.Domain.Contexts.Orders.Entities;

public class Order : Entity
{
    #region Construtors
    protected Order() { } //EF
    private Order (Guid id, Customer customer, List<OrderLine> lines)
    {
        Id = id;

        CustomerId = customer.Id;
        Customer = customer;

        Lines = lines;

        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }
    #endregion

    #region Factorys
    public static Order Create(Customer customer, List<OrderLine> lines)
    {
        if (lines is null || lines.Count <= 0 )
            throw new OrderLineException("Order Line must have at least one item.");

        var id = Guid.NewGuid();
        return new Order(id, customer, lines);
    }
    #endregion

    #region Properties

    public Guid CustomerId { get;  private set; }
    public Customer Customer { get; private set; } = null!;
    
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    public List<OrderLine> Lines { get; private set; } = [];
    
    #endregion
}
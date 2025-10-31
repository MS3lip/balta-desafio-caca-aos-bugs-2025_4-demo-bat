using BugStore.Domain.Contexts.Products.Entities;
using BugStore.Domain.SharedContext.Abstractions.ValueObjects;

namespace BugStore.Domain.Contexts.Orders.ValueObjects;

public class OrderLine : ValueObject
{
    #region Constructors
    protected OrderLine() { } //EF
    private OrderLine(int quantity, Product product)
    {
        Quantity = quantity;
        Total = product.TotalPrice(quantity);
        
        Product = product;
        ProductId = product.Id;
    }
    #endregion

    #region Factorys
    public static OrderLine Create(int quantity, Product product)
    {
        return new OrderLine(quantity, product);
    }
    #endregion

    #region Properties

    public int Quantity { get; set; }
    public decimal Total { get; set; }

    public Guid ProductId { get; set; }
    public Product Product { get; set; } = null!;

    #endregion
}
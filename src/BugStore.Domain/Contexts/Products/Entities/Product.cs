using BugStore.Domain.SharedContext.Abstractions.Entities;

namespace BugStore.Domain.Contexts.Products.Entities;

public class Product : Entity
{
    #region Construtors
    protected Product() { } //EF
    private Product(Guid id, string title, string description, string slug, decimal price)
    { 
        base.Id = id;
        Title = title;
        Description = description;
        Slug = slug;
        Price = price;
    }
    #endregion

    #region Factorys
    public static Product Create(string title, string description, string slug, decimal price) 
    {
        var id = Guid.NewGuid();
        return new Product(id, title, description, slug, price);
    }
    public static Product Update(Guid id, string title, string description, string slug, decimal price)
    {        
        return new Product(id, title, description, slug, price);
    }
    #endregion

    #region Others methods
    public decimal TotalPrice(int quantity) => quantity * Price;
    #endregion

    #region Properties

    public string Title { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public string Slug { get; private set; } = string.Empty;
    public decimal Price { get; private set; }
    
    #endregion
}
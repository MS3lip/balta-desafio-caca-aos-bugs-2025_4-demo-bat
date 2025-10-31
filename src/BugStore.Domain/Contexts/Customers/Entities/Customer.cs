using BugStore.Domain.SharedContext.Abstractions.Entities;

namespace BugStore.Domain.Contexts.Customers.Entities;

public class Customer : Entity
{
    #region Construtors
    protected Customer() { } //EF
    private Customer(Guid id, string name, string email, string phone, DateTime birthDate)
    { 
        Id = id;
        Name = name;
        Email = email;
        Phone = phone;
        BirthDate = birthDate;
    }
    #endregion

    #region Factorys
    public static Customer Create(string name, string email, string phone, DateTime birthDate) 
    {
        var id = Guid.NewGuid();
        return new Customer(id, name, email, phone, birthDate); 
    }
    public static Customer Update(Guid id, string name, string email, string phone, DateTime birthDate)
    {        
        return new Customer(id, name, email, phone, birthDate);
    }
    #endregion

    #region Properties

    public string Name { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public string Phone { get; private set; } = string.Empty;
    public DateTime BirthDate { get;  private set; }
    
    #endregion
}
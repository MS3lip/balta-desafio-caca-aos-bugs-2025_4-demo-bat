namespace BugStore.Domain.SharedContext.Abstractions.Entities;

public abstract class Entity
{
    public Guid Id { get; protected set; }
}


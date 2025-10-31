namespace BugStore.Domain.SharedContext.Exceptions;

public abstract class DomainException(string message) : Exception(message);

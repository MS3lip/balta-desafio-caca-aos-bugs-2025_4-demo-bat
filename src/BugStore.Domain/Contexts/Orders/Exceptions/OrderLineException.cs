using BugStore.Domain.SharedContext.Exceptions;

namespace BugStore.Domain.Contexts.Orders.Exceptions;

public class OrderLineException(string message) : DomainException(message);

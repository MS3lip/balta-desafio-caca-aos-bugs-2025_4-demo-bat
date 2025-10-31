using BugStore.Application.SharedContext.UseCases.Abstractions;
using BugStore.Application.SharedContext.UseCases.Results;
using BugStore.Domain.Contexts.Customers.Entities;
using BugStore.Domain.Contexts.Customers.Repositories;

namespace BugStore.Application.Contexts.Customers.UseCases.Create;

public class Handler(ICustomerRepository repository) : ICommandHandler<Command, Response>
{
    public async Task<Result<Response>> HandleAsync(Command request, CancellationToken cancellationToken = default)
    {
        var customer = Customer.Create(request.Name, request.Email, request.Phone, request.BirthDate);    
        await repository.SaveAsync(customer, cancellationToken);

        return Result.Success(new Response(customer.Id, customer.Name, customer.Email, customer.Phone, customer.BirthDate));
    }    
}
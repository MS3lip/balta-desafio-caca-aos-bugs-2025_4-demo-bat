using BugStore.Application.SharedContext.UseCases.Abstractions;
using BugStore.Application.SharedContext.UseCases.Results;
using BugStore.Domain.Contexts.Customers.Entities;
using BugStore.Domain.Contexts.Customers.Repositories;

namespace BugStore.Application.Contexts.Customers.UseCases.Update;

public class Handler(ICustomerRepository repository) : ICommandHandler<Command, Response>
{
    public async Task<Result<Response>> HandleAsync(Command request, CancellationToken cancellationToken = default)
    {
        var customer = await repository.GetByIdAsync(request.Id, cancellationToken);
        if (customer is null)
            return Result.Failure<Response>(new Error("404", "Customer not found."));

        var updateCustomer = Customer.Update(customer.Id, request.Name, request.Email, request.Phone, request.BirthDate);       
        await repository.UpdateAsync(updateCustomer, cancellationToken);       
        
        return Result.Success(new Response(customer.Id, customer.Name, customer.Email, customer.Phone, customer.BirthDate));
    }
}
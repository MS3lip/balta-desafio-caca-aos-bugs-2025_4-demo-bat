using BugStore.Application.SharedContext.UseCases.Abstractions;
using BugStore.Application.SharedContext.UseCases.Results;
using BugStore.Domain.Contexts.Customers.Repositories;

namespace BugStore.Application.Contexts.Customers.UseCases.Get
{
    public class Handler(ICustomerRepository repository) : IQueryHandler<Query, Response>
    {
        public async Task<Result<Response>> HandleAsync(Query request, CancellationToken cancellationToken = default)
        {
            var result = await repository.GetAllAsync(cancellationToken);
            if(result is null)
                return Result.Failure<Response>(Error.NullValue);

            var customers = new Response(result);
            return Result.Success(customers);
        }
        
    }
}

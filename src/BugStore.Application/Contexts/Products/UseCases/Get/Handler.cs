using BugStore.Application.SharedContext.UseCases.Abstractions;
using BugStore.Application.SharedContext.UseCases.Results;
using BugStore.Domain.Contexts.Products.Repositories;

namespace BugStore.Application.Contexts.Products.UseCases.Get
{
    public class Handler(IProductRepository repository) : IQueryHandler<Query, Response>
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

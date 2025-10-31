using Balta.Mediator.Abstractions;
using BugStore.Application;
using BugStore.Infrastructure;
using BugStore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(op =>
   op.UseSqlite(
       builder.Configuration.GetConnectionString("DefaultConnection"),
       x => x.MigrationsAssembly("BugStore.Infrastructure"))
   );

builder.Services.AddApplication();
builder.Services.AddInfrastructure();

var app = builder.Build();

app.MapGet("/", () => "Balta.io - 4º BugStore a ser desenvolvido...");

app.MapGet("/v1/orders/{id}", async (
    IMediator sender,
    Guid id) => 
{
    var query = new BugStore.Application.Contexts.Orders.UseCases.GetById.Query(id);
    var result = await sender.SendAsync(query);

    return result.IsSuccess
       ? Results.Ok(result.Value)
       : Results.NotFound();
});

app.MapPost("/v1/orders", async (
    IMediator sender,
    BugStore.Application.Contexts.Orders.UseCases.Create.Command request) =>
{
        var result = await sender.SendAsync(request);

        return result.IsSuccess
           ? Results.Created($"/v1/orders/{result.Value.Id}", $"Order: {result.Value.Id} - {result.Value.Customer.Name} Criado com sucesso")
           : Results.BadRequest();
});

app.Run();

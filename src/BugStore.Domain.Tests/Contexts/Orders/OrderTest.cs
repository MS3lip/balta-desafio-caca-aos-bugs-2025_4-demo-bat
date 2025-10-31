using BugStore.Domain.Contexts.Customers.Entities;
using BugStore.Domain.Contexts.Orders.Entities;
using BugStore.Domain.Contexts.Orders.Exceptions;
using BugStore.Domain.Contexts.Orders.ValueObjects;
using BugStore.Domain.Contexts.Products.Entities;

namespace BugStore.Domain.Tests.Contexts.Orders;

public class OrderTest
{
    [Fact]
    public void Should_Create_Order_Sucessfully() 
    {
        //Arrange 
        var customer = Customer.Create("Fornecedor A", "fornecedor@empresa.com.br", "4198886556", DateTime.Now);
        var productA = Product.Create("Mouse Logitech", "Mouse Sem Fio", "mouse-logitech-semfio", 146.0M);
        var productB = Product.Create("Teclado Logitech", "Teclado ABTN2 com fio", "teclado-logitech-comfio", 70.0M);
        var productC = Product.Create("Telefone Intelbras IP", "Telefone Intelbras 125i (TCP/IP) ", "telefone-intelbras-ip", 179.5M);
        
        var lines = new List<OrderLine>()
        {
            OrderLine.Create(100, productA),
            OrderLine.Create(50, productB),
            OrderLine.Create(20, productC),
        };


        //Act
        var order = Order.Create(customer, lines);        

        //Assert
        Assert.NotNull(order);
        Assert.Equal("Fornecedor A", order.Customer.Name);
        Assert.Equal(100, order.Lines[0].Quantity);
        Assert.Equal(14600.0M, order.Lines[0].Total);
    }

    [Fact]
    public void Shouldnt_Create_Order_Sucessfully_ErrorOrderLines()
    {
        //Arrange 
        var customer = Customer.Create("Fornecedor A", "fornecedor@empresa.com.br", "4198886556", DateTime.Now);
        var productA = Product.Create("Mouse Logitech", "Mouse Sem Fio", "mouse-logitech-semfio", 146.0M);
        var productB = Product.Create("Teclado Logitech", "Teclado ABTN2 com fio", "teclado-logitech-comfio", 70.0M);
        var productC = Product.Create("Telefone Intelbras IP", "Telefone Intelbras 125i (TCP/IP) ", "telefone-intelbras-ip", 179.5M);

        var lines = new List<OrderLine>(){ };

        Assert.Throws<OrderLineException>(() =>
        {
            //Act
            var order = Order.Create(customer, lines);
        });        
    }
}


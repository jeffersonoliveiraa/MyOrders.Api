using Moq;
using MyOrders.Domain.Commands.v1.Orders.Create;
using MyOrders.Domain.Contracts.v1.Repository;
using MyOrders.Domain.Entities.v1;
using Xunit;

namespace MyOrders.UnitTests.Command.Create;

public class CreateOrdersTest
{
    private readonly Mock<IOrdersRepository> _ordersRepository = new();
    private readonly CancellationToken cancellationToken = new();

    [Fact]
    public async Task CreateOrder()
    {
        //Arrange
        Order order = new()
        {
            Id = 1,
            NameShare = "B3",
            QuantityShares = 1,
            ShareValue = 1,
            PurchaseDate = Convert.ToDateTime("2023-09-23")
        };

        _ordersRepository.Setup(x => x.CreateOrderAsync(order)).ReturnsAsync(order);
        var commandHandler = new CreateOrdersCommandHandler(_ordersRepository.Object);

        //Act
        var response = await commandHandler.Handle(new CreateOrdersCommand ( order.NameShare, order.QuantityShares, order.ShareValue, order.PurchaseDate ), cancellationToken);

        //Assert
        Assert.NotNull(response);
    }
}

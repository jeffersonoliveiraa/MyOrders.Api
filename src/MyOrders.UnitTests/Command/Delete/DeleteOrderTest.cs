using Moq;
using MyOrders.Domain.Commands.v1.Orders.Delete;
using MyOrders.Domain.Contracts.v1.Repository;
using MyOrders.Domain.Entities.v1;
using Xunit;

namespace MyOrders.UnitTests.Command.Delete;

public class DeleteOrderTest
{
    private readonly Mock<IOrdersRepository> _ordersRepository = new();
    private readonly CancellationToken cancellationToken = new();

    [Fact]
    public async Task DeleteOrder()
    {
        //Arrange
        Order order = new()
        {
            Id = 1,
            NameShare = "B3",
            QuantityShares = 1,
            ShareValue = 1,
            PurchaseDate = DateTime.Now
        };

        var result = Task.FromResult(order.Id);

        _ordersRepository.Setup(x => x.DeleteOrderAsync(order)).Returns(result);

        var commandHandler = new DeleteOrdersCommandHandler(_ordersRepository.Object);

        //Act
        var response = await commandHandler.Handle(new DeleteOrdersCommand { Id = order.Id }, cancellationToken);

        //Assert
        Assert.True(response > 0);
    }
}

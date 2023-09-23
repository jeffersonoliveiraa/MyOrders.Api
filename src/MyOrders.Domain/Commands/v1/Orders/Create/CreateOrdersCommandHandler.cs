using MediatR;
using Microsoft.Extensions.Logging;
using MyOrders.Domain.Contracts.v1.Repository;
using MyOrders.Domain.Entities.v1;

namespace MyOrders.Domain.Commands.v1.Orders.Create;

public class CreateOrdersCommandHandler : IRequestHandler<CreateOrdersCommand, Order>
{
    private readonly IOrdersRepository _ordersRepository;

    public CreateOrdersCommandHandler(IOrdersRepository ordersRepository)
    {
        _ordersRepository = ordersRepository;
    }

    public async Task<Order> Handle(CreateOrdersCommand request, CancellationToken cancellationToken)
    {
        Order order = new()
        {
            NameShare = request.NameShare,
            QuantityShares = request.QuantityShares,
            ShareValue = request.ShareValue,
            PurchaseDate = request.PurchaseDate
        };

        var result = await _ordersRepository.CreateOrderAsync(order);

        return result;
    }
}

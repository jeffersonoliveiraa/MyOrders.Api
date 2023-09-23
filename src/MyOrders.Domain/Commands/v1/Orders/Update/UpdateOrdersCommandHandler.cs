using MediatR;
using MyOrders.Domain.Contracts.v1.Repository;

namespace MyOrders.Domain.Commands.v1.Orders.Update;

public class UpdateOrdersCommandHandler : IRequestHandler<UpdateOrdersCommand, int>
{
    private readonly IOrdersRepository _ordersRepository;

    public UpdateOrdersCommandHandler(IOrdersRepository ordersRepository)
    {
        _ordersRepository = ordersRepository;
    }

    public async Task<int> Handle(UpdateOrdersCommand request, CancellationToken cancellationToken)
    {
        var order = await _ordersRepository.GetOrderByIdAsync(request.Id);

        if (order == null)
            return default;

        order.NameShare = request.NameShare;
        order.QuantityShares = request.QuantityShares;
        order.ShareValue = request.ShareValue;
        order.PurchaseDate = request.PurchaseDate;

        return await _ordersRepository.UpdateOrderAsync(order);
    }
}

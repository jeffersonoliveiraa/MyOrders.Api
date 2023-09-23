using MediatR;
using MyOrders.Domain.Contracts.v1.Repository;

namespace MyOrders.Domain.Commands.v1.Orders.Delete;

public class DeleteOrdersCommandHandler : IRequestHandler<DeleteOrdersCommand, int>
{
    private readonly IOrdersRepository _ordersRepository;

    public DeleteOrdersCommandHandler(IOrdersRepository ordersRepository)
    {
        _ordersRepository = ordersRepository;
    }

    public async Task<int> Handle(DeleteOrdersCommand request, CancellationToken cancellationToken)
    {
        var orderDelete = await _ordersRepository.GetOrderByIdAsync(request.Id);

        if (orderDelete == null)
            return default;

        return await _ordersRepository.DeleteOrderAsync(orderDelete!);
    }
}

using MediatR;
using MyOrders.Domain.Contracts.v1.Repository;
using MyOrders.Domain.Entities.v1;

namespace MyOrders.Infra.Data.Queries.Queries.v1.GetAll;


public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, IEnumerable<Order>>
{
    private readonly IOrdersRepository _ordersRepository;

    public GetAllOrdersQueryHandler(IOrdersRepository ordersRepository)
    {
        _ordersRepository = ordersRepository;
    }

    public async Task<IEnumerable<Order>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
    {
        var ordersList = await _ordersRepository.GetOrdersAsync();
        return ordersList!;
    }
}


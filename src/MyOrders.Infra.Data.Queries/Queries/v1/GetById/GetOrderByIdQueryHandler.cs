using MediatR;
using MyOrders.Domain.Contracts.v1.Repository;
using MyOrders.Domain.Entities.v1;

namespace MyOrders.Infra.Data.Queries.Queries.v1.GetById;

public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, Order>
{
    private readonly IOrdersRepository _ordersRepository;

    public GetOrderByIdQueryHandler(IOrdersRepository ordersRepository)
    {
        _ordersRepository = ordersRepository;
    }
    public async Task<Order> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        return await _ordersRepository.GetOrderByIdAsync(request.Id);
    }
}

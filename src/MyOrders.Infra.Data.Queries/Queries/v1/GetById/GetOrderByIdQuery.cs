using MediatR;
using MyOrders.Domain.Entities.v1;

namespace MyOrders.Infra.Data.Queries.Queries.v1.GetById;

public class GetOrderByIdQuery : IRequest<Order>
{
    public int Id { get; set; }
}

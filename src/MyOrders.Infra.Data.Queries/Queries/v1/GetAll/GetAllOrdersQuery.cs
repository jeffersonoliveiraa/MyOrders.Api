using MediatR;
using MyOrders.Domain.Entities.v1;

namespace MyOrders.Infra.Data.Queries.Queries.v1.GetAll;

public class GetAllOrdersQuery : IRequest<IEnumerable<Order>>
{
}
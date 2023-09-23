using MediatR;

namespace MyOrders.Domain.Commands.v1.Orders.Delete;

public class DeleteOrdersCommand : IRequest<int>
{
    public int Id { get; set; }
}

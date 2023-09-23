using MediatR;
using MyOrders.Domain.Entities.v1;

namespace MyOrders.Domain.Commands.v1.Orders.Create;

public class CreateOrdersCommand : IRequest<Order>
{
    public string? NameShare { get; set; }
    public int QuantityShares { get; set; }
    public double ShareValue { get; set; }
    public DateTime PurchaseDate { get; set; }

    public CreateOrdersCommand(string? nameShare, int quantityShares, double shareValue, DateTime purchaseDate)
    {
        NameShare = nameShare;
        QuantityShares = quantityShares;
        ShareValue = shareValue;
        PurchaseDate = purchaseDate;
    }
}

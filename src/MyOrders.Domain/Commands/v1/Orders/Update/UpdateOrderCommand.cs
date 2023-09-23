using MediatR;

namespace MyOrders.Domain.Commands.v1.Orders.Update
{
    public class UpdateOrdersCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string? NameShare { get; set; }
        public int QuantityShares { get; set; }
        public double ShareValue { get; set; }
        public DateTime PurchaseDate { get; set; }

        public UpdateOrdersCommand(int id, string? nameShare, int quantityShares, double shareValue, DateTime purchaseDate)
        {
            Id = id;
            NameShare = nameShare;
            QuantityShares = quantityShares;
            ShareValue = shareValue;
            PurchaseDate = purchaseDate;
        }
    }
}

namespace MyOrders.Domain.Entities.v1;

public class Order
{
    public int Id { get; set; }
    public string? NameShare { get; set; }
    public int QuantityShares { get; set; }
    public double ShareValue { get; set; }
    public DateTime PurchaseDate { get; set; }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyOrders.Domain.Entities.v1;

namespace MyOrders.Infra.Data.Mapping.v1;

public class OrderMap : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Orders", "dbo");

        builder.HasKey(u => u.Id);

        builder.Property(u => u.Id).HasColumnName("Id");
        builder.Property(u => u.NameShare).HasColumnName("NameShare");
        builder.Property(u => u.QuantityShares).HasColumnName("QuantityShares");
        builder.Property(u => u.ShareValue).HasColumnName("ShareValue");
        builder.Property(u => u.PurchaseDate).HasColumnName("PurchaseDate");
    }
}

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Top_Fashion.TopFashion.Domain.Entities.Order;

namespace Top_Fashion.TopFashion.Infrastructure.Data.Config
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.OwnsOne(x => x.ShipToAddress, n => { n.WithOwner(); });
            builder.Property(x => x.OrderStatus)
                .HasConversion(
                o => o.ToString(),
                o => (OrderStatus)Enum.Parse(typeof(OrderStatus), o)
                );

            builder.HasMany(x => x.OrderItems).WithOne().OnDelete(DeleteBehavior.Cascade);
            builder.Property(x => x.Subtotal).HasColumnType("decimal(18,2)");

        }
    }
}

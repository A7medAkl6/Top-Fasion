using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Top_Fashion.TopFashion.Domain.Entities.Order;

namespace Top_Fashion.TopFashion.Infrastructure.Data.Config
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.OwnsOne(x => x.ProductItemOrderd, n => { n.WithOwner(); });
            builder.Property(x => x.Price).HasColumnType("decimal(18,2)");
        }
    }
}

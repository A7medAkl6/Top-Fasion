using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Top_Fashion.TopFashion.Domain.Entities;

namespace Top_Fashion.TopFashion.Infrastructure.Data.Config
{
    public class ShopConfiguration : IEntityTypeConfiguration<Shop>
    {
        public void Configure(EntityTypeBuilder<Shop> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(30);

            //Seed
            builder.HasData(
                new Shop{ Id = 1, Name = "Shop_one", Description = "1" },
                new Shop { Id = 2, Name = "Shop_two", Description = "2" },
                new Shop { Id = 3, Name = "Shop_three", Description = "3" }
                );
        }
    }
}

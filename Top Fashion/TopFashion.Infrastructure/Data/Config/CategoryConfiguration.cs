using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Top_Fashion.TopFashion.Domain.Entities;

namespace Top_Fashion.TopFashion.Infrastructure.Data.Config
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(30);

            //Seed
            builder.HasData(
                new Category { Id = 1, Name = "Category_one", Description = "1", ShopId = 1 },
                new Category { Id = 2, Name = "Category_two", Description = "2", ShopId = 1 },
                new Category { Id = 3, Name = "Category_three", Description = "3", ShopId = 1 }
                );
        }
    }
}

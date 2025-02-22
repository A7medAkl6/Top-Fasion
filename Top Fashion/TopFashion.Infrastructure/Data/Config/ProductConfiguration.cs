﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Top_Fashion.TopFashion.Domain.Entities;

namespace Top_Fashion.TopFashion.Infrastructure.Data.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(30);
            builder.Property(x => x.Price).HasColumnType("decimal(18,2)");

            // Seed
            builder.HasData(
                new Product { Id = 1, Name = "Product_one", Description = "1", Price = 2000,Vat=10, CategoryId = 1, ProductPicture = "https://" },
                new Product { Id = 2, Name = "Product_two", Description = "2", Price = 2000, Vat = 20, CategoryId = 1, ProductPicture = "https://" },
                new Product { Id = 3, Name = "Product_three", Description = "3", Price = 2000, Vat = 30, CategoryId = 1, ProductPicture = "https://" }
                );

        }
    }
}

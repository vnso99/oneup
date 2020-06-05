using Core.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data.Config
{
    class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Description).IsRequired().HasMaxLength(180);
            builder.Property(p => p.Price).HasColumnType("decimal(18,2)");
            builder.Property(p => p.PictureUrl).IsRequired();

            builder.HasOne(b => b.ProductBrand).WithMany()
                .HasForeignKey(p => p.ProductBrandId);

            builder.HasOne(t => t.ProductType).WithMany()
                .HasForeignKey(p => p.ProductTypeId);

            builder.HasOne(r => r.Rating).WithMany()
                .HasForeignKey(p => p.RatingId);

            builder.HasOne(g => g.Genre).WithMany()
                .HasForeignKey(p => p.GenreId);

            builder.Property(p => p.NumberOfPlayers).IsRequired();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Shop.DAL.Entities;

namespace Shop.DAL.Configuration
{
    // This file contains the configuration for the Product entity
    // which defines the relationships and constraints for the Product table in the database.
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            // Product -> Category: many-to-one
            builder.HasOne(p => p.Category)
                   .WithMany(c => c.Products)
                   .HasForeignKey(p => p.CategoryId);

            builder.Property(p => p.Name)
                   .IsRequired()
                   .HasMaxLength(100); // Ensuring Name is required and has a maximum length
            builder.Property(p => p.Price).HasPrecision(10, 3); // Setting precision for Price to handle decimal values properly

        }
    }
}

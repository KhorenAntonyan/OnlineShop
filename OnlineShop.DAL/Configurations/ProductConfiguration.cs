using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.DAL.Entities;

namespace OnlineShop.DAL.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("ProductId");

            builder.Property(p => p.ProductName)
                .HasMaxLength(512)
                .IsRequired();

            builder.Property(p => p.Description)
                .HasMaxLength(2048)
                .IsRequired();

            builder.Property(p => p.Price)
                .HasPrecision(38, 18)
                .IsRequired();

            builder.Property(p => p.CategoryId)
                .IsRequired(false);

            builder
                .HasOne(p => p.Category)
                .WithMany(p => p.Products)
                .HasForeignKey("CategoryId")
                .OnDelete(DeleteBehavior.SetNull);

        }
    }
}

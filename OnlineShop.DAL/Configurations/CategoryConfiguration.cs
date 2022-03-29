using Microsoft.EntityFrameworkCore;
using OnlineShop.DAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OnlineShop.DAL.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("CategoryId");

            builder.Property(p => p.CategoryName)
                .HasMaxLength(512)
                .IsRequired();

            builder.Property(p => p.Description)
                .HasMaxLength(2048)
                .IsRequired();
        }
    }
}

using OnlineShop.DAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OnlineShop.DAL.Configurations
{
    public class CategoryConfiguration : BaseEntityConfiguration<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(p => p.CategoryName)
                .IsRequired();

            builder.Property(p => p.Description)
                .IsRequired();
        }
    }
}

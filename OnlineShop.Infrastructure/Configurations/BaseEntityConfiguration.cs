using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.DAL.Entities;

namespace OnlineShop.DAL.Configurations
{
    public class BaseEntityConfiguration : IEntityTypeConfiguration<BaseEntity>
    {
        public void Configure(EntityTypeBuilder<BaseEntity> builder)
        {
            builder.Property(p => p.CreatedDate)
                .IsRequired();

            builder.Property(p => p.ModifiedDate)
                .IsRequired();

            builder.Property(p => p.IsDeleted)
                .IsRequired();
        }
    }
}

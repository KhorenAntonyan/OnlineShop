using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.DAL.Entities;

namespace OnlineShop.DAL.Configurations
{
    public class BaseEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasQueryFilter(f => EF.Property<DateTime?>(f, "IsDeleted") == null);

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id);

            builder.Property(p => p.CreatedDate)
                .IsRequired();

            builder.Property(p => p.ModifiedDate)
                .IsRequired();

            builder.Property(p => p.IsDeleted)
                .IsRequired(false)
                .HasDefaultValue(null);
        }
    }
}

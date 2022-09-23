using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.DAL.Entities;

namespace OnlineShop.DAL.Configurations
{
    public class PhotoConfiguration : BaseEntityConfiguration<Photo>
    {
        public override void Configure(EntityTypeBuilder<Photo> builder)
        {
            builder.Property(p => p.PhotoURL)
                .IsRequired(false);

            builder.Property(p => p.IsMain)
                .IsRequired(true);

            builder
                .HasOne(p => p.Product)
                .WithMany(p => p.Photos)
                .HasForeignKey(p => p.ProductId);
        }
    }
}

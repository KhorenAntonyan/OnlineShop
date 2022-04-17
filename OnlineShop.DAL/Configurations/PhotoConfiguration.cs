using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.DAL.Entities;


namespace OnlineShop.DAL.Configurations
{
    public class PhotoConfiguration : IEntityTypeConfiguration<Photo>
    {
        public void Configure(EntityTypeBuilder<Photo> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("PhotoId");

            builder.Property(p => p.PhotoURL)
                .HasColumnType("nvarchar(100)");

            builder
                .HasOne(p => p.Product)
                .WithMany(p => p.Photos)
                .HasForeignKey("ProductId");
        }
    }
}

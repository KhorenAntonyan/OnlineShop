using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Infrastructure.Data.Config
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.OrderId);

            //builder
            //    .HasMany(x => x.Products)
            //    .WithMany(x => x.Orders);

            builder.Property(x => x.TotalQuantity)
                .IsRequired();

            builder.Property(x => x.TotalPrice)
                .IsRequired();
        }
    }
}

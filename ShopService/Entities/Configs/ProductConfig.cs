using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ShopService.Entities.Configs
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Title)
                .HasMaxLength(1000)
                .IsRequired();

            builder.Property(x => x.Price)
               .HasPrecision(24, 8);

            builder.Property(x => x.Status)
               .HasConversion<string>()
               .HasMaxLength(16);
        }
    }
}

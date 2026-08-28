using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace ShopService.Entities.Configs
{

    public class ShopConfig : IEntityTypeConfiguration<Shop>
    {
        public void Configure(EntityTypeBuilder<Shop> builder)
        {
            {
                builder.Property(a => a.Title)
                    .HasMaxLength(1000)
                    .IsRequired();

                builder.Property(b => b.PhoneNumber)
                   .HasMaxLength(11)
                   .IsRequired();
            }
        }
    }
}
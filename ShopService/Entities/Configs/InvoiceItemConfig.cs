using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ShopService.Entities.Configs
{
    public class InvoiceItemConfig : IEntityTypeConfiguration<InvoiceItem>
    {
        public void Configure(EntityTypeBuilder<InvoiceItem> builder)
        {
            //builder.HasOne(x => x.Product1)
            //     .WithMany(x => x.InvoiceItems1)
            //     .HasForeignKey(x => x.Product1Id)
            //     .OnDelete(DeleteBehavior.Restrict);

            //builder.HasOne(x => x.Product2)
            //    .WithMany(x => x.InvoiceItems2)
            //    .HasForeignKey(x => x.Product2Id)
            //    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

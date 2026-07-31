using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace ShopService.Entities.Configs
{




	public class InvoiceConfig : IEntityTypeConfiguration <Invoice>
	{
		public void Configure(EntityTypeBuilder <Invoice> builder)
		{
		}
	}
}
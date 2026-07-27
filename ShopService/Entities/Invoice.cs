namespace ShopService.Entities
{
    public class Invoice
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }

        public IEnumerable<InvoiceItem> Items { get; set; }


    }
}

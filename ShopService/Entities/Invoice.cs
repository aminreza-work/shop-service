namespace ShopService.Entities
{
    public class Invoice
    {
        public int Id { get; set; }
        public string Number { get; set; } // 4050526-F0002
        public DateTime CreatedAt { get; set; }

        public IEnumerable<InvoiceItem> Items { get; set; }


    }
}

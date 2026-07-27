namespace ShopService.Entities
{
    public class InvoiceItem
    {
        public int Id { get; set; }
        public int InvoiceId { get; set; }
        public int ProductId { get; set; }
        public decimal BuyPrice { get; set; }
        public int BuyQty { get; set; }

        public Invoice Invoice { get; set; }
        public Product Product { get; set; }

       
    }
}

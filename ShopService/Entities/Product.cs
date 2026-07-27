using Microsoft.EntityFrameworkCore;
using ShopService.Enums;
using System.ComponentModel.DataAnnotations;

namespace ShopService.Entities
{
    public class Product
    {
     
        public int Id { get; set; }
        public string Title { get; set; } //nvarchar(MAX)
        public int Qty { get; set; } 
        public decimal Price { get; set; } //decimal(18,2)
        public bool IsPublished { get; set; } // bit   0 | 1
        public ProductVerificationStatus Status { get; set; }   // 1 | 10 | 100
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }


        public IEnumerable<InvoiceItem> InvoiceItems { get; set; }
    }
}


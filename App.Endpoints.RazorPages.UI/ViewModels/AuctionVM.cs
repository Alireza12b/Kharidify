using App.Domain.Core.Products.Entities;

namespace App.Endpoints.RazorPages.UI.ViewModels
{
    public class AuctionVM
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public DateTime StartDate { get; set; } = DateTime.Now;

        public DateTime EndDate { get; set; }

        public double? HighestPrice { get; set; }

        public string? ImagePath { get; set; }

        public bool IsActive { get; set; }

        public bool IsRemoved { get; set; }

        public int? LastBuyerId { get; set; }

        public virtual Product Product { get; set; } = null!;
    }
}

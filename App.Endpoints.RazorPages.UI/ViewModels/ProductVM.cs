namespace App.Endpoints.RazorPages.UI.ViewModels
{
    public class ProductVM
    {
        public int Id { get; set; }

        public int ShopId { get; set; }

        public int CategoryId { get; set; }

        public string? Name { get; set; } = null!;

        public string? Description { get; set; } = null!;

        public int TotalQuantity { get; set; }

        public double Price { get; set; }

        public bool IsActive { get; set; }

        public bool IsAuction { get; set; }

        public int AuctionTime { get; set; }

        public IFormFile? Image { get; set; }
    }
}

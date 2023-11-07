namespace App.Endpoints.RazorPages.UI.ViewModels
{
    public class ProductVM
    {
        public int Id { get; set; }

        public int ShopId { get; set; }

        public int SubCategoriesId { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public DateTime RegisterDate { get; set; }

        public int TotalQuantity { get; set; }

        public bool IsActive { get; set; }
    }
}

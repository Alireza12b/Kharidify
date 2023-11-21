namespace App.Endpoints.RazorPages.UI.ViewModels
{
    public class ShopVM
    {
        public int Id { get; set; }

        public int SellerId { get; set; }

        public string ShopName { get; set; } = null!;

        public int Rank { get; set; }

        public int CityId { get; set; }

        public string AdressDetail { get; set; } = null!;

        public string PostalCode { get; set; } = null!;

        public string Phone { get; set; } = null!;

        public bool IsActive { get; set; }

        public int SellsCount { get; set; }
    }
}

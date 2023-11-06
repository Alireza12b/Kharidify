namespace App.Endpoints.RazorPages.UI.ViewModels
{
    public class CityVM
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public int? ProvinceId { get; set; }
    }

    public class ProvinceVm
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;
    }
}

namespace App.Endpoints.RazorPages.UI.ViewModels
{
    public class OrderLineVM
    {
        public int Id { get; set; }

        public int CartId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public bool IsPaid { get; set; } = false;

        public DateTime? PayDate { get; set; }

        public bool IsDeleted { get; set; }
    }
}

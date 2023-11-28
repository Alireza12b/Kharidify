namespace App.Endpoints.RazorPages.UI.ViewModels
{
    public class CommentVM
    {
        public int Id { get; set; }

        public string Message { get; set; } = null!;

        public bool isActive { get; set; } = false;

        public bool IsRemoved { get; set; } = false;

        public int UserId { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        public int ProductId { get; set; }
    }
}

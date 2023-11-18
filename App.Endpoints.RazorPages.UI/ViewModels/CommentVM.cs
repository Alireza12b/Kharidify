namespace App.Endpoints.RazorPages.UI.ViewModels
{
    public class CommentVM
    {
        public int Id { get; set; }

        public string Message { get; set; } = null!;

        public bool isActive { get; set; }

        public bool IsRemoved { get; set; }

        public int UserId { get; set; }

        public DateTime Date { get; set; }

        public int ProductId { get; set; }
    }
}

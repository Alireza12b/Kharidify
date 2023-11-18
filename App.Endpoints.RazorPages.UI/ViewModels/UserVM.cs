using App.Domain.Core.Products.Entities;
using App.Domain.Core.Users.Entities;

namespace App.Endpoints.RazorPages.UI.ViewModels
{
    public class UserVM
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? UserName { get; set; } = null!;
        public string? PhoneNumber { get; set; } = null!;
        public string? Email { get; set; } = string.Empty;
        public string? Password { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public bool IsRemoved { get; set; }
        public string? Role { get; set; }
        public IList<string> Roles { get; set; }
        public string? Province { get; set; }
        public string City { get; set; }
        public string? AddressDetail { get; set; }
        public string? PostalCode { get; set; }
    }

    public class CustomerVM
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int CityId { get; set; }

        public string AddressDetail { get; set; } = null!;

        public string PostalCode { get; set; } = null!;
    }

    public class SellerVM
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public virtual Shop Shop { get; set; } = null!;
    }
}

using App.Domain.Core.Products.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Users.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? UserName { get; set; } = null!;
        public string? Phone { get; set; } = null!;
        public string? Email { get; set; } = string.Empty;
        public string? Password { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public bool IsRemoved { get; set; }
        public string? Role { get; set; }
        public List<string> Roles { get; set; }
    }

    public class CustomerDto
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int CityId { get; set; }

        public string AddressDetail { get; set; } = null!;

        public string PostalCode { get; set; } = null!;
    }

    public class SellerDto
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public virtual Shop Shop { get; set; } = null!;
    }
}

using App.Domain.Core.Products.Entities;
using App.Domain.Core.Users.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Products.DTOs
{
    public class CartInputDto
    {
        public int CustomerId { get; set; }

        public bool IsPaid { get; set; }

        public DateTime? PayDate { get; set; }

        public int? CityId { get; set; }

        public string? AddressDetail { get; set; }

        public string? PostalCode { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }

        public int StatusId { get; set; }
    }

    public class CartOutputDto
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public bool IsPaid { get; set; }

        public DateTime? PayDate { get; set; }

        public int? CityId { get; set; }

        public string? AddressDetail { get; set; }

        public string? PostalCode { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }

        public int StatusId { get; set; }
    }
}

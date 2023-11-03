using App.Domain.Core.Products.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Products.DTOs
{
    public class ShopInputDto
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

    public class ShopOutputDto
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

        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}

using App.Domain.Core.Products.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Products.DTOs
{
    public class ProductInputDto
    {
        public int Id { get; set; } 

        public int ShopId { get; set; }

        public int CategoryId { get; set; }

        public string? Name { get; set; } = null!;

        public string? Description { get; set; } = null!;

        public int TotalQuantity { get; set; }

        public double Price { get; set; }

        public bool IsActive { get; set; }

        public bool IsAuction { get; set; }

        public int AuctionTime { get; set; }

        public string? ImageAddress { get; set; }

        public IFormFile? Image { get; set; }

        public virtual ICollection<ProductsPrice>? ProductsPrices { get; set; }

        public virtual ICollection<ImageInputDto>? Images { get; set; }
    }

    public class ProductOutputDto
    {
        public int Id { get; set; }

        public int ShopId { get; set; }

        public int CategoryId { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public DateTime RegisterDate { get; set; }

        public int TotalQuantity { get; set; }

        public bool IsActive { get; set; }

        public string? LastImageAddress { get; set; }

        public double? LastPrice { get; set; }

        public virtual ICollection<ProductsPrice> ProductsPrices { get; set; }

        public virtual ICollection<Image> Images { get; set; }
    }
}

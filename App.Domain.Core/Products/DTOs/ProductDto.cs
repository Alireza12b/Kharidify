using App.Domain.Core.Products.Entities;
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

        public int SubCategoriesId { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public int TotalQuantity { get; set; }

        public bool IsActive { get; set; }

        public virtual Shop Shop { get; set; } = null!;

        public virtual SubCategory SubCategories { get; set; } = null!;
    }

    public class ProductOutputDto
    {
        public int Id { get; set; }

        public int ShopId { get; set; }

        public int SubCategoriesId { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public int TotalQuantity { get; set; }

        public bool IsActive { get; set; }
    }
}

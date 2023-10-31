using App.Domain.Core.Products.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Products.DTOs
{
    public class ProductPriceInputDto
    {
        public int ProductId { get; set; }

        public DateTime? ToDate { get; set; }

        public double Price { get; set; }

        public double DiscountPercent { get; set; }
    }

    public class ProductPriceOutputDto
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime? ToDate { get; set; }

        public double Price { get; set; }

        public double DiscountPercent { get; set; }
    }
}

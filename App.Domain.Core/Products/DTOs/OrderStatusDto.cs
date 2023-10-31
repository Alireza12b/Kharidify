using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Products.DTOs
{
    public class OrderStatusInputDto
    {
        public string Status { get; set; } = null!;
    }

    public class OrderStatusOutputDto
    {
        public int Id { get; set; }

        public string Status { get; set; } = null!;

        public DateTime Date { get; set; }
    }
}

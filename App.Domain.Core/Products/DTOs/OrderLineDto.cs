using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Products.DTOs
{
    public class OrderLineInputDto
    {
        public int Id { get; set; }

        public int CartId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public bool IsPaid { get; set; } = false;

        public DateTime? PayDate { get; set; }

        public bool IsDeleted { get; set; }
    }

    public class OrderLineOutputDto
    {
        public int Id { get; set; }

        public int CartId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public bool IsPaid { get; set; } = false;

        public DateTime? PayDate { get; set; }

        public bool IsDeleted { get; set; }
    }
}

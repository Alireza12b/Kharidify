using App.Domain.Core.Products.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Products.DTOs
{
    public class ImageInputDto
    {
        public string Address { get; set; } = null!;

        public bool IsRemoved { get; set; }

        public int? ProductsId { get; set; }
    }

    public class ImageOutputDto
    {
        public int Id { get; set; }

        public string Address { get; set; } = null!;

        public bool IsRemoved { get; set; }

        public int? ProductsId { get; set; }
    }
}

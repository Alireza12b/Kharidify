using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Products.DTOs
{
    public class CityOutputDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public int? ProvinceId { get; set; }
    }
}

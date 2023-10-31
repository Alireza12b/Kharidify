using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Products.DTOs
{
    public class SubCategoryOutputDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public int CategoriesId { get; set; }
    }
}

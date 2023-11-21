using System;
using System.Collections.Generic;

namespace App.Domain.Core.Products.Entities;

public partial class Category
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string ImageAddress { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}

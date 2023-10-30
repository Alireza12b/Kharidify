using System;
using System.Collections.Generic;

namespace App.Infra.Data.SqlServer.EF.Models;

public partial class SubCategory
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int CategoriesId { get; set; }

    public virtual Category Categories { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}

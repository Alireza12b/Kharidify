using System;
using System.Collections.Generic;

namespace App.Infra.Data.SqlServer.EF.Models;

public partial class ProductsPrice
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public DateTime FromDate { get; set; }

    public DateTime? ToDate { get; set; }

    public double Price { get; set; }

    public double DiscountPercent { get; set; }

    public virtual Product Product { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace App.Domain.Core.Products.Entities;

public partial class Auction
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public DateTime StartDate { get; set; } = DateTime.Now;

    public DateTime EndDate { get; set; }

    public double StartPrice { get; set; }

    public double? HighestPrice { get; set; }

    public bool IsActive { get; set; }

    public int? LastBuyerId { get; set; }

    public virtual Product Product { get; set; } = null!;
}

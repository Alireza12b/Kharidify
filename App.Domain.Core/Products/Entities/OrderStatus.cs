using System;
using System.Collections.Generic;

namespace App.Domain.Core.Products.Entities;

public partial class OrderStatus
{
    public int Id { get; set; }

    public string? Status { get; set; } = null!;

    public DateTime Date { get; set; } = DateTime.Now;

    public virtual Cart Carts { get; set; } = null!;
}

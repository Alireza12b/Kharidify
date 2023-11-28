using System;
using System.Collections.Generic;

namespace App.Domain.Core.Products.Entities;

public partial class OrderLine
{
    public int Id { get; set; }

    public int CartId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public bool IsPaid { get; set; } = false;

    public DateTime? PayDate { get; set; }

    public bool IsDeleted { get; set; } = false;

    public virtual Cart Cart { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}

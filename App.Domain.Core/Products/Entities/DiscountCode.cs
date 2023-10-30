using System;
using System.Collections.Generic;

namespace App.Domain.Core.Products.Entities;

public partial class DiscountCode
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public bool IsUsed { get; set; }
}

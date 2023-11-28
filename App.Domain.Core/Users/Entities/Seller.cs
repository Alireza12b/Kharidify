using App.Domain.Core.Products.Entities;
using System;
using System.Collections.Generic;

namespace App.Domain.Core.Users.Entities;

public partial class Seller
{
    public int Id { get; set; }

    public double? Wallet { get; set; }

    public int UserId { get; set; }

    public virtual Shop Shop { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}

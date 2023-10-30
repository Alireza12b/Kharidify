using System;
using System.Collections.Generic;

namespace App.Infra.Data.SqlServer.EF.Models;

public partial class OrderStatus
{
    public int Id { get; set; }

    public string Status { get; set; } = null!;

    public DateTime Date { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();
}

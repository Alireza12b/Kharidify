using System;
using System.Collections.Generic;

namespace App.Infra.Data.SqlServer.EF.Models;

public partial class Customer
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int CityId { get; set; }

    public string AddressDetail { get; set; } = null!;

    public string PostalCode { get; set; } = null!;

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual City City { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}

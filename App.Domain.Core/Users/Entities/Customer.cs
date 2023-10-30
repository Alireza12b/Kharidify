using App.Domain.Core.Products.Entities;
using System;
using System.Collections.Generic;

namespace App.Domain.Core.Users.Entities;

public partial class Customer
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int CityId { get; set; }

    public string AddressDetail { get; set; } = null!;

    public string PostalCode { get; set; } = null!;

    public virtual Cart Carts { get; set; } = null!;

    public virtual City City { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
